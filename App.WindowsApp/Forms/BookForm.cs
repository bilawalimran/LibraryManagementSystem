using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Models;
using App.Core.Services;

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

            comboBoxCategory.DataSource = Enum.GetValues(typeof(BookCategory));
            numericUpDownQuantity.Minimum = 0;
            numericUpDownQuantity.Maximum = 1000;

            _mode = mode;
            _book = book;
            _service = service;

            if (book != null)
            {
                Book = book;
                textBoxBookId.Text = book.Id;
                textBoxTitle.Text = book.Title;
                textBoxAuthor.Text = book.Author;
                comboBoxCategory.SelectedItem = book.Category;
                numericUpDownQuantity.Value = book.Quantity;
                dateTimePickerPublishedDate.Value = book.PublishedDate;
            }
            else if (mode == BookFormModeEnum.Add)
            {
                textBoxBookId.Text = new Book().Id;
                dateTimePickerPublishedDate.Value = DateTime.Today;
            }

            bool isViewMode = mode == BookFormModeEnum.View;

            labelBookDetails.Text = mode switch
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
            buttonSave.Text = mode == BookFormModeEnum.Edit ? "Update" : "Save";
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
                Book newBook = new Book();
                newBook.Id = string.IsNullOrWhiteSpace(textBoxBookId.Text) ? newBook.Id : textBoxBookId.Text.Trim();
                newBook.Title = textBoxTitle.Text.Trim();
                newBook.Author = textBoxAuthor.Text.Trim();
                newBook.Category = selectedCategory;
                newBook.Quantity = (int)numericUpDownQuantity.Value;
                newBook.PublishedDate = dateTimePickerPublishedDate.Value;

                _service.AddBook(newBook);
                Book = newBook;
            }
            else if (_mode == BookFormModeEnum.Edit && _book != null)
            {
                _book.Id = string.IsNullOrWhiteSpace(textBoxBookId.Text) ? _book.Id : textBoxBookId.Text.Trim();
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