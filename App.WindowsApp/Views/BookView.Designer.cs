namespace App.WindowsApp.Views
{
    partial class BookView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookView));
            tableLayoutPanel = new TableLayoutPanel();
            toolStripBooks = new ToolStrip();
            toolStripButtonAdd = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonView = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            panelFilters = new Panel();
            tableLayoutPanelFilters = new TableLayoutPanel();
            labelSearch = new Label();
            labelCategory = new Label();
            textBoxSearch = new TextBox();
            comboBoxCategory = new ComboBox();
            dataGridViewBooks = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            Author = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            PublishedDate = new DataGridViewTextBoxColumn();
            tableLayoutPanel.SuspendLayout();
            toolStripBooks.SuspendLayout();
            panelFilters.SuspendLayout();
            tableLayoutPanelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackColor = Color.White;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(toolStripBooks, 0, 0);
            tableLayoutPanel.Controls.Add(panelFilters, 0, 1);
            tableLayoutPanel.Controls.Add(dataGridViewBooks, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tableLayoutPanel.Size = new Size(674, 430);
            tableLayoutPanel.TabIndex = 0;
            // 
            // toolStripBooks
            // 
            toolStripBooks.BackColor = Color.WhiteSmoke;
            toolStripBooks.Dock = DockStyle.Fill;
            toolStripBooks.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonEdit, toolStripButtonView, toolStripButtonDelete });
            toolStripBooks.Location = new Point(0, 0);
            toolStripBooks.Name = "toolStripBooks";
            toolStripBooks.Size = new Size(674, 40);
            toolStripBooks.TabIndex = 0;
            toolStripBooks.Text = "toolStrip";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.Image = (Image)resources.GetObject("toolStripButtonAdd.Image");
            toolStripButtonAdd.ImageTransparentColor = Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new Size(49, 37);
            toolStripButtonAdd.Text = "Add";
            toolStripButtonAdd.ToolTipText = "toolStripButton";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.Image = (Image)resources.GetObject("toolStripButtonEdit.Image");
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(47, 37);
            toolStripButtonEdit.Text = "Edit";
            toolStripButtonEdit.ToolTipText = "toolStripButton";
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
            // 
            // toolStripButtonView
            // 
            toolStripButtonView.Image = (Image)resources.GetObject("toolStripButtonView.Image");
            toolStripButtonView.ImageTransparentColor = Color.Magenta;
            toolStripButtonView.Name = "toolStripButtonView";
            toolStripButtonView.Size = new Size(52, 37);
            toolStripButtonView.Text = "View";
            toolStripButtonView.Click += toolStripButtonView_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.Image = (Image)resources.GetObject("toolStripButtonDelete.Image");
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(60, 37);
            toolStripButtonDelete.Text = "Delete";
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
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
            tableLayoutPanelFilters.ColumnCount = 2;
            tableLayoutPanelFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanelFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanelFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelFilters.Controls.Add(labelSearch, 0, 0);
            tableLayoutPanelFilters.Controls.Add(labelCategory, 1, 0);
            tableLayoutPanelFilters.Controls.Add(textBoxSearch, 0, 1);
            tableLayoutPanelFilters.Controls.Add(comboBoxCategory, 1, 1);
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
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(470, 0);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(55, 15);
            labelCategory.TabIndex = 1;
            labelCategory.Text = "Category";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Dock = DockStyle.Fill;
            textBoxSearch.Location = new Point(3, 34);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(461, 23);
            textBoxSearch.TabIndex = 2;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.Dock = DockStyle.Fill;
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(470, 34);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(195, 23);
            comboBoxCategory.TabIndex = 3;
            comboBoxCategory.SelectedIndexChanged += comboBoxCategory_SelectedIndexChanged;
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBooks.BackgroundColor = Color.White;
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Columns.AddRange(new DataGridViewColumn[] { Id, Title, Author, Category, Quantity, PublishedDate });
            dataGridViewBooks.Dock = DockStyle.Fill;
            dataGridViewBooks.Location = new Point(3, 112);
            dataGridViewBooks.MultiSelect = false;
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.ReadOnly = true;
            dataGridViewBooks.RowHeadersVisible = false;
            dataGridViewBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBooks.Size = new Size(668, 315);
            dataGridViewBooks.TabIndex = 2;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Title
            // 
            Title.HeaderText = "Title";
            Title.Name = "Title";
            Title.ReadOnly = true;
            // 
            // Author
            // 
            Author.HeaderText = "Author";
            Author.Name = "Author";
            Author.ReadOnly = true;
            // 
            // Category
            // 
            Category.HeaderText = "Category";
            Category.Name = "Category";
            Category.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // PublishedDate
            // 
            PublishedDate.HeaderText = "PublishedDate";
            PublishedDate.Name = "PublishedDate";
            PublishedDate.ReadOnly = true;
            // 
            // BookView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "BookView";
            Size = new Size(674, 430);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            toolStripBooks.ResumeLayout(false);
            toolStripBooks.PerformLayout();
            panelFilters.ResumeLayout(false);
            tableLayoutPanelFilters.ResumeLayout(false);
            tableLayoutPanelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private ToolStrip toolStripBooks;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonView;
        private ToolStripButton toolStripButtonDelete;
        private Panel panelFilters;
        private TableLayoutPanel tableLayoutPanelFilters;
        private Label labelSearch;
        private Label labelCategory;
        private TextBox textBoxSearch;
        private ComboBox comboBoxCategory;
        private DataGridView dataGridViewBooks;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Author;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn PublishedDate;
    }
}
