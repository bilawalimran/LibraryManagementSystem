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

namespace App.WindowsApp.Views
{
    public partial class ReservationView : UserControl
    {
        private IReservationService service;
        private IBookService bookService;
        private IMemberService memberService;
        private readonly BindingSource _dgvBindingSource = new BindingSource();

        public ReservationView() : this(new ReservationService(), new BookService(), new MemberService())
        {
        }

        public ReservationView(
            IReservationService _service,
            IBookService _bookService,
            IMemberService _memberService)
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
            dataGridViewReservations.AutoGenerateColumns = false;
            Id.DataPropertyName = nameof(ReservationGridRow.Id);
            Book.DataPropertyName = nameof(ReservationGridRow.Book);
            Member.DataPropertyName = nameof(ReservationGridRow.Member);
            ReservationDate.DataPropertyName = nameof(ReservationGridRow.ReservationDate);
            ExpiryDate.DataPropertyName = nameof(ReservationGridRow.ExpiryDate);
            Status.DataPropertyName = nameof(ReservationGridRow.Status);
            ReservationDate.DefaultCellStyle.Format = "d";
            ExpiryDate.DefaultCellStyle.Format = "d";
            dataGridViewReservations.DataSource = _dgvBindingSource;
        }

        private void ApplyStyles()
        {
            Color accentColor = Color.Teal;

            BackColor = Color.White;
            panelFilters.BackColor = Color.Azure;
            panelFilters.Padding = new Padding(8);

            toolStripReservations.BackColor = Color.WhiteSmoke;
            toolStripReservations.GripStyle = ToolStripGripStyle.Hidden;
            toolStripReservations.Padding = new Padding(6, 4, 6, 4);
            toolStripReservations.RenderMode = ToolStripRenderMode.System;

            foreach (ToolStripItem item in toolStripReservations.Items)
            {
                item.Margin = new Padding(2, 0, 2, 0);
                item.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            }

            dataGridViewReservations.BackgroundColor = Color.White;
            dataGridViewReservations.BorderStyle = BorderStyle.None;
            dataGridViewReservations.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewReservations.GridColor = Color.Gainsboro;
            dataGridViewReservations.EnableHeadersVisualStyles = false;
            dataGridViewReservations.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewReservations.ColumnHeadersDefaultCellStyle.BackColor = accentColor;
            dataGridViewReservations.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewReservations.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewReservations.ColumnHeadersDefaultCellStyle.SelectionBackColor = accentColor;
            dataGridViewReservations.ColumnHeadersHeight = 34;
            dataGridViewReservations.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dataGridViewReservations.DefaultCellStyle.SelectionBackColor = ControlPaint.Light(accentColor, 0.65F);
            dataGridViewReservations.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewReservations.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 250, 250);
            dataGridViewReservations.RowTemplate.Height = 28;
        }

        private void RefreshGrid()
        {
            try
            {
                IEnumerable<Reservation> reservations = service.GetAllReservations();
                var books = bookService.GetAllBooks().ToDictionary(book => book.Id, book => book.Title);
                var members = memberService.GetAllMembers().ToDictionary(member => member.Id, member => member.Name);
                string keyword = textBoxSearch.Text.Trim();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    reservations = reservations.Where(reservation =>
                        reservation.Id.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        reservation.BookId.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        reservation.MemberId.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        reservation.Status.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        GetBookName(books, reservation.BookId).Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        GetMemberName(members, reservation.MemberId).Contains(keyword, StringComparison.OrdinalIgnoreCase));
                }

                _dgvBindingSource.DataSource = reservations
                    .Select(reservation => new ReservationGridRow
                    {
                        Id = reservation.Id,
                        Book = GetBookName(books, reservation.BookId),
                        Member = GetMemberName(members, reservation.MemberId),
                        ReservationDate = reservation.ReservationDate,
                        ExpiryDate = reservation.ExpiryDate,
                        Status = reservation.Status,
                        Reservation = reservation
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load reservations", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private ReservationGridRow? GetSelectedReservationRow()
        {
            return _dgvBindingSource.Current as ReservationGridRow;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            using ReservationForm form = new ReservationForm(
                ReservationFormModeEnum.Add,
                null,
                service,
                bookService,
                memberService);
            form.ShowDialog();
            RefreshGrid();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            ReservationGridRow? selectedReservation = GetSelectedReservationRow();

            if (selectedReservation == null)
            {
                MessageBox.Show("Please select a reservation to edit.", "Edit Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using ReservationForm form = new ReservationForm(
                ReservationFormModeEnum.Edit,
                selectedReservation.Reservation,
                service,
                bookService,
                memberService);
            form.ShowDialog();
            RefreshGrid();
        }

        private void toolStripButtonView_Click(object sender, EventArgs e)
        {
            ReservationGridRow? selectedReservation = GetSelectedReservationRow();

            if (selectedReservation == null)
            {
                MessageBox.Show("Please select a reservation to view.", "View Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using ReservationForm form = new ReservationForm(
                ReservationFormModeEnum.View,
                selectedReservation.Reservation,
                service,
                bookService,
                memberService);
            form.ShowDialog();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            ReservationGridRow? selectedReservation = GetSelectedReservationRow();

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

        private class ReservationGridRow
        {
            public string Id { get; set; } = string.Empty;
            public string Book { get; set; } = string.Empty;
            public string Member { get; set; } = string.Empty;
            public DateTime ReservationDate { get; set; }
            public DateTime? ExpiryDate { get; set; }
            public ReservationStatus Status { get; set; }
            public Reservation Reservation { get; set; } = null!;
        }
    }
}
