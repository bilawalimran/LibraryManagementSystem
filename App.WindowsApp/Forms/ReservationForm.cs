using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Models;
using App.Core.Services;
using System;
using System.Windows.Forms;

namespace App.WindowsApp.Forms
{
    public partial class ReservationForm : Form
    {
        private readonly ReservationFormModeEnum _mode;
        private readonly IReservationService _reservationService;
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private Reservation? _reservation;

        public Reservation? Reservation { get; private set; }

        public ReservationForm()
            : this(ReservationFormModeEnum.Add, null, new ReservationService(), new BookService(), new MemberService())
        {
        }

        public ReservationForm(Reservation? reservation, ReservationFormModeEnum formMode)
            : this(formMode, reservation, new ReservationService(), new BookService(), new MemberService())
        {
        }

        public ReservationForm(
            ReservationFormModeEnum mode,
            Reservation? reservation,
            IReservationService reservationService,
            IBookService bookService,
            IMemberService memberService)
        {
            InitializeComponent();

            _mode = mode;
            _reservation = reservation;
            _reservationService = reservationService;
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
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxBooks.DataSource = _bookService.GetAllBooks();
            comboBoxBooks.DisplayMember = "Title";
            comboBoxBooks.ValueMember = "Id";

            comboBoxMembers.DataSource = _memberService.GetAllMembers();
            comboBoxMembers.DisplayMember = "Name";
            comboBoxMembers.ValueMember = "Id";

            comboBoxStatus.DataSource = Enum.GetValues(typeof(ReservationStatus));
        }

        private void LoadInitialData()
        {
            if (_reservation != null)
            {
                LoadReservation(_reservation);
                return;
            }

            if (_mode == ReservationFormModeEnum.Add)
            {
                textBoxReservationId.Text = new Reservation().Id;
                dateTimePickerReservationDate.Value = DateTime.Today;
                checkBoxHasExpiry.Checked = true;
                dateTimePickerExpiryDate.Value = DateTime.Today.AddDays(7);
                comboBoxStatus.SelectedItem = ReservationStatus.Pending;
            }
        }

        private void LoadReservation(Reservation reservation)
        {
            Reservation = reservation;
            textBoxReservationId.Text = reservation.Id;
            comboBoxBooks.SelectedValue = reservation.BookId;
            comboBoxMembers.SelectedValue = reservation.MemberId;
            dateTimePickerReservationDate.Value = reservation.ReservationDate;
            checkBoxHasExpiry.Checked = reservation.ExpiryDate.HasValue;
            dateTimePickerExpiryDate.Value = reservation.ExpiryDate ?? DateTime.Today.AddDays(7);
            comboBoxStatus.SelectedItem = reservation.Status;
        }

        private void ApplyMode()
        {
            bool isViewMode = _mode == ReservationFormModeEnum.View;

            labelReservationDetails.Text = _mode switch
            {
                ReservationFormModeEnum.Add => "Add Reservation",
                ReservationFormModeEnum.Edit => "Edit Reservation",
                ReservationFormModeEnum.View => "View Reservation",
                _ => "Reservation Details"
            };

            comboBoxBooks.Enabled = !isViewMode;
            comboBoxMembers.Enabled = !isViewMode;
            dateTimePickerReservationDate.Enabled = !isViewMode;
            checkBoxHasExpiry.Enabled = !isViewMode;
            dateTimePickerExpiryDate.Enabled = !isViewMode && checkBoxHasExpiry.Checked;
            comboBoxStatus.Enabled = !isViewMode;
            buttonSave.Visible = !isViewMode;
            buttonSave.Text = _mode == ReservationFormModeEnum.Edit ? "Update" : "Save";
            buttonCancel.Text = isViewMode ? "Close" : "Cancel";
        }

        private void checkBoxHasExpiry_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerExpiryDate.Enabled =
                _mode != ReservationFormModeEnum.View && checkBoxHasExpiry.Checked;

            if (checkBoxHasExpiry.Checked && dateTimePickerExpiryDate.Value.Date < dateTimePickerReservationDate.Value.Date)
            {
                dateTimePickerExpiryDate.Value = dateTimePickerReservationDate.Value.Date.AddDays(7);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_mode == ReservationFormModeEnum.View)
            {
                Close();
                return;
            }

            if (!ValidateForm(out ReservationStatus selectedStatus, out DateTime? expiryDate))
            {
                return;
            }

            SaveReservation(selectedStatus, expiryDate);
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateForm(out ReservationStatus selectedStatus, out DateTime? expiryDate)
        {
            selectedStatus = default;
            expiryDate = checkBoxHasExpiry.Checked ? dateTimePickerExpiryDate.Value : null;

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

            if (comboBoxStatus.SelectedItem is not ReservationStatus status)
            {
                MessageBox.Show("Please select a status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (expiryDate.HasValue && expiryDate.Value.Date < dateTimePickerReservationDate.Value.Date)
            {
                MessageBox.Show("Expiry date cannot be before reservation date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            selectedStatus = status;
            return true;
        }

        private void SaveReservation(ReservationStatus selectedStatus, DateTime? expiryDate)
        {
            if (_mode == ReservationFormModeEnum.Add)
            {
                Reservation newReservation = ReadReservationFromForm(new Reservation(), selectedStatus, expiryDate);
                _reservationService.AddReservation(newReservation);
                Reservation = newReservation;
                return;
            }

            if (_mode == ReservationFormModeEnum.Edit && _reservation != null)
            {
                Reservation = ReadReservationFromForm(_reservation, selectedStatus, expiryDate);
                _reservationService.UpdateReservation(_reservation);
            }
        }

        private Reservation ReadReservationFromForm(
            Reservation reservation,
            ReservationStatus selectedStatus,
            DateTime? expiryDate)
        {
            reservation.Id = string.IsNullOrWhiteSpace(textBoxReservationId.Text)
                ? reservation.Id
                : textBoxReservationId.Text.Trim();
            reservation.BookId = Convert.ToString(comboBoxBooks.SelectedValue) ?? string.Empty;
            reservation.MemberId = Convert.ToString(comboBoxMembers.SelectedValue) ?? string.Empty;
            reservation.ReservationDate = dateTimePickerReservationDate.Value;
            reservation.ExpiryDate = expiryDate;
            reservation.Status = selectedStatus;

            return reservation;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
