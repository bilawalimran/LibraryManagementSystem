namespace App.WindowsApp.Forms
{
    partial class IssueForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelBook = new Label();
            labelMember = new Label();
            labelIssueDate = new Label();
            labelReturnDate = new Label();
            labelId = new Label();
            textBoxId = new TextBox();
            buttonCancel = new Button();
            buttonSave = new Button();
            flowLayoutPanel = new FlowLayoutPanel();
            labelIssueDetails = new Label();
            tableLayoutPanel = new TableLayoutPanel();
            labelStatus = new Label();
            textBoxStatus = new TextBox();
            comboBoxBooks = new ComboBox();
            comboBoxMembers = new ComboBox();
            dateTimePickerIssueDate = new DateTimePicker();
            dateTimePickerReturnDate = new DateTimePicker();
            panelIssueDetails = new Panel();
            flowLayoutPanel.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelIssueDetails.SuspendLayout();
            SuspendLayout();
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
            // labelIssueDate
            // 
            labelIssueDate.AutoSize = true;
            labelIssueDate.Location = new Point(3, 100);
            labelIssueDate.Name = "labelIssueDate";
            labelIssueDate.Size = new Size(60, 15);
            labelIssueDate.TabIndex = 2;
            labelIssueDate.Text = "Issue Date";
            // 
            // labelReturnDate
            // 
            labelReturnDate.AutoSize = true;
            labelReturnDate.Location = new Point(3, 150);
            labelReturnDate.Name = "labelReturnDate";
            labelReturnDate.Size = new Size(69, 15);
            labelReturnDate.TabIndex = 4;
            labelReturnDate.Text = "Return Date";
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(3, 250);
            labelId.Name = "labelId";
            labelId.Size = new Size(17, 15);
            labelId.TabIndex = 5;
            labelId.Text = "Id";
            // 
            // textBoxId
            // 
            textBoxId.Dock = DockStyle.Fill;
            textBoxId.Location = new Point(128, 253);
            textBoxId.Name = "textBoxId";
            textBoxId.ReadOnly = true;
            textBoxId.Size = new Size(494, 23);
            textBoxId.TabIndex = 11;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(547, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(466, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Controls.Add(buttonCancel);
            flowLayoutPanel.Controls.Add(buttonSave);
            flowLayoutPanel.Dock = DockStyle.Bottom;
            flowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel.Location = new Point(0, 358);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(625, 62);
            flowLayoutPanel.TabIndex = 4;
            // 
            // labelIssueDetails
            // 
            labelIssueDetails.AutoSize = true;
            labelIssueDetails.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelIssueDetails.Location = new Point(12, 9);
            labelIssueDetails.Name = "labelIssueDetails";
            labelIssueDetails.Size = new Size(157, 32);
            labelIssueDetails.TabIndex = 0;
            labelIssueDetails.Text = "Issue Details";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel.Controls.Add(labelBook, 0, 0);
            tableLayoutPanel.Controls.Add(labelMember, 0, 1);
            tableLayoutPanel.Controls.Add(labelIssueDate, 0, 2);
            tableLayoutPanel.Controls.Add(labelReturnDate, 0, 3);
            tableLayoutPanel.Controls.Add(labelStatus, 0, 4);
            tableLayoutPanel.Controls.Add(textBoxStatus, 1, 4);
            tableLayoutPanel.Controls.Add(labelId, 0, 5);
            tableLayoutPanel.Controls.Add(textBoxId, 1, 5);
            tableLayoutPanel.Controls.Add(comboBoxBooks, 1, 0);
            tableLayoutPanel.Controls.Add(comboBoxMembers, 1, 1);
            tableLayoutPanel.Controls.Add(dateTimePickerIssueDate, 1, 2);
            tableLayoutPanel.Controls.Add(dateTimePickerReturnDate, 1, 3);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 43);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 6;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.Size = new Size(625, 377);
            tableLayoutPanel.TabIndex = 5;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(3, 200);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(39, 15);
            labelStatus.TabIndex = 6;
            labelStatus.Text = "Status";
            // 
            // textBoxStatus
            // 
            textBoxStatus.Dock = DockStyle.Fill;
            textBoxStatus.Location = new Point(128, 203);
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.ReadOnly = true;
            textBoxStatus.Size = new Size(494, 23);
            textBoxStatus.TabIndex = 17;
            // 
            // comboBoxBooks
            // 
            comboBoxBooks.Dock = DockStyle.Fill;
            comboBoxBooks.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBooks.FormattingEnabled = true;
            comboBoxBooks.Location = new Point(128, 3);
            comboBoxBooks.Name = "comboBoxBooks";
            comboBoxBooks.Size = new Size(494, 23);
            comboBoxBooks.TabIndex = 12;
            // 
            // comboBoxMembers
            // 
            comboBoxMembers.Dock = DockStyle.Fill;
            comboBoxMembers.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMembers.FormattingEnabled = true;
            comboBoxMembers.Location = new Point(128, 53);
            comboBoxMembers.Name = "comboBoxMembers";
            comboBoxMembers.Size = new Size(494, 23);
            comboBoxMembers.TabIndex = 13;
            // 
            // dateTimePickerIssueDate
            // 
            dateTimePickerIssueDate.Dock = DockStyle.Fill;
            dateTimePickerIssueDate.Location = new Point(128, 103);
            dateTimePickerIssueDate.Name = "dateTimePickerIssueDate";
            dateTimePickerIssueDate.Size = new Size(494, 23);
            dateTimePickerIssueDate.TabIndex = 14;
            // 
            // dateTimePickerReturnDate
            // 
            dateTimePickerReturnDate.Dock = DockStyle.Fill;
            dateTimePickerReturnDate.Location = new Point(128, 153);
            dateTimePickerReturnDate.Name = "dateTimePickerReturnDate";
            dateTimePickerReturnDate.Size = new Size(494, 23);
            dateTimePickerReturnDate.TabIndex = 16;
            // 
            // panelIssueDetails
            // 
            panelIssueDetails.Controls.Add(labelIssueDetails);
            panelIssueDetails.Dock = DockStyle.Top;
            panelIssueDetails.Location = new Point(0, 0);
            panelIssueDetails.Name = "panelIssueDetails";
            panelIssueDetails.Size = new Size(625, 43);
            panelIssueDetails.TabIndex = 3;
            // 
            // IssueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 420);
            Controls.Add(flowLayoutPanel);
            Controls.Add(tableLayoutPanel);
            Controls.Add(panelIssueDetails);
            Name = "IssueForm";
            Text = "IssueForm";
            flowLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            panelIssueDetails.ResumeLayout(false);
            panelIssueDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelBook;
        private Label labelMember;
        private Label labelIssueDate;
        private Label labelReturnDate;
        private Label labelId;
        private TextBox textBoxId;
        private Label labelStatus;
        private TextBox textBoxStatus;
        private Button buttonCancel;
        private Button buttonSave;
        private FlowLayoutPanel flowLayoutPanel;
        private Label labelIssueDetails;
        private TableLayoutPanel tableLayoutPanel;
        private Panel panelIssueDetails;
        private ComboBox comboBoxBooks;
        private ComboBox comboBoxMembers;
        private DateTimePicker dateTimePickerIssueDate;
        private DateTimePicker dateTimePickerReturnDate;
    }
}