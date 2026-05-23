using App.Core.Interfaces;
using App.Core.Models;
using App.WindowsApp.Forms;
using App.Core.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App.WindowsApp.Views
{
    public partial class IssueView : UserControl
    {
        private IIssueService service;
        private IBookService bookService;
        private IMemberService memberService;
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
            ApplyStyles();
            RefreshGrid();
        }

        private void ConfigureGridBinding()
        {
            dataGridViewIssues.AutoGenerateColumns = false;
            Id.DataPropertyName = nameof(IssueGridRow.Id);
            Book.DataPropertyName = nameof(IssueGridRow.Book);
            Member.DataPropertyName = nameof(IssueGridRow.Member);
            IssueDate.DataPropertyName = nameof(IssueGridRow.IssueDate);
            ReturnDate.DataPropertyName = nameof(IssueGridRow.ReturnDate);
            IssueDate.DefaultCellStyle.Format = "d";
            ReturnDate.DefaultCellStyle.Format = "d";
            dataGridViewIssues.DataSource = _dgvBindingSource;
        }

        private void ApplyStyles()
        {
            Color accentColor = Color.Goldenrod;

            BackColor = Color.White;
            flowLayoutPanel.BackColor = Color.LemonChiffon;
            flowLayoutPanel.Padding = new Padding(8);

            toolStripIssues.BackColor = Color.WhiteSmoke;
            toolStripIssues.GripStyle = ToolStripGripStyle.Hidden;
            toolStripIssues.Padding = new Padding(6, 4, 6, 4);
            toolStripIssues.RenderMode = ToolStripRenderMode.System;

            foreach (ToolStripItem item in toolStripIssues.Items)
            {
                item.Margin = new Padding(2, 0, 2, 0);
                item.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            }

            dataGridViewIssues.BackgroundColor = Color.White;
            dataGridViewIssues.BorderStyle = BorderStyle.None;
            dataGridViewIssues.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewIssues.GridColor = Color.Gainsboro;
            dataGridViewIssues.EnableHeadersVisualStyles = false;
            dataGridViewIssues.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewIssues.ColumnHeadersDefaultCellStyle.BackColor = accentColor;
            dataGridViewIssues.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewIssues.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewIssues.ColumnHeadersDefaultCellStyle.SelectionBackColor = accentColor;
            dataGridViewIssues.ColumnHeadersHeight = 34;
            dataGridViewIssues.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dataGridViewIssues.DefaultCellStyle.SelectionBackColor = ControlPaint.Light(accentColor, 0.65F);
            dataGridViewIssues.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewIssues.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 250, 220);
            dataGridViewIssues.RowTemplate.Height = 28;
        }

        private void RefreshGrid()
        {
            try
            {
                IEnumerable<IssueRecord> issues = service.GetAllIssues();
                var books = bookService.GetAllBooks().ToDictionary(book => book.Id, book => book.Title);
                var members = memberService.GetAllMembers().ToDictionary(member => member.Id, member => member.Name);
                string keyword = textBoxSearch.Text.Trim();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    issues = issues.Where(issue =>
                        issue.Id.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        issue.BookId.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        issue.MemberId.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        GetBookName(books, issue.BookId).Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        GetMemberName(members, issue.MemberId).Contains(keyword, StringComparison.OrdinalIgnoreCase));
                }

                _dgvBindingSource.DataSource = issues
                    .Select(issue => new IssueGridRow
                    {
                        Id = issue.Id,
                        Book = GetBookName(books, issue.BookId),
                        Member = GetMemberName(members, issue.MemberId),
                        IssueDate = issue.IssueDate,
                        ReturnDate = issue.ReturnDate,
                        Issue = issue
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load issues", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string GetBookName(Dictionary<string, string> books, string bookId)
        {
            return books.TryGetValue(bookId, out string? title) ? title : $"Book #{bookId}";
        }

        private static string GetMemberName(Dictionary<string, string> members, string memberId)
        {
            return members.TryGetValue(memberId, out string? name) ? name : $"Member #{memberId}";
        }

        private IssueGridRow? GetSelectedIssueRow()
        {
            return _dgvBindingSource.Current as IssueGridRow;
        }

        private IssueRecord? GetSelectedIssue()
        {
            return GetSelectedIssueRow()?.Issue;
        }

        private void toolStripButtonIssue_Click(object sender, EventArgs e)
        {
            using IssueForm form = new IssueForm(IssueFormModeEnum.Add, null, service, bookService, memberService);
            form.ShowDialog();
            RefreshGrid();
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

            using IssueForm form = new IssueForm(IssueFormModeEnum.Edit, issue, service, bookService, memberService);
            form.ShowDialog();
            RefreshGrid();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            IssueGridRow? selectedIssue = GetSelectedIssueRow();
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

        private class IssueGridRow
        {
            public string Id { get; set; } = string.Empty;
            public string Book { get; set; } = string.Empty;
            public string Member { get; set; } = string.Empty;
            public DateTime IssueDate { get; set; }
            public DateTime? ReturnDate { get; set; }
            public IssueRecord Issue { get; set; } = null!;
        }
    }
}
