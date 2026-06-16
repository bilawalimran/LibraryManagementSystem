using App.Core.Interfaces;
using App.Core.Models;
using App.Core.Services;
using App.WindowsApp.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App.WindowsApp.Views
{
    public partial class ReservationView : UserControl
    {
        private readonly IReservationService service;
        private readonly IBookService bookService;
        private readonly IMemberService memberService;
        private readonly BindingSource _dgvBindingSource = new BindingSource();

        public ReservationView() : this(new ReservationService(), new BookService(), new MemberService())
        {
        }

        public ReservationView(IReservationService _service, IBookService _bookService,IMemberService _memberService)
        {
            service = _service;
            bookService = _bookService;
            memberService = _memberService;
            InitializeComponent();
            ConfigureGridBinding();
            dataGridViewReservations.DataSource = _dgvBindingSource;
            RefreshGrid();
        }

        private void ConfigureGridBinding()
        {
          dataGridViewReservations.AutoGenerateColumns = false;
            Id.DataPropertyName = nameof(Reservation.Id);
            Book.DataPropertyName = nameof(Reservation.BookName);
            Member.DataPropertyName = nameof(Reservation.MemberName);
            ReservationDate.DataPropertyName = nameof(Reservation.ReservationDate);
            ExpiryDate.DataPropertyName = nameof(Reservation.ExpiryDate);
            Status.DataPropertyName = nameof(Reservation.Status);
        }

        private void RefreshGrid()
        {
            _dgvBindingSource.DataSource = GetFilteredReservations().ToList();
        }

        private IEnumerable<Reservation> GetFilteredReservations()
        {
            IEnumerable<Reservation> reservations = service.GetAllReservations();
            string keyword = textBoxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                return reservations;
            }

            return reservations.Where(reservation =>
                reservation.Id.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                reservation.Status.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                reservation.BookName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                reservation.MemberName.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        private Reservation? GetSelectedReservation()
        {
            return _dgvBindingSource.Current as Reservation;
        }

        private void ShowReservationForm(  ReservationFormModeEnum mode,   Reservation? reservation = null, bool refreshAfterClose = true)
        {
            using ReservationForm form = new ReservationForm(
                mode,
                reservation,
                service,
                bookService,
                memberService);
            form.ShowDialog();

            if (refreshAfterClose)
            {
                RefreshGrid();
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            ShowReservationForm(ReservationFormModeEnum.Add);
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            Reservation? selectedReservation = GetSelectedReservation();

            if (selectedReservation == null)
            {
                MessageBox.Show("Please select a reservation to edit.", "Edit Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowReservationForm(ReservationFormModeEnum.Edit, selectedReservation);
        }

        private void toolStripButtonView_Click(object sender, EventArgs e)
        {
            Reservation? selectedReservation = GetSelectedReservation();

            if (selectedReservation == null)
            {
                MessageBox.Show("Please select a reservation to view.", "View Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowReservationForm(
                ReservationFormModeEnum.View,
                selectedReservation,
                refreshAfterClose: false);
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            Reservation? selectedReservation = GetSelectedReservation();

            if (selectedReservation == null)
            {
                MessageBox.Show("Please select a reservation to delete.", "Delete Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Delete the selected reservation?",
                "Delete Reservation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                service.DeleteReservation(selectedReservation.Id);
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
