using App.Core.Interfaces;
using App.Core.Models;
using App.Core.Services;

namespace App.WindowsApp.Forms
{
    public partial class IssueForm : Form
    {
        private readonly IssueFormModeEnum _mode;
        private readonly IIssueService _issueService;
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private IssueRecord? _issue;

        public IssueRecord? Issue { get; private set; }

        public IssueForm()
            : this(IssueFormModeEnum.Add, null, new IssueService(), new BookService(), new MemberService())
        {
        }

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

            if (issue != null)
            {
                Issue = issue;
                textBoxId.Text = issue.Id;
                comboBoxBooks.SelectedValue = issue.BookId;
                comboBoxMembers.SelectedValue = issue.MemberId;
                dateTimePickerIssueDate.Value = issue.IssueDate;
                checkBoxReturned.Checked = issue.ReturnDate.HasValue || mode == IssueFormModeEnum.Edit;
                dateTimePickerReturnDate.Value = issue.ReturnDate ?? DateTime.Now;
            }
            else if (mode == IssueFormModeEnum.Add)
            {
                textBoxId.Text = new IssueRecord().Id;
                dateTimePickerIssueDate.Value = DateTime.Now;
                checkBoxReturned.Checked = false;
            }

            bool isEditMode = mode == IssueFormModeEnum.Edit;
            bool isViewMode = mode == IssueFormModeEnum.View;

            labelIssueDetails.Text = mode switch
            {
                IssueFormModeEnum.Add => "Issue Details",
                IssueFormModeEnum.Edit => "Return Details",
                IssueFormModeEnum.View => "View Issue",
                _ => "Issue Details"
            };

            comboBoxBooks.Enabled = mode == IssueFormModeEnum.Add;
            comboBoxMembers.Enabled = mode == IssueFormModeEnum.Add;
            dateTimePickerIssueDate.Enabled = mode == IssueFormModeEnum.Add;
            checkBoxReturned.Enabled = mode == IssueFormModeEnum.Add;
            checkBoxReturned.Checked = isEditMode || checkBoxReturned.Checked;
            dateTimePickerReturnDate.Enabled = !isViewMode && checkBoxReturned.Checked;
            buttonSave.Visible = !isViewMode;
            buttonSave.Text = isEditMode ? "Return" : "Save";
            buttonCancel.Text = isViewMode ? "Close" : "Cancel";
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
            if (_mode == IssueFormModeEnum.View)
            {
                Close();
                return;
            }

            DateTime? returnDate = checkBoxReturned.Checked ? dateTimePickerReturnDate.Value : null;

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

            if (returnDate.HasValue && returnDate.Value.Date < dateTimePickerIssueDate.Value.Date)
            {
                MessageBox.Show("Return date cannot be before issue date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_mode == IssueFormModeEnum.Add)
            {
                IssueRecord newIssue = new IssueRecord();
                newIssue.Id = string.IsNullOrWhiteSpace(textBoxId.Text) ? newIssue.Id : textBoxId.Text.Trim();
                newIssue.BookId = Convert.ToString(comboBoxBooks.SelectedValue) ?? string.Empty;
                newIssue.MemberId = Convert.ToString(comboBoxMembers.SelectedValue) ?? string.Empty;
                newIssue.IssueDate = dateTimePickerIssueDate.Value;
                newIssue.ReturnDate = returnDate;

                _issueService.IssueBook(newIssue);
                Issue = newIssue;
            }
            else if (_mode == IssueFormModeEnum.Edit && _issue != null)
            {
                DateTime selectedReturnDate = returnDate ?? DateTime.Now;
                _issue.ReturnDate = selectedReturnDate;
                _issueService.ReturnBook(_issue.Id, selectedReturnDate);
                Issue = _issue;
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