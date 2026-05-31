namespace App.WindowsApp.Views
{
    partial class DashboardView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanelMain = new TableLayoutPanel();
            panelHeader = new Panel();
            buttonRefresh = new Button();
            labelTitle = new Label();
            tableLayoutPanelStats = new TableLayoutPanel();
            panelBooks = new Panel();
            labelBooksCount = new Label();
            labelBooksTitle = new Label();
            panelMembers = new Panel();
            labelMembersCount = new Label();
            labelMembersTitle = new Label();
            panelActiveIssues = new Panel();
            labelActiveIssuesCount = new Label();
            labelActiveIssuesTitle = new Label();
            panelReturned = new Panel();
            labelReturnedCount = new Label();
            labelReturnedTitle = new Label();
            panelReservations = new Panel();
            labelReservationsCount = new Label();
            labelReservationsTitle = new Label();
            panelFooter = new Panel();
            tableLayoutPanelCharts = new TableLayoutPanel();
            panelIssueStatusChart = new Panel();
            panelLibraryTotalsChart = new Panel();
            labelFooter = new Label();
            tableLayoutPanelMain.SuspendLayout();
            panelHeader.SuspendLayout();
            tableLayoutPanelStats.SuspendLayout();
            panelBooks.SuspendLayout();
            panelMembers.SuspendLayout();
            panelActiveIssues.SuspendLayout();
            panelReturned.SuspendLayout();
            panelReservations.SuspendLayout();
            panelFooter.SuspendLayout();
            tableLayoutPanelCharts.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.BackColor = Color.White;
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Controls.Add(panelHeader, 0, 0);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelStats, 0, 1);
            tableLayoutPanelMain.Controls.Add(panelFooter, 0, 2);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.Padding = new Padding(12);
            tableLayoutPanelMain.RowCount = 3;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 78F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 135F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Size = new Size(676, 428);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.WhiteSmoke;
            panelHeader.Controls.Add(buttonRefresh);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.Location = new Point(15, 15);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(646, 72);
            panelHeader.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRefresh.BackColor = Color.RoyalBlue;
            buttonRefresh.FlatStyle = FlatStyle.Flat;
            buttonRefresh.ForeColor = Color.White;
            buttonRefresh.Location = new Point(548, 22);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(83, 28);
            buttonRefresh.TabIndex = 2;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = false;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(16, 10);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(138, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Dashboard";
            // 
            // tableLayoutPanelStats
            // 
            tableLayoutPanelStats.ColumnCount = 5;
            tableLayoutPanelStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelStats.Controls.Add(panelBooks, 0, 0);
            tableLayoutPanelStats.Controls.Add(panelMembers, 1, 0);
            tableLayoutPanelStats.Controls.Add(panelActiveIssues, 2, 0);
            tableLayoutPanelStats.Controls.Add(panelReturned, 3, 0);
            tableLayoutPanelStats.Controls.Add(panelReservations, 4, 0);
            tableLayoutPanelStats.Dock = DockStyle.Fill;
            tableLayoutPanelStats.Location = new Point(15, 93);
            tableLayoutPanelStats.Name = "tableLayoutPanelStats";
            tableLayoutPanelStats.RowCount = 1;
            tableLayoutPanelStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelStats.Size = new Size(646, 129);
            tableLayoutPanelStats.TabIndex = 1;
            // 
            // panelBooks
            // 
            panelBooks.BackColor = Color.AliceBlue;
            panelBooks.BorderStyle = BorderStyle.FixedSingle;
            panelBooks.Controls.Add(labelBooksCount);
            panelBooks.Controls.Add(labelBooksTitle);
            panelBooks.Dock = DockStyle.Fill;
            panelBooks.Location = new Point(3, 3);
            panelBooks.Name = "panelBooks";
            panelBooks.Size = new Size(123, 123);
            panelBooks.TabIndex = 0;
            // 
            // labelBooksCount
            // 
            labelBooksCount.AutoSize = true;
            labelBooksCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBooksCount.Location = new Point(14, 41);
            labelBooksCount.Name = "labelBooksCount";
            labelBooksCount.Size = new Size(38, 45);
            labelBooksCount.TabIndex = 1;
            labelBooksCount.Text = "0";
            // 
            // labelBooksTitle
            // 
            labelBooksTitle.AutoSize = true;
            labelBooksTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBooksTitle.Location = new Point(16, 17);
            labelBooksTitle.Name = "labelBooksTitle";
            labelBooksTitle.Size = new Size(87, 19);
            labelBooksTitle.TabIndex = 0;
            labelBooksTitle.Text = "Total Books";
            // 
            // panelMembers
            // 
            panelMembers.BackColor = Color.Honeydew;
            panelMembers.BorderStyle = BorderStyle.FixedSingle;
            panelMembers.Controls.Add(labelMembersCount);
            panelMembers.Controls.Add(labelMembersTitle);
            panelMembers.Dock = DockStyle.Fill;
            panelMembers.Location = new Point(132, 3);
            panelMembers.Name = "panelMembers";
            panelMembers.Size = new Size(123, 123);
            panelMembers.TabIndex = 1;
            // 
            // labelMembersCount
            // 
            labelMembersCount.AutoSize = true;
            labelMembersCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMembersCount.Location = new Point(14, 41);
            labelMembersCount.Name = "labelMembersCount";
            labelMembersCount.Size = new Size(38, 45);
            labelMembersCount.TabIndex = 1;
            labelMembersCount.Text = "0";
            // 
            // labelMembersTitle
            // 
            labelMembersTitle.AutoSize = true;
            labelMembersTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMembersTitle.Location = new Point(16, 17);
            labelMembersTitle.Name = "labelMembersTitle";
            labelMembersTitle.Size = new Size(72, 19);
            labelMembersTitle.TabIndex = 0;
            labelMembersTitle.Text = "Members";
            // 
            // panelActiveIssues
            // 
            panelActiveIssues.BackColor = Color.LemonChiffon;
            panelActiveIssues.BorderStyle = BorderStyle.FixedSingle;
            panelActiveIssues.Controls.Add(labelActiveIssuesCount);
            panelActiveIssues.Controls.Add(labelActiveIssuesTitle);
            panelActiveIssues.Dock = DockStyle.Fill;
            panelActiveIssues.Location = new Point(261, 3);
            panelActiveIssues.Name = "panelActiveIssues";
            panelActiveIssues.Size = new Size(123, 123);
            panelActiveIssues.TabIndex = 2;
            // 
            // labelActiveIssuesCount
            // 
            labelActiveIssuesCount.AutoSize = true;
            labelActiveIssuesCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelActiveIssuesCount.Location = new Point(14, 41);
            labelActiveIssuesCount.Name = "labelActiveIssuesCount";
            labelActiveIssuesCount.Size = new Size(38, 45);
            labelActiveIssuesCount.TabIndex = 1;
            labelActiveIssuesCount.Text = "0";
            // 
            // labelActiveIssuesTitle
            // 
            labelActiveIssuesTitle.AutoSize = true;
            labelActiveIssuesTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelActiveIssuesTitle.Location = new Point(16, 17);
            labelActiveIssuesTitle.Name = "labelActiveIssuesTitle";
            labelActiveIssuesTitle.Size = new Size(93, 19);
            labelActiveIssuesTitle.TabIndex = 0;
            labelActiveIssuesTitle.Text = "Active Issues";
            // 
            // panelReturned
            // 
            panelReturned.BackColor = Color.MistyRose;
            panelReturned.BorderStyle = BorderStyle.FixedSingle;
            panelReturned.Controls.Add(labelReturnedCount);
            panelReturned.Controls.Add(labelReturnedTitle);
            panelReturned.Dock = DockStyle.Fill;
            panelReturned.Location = new Point(390, 3);
            panelReturned.Name = "panelReturned";
            panelReturned.Size = new Size(123, 123);
            panelReturned.TabIndex = 3;
            // 
            // labelReturnedCount
            // 
            labelReturnedCount.AutoSize = true;
            labelReturnedCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelReturnedCount.Location = new Point(14, 41);
            labelReturnedCount.Name = "labelReturnedCount";
            labelReturnedCount.Size = new Size(38, 45);
            labelReturnedCount.TabIndex = 1;
            labelReturnedCount.Text = "0";
            // 
            // labelReturnedTitle
            // 
            labelReturnedTitle.AutoSize = true;
            labelReturnedTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelReturnedTitle.Location = new Point(16, 17);
            labelReturnedTitle.Name = "labelReturnedTitle";
            labelReturnedTitle.Size = new Size(70, 19);
            labelReturnedTitle.TabIndex = 0;
            labelReturnedTitle.Text = "Returned";
            // 
            // panelReservations
            // 
            panelReservations.BackColor = Color.Azure;
            panelReservations.BorderStyle = BorderStyle.FixedSingle;
            panelReservations.Controls.Add(labelReservationsCount);
            panelReservations.Controls.Add(labelReservationsTitle);
            panelReservations.Dock = DockStyle.Fill;
            panelReservations.Location = new Point(519, 3);
            panelReservations.Name = "panelReservations";
            panelReservations.Size = new Size(124, 123);
            panelReservations.TabIndex = 4;
            // 
            // labelReservationsCount
            // 
            labelReservationsCount.AutoSize = true;
            labelReservationsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelReservationsCount.Location = new Point(14, 41);
            labelReservationsCount.Name = "labelReservationsCount";
            labelReservationsCount.Size = new Size(38, 45);
            labelReservationsCount.TabIndex = 1;
            labelReservationsCount.Text = "0";
            // 
            // labelReservationsTitle
            // 
            labelReservationsTitle.AutoSize = true;
            labelReservationsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelReservationsTitle.Location = new Point(16, 17);
            labelReservationsTitle.Name = "labelReservationsTitle";
            labelReservationsTitle.Size = new Size(95, 19);
            labelReservationsTitle.TabIndex = 0;
            labelReservationsTitle.Text = "Reservations";
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(tableLayoutPanelCharts);
            panelFooter.Controls.Add(labelFooter);
            panelFooter.Dock = DockStyle.Fill;
            panelFooter.Location = new Point(15, 228);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(646, 185);
            panelFooter.TabIndex = 2;
            // 
            // tableLayoutPanelCharts
            // 
            tableLayoutPanelCharts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelCharts.ColumnCount = 2;
            tableLayoutPanelCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelCharts.Controls.Add(panelIssueStatusChart, 0, 0);
            tableLayoutPanelCharts.Controls.Add(panelLibraryTotalsChart, 1, 0);
            tableLayoutPanelCharts.Location = new Point(4, 45);
            tableLayoutPanelCharts.Name = "tableLayoutPanelCharts";
            tableLayoutPanelCharts.RowCount = 1;
            tableLayoutPanelCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelCharts.Size = new Size(638, 128);
            tableLayoutPanelCharts.TabIndex = 1;
            // 
            // panelIssueStatusChart
            // 
            panelIssueStatusChart.BackColor = Color.White;
            panelIssueStatusChart.BorderStyle = BorderStyle.FixedSingle;
            panelIssueStatusChart.Dock = DockStyle.Fill;
            panelIssueStatusChart.Location = new Point(3, 3);
            panelIssueStatusChart.Name = "panelIssueStatusChart";
            panelIssueStatusChart.Size = new Size(313, 122);
            panelIssueStatusChart.TabIndex = 0;
            panelIssueStatusChart.Paint += panelIssueStatusChart_Paint;
            // 
            // panelLibraryTotalsChart
            // 
            panelLibraryTotalsChart.BackColor = Color.White;
            panelLibraryTotalsChart.BorderStyle = BorderStyle.FixedSingle;
            panelLibraryTotalsChart.Dock = DockStyle.Fill;
            panelLibraryTotalsChart.Location = new Point(322, 3);
            panelLibraryTotalsChart.Name = "panelLibraryTotalsChart";
            panelLibraryTotalsChart.Size = new Size(313, 122);
            panelLibraryTotalsChart.TabIndex = 1;
            panelLibraryTotalsChart.Paint += panelLibraryTotalsChart_Paint;
            // 
            // labelFooter
            // 
            labelFooter.AutoSize = true;
            labelFooter.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFooter.ForeColor = Color.DimGray;
            labelFooter.Location = new Point(4, 12);
            labelFooter.Name = "labelFooter";
            labelFooter.Size = new Size(221, 20);
            labelFooter.TabIndex = 0;
            labelFooter.Text = "Library activity at a quick glance";
            // 
            // DashboardView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelMain);
            Name = "DashboardView";
            Size = new Size(676, 428);
            tableLayoutPanelMain.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tableLayoutPanelStats.ResumeLayout(false);
            panelBooks.ResumeLayout(false);
            panelBooks.PerformLayout();
            panelMembers.ResumeLayout(false);
            panelMembers.PerformLayout();
            panelActiveIssues.ResumeLayout(false);
            panelActiveIssues.PerformLayout();
            panelReturned.ResumeLayout(false);
            panelReturned.PerformLayout();
            panelReservations.ResumeLayout(false);
            panelReservations.PerformLayout();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            tableLayoutPanelCharts.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private Panel panelHeader;
        private Button buttonRefresh;
        private Label labelTitle;
        private TableLayoutPanel tableLayoutPanelStats;
        private Panel panelBooks;
        private Label labelBooksCount;
        private Label labelBooksTitle;
        private Panel panelMembers;
        private Label labelMembersCount;
        private Label labelMembersTitle;
        private Panel panelActiveIssues;
        private Label labelActiveIssuesCount;
        private Label labelActiveIssuesTitle;
        private Panel panelReturned;
        private Label labelReturnedCount;
        private Label labelReturnedTitle;
        private Panel panelReservations;
        private Label labelReservationsCount;
        private Label labelReservationsTitle;
        private Panel panelFooter;
        private Label labelFooter;
        private TableLayoutPanel tableLayoutPanelCharts;
        private Panel panelIssueStatusChart;
        private Panel panelLibraryTotalsChart;
    }
}
