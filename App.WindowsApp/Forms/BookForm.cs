using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Models;

namespace App.WindowsApp.Forms
{
    public partial class BookForm : Form
    {
        private BookFormModeEnum _mode;
        private Book? _book;
        private IBookService _service;

        public BookForm(BookFormModeEnum mode, Book? book, IBookService service)
        {
            InitializeComponent();

            numericUpDownQuantity.Maximum = int.MaxValue;

            comboBoxCategory.Items.Clear();
            comboBoxCategory.DataSource = Enum.GetValues(typeof(BookCategory));
            comboBoxCategory.SelectedIndex = 0;

            _mode = mode;
            _book = book;
            _service = service;

            if (mode == BookFormModeEnum.Edit)
            {
                buttonSave.Text = "Update";
                this.Text = "Edit Book";
                labelBookDetails.Text = "Edit Book";
            }
            else if (mode == BookFormModeEnum.View)
            {
                buttonSave.Visible = false;
                this.Text = "View Book";
                labelBookDetails.Text = "View Book";
            }
            else
            {
                this.Text = "Add Book";
                labelBookDetails.Text = "Add Book";
                labelId.Visible = false;
                textBoxBookId.Visible = false;
            }

            if (mode == BookFormModeEnum.Edit || mode == BookFormModeEnum.View)
            {
                textBoxBookId.Text = book.Id;
                textBoxTitle.Text = book.Title;
                textBoxAuthor.Text = book.Author;
                comboBoxCategory.SelectedItem = book.Category;
                numericUpDownQuantity.Value = book.Quantity;
                dateTimePickerPublishedDate.Value = book.PublishedDate;
            }

            if (mode == BookFormModeEnum.View)
            {
                textBoxTitle.ReadOnly = true;
                textBoxAuthor.ReadOnly = true;
                comboBoxCategory.Enabled = false;
                numericUpDownQuantity.Enabled = false;
                dateTimePickerPublishedDate.Enabled = false;
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTitle.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxAuthor.Text))
            {
                MessageBox.Show("Author cannot be empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxAuthor.Focus();
                return false;
            }
            if (numericUpDownQuantity.Value < 0)
            {
                MessageBox.Show("Quantity cannot be negative.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownQuantity.Focus();
                return false;
            }
            if (_mode == BookFormModeEnum.Add && numericUpDownQuantity.Value == 0)
            {
                MessageBox.Show("Cannot add a book with 0 quantity. Please enter at least 1.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownQuantity.Focus();
                return false;
            }
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            try
            {
                if (_mode == BookFormModeEnum.Add)
                {
                    Book newBook = new Book();
                    newBook.Title = textBoxTitle.Text.Trim();
                    newBook.Author = textBoxAuthor.Text.Trim();
                    newBook.Category = (BookCategory)comboBoxCategory.SelectedItem;
                    newBook.Quantity = (int)numericUpDownQuantity.Value;
                    newBook.PublishedDate = dateTimePickerPublishedDate.Value;

                    _service.AddBook(newBook);
                    textBoxBookId.Text = newBook.Id;
                    MessageBox.Show("Book added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (_mode == BookFormModeEnum.Edit && _book != null)
                {
                    _book.Title = textBoxTitle.Text.Trim();
                    _book.Author = textBoxAuthor.Text.Trim();
                    _book.Category = (BookCategory)comboBoxCategory.SelectedItem;
                    _book.Quantity = (int)numericUpDownQuantity.Value;
                    _book.PublishedDate = dateTimePickerPublishedDate.Value;

                    _service.UpdateBook(_book);
                    MessageBox.Show("Book updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}