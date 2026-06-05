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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tableLayoutPanel = new TableLayoutPanel();
            toolStripIssues = new ToolStrip();
            toolStripButtonIssue = new ToolStripButton();
            toolStripButtonReturn = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonView = new ToolStripButton();
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
            Status = new DataGridViewTextBoxColumn();
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
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tableLayoutPanel.Size = new Size(674, 462);
            tableLayoutPanel.TabIndex = 0;
            // 
            // toolStripIssues
            // 
            toolStripIssues.Dock = DockStyle.Fill;
            toolStripIssues.GripStyle = ToolStripGripStyle.Hidden;
            toolStripIssues.Items.AddRange(new ToolStripItem[] { toolStripButtonIssue, toolStripButtonReturn, toolStripButtonEdit, toolStripButtonView, toolStripButtonDelete, toolStripSeparator, toolStripButtonRefresh });
            toolStripIssues.Location = new Point(0, 0);
            toolStripIssues.Name = "toolStripIssues";
            toolStripIssues.RenderMode = ToolStripRenderMode.System;
            toolStripIssues.Size = new Size(674, 40);
            toolStripIssues.TabIndex = 0;
            toolStripIssues.Text = "toolStrip";
            // 
            // toolStripButtonIssue
            // 
            toolStripButtonIssue.Image = Properties.Resources.books_medical;
            toolStripButtonIssue.ImageTransparentColor = Color.Magenta;
            toolStripButtonIssue.Name = "toolStripButtonIssue";
            toolStripButtonIssue.Size = new Size(83, 37);
            toolStripButtonIssue.Text = "Issue Book";
            toolStripButtonIssue.ToolTipText = "Issue";
            toolStripButtonIssue.Click += toolStripButtonIssue_Click;
            // 
            // toolStripButtonReturn
            // 
            toolStripButtonReturn.Image = Properties.Resources.undo;
            toolStripButtonReturn.ImageTransparentColor = Color.Magenta;
            toolStripButtonReturn.Name = "toolStripButtonReturn";
            toolStripButtonReturn.Size = new Size(92, 37);
            toolStripButtonReturn.Text = "Return Book";
            toolStripButtonReturn.ToolTipText = "Return";
            toolStripButtonReturn.Click += toolStripButtonReturn_Click;
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.Image = Properties.Resources.pencil;
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(47, 37);
            toolStripButtonEdit.Text = "Edit";
            toolStripButtonEdit.ToolTipText = "Edit";
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
            // 
            // toolStripButtonView
            // 
            toolStripButtonView.Image = Properties.Resources.eye;
            toolStripButtonView.ImageTransparentColor = Color.Magenta;
            toolStripButtonView.Name = "toolStripButtonView";
            toolStripButtonView.Size = new Size(52, 37);
            toolStripButtonView.Text = "View";
            toolStripButtonView.ToolTipText = "View";
            toolStripButtonView.Click += toolStripButtonView_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.Image = Properties.Resources.trash1;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(60, 37);
            toolStripButtonDelete.Text = "Delete";
            toolStripButtonDelete.ToolTipText = "Delete";
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(6, 40);
            // 
            // toolStripButtonRefresh
            // 
            toolStripButtonRefresh.Image = Properties.Resources.refresh;
            toolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
            toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            toolStripButtonRefresh.Size = new Size(66, 37);
            toolStripButtonRefresh.Text = "Refresh";
            toolStripButtonRefresh.Click += toolStripButtonRefresh_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Controls.Add(labelSearch);
            flowLayoutPanel.Controls.Add(textBoxSearch);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(3, 43);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(668, 63);
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
            dataGridViewIssues.AllowUserToAddRows = false;
            dataGridViewIssues.AllowUserToResizeRows = false;
            dataGridViewIssues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewIssues.BackgroundColor = Color.White;
            dataGridViewIssues.BorderStyle = BorderStyle.None;
            dataGridViewIssues.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewIssues.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewIssues.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewIssues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIssues.Columns.AddRange(new DataGridViewColumn[] { Id, Book, Member, IssueDate, ReturnDate, Status });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridViewIssues.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewIssues.Dock = DockStyle.Fill;
            dataGridViewIssues.EnableHeadersVisualStyles = false;
            dataGridViewIssues.GridColor = Color.White;
            dataGridViewIssues.Location = new Point(3, 112);
            dataGridViewIssues.MultiSelect = false;
            dataGridViewIssues.Name = "dataGridViewIssues";
            dataGridViewIssues.ReadOnly = true;
            dataGridViewIssues.RowHeadersVisible = false;
            dataGridViewIssues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIssues.Size = new Size(668, 347);
            dataGridViewIssues.TabIndex = 2;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Book
            // 
            Book.DataPropertyName = "Book";
            Book.HeaderText = "Book";
            Book.Name = "Book";
            Book.ReadOnly = true;
            // 
            // Member
            // 
            Member.DataPropertyName = "Member";
            Member.HeaderText = "Member";
            Member.Name = "Member";
            Member.ReadOnly = true;
            // 
            // IssueDate
            // 
            IssueDate.DataPropertyName = "IssueDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            IssueDate.DefaultCellStyle = dataGridViewCellStyle2;
            IssueDate.HeaderText = "IssueDate";
            IssueDate.Name = "IssueDate";
            IssueDate.ReadOnly = true;
            // 
            // ReturnDate
            // 
            ReturnDate.DataPropertyName = "ReturnDate";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            ReturnDate.DefaultCellStyle = dataGridViewCellStyle3;
            ReturnDate.HeaderText = "ReturnDate";
            ReturnDate.Name = "ReturnDate";
            ReturnDate.ReadOnly = true;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
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
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonView;
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
        private DataGridViewTextBoxColumn Status;
    }
}