namespace App.WindowsApp.Views
{
    partial class IssueView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueView));
            tableLayoutPanel = new TableLayoutPanel();
            toolStripIssues = new ToolStrip();
            toolStripButtonIssue = new ToolStripButton();
            toolStripButtonReturn = new ToolStripButton();
            toolStripButtonRefresh = new ToolStripButton();
            toolStripSeparator = new ToolStripSeparator();
            flowLayoutPanel = new FlowLayoutPanel();
            labelSearch = new Label();
            textBoxSearch = new TextBox();
            dataGridViewIssues = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            BookId = new DataGridViewTextBoxColumn();
            MemberId = new DataGridViewTextBoxColumn();
            IssueDate = new DataGridViewTextBoxColumn();
            ReturnDate = new DataGridViewTextBoxColumn();
            tableLayoutPanel.SuspendLayout();
            toolStripIssues.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIssues).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(toolStripIssues, 0, 0);
            tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 1);
            tableLayoutPanel.Controls.Add(dataGridViewIssues, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel.Size = new Size(674, 462);
            tableLayoutPanel.TabIndex = 0;
            // 
            // toolStripIssues
            // 
            toolStripIssues.Dock = DockStyle.Fill;
            toolStripIssues.Items.AddRange(new ToolStripItem[] { toolStripButtonIssue, toolStripButtonReturn, toolStripSeparator, toolStripButtonRefresh });
            toolStripIssues.Location = new Point(0, 0);
            toolStripIssues.Name = "toolStripIssues";
            toolStripIssues.Size = new Size(674, 46);
            toolStripIssues.TabIndex = 0;
            toolStripIssues.Text = "toolStrip";
            // 
            // toolStripButtonIssue
            // 
            toolStripButtonIssue.Image = (Image)resources.GetObject("toolStripButtonIssue.Image");
            toolStripButtonIssue.ImageTransparentColor = Color.Magenta;
            toolStripButtonIssue.Name = "toolStripButtonIssue";
            toolStripButtonIssue.Size = new Size(83, 43);
            toolStripButtonIssue.Text = "Issue Book";
            toolStripButtonIssue.ToolTipText = "Issue";
            toolStripButtonIssue.Click += toolStripButtonIssue_Click;
            // 
            // toolStripButtonReturn
            // 
            toolStripButtonReturn.Image = (Image)resources.GetObject("toolStripButtonReturn.Image");
            toolStripButtonReturn.ImageTransparentColor = Color.Magenta;
            toolStripButtonReturn.Name = "toolStripButtonReturn";
            toolStripButtonReturn.Size = new Size(92, 43);
            toolStripButtonReturn.Text = "Return Book";
            toolStripButtonReturn.ToolTipText = "Return";
            toolStripButtonReturn.Click += toolStripButtonReturn_Click;
            // 
            // toolStripButtonRefresh
            // 
            toolStripButtonRefresh.Image = (Image)resources.GetObject("toolStripButtonRefresh.Image");
            toolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
            toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            toolStripButtonRefresh.Size = new Size(66, 43);
            toolStripButtonRefresh.Text = "Refresh";
            toolStripButtonRefresh.Click += toolStripButtonRefresh_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(6, 46);
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Controls.Add(labelSearch);
            flowLayoutPanel.Controls.Add(textBoxSearch);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(3, 49);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(668, 86);
            flowLayoutPanel.TabIndex = 1;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(3, 0);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(42, 15);
            labelSearch.TabIndex = 0;
            labelSearch.Text = "Search";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Dock = DockStyle.Fill;
            textBoxSearch.Location = new Point(3, 18);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(665, 23);
            textBoxSearch.TabIndex = 1;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // dataGridViewIssues
            // 
            dataGridViewIssues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewIssues.BackgroundColor = Color.White;
            dataGridViewIssues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIssues.Columns.AddRange(new DataGridViewColumn[] { Id, BookId, MemberId, IssueDate, ReturnDate });
            dataGridViewIssues.Dock = DockStyle.Fill;
            dataGridViewIssues.Location = new Point(3, 141);
            dataGridViewIssues.MultiSelect = false;
            dataGridViewIssues.Name = "dataGridViewIssues";
            dataGridViewIssues.ReadOnly = true;
            dataGridViewIssues.RowHeadersVisible = false;
            dataGridViewIssues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIssues.Size = new Size(668, 318);
            dataGridViewIssues.TabIndex = 2;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            // 
            // BookId
            // 
            BookId.HeaderText = "BookId";
            BookId.Name = "BookId";
            // 
            // MemberId
            // 
            MemberId.HeaderText = "MemberId";
            MemberId.Name = "MemberId";
            // 
            // IssueDate
            // 
            IssueDate.HeaderText = "IssueDate";
            IssueDate.Name = "IssueDate";
            // 
            // ReturnDate
            // 
            ReturnDate.HeaderText = "ReturnDate";
            ReturnDate.Name = "ReturnDate";
            // 
            // IssueView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "IssueView";
            Size = new Size(674, 462);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            toolStripIssues.ResumeLayout(false);
            toolStripIssues.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIssues).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private ToolStrip toolStripIssues;
        private ToolStripButton toolStripButtonIssue;
        private ToolStripButton toolStripButtonReturn;
        private ToolStripButton toolStripButtonRefresh;
        private ToolStripSeparator toolStripSeparator;
        private FlowLayoutPanel flowLayoutPanel;
        private Label labelSearch;
        private TextBox textBoxSearch;
        private DataGridView dataGridViewIssues;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn BookId;
        private DataGridViewTextBoxColumn MemberId;
        private DataGridViewTextBoxColumn IssueDate;
        private DataGridViewTextBoxColumn ReturnDate;
    }
}
