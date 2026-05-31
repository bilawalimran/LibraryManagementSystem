using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Models;
using App.Core.Services;
using System;
using System.Windows.Forms;

namespace App.WindowsApp.Forms
{
    public partial class BookForm : Form
    {
        private readonly BookFormModeEnum _mode;
        private readonly IBookService _service;
        private Book? _book;

        public Book? Book { get; private set; }

        public BookForm() : this(BookFormModeEnum.Add, null, new BookService())
        {
        }

        public BookForm(BookFormModeEnum mode, Book? book, IBookService service)
        {
            InitializeComponent();

            _mode = mode;
            _book = book;
            _service = service;

            LoadCategories();
            LoadInitialData();
            ApplyMode();
        }

        private void LoadCategories()
        {
            comboBoxCategory.DataSource = Enum.GetValues(typeof(BookCategory));
            numericUpDownQuantity.Minimum = 0;
            numericUpDownQuantity.Maximum = 1000;
        }

        private void LoadInitialData()
        {
            if (_book != null)
            {
                LoadBook(_book);
                return;
            }

            if (_mode == BookFormModeEnum.Add)
            {
                textBoxBookId.Text = new Book().Id;
                dateTimePickerPublishedDate.Value = DateTime.Today;
            }
        }

        private void LoadBook(Book book)
        {
            Book = book;
            textBoxBookId.Text = book.Id;
            textBoxTitle.Text = book.Title;
            textBoxAuthor.Text = book.Author;
            comboBoxCategory.SelectedItem = book.Category;
            numericUpDownQuantity.Value = book.Quantity;
            dateTimePickerPublishedDate.Value = book.PublishedDate;
        }

        private void ApplyMode()
        {
            bool isViewMode = _mode == BookFormModeEnum.View;

            labelBookDetails.Text = _mode switch
            {
                BookFormModeEnum.Add => "Add Book",
                BookFormModeEnum.Edit => "Edit Book",
                BookFormModeEnum.View => "View Book",
                _ => "Book Details"
            };

            textBoxTitle.ReadOnly = isViewMode;
            textBoxAuthor.ReadOnly = isViewMode;
            comboBoxCategory.Enabled = !isViewMode;
            numericUpDownQuantity.Enabled = !isViewMode;
            dateTimePickerPublishedDate.Enabled = !isViewMode;
            buttonSave.Visible = !isViewMode;
            buttonSave.Text = _mode == BookFormModeEnum.Edit ? "Update" : "Save";
            buttonCancel.Text = isViewMode ? "Close" : "Cancel";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_mode == BookFormModeEnum.View)
            {
                Close();
                return;
            }

            if (!ValidateForm(out BookCategory selectedCategory))
            {
                return;
            }

            SaveBook(selectedCategory);
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateForm(out BookCategory selectedCategory)
        {
            selectedCategory = default;

            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Please enter book title.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxAuthor.Text))
            {
                MessageBox.Show("Please enter author name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxCategory.SelectedItem is not BookCategory category)
            {
                MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            selectedCategory = category;
            return true;
        }

        private void SaveBook(BookCategory selectedCategory)
        {
            if (_mode == BookFormModeEnum.Add)
            {
                Book newBook = ReadBookFromForm(new Book(), selectedCategory);
                _service.AddBook(newBook);
                Book = newBook;
                return;
            }

            if (_mode == BookFormModeEnum.Edit && _book != null)
            {
                Book = ReadBookFromForm(_book, selectedCategory);
                _service.UpdateBook(_book);
            }
        }

        private Book ReadBookFromForm(Book book, BookCategory selectedCategory)
        {
            book.Id = string.IsNullOrWhiteSpace(textBoxBookId.Text)
                ? book.Id
                : textBoxBookId.Text.Trim();
            book.Title = textBoxTitle.Text.Trim();
            book.Author = textBoxAuthor.Text.Trim();
            book.Category = selectedCategory;
            book.Quantity = (int)numericUpDownQuantity.Value;
            book.PublishedDate = dateTimePickerPublishedDate.Value;

            return book;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
