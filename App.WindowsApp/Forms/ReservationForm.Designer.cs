namespace App.WindowsApp.Forms
{
    partial class ReservationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelReservationDetails = new Panel();
            labelReservationDetails = new Label();
            tableLayoutPanel = new TableLayoutPanel();
            labelBook = new Label();
            labelMember = new Label();
            labelReservationDate = new Label();
            labelHasExpiry = new Label();
            labelExpiryDate = new Label();
            labelStatus = new Label();
            labelId = new Label();
            comboBoxBooks = new ComboBox();
            comboBoxMembers = new ComboBox();
            dateTimePickerReservationDate = new DateTimePicker();
            checkBoxHasExpiry = new CheckBox();
            dateTimePickerExpiryDate = new DateTimePicker();
            comboBoxStatus = new ComboBox();
            textBoxReservationId = new TextBox();
            flowLayoutPanel = new FlowLayoutPanel();
            buttonCancel = new Button();
            buttonSave = new Button();
            panelReservationDetails.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelReservationDetails
            // 
            panelReservationDetails.Controls.Add(labelReservationDetails);
            panelReservationDetails.Dock = DockStyle.Top;
            panelReservationDetails.Location = new Point(0, 0);
            panelReservationDetails.Name = "panelReservationDetails";
            panelReservationDetails.Size = new Size(650, 43);
            panelReservationDetails.TabIndex = 0;
            // 
            // labelReservationDetails
            // 
            labelReservationDetails.AutoSize = true;
            labelReservationDetails.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelReservationDetails.Location = new Point(12, 9);
            labelReservationDetails.Name = "labelReservationDetails";
            labelReservationDetails.Size = new Size(234, 32);
            labelReservationDetails.TabIndex = 0;
            labelReservationDetails.Text = "Reservation Details";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76F));
            tableLayoutPanel.Controls.Add(labelBook, 0, 0);
            tableLayoutPanel.Controls.Add(labelMember, 0, 1);
            tableLayoutPanel.Controls.Add(labelReservationDate, 0, 2);
            tableLayoutPanel.Controls.Add(labelHasExpiry, 0, 3);
            tableLayoutPanel.Controls.Add(labelExpiryDate, 0, 4);
            tableLayoutPanel.Controls.Add(labelStatus, 0, 5);
            tableLayoutPanel.Controls.Add(labelId, 0, 6);
            tableLayoutPanel.Controls.Add(comboBoxBooks, 1, 0);
            tableLayoutPanel.Controls.Add(comboBoxMembers, 1, 1);
            tableLayoutPanel.Controls.Add(dateTimePickerReservationDate, 1, 2);
            tableLayoutPanel.Controls.Add(checkBoxHasExpiry, 1, 3);
            tableLayoutPanel.Controls.Add(dateTimePickerExpiryDate, 1, 4);
            tableLayoutPanel.Controls.Add(comboBoxStatus, 1, 5);
            tableLayoutPanel.Controls.Add(textBoxReservationId, 1, 6);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 43);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 7;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.Size = new Size(650, 333);
            tableLayoutPanel.TabIndex = 1;
            // 
            // labelBook
            // 
            labelBook.AutoSize = true;
            labelBook.Location = new Point(3, 0);
            labelBook.Name = "labelBook";
            labelBook.Size = new Size(34, 15);
            labelBook.TabIndex = 0;
            labelBook.Text = "Book";
            // 
            // labelMember
            // 
            labelMember.AutoSize = true;
            labelMember.Location = new Point(3, 50);
            labelMember.Name = "labelMember";
            labelMember.Size = new Size(52, 15);
            labelMember.TabIndex = 1;
            labelMember.Text = "Member";
            // 
            // labelReservationDate
            // 
            labelReservationDate.AutoSize = true;
            labelReservationDate.Location = new Point(3, 100);
            labelReservationDate.Name = "labelReservationDate";
            labelReservationDate.Size = new Size(95, 15);
            labelReservationDate.TabIndex = 2;
            labelReservationDate.Text = "Reservation Date";
            // 
            // labelHasExpiry
            // 
            labelHasExpiry.AutoSize = true;
            labelHasExpiry.Location = new Point(3, 150);
            labelHasExpiry.Name = "labelHasExpiry";
            labelHasExpiry.Size = new Size(62, 15);
            labelHasExpiry.TabIndex = 3;
            labelHasExpiry.Text = "Has Expiry";
            // 
            // labelExpiryDate
            // 
            labelExpiryDate.AutoSize = true;
            labelExpiryDate.Location = new Point(3, 200);
            labelExpiryDate.Name = "labelExpiryDate";
            labelExpiryDate.Size = new Size(66, 15);
            labelExpiryDate.TabIndex = 4;
            labelExpiryDate.Text = "Expiry Date";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(3, 250);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(39, 15);
            labelStatus.TabIndex = 5;
            labelStatus.Text = "Status";
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(3, 300);
            labelId.Name = "labelId";
            labelId.Size = new Size(17, 15);
            labelId.TabIndex = 6;
            labelId.Text = "Id";
            // 
            // comboBoxBooks
            // 
            comboBoxBooks.Dock = DockStyle.Fill;
            comboBoxBooks.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBooks.FormattingEnabled = true;
            comboBoxBooks.Location = new Point(159, 3);
            comboBoxBooks.Name = "comboBoxBooks";
            comboBoxBooks.Size = new Size(488, 23);
            comboBoxBooks.TabIndex = 7;
            // 
            // comboBoxMembers
            // 
            comboBoxMembers.Dock = DockStyle.Fill;
            comboBoxMembers.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMembers.FormattingEnabled = true;
            comboBoxMembers.Location = new Point(159, 53);
            comboBoxMembers.Name = "comboBoxMembers";
            comboBoxMembers.Size = new Size(488, 23);
            comboBoxMembers.TabIndex = 8;
            // 
            // dateTimePickerReservationDate
            // 
            dateTimePickerReservationDate.Dock = DockStyle.Fill;
            dateTimePickerReservationDate.Location = new Point(159, 103);
            dateTimePickerReservationDate.Name = "dateTimePickerReservationDate";
            dateTimePickerReservationDate.Size = new Size(488, 23);
            dateTimePickerReservationDate.TabIndex = 9;
            // 
            // checkBoxHasExpiry
            // 
            checkBoxHasExpiry.AutoSize = true;
            checkBoxHasExpiry.Location = new Point(159, 153);
            checkBoxHasExpiry.Name = "checkBoxHasExpiry";
            checkBoxHasExpiry.Size = new Size(81, 19);
            checkBoxHasExpiry.TabIndex = 10;
            checkBoxHasExpiry.Text = "Has Expiry";
            checkBoxHasExpiry.UseVisualStyleBackColor = true;
            checkBoxHasExpiry.CheckedChanged += checkBoxHasExpiry_CheckedChanged;
            // 
            // dateTimePickerExpiryDate
            // 
            dateTimePickerExpiryDate.Dock = DockStyle.Fill;
            dateTimePickerExpiryDate.Location = new Point(159, 203);
            dateTimePickerExpiryDate.Name = "dateTimePickerExpiryDate";
            dateTimePickerExpiryDate.Size = new Size(488, 23);
            dateTimePickerExpiryDate.TabIndex = 11;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.Dock = DockStyle.Fill;
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(159, 253);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(488, 23);
            comboBoxStatus.TabIndex = 12;
            // 
            // textBoxReservationId
            // 
            textBoxReservationId.Dock = DockStyle.Fill;
            textBoxReservationId.Location = new Point(159, 303);
            textBoxReservationId.Name = "textBoxReservationId";
            textBoxReservationId.ReadOnly = true;
            textBoxReservationId.Size = new Size(488, 23);
            textBoxReservationId.TabIndex = 13;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Controls.Add(buttonCancel);
            flowLayoutPanel.Controls.Add(buttonSave);
            flowLayoutPanel.Dock = DockStyle.Bottom;
            flowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel.Location = new Point(0, 376);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(650, 62);
            flowLayoutPanel.TabIndex = 2;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(572, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(491, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 438);
            Controls.Add(tableLayoutPanel);
            Controls.Add(flowLayoutPanel);
            Controls.Add(panelReservationDetails);
            Name = "ReservationForm";
            Text = "ReservationForm";
            panelReservationDetails.ResumeLayout(false);
            panelReservationDetails.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelReservationDetails;
        private Label labelReservationDetails;
        private TableLayoutPanel tableLayoutPanel;
        private Label labelBook;
        private Label labelMember;
        private Label labelReservationDate;
        private Label labelHasExpiry;
        private Label labelExpiryDate;
        private Label labelStatus;
        private Label labelId;
        private ComboBox comboBoxBooks;
        private ComboBox comboBoxMembers;
        private DateTimePicker dateTimePickerReservationDate;
        private CheckBox checkBoxHasExpiry;
        private DateTimePicker dateTimePickerExpiryDate;
        private ComboBox comboBoxStatus;
        private TextBox textBoxReservationId;
        private FlowLayoutPanel flowLayoutPanel;
        private Button buttonCancel;
        private Button buttonSave;
    }
}
