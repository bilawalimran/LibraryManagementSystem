namespace App.WindowsApp.Forms
{
    partial class BookForm
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
            panelBookDetails = new Panel();
            labelBookDetails = new Label();
            flowLayoutPanel = new FlowLayoutPanel();
            buttonCancel = new Button();
            buttonSave = new Button();
            tableLayoutPanel = new TableLayoutPanel();
            labelTitle = new Label();
            labelAuthor = new Label();
            labelCategory = new Label();
            labelQuantity = new Label();
            labelPublishedDate = new Label();
            labelId = new Label();
            textBoxTitle = new TextBox();
            textBoxAuthor = new TextBox();
            comboBoxCategory = new ComboBox();
            numericUpDownQuantity = new NumericUpDown();
            dateTimePickerPublishedDate = new DateTimePicker();
            textBoxBookId = new TextBox();
            panelBookDetails.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            SuspendLayout();
            // 
            // panelBookDetails
            // 
            panelBookDetails.Controls.Add(labelBookDetails);
            panelBookDetails.Dock = DockStyle.Top;
            panelBookDetails.Location = new Point(0, 0);
            panelBookDetails.Name = "panelBookDetails";
            panelBookDetails.Size = new Size(855, 43);
            panelBookDetails.TabIndex = 0;
            // 
            // labelBookDetails
            // 
            labelBookDetails.AutoSize = true;
            labelBookDetails.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBookDetails.Location = new Point(12, 9);
            labelBookDetails.Name = "labelBookDetails";
            labelBookDetails.Size = new Size(157, 32);
            labelBookDetails.TabIndex = 0;
            labelBookDetails.Text = "Book Details";
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Controls.Add(buttonCancel);
            flowLayoutPanel.Controls.Add(buttonSave);
            flowLayoutPanel.Dock = DockStyle.Bottom;
            flowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel.Location = new Point(0, 399);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(855, 62);
            flowLayoutPanel.TabIndex = 1;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(777, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(696, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel.Controls.Add(labelTitle, 0, 0);
            tableLayoutPanel.Controls.Add(labelAuthor, 0, 1);
            tableLayoutPanel.Controls.Add(labelCategory, 0, 2);
            tableLayoutPanel.Controls.Add(labelQuantity, 0, 3);
            tableLayoutPanel.Controls.Add(labelPublishedDate, 0, 4);
            tableLayoutPanel.Controls.Add(labelId, 0, 5);
            tableLayoutPanel.Controls.Add(textBoxTitle, 1, 0);
            tableLayoutPanel.Controls.Add(textBoxAuthor, 1, 1);
            tableLayoutPanel.Controls.Add(comboBoxCategory, 1, 2);
            tableLayoutPanel.Controls.Add(numericUpDownQuantity, 1, 3);
            tableLayoutPanel.Controls.Add(dateTimePickerPublishedDate, 1, 4);
            tableLayoutPanel.Controls.Add(textBoxBookId, 1, 5);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 43);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 6;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.Size = new Size(855, 356);
            tableLayoutPanel.TabIndex = 2;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(3, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(29, 15);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Title";
            // 
            // labelAuthor
            // 
            labelAuthor.AutoSize = true;
            labelAuthor.Location = new Point(3, 50);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new Size(44, 15);
            labelAuthor.TabIndex = 1;
            labelAuthor.Text = "Author";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(3, 100);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(55, 15);
            labelCategory.TabIndex = 2;
            labelCategory.Text = "Category";
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new Point(3, 150);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(53, 15);
            labelQuantity.TabIndex = 3;
            labelQuantity.Text = "Quantity";
            // 
            // labelPublishedDate
            // 
            labelPublishedDate.AutoSize = true;
            labelPublishedDate.Location = new Point(3, 200);
            labelPublishedDate.Name = "labelPublishedDate";
            labelPublishedDate.Size = new Size(86, 15);
            labelPublishedDate.TabIndex = 4;
            labelPublishedDate.Text = "Published Date";
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(3, 250);
            labelId.Name = "labelId";
            labelId.Size = new Size(17, 15);
            labelId.TabIndex = 5;
            labelId.Text = "Id";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Dock = DockStyle.Fill;
            textBoxTitle.Location = new Point(174, 3);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(678, 23);
            textBoxTitle.TabIndex = 6;
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.Dock = DockStyle.Fill;
            textBoxAuthor.Location = new Point(174, 53);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new Size(678, 23);
            textBoxAuthor.TabIndex = 7;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.Dock = DockStyle.Fill;
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(174, 103);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(678, 23);
            comboBoxCategory.TabIndex = 8;
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Dock = DockStyle.Fill;
            numericUpDownQuantity.Location = new Point(174, 153);
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(678, 23);
            numericUpDownQuantity.TabIndex = 9;
            // 
            // dateTimePickerPublishedDate
            // 
            dateTimePickerPublishedDate.Dock = DockStyle.Fill;
            dateTimePickerPublishedDate.Location = new Point(174, 203);
            dateTimePickerPublishedDate.Name = "dateTimePickerPublishedDate";
            dateTimePickerPublishedDate.Size = new Size(678, 23);
            dateTimePickerPublishedDate.TabIndex = 10;
            // 
            // textBoxBookId
            // 
            textBoxBookId.Dock = DockStyle.Fill;
            textBoxBookId.Location = new Point(174, 253);
            textBoxBookId.Name = "textBoxBookId";
            textBoxBookId.ReadOnly = true;
            textBoxBookId.Size = new Size(678, 23);
            textBoxBookId.TabIndex = 11;
            // 
            // BookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 461);
            Controls.Add(tableLayoutPanel);
            Controls.Add(flowLayoutPanel);
            Controls.Add(panelBookDetails);
            Name = "BookForm";
            Text = "BookForm";
            panelBookDetails.ResumeLayout(false);
            panelBookDetails.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBookDetails;
        private Label labelBookDetails;
        private FlowLayoutPanel flowLayoutPanel;
        private TableLayoutPanel tableLayoutPanel;
        private Label labelTitle;
        private Label labelAuthor;
        private Label labelCategory;
        private Label labelQuantity;
        private Label labelPublishedDate;
        private Label labelId;
        private TextBox textBoxTitle;
        private TextBox textBoxAuthor;
        private ComboBox comboBoxCategory;
        private NumericUpDown numericUpDownQuantity;
        private DateTimePicker dateTimePickerPublishedDate;
        private Button buttonCancel;
        private Button buttonSave;
        private TextBox textBoxBookId;
    }
}
