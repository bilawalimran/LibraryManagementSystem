using App.Core.Models;
using App.Core.Services;
using System;
using System.Windows.Forms;

namespace App.WindowsApp.Forms
{
    public partial class IssueForm : Form
    {
        private readonly BookService bookService = new BookService();
        private readonly MemberService memberService = new MemberService();
        private readonly bool isReturnMode;

        public IssueRecord? Issue { get; private set; }

        public IssueForm() : this(null, false)
        {
        }

        public IssueForm(IssueRecord? issue, bool isReturnMode)
        {
            InitializeComponent();

            this.isReturnMode = isReturnMode;
            LoadSelections();

            if (issue != null)
            {
                LoadIssue(issue);
            }
            else
            {
                textBoxId.Text = new IssueRecord().Id;
                dateTimePickerIssueDate.Value = DateTime.Now;
                checkBoxReturned.Checked = false;
            }

            ApplyMode();
        }

        private void LoadSelections()
        {
            comboBoxBooks.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMembers.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxBooks.DataSource = bookService.GetAllBooks();
            comboBoxBooks.DisplayMember = "Title";
            comboBoxBooks.ValueMember = "Id";

            comboBoxMembers.DataSource = memberService.GetAllMembers();
            comboBoxMembers.DisplayMember = "Name";
            comboBoxMembers.ValueMember = "Id";
        }

        private void LoadIssue(IssueRecord issue)
        {
            Issue = issue;
            textBoxId.Text = issue.Id.ToString();
            comboBoxBooks.SelectedValue = issue.BookId;
            comboBoxMembers.SelectedValue = issue.MemberId;
            dateTimePickerIssueDate.Value = issue.IssueDate;
            checkBoxReturned.Checked = issue.ReturnDate.HasValue || isReturnMode;
            dateTimePickerReturnDate.Value = issue.ReturnDate ?? DateTime.Now;
        }

        private void ApplyMode()
        {
            labelIssueDetails.Text = isReturnMode ? "Return Details" : "Issue Details";

            comboBoxBooks.Enabled = !isReturnMode;
            comboBoxMembers.Enabled = !isReturnMode;
            dateTimePickerIssueDate.Enabled = !isReturnMode;
            checkBoxReturned.Enabled = !isReturnMode;

            if (isReturnMode)
            {
                checkBoxReturned.Checked = true;
            }

            dateTimePickerReturnDate.Enabled = checkBoxReturned.Checked;
        }

        private void checkBoxReturned_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerReturnDate.Enabled = checkBoxReturned.Checked;

            if (checkBoxReturned.Checked)
            {
                dateTimePickerReturnDate.Value = DateTime.Now;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxBooks.SelectedValue == null)
            {
                MessageBox.Show("Please select a book.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxMembers.SelectedValue == null)
            {
                MessageBox.Show("Please select a member.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime? returnDate = checkBoxReturned.Checked ? dateTimePickerReturnDate.Value : null;

            if (returnDate.HasValue && returnDate.Value.Date < dateTimePickerIssueDate.Value.Date)
            {
                MessageBox.Show("Return date cannot be before issue date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Issue = new IssueRecord
            {
                Id = string.IsNullOrWhiteSpace(textBoxId.Text)
                    ? new IssueRecord().Id
                    : textBoxId.Text.Trim(),
                BookId = comboBoxBooks.SelectedValue.ToString() ?? string.Empty,
                MemberId = comboBoxMembers.SelectedValue.ToString() ?? string.Empty,
                IssueDate = dateTimePickerIssueDate.Value,
                ReturnDate = returnDate
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
