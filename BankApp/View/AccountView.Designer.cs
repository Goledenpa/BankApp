namespace BankApp.View
{
    partial class AccountView
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
            accountsDataGridView = new DataGridView();
            accountNumberColumn = new DataGridViewTextBoxColumn();
            descriptionColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)accountsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // accountsDataGridView
            // 
            accountsDataGridView.AllowUserToAddRows = false;
            accountsDataGridView.AllowUserToDeleteRows = false;
            accountsDataGridView.AllowUserToResizeColumns = false;
            accountsDataGridView.AllowUserToResizeRows = false;
            accountsDataGridView.CausesValidation = false;
            accountsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accountsDataGridView.Columns.AddRange(new DataGridViewColumn[] { accountNumberColumn, descriptionColumn });
            accountsDataGridView.Location = new Point(12, 12);
            accountsDataGridView.MultiSelect = false;
            accountsDataGridView.Name = "accountsDataGridView";
            accountsDataGridView.ReadOnly = true;
            accountsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            accountsDataGridView.Size = new Size(776, 154);
            accountsDataGridView.TabIndex = 0;
            accountsDataGridView.AutoGenerateColumns = false;
            // 
            // accountNumberColumn
            // 
            accountNumberColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            accountNumberColumn.DataPropertyName = "AccountNumber";
            accountNumberColumn.HeaderText = "Account Number";
            accountNumberColumn.Name = "accountNumberColumn";
            accountNumberColumn.ReadOnly = true;
            // 
            // descriptionColumn
            // 
            descriptionColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descriptionColumn.DataPropertyName = "Description";
            descriptionColumn.HeaderText = "Description";
            descriptionColumn.Name = "descriptionColumn";
            descriptionColumn.ReadOnly = true;
            // 
            // AccountView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 181);
            Controls.Add(accountsDataGridView);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AccountView";
            Text = "Bank Account";
            ((System.ComponentModel.ISupportInitialize)accountsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView accountsDataGridView;
        private DataGridViewTextBoxColumn accountNumberColumn;
        private DataGridViewTextBoxColumn descriptionColumn;
    }
}