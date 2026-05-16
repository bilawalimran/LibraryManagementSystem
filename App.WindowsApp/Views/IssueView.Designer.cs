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
            tableLayoutPanel = new TableLayoutPanel();
            toolStripIssues = new ToolStrip();
            toolStripButtonIssue = new ToolStripButton();
            toolStripButtonReturn = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripSeparator = new ToolStripSeparator();
            toolStripButtonRefresh = new ToolStripButton();
            flowLayoutPanel = new FlowLayoutPanel();
            labelSearch = new Label();
            textBoxSearch = new TextBox();
            dataGridViewIssues = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Book = new DataGridViewTextBoxColumn();
            Member = new DataGridViewTextBoxColumn();
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
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9.995673F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.2505407F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 78.75379F));
            tableLayoutPanel.Size = new Size(674, 462);
            tableLayoutPanel.TabIndex = 0;
            // 
            // toolStripIssues
            // 
            toolStripIssues.Dock = DockStyle.Fill;
            toolStripIssues.Items.AddRange(new ToolStripItem[] { toolStripButtonIssue, toolStripButtonReturn, toolStripButtonDelete, toolStripSeparator, toolStripButtonRefresh });
            toolStripIssues.Location = new Point(0, 0);
            toolStripIssues.Name = "toolStripIssues";
            toolStripIssues.Size = new Size(674, 46);
            toolStripIssues.TabIndex = 0;
            toolStripIssues.Text = "toolStrip";
            // 
            // toolStripButtonIssue
            // 
            toolStripButtonIssue.Image = Properties.Resources.books_medical;
            toolStripButtonIssue.ImageTransparentColor = Color.Magenta;
            toolStripButtonIssue.Name = "toolStripButtonIssue";
            toolStripButtonIssue.Size = new Size(83, 43);
            toolStripButtonIssue.Text = "Issue Book";
            toolStripButtonIssue.ToolTipText = "Issue";
            toolStripButtonIssue.Click += toolStripButtonIssue_Click;
            // 
            // toolStripButtonReturn
            // 
            toolStripButtonReturn.Image = Properties.Resources.undo;
            toolStripButtonReturn.ImageTransparentColor = Color.Magenta;
            toolStripButtonReturn.Name = "toolStripButtonReturn";
            toolStripButtonReturn.Size = new Size(92, 43);
            toolStripButtonReturn.Text = "Return Book";
            toolStripButtonReturn.ToolTipText = "Return";
            toolStripButtonReturn.Click += toolStripButtonReturn_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.Image = Properties.Resources.trash1;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(60, 43);
            toolStripButtonDelete.Text = "Delete";
            toolStripButtonDelete.ToolTipText = "Delete";
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(6, 46);
            // 
            // toolStripButtonRefresh
            // 
            toolStripButtonRefresh.Image = Properties.Resources.refresh;
            toolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
            toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            toolStripButtonRefresh.Size = new Size(66, 43);
            toolStripButtonRefresh.Text = "Refresh";
            toolStripButtonRefresh.Click += toolStripButtonRefresh_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Controls.Add(labelSearch);
            flowLayoutPanel.Controls.Add(textBoxSearch);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(3, 49);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(668, 45);
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
            dataGridViewIssues.Columns.AddRange(new DataGridViewColumn[] { Id, Book, Member, IssueDate, ReturnDate });
            dataGridViewIssues.Dock = DockStyle.Fill;
            dataGridViewIssues.Location = new Point(3, 100);
            dataGridViewIssues.MultiSelect = false;
            dataGridViewIssues.Name = "dataGridViewIssues";
            dataGridViewIssues.ReadOnly = true;
            dataGridViewIssues.RowHeadersVisible = false;
            dataGridViewIssues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIssues.Size = new Size(668, 359);
            dataGridViewIssues.TabIndex = 2;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Book
            // 
            Book.HeaderText = "Book";
            Book.Name = "Book";
            Book.ReadOnly = true;
            // 
            // Member
            // 
            Member.HeaderText = "Member";
            Member.Name = "Member";
            Member.ReadOnly = true;
            // 
            // IssueDate
            // 
            IssueDate.HeaderText = "IssueDate";
            IssueDate.Name = "IssueDate";
            IssueDate.ReadOnly = true;
            // 
            // ReturnDate
            // 
            ReturnDate.HeaderText = "ReturnDate";
            ReturnDate.Name = "ReturnDate";
            ReturnDate.ReadOnly = true;
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
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonRefresh;
        private ToolStripSeparator toolStripSeparator;
        private FlowLayoutPanel flowLayoutPanel;
        private Label labelSearch;
        private TextBox textBoxSearch;
        private DataGridView dataGridViewIssues;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Book;
        private DataGridViewTextBoxColumn Member;
        private DataGridViewTextBoxColumn IssueDate;
        private DataGridViewTextBoxColumn ReturnDate;
    }
}
