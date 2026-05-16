using App.Core.Enums;
using App.Core.Models;
using System;
using System.Windows.Forms;

namespace App.WindowsApp.Forms
{
    public partial class BookForm : Form
    {
        private readonly bool isReadOnly;

        public Book? Book { get; private set; }

        public BookForm() : this(null, false)
        {
        }

        public BookForm(Book? book, bool isReadOnly = false)
        {
            InitializeComponent();

            this.isReadOnly = isReadOnly;
            LoadCategories();

            if (book != null)
            {
                LoadBook(book);
            }

            ApplyReadOnlyMode();
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
            textBoxBookId.Text = book.Id.ToString();
            textBoxTitle.Text = book.Title;
            textBoxAuthor.Text = book.Author;
            comboBoxCategory.SelectedItem = book.Category;
            numericUpDownQuantity.Value = book.Quantity;
            dateTimePickerPublishedDate.Value = book.PublishedDate;
        }

        private void ApplyReadOnlyMode()
        {
            textBoxTitle.ReadOnly = isReadOnly;
            textBoxAuthor.ReadOnly = isReadOnly;
            comboBoxCategory.Enabled = !isReadOnly;
            numericUpDownQuantity.Enabled = !isReadOnly;
            dateTimePickerPublishedDate.Enabled = !isReadOnly;
            buttonSave.Visible = !isReadOnly;
            buttonCancel.Text = isReadOnly ? "Close" : "Cancel";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
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

            Book = new Book
            {
                Id = int.TryParse(textBoxBookId.Text, out int id) ? id : 0,
                Title = textBoxTitle.Text.Trim(),
                Author = textBoxAuthor.Text.Trim(),
                Category = selectedCategory,
                Quantity = (int)numericUpDownQuantity.Value,
                PublishedDate = dateTimePickerPublishedDate.Value
            };

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
