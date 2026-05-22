using App.Core.Enums;
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
        private readonly BookService bookService = new BookService();

        public BookView()
        {
            InitializeComponent();
            ApplyStyles();
            LoadCategoryFilter();
            LoadBooks();
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
            comboBoxCategory.Items.Add("All");

            foreach (BookCategory category in Enum.GetValues(typeof(BookCategory)))
            {
                comboBoxCategory.Items.Add(category.ToString());
            }

            comboBoxCategory.SelectedIndex = 0;
        }

        private void LoadBooks()
        {
            try
            {
                IEnumerable<Book> books = bookService.GetAllBooks();
                string keyword = textBoxSearch.Text.Trim();
                string? category = comboBoxCategory.SelectedItem?.ToString();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    books = books.Where(book =>
                        book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        book.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrWhiteSpace(category) && category != "All")
                {
                    books = books.Where(book => book.Category.ToString() == category);
                }

                dataGridViewBooks.Rows.Clear();

                foreach (Book book in books)
                {
                    dataGridViewBooks.Rows.Add(
                        book.Id,
                        book.Title,
                        book.Author,
                        book.Category,
                        book.Quantity,
                        book.PublishedDate.ToShortDateString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load books", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string? GetSelectedBookId()
        {
            if (dataGridViewBooks.CurrentRow == null)
            {
                return null;
            }

            return dataGridViewBooks.CurrentRow.Cells["Id"].Value?.ToString();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            using BookForm form = new BookForm();

            if (form.ShowDialog() == DialogResult.OK && form.Book != null)
            {
                bookService.AddBook(form.Book);
                LoadBooks();
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            string? bookId = GetSelectedBookId();

            if (string.IsNullOrWhiteSpace(bookId))
            {
                MessageBox.Show("Please select a book to edit.", "Edit Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Book? book = bookService.GetBookById(bookId);

            if (book == null)
            {
                MessageBox.Show("Selected book was not found.", "Edit Book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadBooks();
                return;
            }

            using BookForm form = new BookForm(book);

            if (form.ShowDialog() == DialogResult.OK && form.Book != null)
            {
                bookService.UpdateBook(form.Book);
                LoadBooks();
            }
        }

        private void toolStripButtonView_Click(object sender, EventArgs e)
        {
            string? bookId = GetSelectedBookId();

            if (string.IsNullOrWhiteSpace(bookId))
            {
                MessageBox.Show("Please select a book to view.", "View Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Book? book = bookService.GetBookById(bookId);

            if (book == null)
            {
                MessageBox.Show("Selected book was not found.", "View Book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadBooks();
                return;
            }

            using BookForm form = new BookForm(book, true);
            form.ShowDialog();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            string? bookId = GetSelectedBookId();

            if (string.IsNullOrWhiteSpace(bookId))
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
                bookService.DeleteBook(bookId);
                LoadBooks();
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBooks();
        }
    }
}
