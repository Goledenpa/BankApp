namespace BankApp.View
{
    partial class loginView
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
            loginLabel = new Label();
            passwordLabel = new Label();
            loginTxtBox = new TextBox();
            passwordTxtBox = new TextBox();
            loginBtn = new Button();
            SuspendLayout();
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Location = new Point(110, 86);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(40, 15);
            loginLabel.TabIndex = 0;
            loginLabel.Text = "Login:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(110, 139);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 1;
            passwordLabel.Text = "Password:";
            // 
            // loginTxtBox
            // 
            loginTxtBox.Location = new Point(233, 83);
            loginTxtBox.Name = "loginTxtBox";
            loginTxtBox.Size = new Size(173, 23);
            loginTxtBox.TabIndex = 2;
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Location = new Point(233, 136);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.Size = new Size(173, 23);
            passwordTxtBox.TabIndex = 3;
            passwordTxtBox.UseSystemPasswordChar = true;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(204, 219);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(103, 23);
            loginBtn.TabIndex = 4;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            // 
            // loginView
            // 
            AcceptButton = loginBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 296);
            Controls.Add(loginBtn);
            Controls.Add(passwordTxtBox);
            Controls.Add(loginTxtBox);
            Controls.Add(passwordLabel);
            Controls.Add(loginLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "loginView";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label loginLabel;
        private Label passwordLabel;
        private TextBox loginTxtBox;
        private TextBox passwordTxtBox;
        private Button loginBtn;
    }
}