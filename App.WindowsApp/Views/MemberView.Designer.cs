namespace App.WindowsApp.Views
{
    partial class MemberView
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayoutPanel = new TableLayoutPanel();
            toolStripMembers = new ToolStrip();
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
            dataGridViewMembers = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            MemberName = new DataGridViewTextBoxColumn();
            Phone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            tableLayoutPanel.SuspendLayout();
            toolStripMembers.SuspendLayout();
            panelFilters.SuspendLayout();
            tableLayoutPanelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMembers).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackColor = Color.White;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(toolStripMembers, 0, 0);
            tableLayoutPanel.Controls.Add(panelFilters, 0, 1);
            tableLayoutPanel.Controls.Add(dataGridViewMembers, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tableLayoutPanel.Size = new Size(676, 428);
            tableLayoutPanel.TabIndex = 1;
            // 
            // toolStripMembers
            // 
            toolStripMembers.BackColor = Color.WhiteSmoke;
            toolStripMembers.Dock = DockStyle.Fill;
            toolStripMembers.GripStyle = ToolStripGripStyle.Hidden;
            toolStripMembers.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonEdit, toolStripButtonView, toolStripButtonDelete, toolStripSeparator, toolStripButtonRefresh });
            toolStripMembers.Location = new Point(0, 0);
            toolStripMembers.Name = "toolStripMembers";
            toolStripMembers.RenderMode = ToolStripRenderMode.System;
            toolStripMembers.Size = new Size(676, 40);
            toolStripMembers.TabIndex = 0;
            toolStripMembers.Text = "toolStrip";
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
            toolStripButtonView.Click += toolStripButtonView_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.Image = Properties.Resources.trash;
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(60, 37);
            toolStripButtonDelete.Text = "Delete";
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
            panelFilters.Size = new Size(670, 63);
            panelFilters.TabIndex = 1;
            // 
            // tableLayoutPanelFilters
            // 
            tableLayoutPanelFilters.ColumnCount = 1;
            tableLayoutPanelFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelFilters.Controls.Add(labelSearch, 0, 0);
            tableLayoutPanelFilters.Controls.Add(textBoxSearch, 0, 1);
            tableLayoutPanelFilters.Dock = DockStyle.Fill;
            tableLayoutPanelFilters.Location = new Point(0, 0);
            tableLayoutPanelFilters.Name = "tableLayoutPanelFilters";
            tableLayoutPanelFilters.RowCount = 2;
            tableLayoutPanelFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelFilters.Size = new Size(670, 63);
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
            textBoxSearch.Size = new Size(664, 23);
            textBoxSearch.TabIndex = 2;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // dataGridViewMembers
            // 
            dataGridViewMembers.AllowUserToAddRows = false;
            dataGridViewMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMembers.BackgroundColor = Color.White;
            dataGridViewMembers.BorderStyle = BorderStyle.None;
            dataGridViewMembers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewMembers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMembers.Columns.AddRange(new DataGridViewColumn[] { Id, MemberName, Phone, Email, Address });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewMembers.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewMembers.Dock = DockStyle.Fill;
            dataGridViewMembers.EnableHeadersVisualStyles = false;
            dataGridViewMembers.GridColor = Color.White;
            dataGridViewMembers.Location = new Point(3, 112);
            dataGridViewMembers.MultiSelect = false;
            dataGridViewMembers.Name = "dataGridViewMembers";
            dataGridViewMembers.ReadOnly = true;
            dataGridViewMembers.RowHeadersVisible = false;
            dataGridViewMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMembers.Size = new Size(670, 313);
            dataGridViewMembers.TabIndex = 2;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // MemberName
            // 
            MemberName.DataPropertyName = "Name";
            MemberName.HeaderText = "Name";
            MemberName.Name = "MemberName";
            MemberName.ReadOnly = true;
            // 
            // Phone
            // 
            Phone.DataPropertyName = "Phone";
            Phone.HeaderText = "Phone";
            Phone.Name = "Phone";
            Phone.ReadOnly = true;
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.HeaderText = "Address";
            Address.Name = "Address";
            Address.ReadOnly = true;
            // 
            // MemberView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "MemberView";
            Size = new Size(676, 428);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            toolStripMembers.ResumeLayout(false);
            toolStripMembers.PerformLayout();
            panelFilters.ResumeLayout(false);
            tableLayoutPanelFilters.ResumeLayout(false);
            tableLayoutPanelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMembers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private ToolStrip toolStripMembers;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonView;
        private ToolStripButton toolStripButtonDelete;
        private Panel panelFilters;
        private TableLayoutPanel tableLayoutPanelFilters;
        private Label labelSearch;
        private TextBox textBoxSearch;
        private DataGridView dataGridViewMembers;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton toolStripButtonRefresh;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn MemberName;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Address;
    }
}
