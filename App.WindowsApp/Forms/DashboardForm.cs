using System;
using System.Windows.Forms;
using App.WindowsApp.Views;

namespace App.WindowsApp.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            ShowView(new DashboardView());
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
