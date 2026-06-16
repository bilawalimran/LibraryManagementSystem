namespace App.WindowsApp.Forms
{
    partial class MemberForm
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
            tableLayoutPanel = new TableLayoutPanel();
            labelName = new Label();
            labelEmail = new Label();
            labelPhone = new Label();
            labelAddress = new Label();
            labelId = new Label();
            textBoxName = new TextBox();
            textBoxEmail = new TextBox();
            textBoxMemberId = new TextBox();
            textBoxPhone = new TextBox();
            textBoxAddress = new TextBox();
            flowLayoutPanel = new FlowLayoutPanel();
            buttonCancel = new Button();
            buttonSave = new Button();
            panelBookDetails = new Panel();
            labelMemberDetails = new Label();
            tableLayoutPanel.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            panelBookDetails.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel.Controls.Add(labelName, 0, 0);
            tableLayoutPanel.Controls.Add(labelEmail, 0, 1);
            tableLayoutPanel.Controls.Add(labelPhone, 0, 2);
            tableLayoutPanel.Controls.Add(labelAddress, 0, 3);
            tableLayoutPanel.Controls.Add(labelId, 0, 4);
            tableLayoutPanel.Controls.Add(textBoxName, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxEmail, 1, 1);
            tableLayoutPanel.Controls.Add(textBoxMemberId, 1, 4);
            tableLayoutPanel.Controls.Add(textBoxPhone, 1, 2);
            tableLayoutPanel.Controls.Add(textBoxAddress, 1, 3);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 43);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(599, 266);
            tableLayoutPanel.TabIndex = 5;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(3, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(39, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Name";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(3, 50);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(36, 15);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(3, 100);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(41, 15);
            labelPhone.TabIndex = 2;
            labelPhone.Text = "Phone";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(3, 150);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(49, 15);
            labelAddress.TabIndex = 3;
            labelAddress.Text = "Address";
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(3, 200);
            labelId.Name = "labelId";
            labelId.Size = new Size(17, 15);
            labelId.TabIndex = 5;
            labelId.Text = "Id";
            // 
            // textBoxName
            // 
            textBoxName.Dock = DockStyle.Fill;
            textBoxName.Location = new Point(122, 3);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(474, 23);
            textBoxName.TabIndex = 6;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Dock = DockStyle.Fill;
            textBoxEmail.Location = new Point(122, 53);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(474, 23);
            textBoxEmail.TabIndex = 7;
            // 
            // textBoxMemberId
            // 
            textBoxMemberId.Dock = DockStyle.Fill;
            textBoxMemberId.Location = new Point(122, 203);
            textBoxMemberId.Name = "textBoxMemberId";
            textBoxMemberId.ReadOnly = true;
            textBoxMemberId.Size = new Size(474, 23);
            textBoxMemberId.TabIndex = 11;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Dock = DockStyle.Fill;
            textBoxPhone.Location = new Point(122, 103);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(474, 23);
            textBoxPhone.TabIndex = 12;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Dock = DockStyle.Fill;
            textBoxAddress.Location = new Point(122, 153);
            textBoxAddress.Multiline = true;
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.ScrollBars = ScrollBars.Vertical;
            textBoxAddress.Size = new Size(474, 44);
            textBoxAddress.TabIndex = 13;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Controls.Add(buttonCancel);
            flowLayoutPanel.Controls.Add(buttonSave);
            flowLayoutPanel.Dock = DockStyle.Bottom;
            flowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel.Location = new Point(0, 309);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(599, 62);
            flowLayoutPanel.TabIndex = 4;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(521, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(440, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // panelBookDetails
            // 
            panelBookDetails.Controls.Add(labelMemberDetails);
            panelBookDetails.Dock = DockStyle.Top;
            panelBookDetails.Location = new Point(0, 0);
            panelBookDetails.Name = "panelBookDetails";
            panelBookDetails.Size = new Size(599, 43);
            panelBookDetails.TabIndex = 3;
            // 
            // labelMemberDetails
            // 
            labelMemberDetails.AutoSize = true;
            labelMemberDetails.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMemberDetails.Location = new Point(12, 9);
            labelMemberDetails.Name = "labelMemberDetails";
            labelMemberDetails.Size = new Size(195, 32);
            labelMemberDetails.TabIndex = 0;
            labelMemberDetails.Text = "Member Details";
            // 
            // MemberForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 371);
            Controls.Add(tableLayoutPanel);
            Controls.Add(flowLayoutPanel);
            Controls.Add(panelBookDetails);
            Name = "MemberForm";
            Text = "MemberForm";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
            panelBookDetails.ResumeLayout(false);
            panelBookDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Label labelName;
        private Label labelEmail;
        private Label labelPhone;
        private Label labelAddress;
        private Label labelId;
        private TextBox textBoxName;
        private TextBox textBoxEmail;
        private FlowLayoutPanel flowLayoutPanel;
        private Button buttonCancel;
        private Button buttonSave;
        private Panel panelBookDetails;
        private Label labelMemberDetails;
        private TextBox textBoxMemberId;
        private TextBox textBoxPhone;
        private TextBox textBoxAddress;
    }
}