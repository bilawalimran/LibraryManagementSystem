using App.Core.Interfaces;
using App.Core.Models;
using App.Core.Services;
using System;
using System.Windows.Forms;

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

        public IssueForm(IssueRecord? issue, IssueFormModeEnum formMode)
            : this(formMode, issue, new IssueService(), new BookService(), new MemberService())
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

            LoadSelections();
            LoadInitialData();
            ApplyMode();
        }

        private void LoadSelections()
        {
            comboBoxBooks.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMembers.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxBooks.DataSource = _bookService.GetAllBooks();
            comboBoxBooks.DisplayMember = "Title";
            comboBoxBooks.ValueMember = "Id";

            comboBoxMembers.DataSource = _memberService.GetAllMembers();
            comboBoxMembers.DisplayMember = "Name";
            comboBoxMembers.ValueMember = "Id";
        }

        private void LoadInitialData()
        {
            if (_issue != null)
            {
                LoadIssue(_issue);
                return;
            }

            if (_mode == IssueFormModeEnum.Add)
            {
                textBoxId.Text = new IssueRecord().Id;
                dateTimePickerIssueDate.Value = DateTime.Now;
                checkBoxReturned.Checked = false;
            }
        }

        private void LoadIssue(IssueRecord issue)
        {
            Issue = issue;
            textBoxId.Text = issue.Id;
            comboBoxBooks.SelectedValue = issue.BookId;
            comboBoxMembers.SelectedValue = issue.MemberId;
            dateTimePickerIssueDate.Value = issue.IssueDate;
            checkBoxReturned.Checked = issue.ReturnDate.HasValue || _mode == IssueFormModeEnum.Edit;
            dateTimePickerReturnDate.Value = issue.ReturnDate ?? DateTime.Now;
        }

        private void ApplyMode()
        {
            bool isEditMode = _mode == IssueFormModeEnum.Edit;
            bool isViewMode = _mode == IssueFormModeEnum.View;

            labelIssueDetails.Text = _mode switch
            {
                IssueFormModeEnum.Add => "Issue Details",
                IssueFormModeEnum.Edit => "Return Details",
                IssueFormModeEnum.View => "View Issue",
                _ => "Issue Details"
            };

            comboBoxBooks.Enabled = _mode == IssueFormModeEnum.Add;
            comboBoxMembers.Enabled = _mode == IssueFormModeEnum.Add;
            dateTimePickerIssueDate.Enabled = _mode == IssueFormModeEnum.Add;
            checkBoxReturned.Enabled = _mode == IssueFormModeEnum.Add;
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

            if (!ValidateForm(out DateTime? returnDate))
            {
                return;
            }

            SaveIssue(returnDate);
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateForm(out DateTime? returnDate)
        {
            returnDate = checkBoxReturned.Checked ? dateTimePickerReturnDate.Value : null;

            if (comboBoxBooks.SelectedValue == null)
            {
                MessageBox.Show("Please select a book.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxMembers.SelectedValue == null)
            {
                MessageBox.Show("Please select a member.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (returnDate.HasValue && returnDate.Value.Date < dateTimePickerIssueDate.Value.Date)
            {
                MessageBox.Show("Return date cannot be before issue date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SaveIssue(DateTime? returnDate)
        {
            if (_mode == IssueFormModeEnum.Add)
            {
                IssueRecord newIssue = ReadIssueFromForm(new IssueRecord(), returnDate);
                _issueService.IssueBook(newIssue);
                Issue = newIssue;
                return;
            }

            if (_mode == IssueFormModeEnum.Edit && _issue != null)
            {
                DateTime selectedReturnDate = returnDate ?? DateTime.Now;
                _issue.ReturnDate = selectedReturnDate;
                _issueService.ReturnBook(_issue.Id, selectedReturnDate);
                Issue = _issue;
            }
        }

        private IssueRecord ReadIssueFromForm(IssueRecord issue, DateTime? returnDate)
        {
            issue.Id = string.IsNullOrWhiteSpace(textBoxId.Text)
                ? issue.Id
                : textBoxId.Text.Trim();
            issue.BookId = Convert.ToString(comboBoxBooks.SelectedValue) ?? string.Empty;
            issue.MemberId = Convert.ToString(comboBoxMembers.SelectedValue) ?? string.Empty;
            issue.IssueDate = dateTimePickerIssueDate.Value;
            issue.ReturnDate = returnDate;

            return issue;
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
