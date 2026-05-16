using App.Core.Enums;
using App.Core.Models;
using App.WindowsApp.Forms;
using LibraryManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
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
            LoadCategoryFilter();
            LoadBooks();
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

        private int? GetSelectedBookId()
        {
            if (dataGridViewBooks.CurrentRow == null)
            {
                return null;
            }

            return Convert.ToInt32(dataGridViewBooks.CurrentRow.Cells["Id"].Value);
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
            int? bookId = GetSelectedBookId();

            if (!bookId.HasValue)
            {
                MessageBox.Show("Please select a book to edit.", "Edit Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Book book = bookService.GetBookById(bookId.Value);
            using BookForm form = new BookForm(book);

            if (form.ShowDialog() == DialogResult.OK && form.Book != null)
            {
                bookService.UpdateBook(form.Book);
                LoadBooks();
            }
        }

        private void toolStripButtonView_Click(object sender, EventArgs e)
        {
            int? bookId = GetSelectedBookId();

            if (!bookId.HasValue)
            {
                MessageBox.Show("Please select a book to view.", "View Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Book book = bookService.GetBookById(bookId.Value);
            using BookForm form = new BookForm(book, true);
            form.ShowDialog();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            int? bookId = GetSelectedBookId();

            if (!bookId.HasValue)
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
                bookService.DeleteBook(bookId.Value);
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
