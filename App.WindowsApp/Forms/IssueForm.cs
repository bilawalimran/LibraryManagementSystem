using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Models;

namespace App.WindowsApp.Forms
{
    public partial class IssueForm : Form
    {
        private IssueFormModeEnum _mode;
        private IssueRecord? _issue;
        private IIssueService _issueService;
        private IBookService _bookService;
        private IMemberService _memberService;

        public IssueForm(
            IssueFormModeEnum mode,
            IssueRecord? issue,
            IIssueService issueService,
            IBookService bookService,
            IMemberService memberService)
        {
            InitializeComponent();

            _mode = mode;
            _issue = issue;
            _issueService = issueService;
            _bookService = bookService;
            _memberService = memberService;

            comboBoxBooks.DataSource = _bookService.GetAllBooks();
            comboBoxBooks.DisplayMember = "Title";
            comboBoxBooks.ValueMember = "Id";

            comboBoxMembers.DataSource = _memberService.GetAllMembers();
            comboBoxMembers.DisplayMember = "Name";
            comboBoxMembers.ValueMember = "Id";

            if (mode == IssueFormModeEnum.Edit)
            {
                buttonSave.Text = "Update";
                this.Text = "Edit Issue";
                labelIssueDetails.Text = "Edit Issue";
            }
            else if (mode == IssueFormModeEnum.View)
            {
                buttonSave.Visible = false;
                this.Text = "View Issue";
                labelIssueDetails.Text = "View Issue";
            }
            else
            {
                this.Text = "Add Issue";
                labelIssueDetails.Text = "Add Issue";
                labelId.Visible = false;
                textBoxId.Visible = false;

                dateTimePickerIssueDate.Value = DateTime.Now;
                dateTimePickerReturnDate.Value = DateTime.Now;
                textBoxStatus.Text = IssueStatus.Issued.ToString();
            }

            if (mode == IssueFormModeEnum.Edit || mode == IssueFormModeEnum.View)
            {
                textBoxId.Text = issue.Id;
                comboBoxBooks.SelectedValue = issue.BookId;
                comboBoxMembers.SelectedValue = issue.MemberId;
                dateTimePickerIssueDate.Value = issue.IssueDate;
                dateTimePickerReturnDate.Value = issue.ReturnDate ?? DateTime.Now;
                textBoxStatus.Text = issue.Status.ToString();
            }

            comboBoxBooks.Enabled = mode == IssueFormModeEnum.Add;
            comboBoxMembers.Enabled = mode == IssueFormModeEnum.Add;
            dateTimePickerIssueDate.Enabled = mode == IssueFormModeEnum.Add;
            dateTimePickerReturnDate.Enabled = mode != IssueFormModeEnum.View;
        }

        private bool ValidateData()
        {
            if (comboBoxBooks.SelectedValue == null)
            {
                MessageBox.Show("Please select a book.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxBooks.Focus();
                return false;
            }
            if (comboBoxMembers.SelectedValue == null)
            {
                MessageBox.Show("Please select a member.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxMembers.Focus();
                return false;
            }
            if (dateTimePickerReturnDate.Value.Date < dateTimePickerIssueDate.Value.Date)
            {
                MessageBox.Show("Return date cannot be before issue date.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerReturnDate.Focus();
                return false;
            }
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            try
            {
                if (_mode == IssueFormModeEnum.Add)
                {
                    IssueRecord newIssue = new IssueRecord();
                    newIssue.BookId = Convert.ToString(comboBoxBooks.SelectedValue) ?? string.Empty;
                    newIssue.MemberId = Convert.ToString(comboBoxMembers.SelectedValue) ?? string.Empty;
                    newIssue.IssueDate = dateTimePickerIssueDate.Value;
                    newIssue.ReturnDate = dateTimePickerReturnDate.Value;
                    newIssue.Status = IssueStatus.Issued;

                    _issueService.IssueBook(newIssue);
                    textBoxId.Text = newIssue.Id;
                    MessageBox.Show("Book issued successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (_mode == IssueFormModeEnum.Edit && _issue != null)
                {
                    _issue.ReturnDate = dateTimePickerReturnDate.Value;

                    _issueService.ReturnBook(_issue.Id, dateTimePickerReturnDate.Value);
                    MessageBox.Show("Book returned successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving issue: {ex.Message}", "Error",
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