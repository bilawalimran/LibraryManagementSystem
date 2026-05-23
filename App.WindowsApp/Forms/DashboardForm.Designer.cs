namespace App.WindowsApp.Forms
{
    partial class DashboardForm
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
            panelHeader = new Panel();
            pictureBoxLogo = new PictureBox();
            labelHeader = new Label();
            panelContent = new Panel();
            panelNavigation = new Panel();
            buttonReservations = new Button();
            buttonIssueReturn = new Button();
            buttonMembers = new Button();
            buttonBooks = new Button();
            buttonDashboard = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelNavigation.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(pictureBoxLogo);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(784, 61);
            panelHeader.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = SystemColors.Control;
            pictureBoxLogo.BackgroundImageLayout = ImageLayout.None;
            pictureBoxLogo.Image = Properties.Resources.icons8_homework_30;
            pictureBoxLogo.Location = new Point(12, 12);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(32, 32);
            pictureBoxLogo.TabIndex = 1;
            pictureBoxLogo.TabStop = false;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Script MT Bold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHeader.Location = new Point(50, 11);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(132, 33);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "BookVerse";
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(123, 61);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(661, 400);
            panelContent.TabIndex = 2;
            // 
            // panelNavigation
            // 
            panelNavigation.Controls.Add(buttonReservations);
            panelNavigation.Controls.Add(buttonIssueReturn);
            panelNavigation.Controls.Add(buttonMembers);
            panelNavigation.Controls.Add(buttonBooks);
            panelNavigation.Controls.Add(buttonDashboard);
            panelNavigation.Dock = DockStyle.Left;
            panelNavigation.Location = new Point(0, 61);
            panelNavigation.Name = "panelNavigation";
            panelNavigation.Size = new Size(123, 400);
            panelNavigation.TabIndex = 1;
            // 
            // buttonReservations
            // 
            buttonReservations.BackColor = Color.DarkSlateGray;
            buttonReservations.FlatStyle = FlatStyle.Flat;
            buttonReservations.ForeColor = SystemColors.Control;
            buttonReservations.Image = Properties.Resources.icons8_today_30;
            buttonReservations.ImageAlign = ContentAlignment.MiddleLeft;
            buttonReservations.Location = new Point(6, 166);
            buttonReservations.Name = "buttonReservations";
            buttonReservations.Size = new Size(114, 40);
            buttonReservations.TabIndex = 2;
            buttonReservations.Text = "Reservations";
            buttonReservations.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonReservations.UseVisualStyleBackColor = false;
            buttonReservations.Click += buttonReservations_Click;
            // 
            // buttonIssueReturn
            // 
            buttonIssueReturn.BackColor = Color.DarkSlateGray;
            buttonIssueReturn.FlatStyle = FlatStyle.Flat;
            buttonIssueReturn.ForeColor = SystemColors.Control;
            buttonIssueReturn.Image = Properties.Resources.icons8_book_30;
            buttonIssueReturn.ImageAlign = ContentAlignment.MiddleLeft;
            buttonIssueReturn.Location = new Point(6, 126);
            buttonIssueReturn.Name = "buttonIssueReturn";
            buttonIssueReturn.Size = new Size(114, 40);
            buttonIssueReturn.TabIndex = 1;
            buttonIssueReturn.Text = "Issue/Return";
            buttonIssueReturn.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonIssueReturn.UseVisualStyleBackColor = false;
            buttonIssueReturn.Click += buttonIssueReturn_Click;
            // 
            // buttonMembers
            // 
            buttonMembers.BackColor = Color.DarkSlateGray;
            buttonMembers.FlatStyle = FlatStyle.Flat;
            buttonMembers.ForeColor = SystemColors.Control;
            buttonMembers.Image = Properties.Resources.icons8_people_30;
            buttonMembers.ImageAlign = ContentAlignment.MiddleLeft;
            buttonMembers.Location = new Point(6, 86);
            buttonMembers.Name = "buttonMembers";
            buttonMembers.Size = new Size(114, 40);
            buttonMembers.TabIndex = 1;
            buttonMembers.Text = "Members";
            buttonMembers.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonMembers.UseVisualStyleBackColor = false;
            buttonMembers.Click += buttonMembers_Click;
            // 
            // buttonBooks
            // 
            buttonBooks.BackColor = Color.DarkSlateGray;
            buttonBooks.FlatStyle = FlatStyle.Flat;
            buttonBooks.ForeColor = SystemColors.Control;
            buttonBooks.Image = Properties.Resources.icons8_books_30__1_;
            buttonBooks.ImageAlign = ContentAlignment.MiddleLeft;
            buttonBooks.Location = new Point(6, 46);
            buttonBooks.Name = "buttonBooks";
            buttonBooks.Size = new Size(114, 40);
            buttonBooks.TabIndex = 1;
            buttonBooks.Text = "Books";
            buttonBooks.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonBooks.UseVisualStyleBackColor = false;
            buttonBooks.Click += buttonBooks_Click;
            // 
            // buttonDashboard
            // 
            buttonDashboard.BackColor = Color.DarkSlateGray;
            buttonDashboard.FlatStyle = FlatStyle.Flat;
            buttonDashboard.ForeColor = SystemColors.Control;
            buttonDashboard.Image = Properties.Resources.icons8_home_30;
            buttonDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDashboard.Location = new Point(6, 6);
            buttonDashboard.Name = "buttonDashboard";
            buttonDashboard.Size = new Size(114, 40);
            buttonDashboard.TabIndex = 0;
            buttonDashboard.Text = "Dashboard";
            buttonDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDashboard.UseVisualStyleBackColor = false;
            buttonDashboard.Click += buttonDashboard_Click;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(panelContent);
            Controls.Add(panelNavigation);
            Controls.Add(panelHeader);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Management System";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelNavigation.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Panel panelContent;
        private Label labelHeader;
        private Panel panelNavigation;
        private Button buttonDashboard;
        private Button buttonIssueReturn;
        private Button buttonMembers;
        private Button buttonBooks;
        private Button buttonReservations;
        private PictureBox pictureBoxLogo;
    }
}
