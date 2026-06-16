using System;
using System.Windows.Forms;
using App.Core.Interfaces;
using App.Core.Services;
using App.WindowsApp.Views;

namespace App.WindowsApp.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private readonly IReservationService _reservationService;

        public DashboardForm() : this(new BookService(), new MemberService(), new ReservationService())
        {
        }

        public DashboardForm(IBookService bookService, IMemberService memberService, IReservationService reservationService)
        {
            _bookService = bookService;
            _memberService = memberService;
            _reservationService = reservationService;

            InitializeComponent();

            ShowView(new DashboardView());

            toolStripStatusLabelBooks.Text = $"Books: {_bookService.GetAllBooks().Count}";
            toolStripStatusLabelMembers.Text = $"Members: {_memberService.GetAllMembers().Count}";
            toolStripStatusLabelReservations.Text = $"Reservations: {_reservationService.GetAllReservations().Count}";
        }

        private void ShowView(UserControl view)
        {
            this.panelContent.Controls.Clear();
            view.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(view);
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            ShowView(new DashboardView());
        }

        private void buttonBooks_Click(object sender, EventArgs e)
        {
            ShowView(new BookView());
        }

        private void buttonMembers_Click(object sender, EventArgs e)
        {
            ShowView(new MemberView());
        }

        private void buttonIssueReturn_Click(object sender, EventArgs e)
        {
            ShowView(new IssueView());
        }

        private void buttonReservations_Click(object sender, EventArgs e)
        {
            ShowView(new ReservationView());
        }
    }
}