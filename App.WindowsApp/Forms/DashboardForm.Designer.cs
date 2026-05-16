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
            labelHeader = new Label();
            panelContent = new Panel();
            panelNavigation = new Panel();
            buttonIssueReturn = new Button();
            buttonMembers = new Button();
            buttonBooks = new Button();
            buttonDashboard = new Button();
            panelHeader.SuspendLayout();
            panelNavigation.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(784, 61);
            panelHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHeader.Location = new Point(237, 9);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(340, 32);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Library Management System";
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(118, 61);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(666, 400);
            panelContent.TabIndex = 2;
            // 
            // panelNavigation
            // 
            panelNavigation.Controls.Add(buttonIssueReturn);
            panelNavigation.Controls.Add(buttonMembers);
            panelNavigation.Controls.Add(buttonBooks);
            panelNavigation.Controls.Add(buttonDashboard);
            panelNavigation.Dock = DockStyle.Left;
            panelNavigation.Location = new Point(0, 61);
            panelNavigation.Name = "panelNavigation";
            panelNavigation.Size = new Size(118, 400);
            panelNavigation.TabIndex = 1;
            // 
            // buttonIssueReturn
            // 
            buttonIssueReturn.BackColor = Color.Blue;
            buttonIssueReturn.FlatStyle = FlatStyle.Flat;
            buttonIssueReturn.ForeColor = SystemColors.Control;
            buttonIssueReturn.Location = new Point(6, 126);
            buttonIssueReturn.Name = "buttonIssueReturn";
            buttonIssueReturn.Size = new Size(106, 34);
            buttonIssueReturn.TabIndex = 1;
            buttonIssueReturn.Text = "Issue/Return";
            buttonIssueReturn.UseVisualStyleBackColor = false;
            buttonIssueReturn.Click += buttonIssueReturn_Click;
            // 
            // buttonMembers
            // 
            buttonMembers.BackColor = Color.Blue;
            buttonMembers.FlatStyle = FlatStyle.Flat;
            buttonMembers.ForeColor = SystemColors.Control;
            buttonMembers.Location = new Point(6, 86);
            buttonMembers.Name = "buttonMembers";
            buttonMembers.Size = new Size(106, 34);
            buttonMembers.TabIndex = 1;
            buttonMembers.Text = "Members";
            buttonMembers.UseVisualStyleBackColor = false;
            buttonMembers.Click += buttonMembers_Click;
            // 
            // buttonBooks
            // 
            buttonBooks.BackColor = Color.Blue;
            buttonBooks.FlatStyle = FlatStyle.Flat;
            buttonBooks.ForeColor = SystemColors.Control;
            buttonBooks.Location = new Point(6, 46);
            buttonBooks.Name = "buttonBooks";
            buttonBooks.Size = new Size(106, 34);
            buttonBooks.TabIndex = 1;
            buttonBooks.Text = "Books";
            buttonBooks.UseVisualStyleBackColor = false;
            buttonBooks.Click += buttonBooks_Click;
            // 
            // buttonDashboard
            // 
            buttonDashboard.BackColor = Color.Blue;
            buttonDashboard.FlatStyle = FlatStyle.Flat;
            buttonDashboard.ForeColor = SystemColors.Control;
            buttonDashboard.Location = new Point(6, 6);
            buttonDashboard.Name = "buttonDashboard";
            buttonDashboard.Size = new Size(106, 34);
            buttonDashboard.TabIndex = 0;
            buttonDashboard.Text = "Dashboard";
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
            Text = "DashboardForm";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
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
    }
}
