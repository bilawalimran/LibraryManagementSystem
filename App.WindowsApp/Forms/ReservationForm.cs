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
        private Reservation? _reservation;
        private readonly IReservationService _reservationService;
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;

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

            if (_mode == ReservationFormModeEnum.Edit)
            {
                buttonSave.Text = "Update";
            }
            else if (_mode == ReservationFormModeEnum.View)
            {
                buttonSave.Visible = false;
            }

            if (_mode == ReservationFormModeEnum.Edit || _mode == ReservationFormModeEnum.View)
            {
                if (_reservation != null)
                {
                    LoadReservation(_reservation);
                }
            }
            else
            {
                textBoxReservationId.Text = new Reservation().Id;
                dateTimePickerReservationDate.Value = DateTime.Today;
                checkBoxHasExpiry.Checked = true;
                dateTimePickerExpiryDate.Value = DateTime.Today.AddDays(7);
                comboBoxStatus.SelectedItem = ReservationStatus.Pending;
            }

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

            if (comboBoxBooks.SelectedValue == null)
            {
                MessageBox.Show("Please select a book.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxMembers.SelectedValue == null)
            {
                MessageBox.Show("Please select a member.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxStatus.SelectedItem is not ReservationStatus selectedStatus)
            {
                MessageBox.Show("Please select a status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime? expiryDate = checkBoxHasExpiry.Checked ? dateTimePickerExpiryDate.Value : null;

            if (expiryDate.HasValue && expiryDate.Value.Date < dateTimePickerReservationDate.Value.Date)
            {
                MessageBox.Show("Expiry date cannot be before reservation date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_mode == ReservationFormModeEnum.Add)
            {
                Reservation newReservation = new Reservation
                {
                    Id = string.IsNullOrWhiteSpace(textBoxReservationId.Text)
                        ? new Reservation().Id
                        : textBoxReservationId.Text.Trim(),
                    BookId = comboBoxBooks.SelectedValue.ToString() ?? string.Empty,
                    MemberId = comboBoxMembers.SelectedValue.ToString() ?? string.Empty,
                    ReservationDate = dateTimePickerReservationDate.Value,
                    ExpiryDate = expiryDate,
                    Status = selectedStatus
                };

                _reservationService.AddReservation(newReservation);
                Reservation = newReservation;
            }
            else if (_mode == ReservationFormModeEnum.Edit && _reservation != null)
            {
                _reservation.BookId = comboBoxBooks.SelectedValue.ToString() ?? string.Empty;
                _reservation.MemberId = comboBoxMembers.SelectedValue.ToString() ?? string.Empty;
                _reservation.ReservationDate = dateTimePickerReservationDate.Value;
                _reservation.ExpiryDate = expiryDate;
                _reservation.Status = selectedStatus;

                _reservationService.UpdateReservation(_reservation);
                Reservation = _reservation;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
