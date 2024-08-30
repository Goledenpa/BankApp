using BankApp.Controls;

namespace BankApp.View
{
    partial class CustomerView
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
            firstNameLbl = new Label();
            lastNameLbl = new Label();
            firstNameTxtBox = new TextBox();
            lastNameTxtBox = new TextBox();
            usernameLbl = new Label();
            usernameTxtBox = new TextBox();
            countryTxtBox = new TextBox();
            label5 = new Label();
            cityTxtBox = new TextBox();
            label4 = new Label();
            addressTxtBox = new TextBox();
            label3 = new Label();
            regionTxtBox = new TextBox();
            label6 = new Label();
            passwordTxtBox = new TextBox();
            label7 = new Label();
            newBtn = new Button();
            saveBtn = new Button();
            deleteBtn = new Button();
            showAccsBtn = new Button();
            searchCustomerBtn = new Button();
            searchCustomerTxtBox = new IntegerTextBox();
            searchCustomerCodeLbl = new Label();
            label1 = new Label();
            showPasswordBtn = new Button();
            SuspendLayout();
            // 
            // firstNameLbl
            // 
            firstNameLbl.AutoSize = true;
            firstNameLbl.Location = new Point(68, 117);
            firstNameLbl.Name = "firstNameLbl";
            firstNameLbl.Size = new Size(67, 15);
            firstNameLbl.TabIndex = 3;
            firstNameLbl.Text = "First Name:";
            // 
            // lastNameLbl
            // 
            lastNameLbl.AutoSize = true;
            lastNameLbl.Location = new Point(383, 117);
            lastNameLbl.Name = "lastNameLbl";
            lastNameLbl.Size = new Size(66, 15);
            lastNameLbl.TabIndex = 4;
            lastNameLbl.Text = "Last Name:";
            // 
            // firstNameTxtBox
            // 
            firstNameTxtBox.Location = new Point(141, 114);
            firstNameTxtBox.Name = "firstNameTxtBox";
            firstNameTxtBox.Size = new Size(203, 23);
            firstNameTxtBox.TabIndex = 5;
            // 
            // lastNameTxtBox
            // 
            lastNameTxtBox.Location = new Point(455, 114);
            lastNameTxtBox.Name = "lastNameTxtBox";
            lastNameTxtBox.Size = new Size(203, 23);
            lastNameTxtBox.TabIndex = 6;
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Location = new Point(68, 151);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(63, 15);
            usernameLbl.TabIndex = 7;
            usernameLbl.Text = "Username:";
            // 
            // usernameTxtBox
            // 
            usernameTxtBox.Location = new Point(141, 148);
            usernameTxtBox.Name = "usernameTxtBox";
            usernameTxtBox.Size = new Size(203, 23);
            usernameTxtBox.TabIndex = 8;
            // 
            // countryTxtBox
            // 
            countryTxtBox.Location = new Point(141, 182);
            countryTxtBox.Name = "countryTxtBox";
            countryTxtBox.Size = new Size(203, 23);
            countryTxtBox.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(68, 185);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 15;
            label5.Text = "Country:";
            // 
            // cityTxtBox
            // 
            cityTxtBox.Location = new Point(141, 216);
            cityTxtBox.Name = "cityTxtBox";
            cityTxtBox.Size = new Size(203, 23);
            cityTxtBox.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 219);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 19;
            label4.Text = "City:";
            // 
            // addressTxtBox
            // 
            addressTxtBox.Location = new Point(455, 216);
            addressTxtBox.Name = "addressTxtBox";
            addressTxtBox.Size = new Size(203, 23);
            addressTxtBox.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(383, 219);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 29;
            label3.Text = "Address:";
            // 
            // regionTxtBox
            // 
            regionTxtBox.Location = new Point(455, 182);
            regionTxtBox.Name = "regionTxtBox";
            regionTxtBox.Size = new Size(203, 23);
            regionTxtBox.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(383, 185);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 27;
            label6.Text = "Region:";
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Location = new Point(455, 148);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.Size = new Size(203, 23);
            passwordTxtBox.TabIndex = 26;
            passwordTxtBox.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(383, 151);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 25;
            label7.Text = "Password:";
            // 
            // newBtn
            // 
            newBtn.Location = new Point(68, 292);
            newBtn.Name = "newBtn";
            newBtn.Size = new Size(92, 26);
            newBtn.TabIndex = 31;
            newBtn.Text = "New";
            newBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(183, 292);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(92, 26);
            saveBtn.TabIndex = 32;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(298, 292);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(92, 26);
            deleteBtn.TabIndex = 34;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            // 
            // showAccsBtn
            // 
            showAccsBtn.Location = new Point(566, 292);
            showAccsBtn.Name = "showAccsBtn";
            showAccsBtn.Size = new Size(92, 26);
            showAccsBtn.TabIndex = 35;
            showAccsBtn.Text = "Accounts";
            showAccsBtn.UseVisualStyleBackColor = true;
            // 
            // searchCustomerBtn
            // 
            searchCustomerBtn.Location = new Point(266, 36);
            searchCustomerBtn.Name = "searchCustomerBtn";
            searchCustomerBtn.Size = new Size(68, 23);
            searchCustomerBtn.TabIndex = 38;
            searchCustomerBtn.Text = "Search";
            searchCustomerBtn.UseVisualStyleBackColor = true;
            // 
            // searchCustomerTxtBox
            // 
            searchCustomerTxtBox.Location = new Point(144, 37);
            searchCustomerTxtBox.Name = "searchCustomerTxtBox";
            searchCustomerTxtBox.Size = new Size(100, 23);
            searchCustomerTxtBox.TabIndex = 37;
            // 
            // searchCustomerCodeLbl
            // 
            searchCustomerCodeLbl.AutoSize = true;
            searchCustomerCodeLbl.Location = new Point(68, 40);
            searchCustomerCodeLbl.Name = "searchCustomerCodeLbl";
            searchCustomerCodeLbl.Size = new Size(38, 15);
            searchCustomerCodeLbl.TabIndex = 36;
            searchCustomerCodeLbl.Text = "Code:";
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(-38, 80);
            label1.Name = "label1";
            label1.Size = new Size(816, 2);
            label1.TabIndex = 39;
            // 
            // showPasswordBtn
            // 
            showPasswordBtn.Location = new Point(680, 148);
            showPasswordBtn.Name = "showPasswordBtn";
            showPasswordBtn.Size = new Size(55, 23);
            showPasswordBtn.TabIndex = 40;
            showPasswordBtn.UseVisualStyleBackColor = true;
            // 
            // CustomerView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 347);
            Controls.Add(showPasswordBtn);
            Controls.Add(label1);
            Controls.Add(searchCustomerBtn);
            Controls.Add(searchCustomerTxtBox);
            Controls.Add(searchCustomerCodeLbl);
            Controls.Add(showAccsBtn);
            Controls.Add(deleteBtn);
            Controls.Add(saveBtn);
            Controls.Add(newBtn);
            Controls.Add(addressTxtBox);
            Controls.Add(label3);
            Controls.Add(regionTxtBox);
            Controls.Add(label6);
            Controls.Add(passwordTxtBox);
            Controls.Add(label7);
            Controls.Add(cityTxtBox);
            Controls.Add(label4);
            Controls.Add(countryTxtBox);
            Controls.Add(label5);
            Controls.Add(usernameTxtBox);
            Controls.Add(usernameLbl);
            Controls.Add(lastNameTxtBox);
            Controls.Add(firstNameTxtBox);
            Controls.Add(lastNameLbl);
            Controls.Add(firstNameLbl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CustomerView";
            Text = "Customer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label firstNameLbl;
        private Label lastNameLbl;
        private TextBox firstNameTxtBox;
        private TextBox lastNameTxtBox;
        private Label usernameLbl;
        private TextBox usernameTxtBox;
        private TextBox countryTxtBox;
        private Label label5;
        private TextBox cityTxtBox;
        private Label label4;
        private TextBox addressTxtBox;
        private Label label3;
        private TextBox regionTxtBox;
        private Label label6;
        private TextBox passwordTxtBox;
        private Label label7;
        private Button newBtn;
        private Button saveBtn;
        private Button deleteBtn;
        private Button showAccsBtn;
        private Button searchCustomerBtn;
        private IntegerTextBox searchCustomerTxtBox;
        private Label searchCustomerCodeLbl;
        private Label label1;
        private Button showPasswordBtn;
    }
}