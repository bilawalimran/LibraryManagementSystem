using App.Core.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace App.WindowsApp.Views
{
    public partial class DashboardView : UserControl
    {
        private readonly BookService bookService = new BookService();
        private readonly MemberService memberService = new MemberService();
        private readonly IssueService issueService = new IssueService();
        private readonly ReservationService reservationService = new ReservationService();

        private int booksCount;
        private int membersCount;
        private int activeIssuesCount;
        private int returnedCount;
        private int reservationsCount;

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
          {
            var books = bookService.GetAllBooks();
            var members = memberService.GetAllMembers();
            var issues = issueService.GetAllIssues();
            var reservations = reservationService.GetAllReservations();

            booksCount = books.Count;
            membersCount = members.Count;
            activeIssuesCount = issues.Count(issue => !issue.ReturnDate.HasValue);
            returnedCount = issues.Count(issue => issue.ReturnDate.HasValue);
            reservationsCount = reservations.Count;

            labelBooksCount.Text = booksCount.ToString();
            labelMembersCount.Text = membersCount.ToString();
            labelActiveIssuesCount.Text = activeIssuesCount.ToString();
            labelReturnedCount.Text = returnedCount.ToString();
            labelReservationsCount.Text = reservationsCount.ToString();
          }

             RefreshCharts();
        }

        private void RefreshCharts()
        {
            panelIssueStatusChart.Invalidate();
            panelLibraryTotalsChart.Invalidate();
        }

        private void panelIssueStatusChart_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawChartTitle(e.Graphics, panelIssueStatusChart.ClientRectangle, "Issue Status");

            int totalIssues = activeIssuesCount + returnedCount;
            if (totalIssues == 0)
            {
                DrawEmptyChart(e.Graphics, panelIssueStatusChart.ClientRectangle, "No issue records yet");
                return;
            }

            Rectangle pieBounds = GetPieBounds(panelIssueStatusChart.ClientRectangle);
            float activeSweep = activeIssuesCount * 360F / totalIssues;

            using SolidBrush activeBrush = new SolidBrush(Color.Goldenrod);
            using SolidBrush returnedBrush = new SolidBrush(Color.SeaGreen);
            using Pen borderPen = new Pen(Color.White, 2F);

            e.Graphics.FillPie(activeBrush, pieBounds, -90F, activeSweep);
            e.Graphics.FillPie(returnedBrush, pieBounds, -90F + activeSweep, 360F - activeSweep);
            e.Graphics.DrawEllipse(borderPen, pieBounds);

            int legendX = pieBounds.Right + 18;
            int legendY = pieBounds.Top + 18;
            DrawLegendItem(e.Graphics, legendX, legendY, Color.Goldenrod, "Active", activeIssuesCount);
            DrawLegendItem(e.Graphics, legendX, legendY + 28, Color.SeaGreen, "Returned", returnedCount);
        }

        private void panelLibraryTotalsChart_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawChartTitle(e.Graphics, panelLibraryTotalsChart.ClientRectangle, "Library Totals");

            int maxValue = Math.Max(1, Math.Max(booksCount, Math.Max(membersCount, reservationsCount)));
            int top = 50;
            int left = 110;
            int rightPadding = 26;
            int barHeight = 18;
            int gap = 18;
            int maxBarWidth = Math.Max(20, panelLibraryTotalsChart.Width - left - rightPadding);

            DrawBar(e.Graphics, "Books", booksCount, maxValue, left, top, maxBarWidth, barHeight, Color.RoyalBlue);
            DrawBar(e.Graphics, "Members", membersCount, maxValue, left, top + barHeight + gap, maxBarWidth, barHeight, Color.SeaGreen);
            DrawBar(e.Graphics, "Reservations", reservationsCount, maxValue, left, top + (barHeight + gap) * 2, maxBarWidth, barHeight, Color.Teal);
        }

        private static void DrawChartTitle(Graphics graphics, Rectangle bounds, string title)
        {
            using Font titleFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            TextRenderer.DrawText(
                graphics,
                title,
                titleFont,
                new Rectangle(12, 10, bounds.Width - 24, 24),
                Color.FromArgb(35, 45, 60),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        private static void DrawEmptyChart(Graphics graphics, Rectangle bounds, string message)
        {
            using Font messageFont = new Font("Segoe UI", 9F, FontStyle.Regular);
            TextRenderer.DrawText(
                graphics,
                message,
                messageFont,
                new Rectangle(12, 48, bounds.Width - 24, 32),
                Color.DimGray,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private static Rectangle GetPieBounds(Rectangle bounds)
        {
            int size = Math.Min(92, Math.Max(48, Math.Min(bounds.Width / 3, bounds.Height - 58)));
            return new Rectangle(18, 48, size, size);
        }

        private static void DrawLegendItem(Graphics graphics, int x, int y, Color color, string label, int value)
        {
            using SolidBrush colorBrush = new SolidBrush(color);
            using Font legendFont = new Font("Segoe UI", 9F, FontStyle.Regular);

            graphics.FillRectangle(colorBrush, x, y + 4, 12, 12);
            TextRenderer.DrawText(
                graphics,
                $"{label}: {value}",
                legendFont,
                new Rectangle(x + 18, y, 140, 22),
                Color.FromArgb(45, 45, 45),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        private static void DrawBar(
            Graphics graphics,
            string label,
            int value,
            int maxValue,
            int x,
            int y,
            int maxWidth,
            int height,
            Color color)
        {
            int width = Math.Max(2, value * maxWidth / maxValue);

            using SolidBrush barBrush = new SolidBrush(color);
            using SolidBrush trackBrush = new SolidBrush(Color.FromArgb(235, 239, 244));
            using Font labelFont = new Font("Segoe UI", 9F, FontStyle.Regular);

            TextRenderer.DrawText(
                graphics,
                label,
                labelFont,
                new Rectangle(12, y - 2, x - 20, height + 4),
                Color.FromArgb(45, 45, 45),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

            graphics.FillRectangle(trackBrush, x, y, maxWidth, height);
            graphics.FillRectangle(barBrush, x, y, width, height);

            TextRenderer.DrawText(
                graphics,
                value.ToString(),
                labelFont,
                new Rectangle(x + maxWidth - 38, y - 2, 38, height + 4),
                Color.FromArgb(35, 35, 35),
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
        }
    }
}
