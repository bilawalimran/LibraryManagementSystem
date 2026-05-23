using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Models;
using App.WindowsApp.Forms;
using App.Core.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App.WindowsApp.Views
{
    public partial class BookView : UserControl
    {
        private const string AllCategories = "--All--";

        private readonly IBookService service;
        private readonly BindingSource _dgvBindingSource = new BindingSource();

        public BookView() : this(new BookService())
        {
        }

        public BookView(IBookService _service)
        {
            service = _service;
            InitializeComponent();
            ConfigureGridBinding();
            ApplyStyles();
            LoadCategoryFilter();
            RefreshGrid();
        }

        private void ConfigureGridBinding()
        {
            dataGridViewBooks.AutoGenerateColumns = false;
            Id.DataPropertyName = nameof(Book.Id);
            Title.DataPropertyName = nameof(Book.Title);
            Author.DataPropertyName = nameof(Book.Author);
            Category.DataPropertyName = nameof(Book.Category);
            Quantity.DataPropertyName = nameof(Book.Quantity);
            PublishedDate.DataPropertyName = nameof(Book.PublishedDate);
            PublishedDate.DefaultCellStyle.Format = "d";
            dataGridViewBooks.DataSource = _dgvBindingSource;
        }

        private void ApplyStyles()
        {
            Color accentColor = Color.RoyalBlue;

            BackColor = Color.White;
            panelFilters.BackColor = Color.AliceBlue;
            panelFilters.Padding = new Padding(8);

            toolStripBooks.BackColor = Color.WhiteSmoke;
            toolStripBooks.GripStyle = ToolStripGripStyle.Hidden;
            toolStripBooks.Padding = new Padding(6, 4, 6, 4);
            toolStripBooks.RenderMode = ToolStripRenderMode.System;

            foreach (ToolStripItem item in toolStripBooks.Items)
            {
                item.Margin = new Padding(2, 0, 2, 0);
                item.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            }

            dataGridViewBooks.BackgroundColor = Color.White;
            dataGridViewBooks.BorderStyle = BorderStyle.None;
            dataGridViewBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewBooks.GridColor = Color.Gainsboro;
            dataGridViewBooks.EnableHeadersVisualStyles = false;
            dataGridViewBooks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewBooks.ColumnHeadersDefaultCellStyle.BackColor = accentColor;
            dataGridViewBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewBooks.ColumnHeadersDefaultCellStyle.SelectionBackColor = accentColor;
            dataGridViewBooks.ColumnHeadersHeight = 34;
            dataGridViewBooks.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dataGridViewBooks.DefaultCellStyle.SelectionBackColor = ControlPaint.Light(accentColor, 0.65F);
            dataGridViewBooks.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 247, 255);
            dataGridViewBooks.RowTemplate.Height = 28;
        }

        private void LoadCategoryFilter()
        {
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.Items.Clear();
            comboBoxCategory.Items.Add(AllCategories);

            foreach (BookCategory category in Enum.GetValues(typeof(BookCategory)))
            {
                comboBoxCategory.Items.Add(category);
            }

            comboBoxCategory.SelectedIndex = 0;
        }

        private void RefreshGrid()
        {
            try
            {
                _dgvBindingSource.DataSource = GetFilteredBooks().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load books", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IEnumerable<Book> GetFilteredBooks()
        {
            IEnumerable<Book> books = service.GetAllBooks();
            string keyword = textBoxSearch.Text.Trim();
            BookCategory? selectedCategory = GetSelectedCategory();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                books = books.Where(book =>
                    book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    book.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            }

            if (selectedCategory.HasValue)
            {
                books = books.Where(book => book.Category == selectedCategory.Value);
            }

            return books;
        }

        private BookCategory? GetSelectedCategory()
        {
            return comboBoxCategory.SelectedItem is BookCategory category ? category : null;
        }

        private Book? GetSelectedBook()
        {
            return _dgvBindingSource.Current as Book;
        }

        private void ShowBookForm(BookFormModeEnum mode, Book? book = null, bool refreshAfterClose = true)
        {
            using BookForm form = new BookForm(mode, book, service);
            form.ShowDialog();

            if (refreshAfterClose)
            {
                RefreshGrid();
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            ShowBookForm(BookFormModeEnum.Add);
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            Book? selectedBook = GetSelectedBook();
            if (selectedBook == null)
            {
                MessageBox.Show("Please select a book to edit.", "Edit Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowBookForm(BookFormModeEnum.Edit, selectedBook);
        }

        private void toolStripButtonView_Click(object sender, EventArgs e)
        {
            Book? selectedBook = GetSelectedBook();
            if (selectedBook == null)
            {
                MessageBox.Show("Please select a book to view.", "View Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowBookForm(BookFormModeEnum.View, selectedBook, refreshAfterClose: false);
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            Book? selectedBook = GetSelectedBook();
            if (selectedBook == null)
            {
                MessageBox.Show("Please select a book to delete.", "Delete Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Delete the selected book?",
                "Delete Book",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                service.DeleteBook(selectedBook.Id);
                RefreshGrid();
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}
