namespace App.WindowsApp.Views
{
    partial class ReservationView
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            toolStripReservations = new ToolStrip();
            toolStripButtonAdd = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonView = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripSeparator = new ToolStripSeparator();
            toolStripButtonRefresh = new ToolStripButton();
            panelFilters = new Panel();
            tableLayoutPanelFilters = new TableLayoutPanel();
            labelSearch = new Label();
            textBoxSearch = new TextBox();
            dataGridViewReservations = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Book = new DataGridViewTextBoxColumn();
            Member = new DataGridViewTextBoxColumn();
            ReservationDate = new DataGridViewTextBoxColumn();
            ExpiryDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            tableLayoutPanel.SuspendLayout();
            toolStripReservations.SuspendLayout();
            panelFilters.SuspendLayout();
            tableLayoutPanelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReservations).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackColor = Color.White;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(toolStripReservations, 0, 0);
            tableLayoutPanel.Controls.Add(panelFilters, 0, 1);
            tableLayoutPanel.Controls.Add(dataGridViewReservations, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(674, 430);
            tableLayoutPanel.TabIndex = 0;
            // 
            // toolStripReservations
            // 
            toolStripReservations.BackColor = Color.WhiteSmoke;
            toolStripReservations.Dock = DockStyle.Fill;
            toolStripReservations.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonEdit, toolStripButtonView, toolStripButtonDelete, toolStripSeparator, toolStripButtonRefresh });
            toolStripReservations.Location = new Point(0, 0);
            toolStripReservations.Name = "toolStripReservations";
            toolStripReservations.Size = new Size(674, 40);
            toolStripReservations.TabIndex = 0;
            toolStripReservations.Text = "toolStrip";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.Image = Properties.Resources.plus;
            toolStripButtonAdd.ImageTransparentColor = Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new Size(49, 37);
            toolStripButtonAdd.Text = "Add";
            toolStripButtonAdd.ToolTipText = "Add";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
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
            toolStripButtonDelete.Image = Properties.Resources.trash;
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
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
            toolStripButtonRefresh.ToolTipText = "Refresh";
            toolStripButtonRefresh.Click += toolStripButtonRefresh_Click;
            // 
            // panelFilters
            // 
            panelFilters.BackColor = Color.White;
            panelFilters.Controls.Add(tableLayoutPanelFilters);
            panelFilters.Dock = DockStyle.Fill;
            panelFilters.Location = new Point(3, 43);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(668, 63);
            panelFilters.TabIndex = 1;
            // 
            // tableLayoutPanelFilters
            // 
            tableLayoutPanelFilters.ColumnCount = 1;
            tableLayoutPanelFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelFilters.Controls.Add(labelSearch, 0, 0);
            tableLayoutPanelFilters.Controls.Add(textBoxSearch, 0, 1);
            tableLayoutPanelFilters.Dock = DockStyle.Fill;
            tableLayoutPanelFilters.Location = new Point(0, 0);
            tableLayoutPanelFilters.Name = "tableLayoutPanelFilters";
            tableLayoutPanelFilters.RowCount = 2;
            tableLayoutPanelFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelFilters.Size = new Size(668, 63);
            tableLayoutPanelFilters.TabIndex = 0;
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
            textBoxSearch.Location = new Point(3, 34);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(662, 23);
            textBoxSearch.TabIndex = 1;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // dataGridViewReservations
            // 
            dataGridViewReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReservations.BackgroundColor = Color.White;
            dataGridViewReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReservations.Columns.AddRange(new DataGridViewColumn[] { Id, Book, Member, ReservationDate, ExpiryDate, Status });
            dataGridViewReservations.Dock = DockStyle.Fill;
            dataGridViewReservations.Location = new Point(3, 112);
            dataGridViewReservations.MultiSelect = false;
            dataGridViewReservations.Name = "dataGridViewReservations";
            dataGridViewReservations.ReadOnly = true;
            dataGridViewReservations.RowHeadersVisible = false;
            dataGridViewReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReservations.Size = new Size(668, 315);
            dataGridViewReservations.TabIndex = 2;
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
            // ReservationDate
            // 
            ReservationDate.HeaderText = "ReservationDate";
            ReservationDate.Name = "ReservationDate";
            ReservationDate.ReadOnly = true;
            // 
            // ExpiryDate
            // 
            ExpiryDate.HeaderText = "ExpiryDate";
            ExpiryDate.Name = "ExpiryDate";
            ExpiryDate.ReadOnly = true;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // ReservationView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "ReservationView";
            Size = new Size(674, 430);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            toolStripReservations.ResumeLayout(false);
            toolStripReservations.PerformLayout();
            panelFilters.ResumeLayout(false);
            tableLayoutPanelFilters.ResumeLayout(false);
            tableLayoutPanelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReservations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private ToolStrip toolStripReservations;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonView;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton toolStripButtonRefresh;
        private Panel panelFilters;
        private TableLayoutPanel tableLayoutPanelFilters;
        private Label labelSearch;
        private TextBox textBoxSearch;
        private DataGridView dataGridViewReservations;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Book;
        private DataGridViewTextBoxColumn Member;
        private DataGridViewTextBoxColumn ReservationDate;
        private DataGridViewTextBoxColumn ExpiryDate;
        private DataGridViewTextBoxColumn Status;
    }
}
