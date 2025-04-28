namespace FinaWFProject
{
    partial class CreateAccountForm
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
            this.components = new System.ComponentModel.Container();
            this.createaccountLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.noticeLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.repasswordLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.repasswordTextBox = new System.Windows.Forms.TextBox();
            this.sendcodeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.sendcodeTimer = new System.Windows.Forms.Timer(this.components);
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.selectRoleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createaccountLabel
            // 
            this.createaccountLabel.AutoSize = true;
            this.createaccountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createaccountLabel.Location = new System.Drawing.Point(201, 18);
            this.createaccountLabel.Name = "createaccountLabel";
            this.createaccountLabel.Size = new System.Drawing.Size(338, 38);
            this.createaccountLabel.TabIndex = 0;
            this.createaccountLabel.Text = "CREATE ACCOUNT";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(49, 81);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(72, 25);
            this.emailLabel.TabIndex = 1;
            this.emailLabel.Text = "Email:";
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLabel.Location = new System.Drawing.Point(49, 137);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(71, 25);
            this.codeLabel.TabIndex = 2;
            this.codeLabel.Text = "Code:";
            // 
            // noticeLabel
            // 
            this.noticeLabel.AutoSize = true;
            this.noticeLabel.ForeColor = System.Drawing.Color.Red;
            this.noticeLabel.Location = new System.Drawing.Point(136, 179);
            this.noticeLabel.Name = "noticeLabel";
            this.noticeLabel.Size = new System.Drawing.Size(49, 16);
            this.noticeLabel.TabIndex = 3;
            this.noticeLabel.Text = "Notice:";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(97, 227);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(23, 16);
            this.idLabel.TabIndex = 4;
            this.idLabel.Text = "ID:";
            this.idLabel.Click += new System.EventHandler(this.idLabel_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(97, 267);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(73, 16);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(97, 305);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(70, 16);
            this.passwordLabel.TabIndex = 6;
            this.passwordLabel.Text = "Password:";
            // 
            // repasswordLabel
            // 
            this.repasswordLabel.AutoSize = true;
            this.repasswordLabel.Location = new System.Drawing.Point(97, 344);
            this.repasswordLabel.Name = "repasswordLabel";
            this.repasswordLabel.Size = new System.Drawing.Size(92, 16);
            this.repasswordLabel.TabIndex = 7;
            this.repasswordLabel.Text = "Re-Password:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(139, 74);
            this.emailTextBox.Multiline = true;
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(412, 32);
            this.emailTextBox.TabIndex = 8;
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(139, 131);
            this.codeTextBox.Multiline = true;
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(412, 31);
            this.codeTextBox.TabIndex = 9;
            this.codeTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(200, 221);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(173, 22);
            this.idTextBox.TabIndex = 10;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(200, 261);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(173, 22);
            this.usernameTextBox.TabIndex = 11;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(200, 299);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(173, 22);
            this.passwordTextBox.TabIndex = 12;
            // 
            // repasswordTextBox
            // 
            this.repasswordTextBox.Location = new System.Drawing.Point(200, 338);
            this.repasswordTextBox.Name = "repasswordTextBox";
            this.repasswordTextBox.PasswordChar = '*';
            this.repasswordTextBox.Size = new System.Drawing.Size(173, 22);
            this.repasswordTextBox.TabIndex = 13;
            // 
            // sendcodeButton
            // 
            this.sendcodeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sendcodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendcodeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendcodeButton.Location = new System.Drawing.Point(569, 74);
            this.sendcodeButton.Name = "sendcodeButton";
            this.sendcodeButton.Size = new System.Drawing.Size(109, 32);
            this.sendcodeButton.TabIndex = 14;
            this.sendcodeButton.Text = "Send Code";
            this.sendcodeButton.UseVisualStyleBackColor = false;
            this.sendcodeButton.Click += new System.EventHandler(this.sendcodeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Red;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(159, 412);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(132, 41);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(419, 412);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(132, 41);
            this.createButton.TabIndex = 16;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // roleComboBox
            // 
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Location = new System.Drawing.Point(490, 261);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(129, 24);
            this.roleComboBox.TabIndex = 17;
            // 
            // selectRoleLabel
            // 
            this.selectRoleLabel.AutoSize = true;
            this.selectRoleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectRoleLabel.Location = new System.Drawing.Point(505, 238);
            this.selectRoleLabel.Name = "selectRoleLabel";
            this.selectRoleLabel.Size = new System.Drawing.Size(106, 20);
            this.selectRoleLabel.TabIndex = 18;
            this.selectRoleLabel.Text = "Select Role";
            // 
            // CreateAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(700, 486);
            this.Controls.Add(this.selectRoleLabel);
            this.Controls.Add(this.roleComboBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.sendcodeButton);
            this.Controls.Add(this.repasswordTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.repasswordLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.noticeLabel);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.createaccountLabel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "CreateAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreatAccountForm";
            this.Load += new System.EventHandler(this.CreateAccountForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label createaccountLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label noticeLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label repasswordLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox repasswordTextBox;
        private System.Windows.Forms.Button sendcodeButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Timer sendcodeTimer;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.Label selectRoleLabel;
    }
}