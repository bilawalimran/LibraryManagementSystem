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
        private Book? _book;
        private readonly IBookService _service;

        public Book? Book { get; private set; }

        public BookForm() : this(BookFormModeEnum.Add, null, new BookService())
        {
        }

        public BookForm(Book? book, BookFormModeEnum formMode = BookFormModeEnum.Add)
            : this(formMode, book, new BookService())
        {
        }

        public BookForm(BookFormModeEnum mode, Book? book, IBookService service)
        {
            InitializeComponent();

            _mode = mode;
            _book = book;
            _service = service;

            LoadCategories();

            if (_mode == BookFormModeEnum.Edit)
            {
                buttonSave.Text = "Update";
            }
            else if (_mode == BookFormModeEnum.View)
            {
                buttonSave.Visible = false;
            }

            if (_mode == BookFormModeEnum.Edit || _mode == BookFormModeEnum.View)
            {
                if (_book != null)
                {
                    LoadBook(_book);
                }
            }
            else
            {
                textBoxBookId.Text = new Book().Id;
                dateTimePickerPublishedDate.Value = DateTime.Today;
            }

            ApplyMode();
        }

        private void LoadCategories()
        {
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.DataSource = Enum.GetValues(typeof(BookCategory));
            numericUpDownQuantity.Minimum = 0;
            numericUpDownQuantity.Maximum = 100000;
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
            buttonCancel.Text = isViewMode ? "Close" : "Cancel";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_mode == BookFormModeEnum.View)
            {
                Close();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Please enter book title.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxAuthor.Text))
            {
                MessageBox.Show("Please enter author name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxCategory.SelectedItem is not BookCategory selectedCategory)
            {
                MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_mode == BookFormModeEnum.Add)
            {
                Book newBook = new Book
                {
                    Id = string.IsNullOrWhiteSpace(textBoxBookId.Text)
                        ? new Book().Id
                        : textBoxBookId.Text.Trim(),
                    Title = textBoxTitle.Text.Trim(),
                    Author = textBoxAuthor.Text.Trim(),
                    Category = selectedCategory,
                    Quantity = (int)numericUpDownQuantity.Value,
                    PublishedDate = dateTimePickerPublishedDate.Value
                };

                _service.AddBook(newBook);
                Book = newBook;
            }
            else if (_mode == BookFormModeEnum.Edit && _book != null)
            {
                _book.Title = textBoxTitle.Text.Trim();
                _book.Author = textBoxAuthor.Text.Trim();
                _book.Category = selectedCategory;
                _book.Quantity = (int)numericUpDownQuantity.Value;
                _book.PublishedDate = dateTimePickerPublishedDate.Value;

                _service.UpdateBook(_book);
                Book = _book;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
