using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Models;
using App.Core.Services;
using App.WindowsApp.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App.WindowsApp.Views
{
    public partial class IssueView : UserControl
    {
        private readonly IIssueService service;
        private readonly IBookService bookService;
        private readonly IMemberService memberService;
        private readonly BindingSource _dgvBindingSource = new BindingSource();

        public IssueView() : this(new IssueService(), new BookService(), new MemberService())
        {
        }

        public IssueView(IIssueService _service, IBookService _bookService, IMemberService _memberService)
        {
            service = _service;
            bookService = _bookService;
            memberService = _memberService;
            InitializeComponent();
            ConfigureGridBinding();
            RefreshGrid();
        }

        private void ConfigureGridBinding()
        {
            dataGridViewIssues.AutoGenerateColumns = false;
            Id.DataPropertyName = nameof(IssueRecord.Id);
            Book.DataPropertyName = nameof(IssueRecord.BookName);
            Member.DataPropertyName = nameof(IssueRecord.MemberName);
            IssueDate.DataPropertyName = nameof(IssueRecord.IssueDate);
            ReturnDate.DataPropertyName = nameof(IssueRecord.ReturnDate);
            Status.DataPropertyName = nameof(IssueRecord.Status);
            dataGridViewIssues.DataSource = _dgvBindingSource;
        }

        private void RefreshGrid()
        {
            _dgvBindingSource.DataSource = GetFilteredIssues().ToList();
        }

        private IEnumerable<IssueRecord> GetFilteredIssues()
        {
            IEnumerable<IssueRecord> issues = service.GetAllIssues();
            string keyword = textBoxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                return issues;
            }

            return issues.Where(issue =>
                issue.Id.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                issue.BookName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                issue.MemberName.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        private IssueRecord? GetSelectedIssue()
        {
            return _dgvBindingSource.Current as IssueRecord;
        }

        private void ShowIssueForm(IssueFormModeEnum mode, IssueRecord? issue = null)
        {
            using IssueForm form = new IssueForm(mode, issue, service, bookService, memberService);
            form.ShowDialog();
            RefreshGrid();
        }

        private void toolStripButtonIssue_Click(object sender, EventArgs e)
        {
            ShowIssueForm(IssueFormModeEnum.Add);
        }

        private void toolStripButtonReturn_Click(object sender, EventArgs e)
        {
            IssueRecord? issue = GetSelectedIssue();

            if (issue == null)
            {
                MessageBox.Show("Please select an issue record to return.", "Return Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (issue.Status == IssueStatus.Returned)
            {
                MessageBox.Show("This book is already marked as returned.", "Return Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Mark the selected book as returned?",
                "Return Book",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                service.UpdateStatus(issue.Id, IssueStatus.Returned);
                RefreshGrid();
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            IssueRecord? selectedIssue = GetSelectedIssue();

            if (selectedIssue == null)
            {
                MessageBox.Show("Please select an issue record to edit.", "Edit Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowIssueForm(IssueFormModeEnum.Edit, selectedIssue);
        }

        private void toolStripButtonView_Click(object sender, EventArgs e)
        {
            IssueRecord? selectedIssue = GetSelectedIssue();

            if (selectedIssue == null)
            {
                MessageBox.Show("Please select an issue record to view.", "View Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowIssueForm(IssueFormModeEnum.View, selectedIssue);
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            IssueRecord? selectedIssue = GetSelectedIssue();
            if (selectedIssue == null)
            {
                MessageBox.Show("Please select an issue record to delete.", "Delete Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Delete the selected issue record?",
                "Delete Issue",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                service.DeleteIssue(selectedIssue.Id);
                RefreshGrid();
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}