using LibraryManagementSystem.Core.Services;
using LibraryManagementSystem.Infrastructure.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace App.WindowsApp.Views
{
    public partial class DashboardView : UserControl
    {
        private readonly BookService bookService = new BookService();
        private readonly MemberService memberService = new MemberService();
        private readonly IssueService issueService = new IssueService();

        public DashboardView()
        {
            InitializeComponent();
            LoadSummary();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadSummary();
        }

        private void LoadSummary()
        {
            try
            {
                var books = bookService.GetAllBooks();
                var members = memberService.GetAllMembers();
                var issues = issueService.GetAllIssues();

                labelBooksCount.Text = books.Count.ToString();
                labelMembersCount.Text = members.Count.ToString();
                labelActiveIssuesCount.Text = issues.Count(issue => !issue.ReturnDate.HasValue).ToString();
                labelReturnedCount.Text = issues.Count(issue => issue.ReturnDate.HasValue).ToString();
                labelStatus.Text = $"Last updated {DateTime.Now:g}";
            }
            catch (Exception)
            {
                labelBooksCount.Text = "N/A";
                labelMembersCount.Text = "N/A";
                labelActiveIssuesCount.Text = "N/A";
                labelReturnedCount.Text = "N/A";
                labelStatus.Text = "Unable to load dashboard data.";
            }
        }
    }
}
