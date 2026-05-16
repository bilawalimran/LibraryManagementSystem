using App.Core.Models;
using App.WindowsApp.Forms;
using LibraryManagementSystem.Core.Services;
using LibraryManagementSystem.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace App.WindowsApp.Views
{
    public partial class IssueView : UserControl
    {
        private readonly IssueService issueService = new IssueService();
        private readonly BookService bookService = new BookService();
        private readonly MemberService memberService = new MemberService();

        public IssueView()
        {
            InitializeComponent();
            LoadIssues();
        }

        private void LoadIssues()
        {
            try
            {
                IEnumerable<IssueRecord> issues = issueService.GetAllIssues();
                var books = bookService.GetAllBooks().ToDictionary(book => book.Id, book => book.Title);
                var members = memberService.GetAllMembers().ToDictionary(member => member.Id, member => member.Name);
                string keyword = textBoxSearch.Text.Trim();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    issues = issues.Where(issue =>
                        issue.Id.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        issue.BookId.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        issue.MemberId.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        GetBookName(books, issue.BookId).Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        GetMemberName(members, issue.MemberId).Contains(keyword, StringComparison.OrdinalIgnoreCase));
                }

                dataGridViewIssues.Rows.Clear();

                foreach (IssueRecord issue in issues)
                {
                    dataGridViewIssues.Rows.Add(
                        issue.Id,
                        GetBookName(books, issue.BookId),
                        GetMemberName(members, issue.MemberId),
                        issue.IssueDate.ToShortDateString(),
                        issue.ReturnDate?.ToShortDateString() ?? string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load issues", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string GetBookName(Dictionary<int, string> books, int bookId)
        {
            return books.TryGetValue(bookId, out string? title) ? title : $"Book #{bookId}";
        }

        private static string GetMemberName(Dictionary<int, string> members, int memberId)
        {
            return members.TryGetValue(memberId, out string? name) ? name : $"Member #{memberId}";
        }

        private int? GetSelectedIssueId()
        {
            if (dataGridViewIssues.CurrentRow == null)
            {
                return null;
            }

            return Convert.ToInt32(dataGridViewIssues.CurrentRow.Cells["Id"].Value);
        }

        private IssueRecord? GetSelectedIssue()
        {
            int? issueId = GetSelectedIssueId();

            if (!issueId.HasValue)
            {
                return null;
            }

            return issueService.GetAllIssues().FirstOrDefault(issue => issue.Id == issueId.Value);
        }

        private void toolStripButtonIssue_Click(object sender, EventArgs e)
        {
            using IssueForm form = new IssueForm();

            if (form.ShowDialog() == DialogResult.OK && form.Issue != null)
            {
                issueService.IssueBook(form.Issue);
                LoadIssues();
            }
        }

        private void toolStripButtonReturn_Click(object sender, EventArgs e)
        {
            IssueRecord? issue = GetSelectedIssue();

            if (issue == null)
            {
                MessageBox.Show("Please select an issue record to return.", "Return Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (issue.ReturnDate.HasValue)
            {
                DialogResult result = MessageBox.Show(
                    "This book already has a return date. Update it?",
                    "Return Book",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            using IssueForm form = new IssueForm(issue, true);

            if (form.ShowDialog() == DialogResult.OK && form.Issue?.ReturnDate != null)
            {
                issueService.ReturnBook(issue.Id, form.Issue.ReturnDate.Value);
                LoadIssues();
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            int? issueId = GetSelectedIssueId();

            if (!issueId.HasValue)
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
                issueService.DeleteIssue(issueId.Value);
                LoadIssues();
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadIssues();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadIssues();
        }
    }
}
