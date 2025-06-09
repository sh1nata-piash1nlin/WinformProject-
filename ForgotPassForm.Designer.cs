namespace L2_LoginForm
{
    partial class ForgotPassForm
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
            this.forgotLabel = new System.Windows.Forms.Label();
            this.verifyButton = new System.Windows.Forms.Button();
            this.sendCodeButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.emailTxtBox = new System.Windows.Forms.TextBox();
            this.codeTxtBox = new System.Windows.Forms.TextBox();
            this.newPassLabel = new System.Windows.Forms.Label();
            this.rePassButton = new System.Windows.Forms.Label();
            this.newPassTxtBox = new System.Windows.Forms.TextBox();
            this.rePassTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // forgotLabel
            // 
            this.forgotLabel.AutoSize = true;
            this.forgotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotLabel.ForeColor = System.Drawing.Color.PaleGreen;
            this.forgotLabel.Location = new System.Drawing.Point(93, 0);
            this.forgotLabel.Name = "forgotLabel";
            this.forgotLabel.Size = new System.Drawing.Size(677, 91);
            this.forgotLabel.TabIndex = 0;
            this.forgotLabel.Text = "Forgot Password ";
            this.forgotLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // verifyButton
            // 
            this.verifyButton.BackColor = System.Drawing.Color.Aqua;
            this.verifyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyButton.Location = new System.Drawing.Point(560, 276);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(142, 63);
            this.verifyButton.TabIndex = 1;
            this.verifyButton.Text = "Verify Code ";
            this.verifyButton.UseVisualStyleBackColor = false;
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // sendCodeButton
            // 
            this.sendCodeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.sendCodeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendCodeButton.Location = new System.Drawing.Point(560, 104);
            this.sendCodeButton.Name = "sendCodeButton";
            this.sendCodeButton.Size = new System.Drawing.Size(142, 48);
            this.sendCodeButton.TabIndex = 2;
            this.sendCodeButton.Text = "Send Code ";
            this.sendCodeButton.UseVisualStyleBackColor = false;
            this.sendCodeButton.Click += new System.EventHandler(this.sendCodeButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.backButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Back ";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LawnGreen;
            this.label2.Location = new System.Drawing.Point(129, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Email:";
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLabel.ForeColor = System.Drawing.Color.LawnGreen;
            this.codeLabel.Location = new System.Drawing.Point(129, 169);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(66, 25);
            this.codeLabel.TabIndex = 5;
            this.codeLabel.Text = "Code:";
            // 
            // emailTxtBox
            // 
            this.emailTxtBox.Location = new System.Drawing.Point(238, 120);
            this.emailTxtBox.Name = "emailTxtBox";
            this.emailTxtBox.Size = new System.Drawing.Size(269, 22);
            this.emailTxtBox.TabIndex = 6;
            // 
            // codeTxtBox
            // 
            this.codeTxtBox.Location = new System.Drawing.Point(238, 173);
            this.codeTxtBox.Name = "codeTxtBox";
            this.codeTxtBox.Size = new System.Drawing.Size(269, 22);
            this.codeTxtBox.TabIndex = 7;
            // 
            // newPassLabel
            // 
            this.newPassLabel.AutoSize = true;
            this.newPassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassLabel.ForeColor = System.Drawing.Color.LawnGreen;
            this.newPassLabel.Location = new System.Drawing.Point(34, 228);
            this.newPassLabel.Name = "newPassLabel";
            this.newPassLabel.Size = new System.Drawing.Size(167, 25);
            this.newPassLabel.TabIndex = 8;
            this.newPassLabel.Text = "New Password: ";
            // 
            // rePassButton
            // 
            this.rePassButton.AutoSize = true;
            this.rePassButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rePassButton.ForeColor = System.Drawing.Color.LawnGreen;
            this.rePassButton.Location = new System.Drawing.Point(48, 274);
            this.rePassButton.Name = "rePassButton";
            this.rePassButton.Size = new System.Drawing.Size(153, 25);
            this.rePassButton.TabIndex = 9;
            this.rePassButton.Text = "Re-Password: ";
            // 
            // newPassTxtBox
            // 
            this.newPassTxtBox.Location = new System.Drawing.Point(238, 230);
            this.newPassTxtBox.Name = "newPassTxtBox";
            this.newPassTxtBox.Size = new System.Drawing.Size(269, 22);
            this.newPassTxtBox.TabIndex = 10;
            // 
            // rePassTxtBox
            // 
            this.rePassTxtBox.Location = new System.Drawing.Point(238, 276);
            this.rePassTxtBox.Name = "rePassTxtBox";
            this.rePassTxtBox.Size = new System.Drawing.Size(269, 22);
            this.rePassTxtBox.TabIndex = 11;
            // 
            // ForgotPassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 365);
            this.Controls.Add(this.rePassTxtBox);
            this.Controls.Add(this.newPassTxtBox);
            this.Controls.Add(this.rePassButton);
            this.Controls.Add(this.newPassLabel);
            this.Controls.Add(this.codeTxtBox);
            this.Controls.Add(this.emailTxtBox);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.sendCodeButton);
            this.Controls.Add(this.verifyButton);
            this.Controls.Add(this.forgotLabel);
            this.Name = "ForgotPassForm";
            this.Text = "ForgotPass_22110082_NguyenDucTri ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label forgotLabel;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.Button sendCodeButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.TextBox emailTxtBox;
        private System.Windows.Forms.TextBox codeTxtBox;
        private System.Windows.Forms.Label newPassLabel;
        private System.Windows.Forms.Label rePassButton;
        private System.Windows.Forms.TextBox newPassTxtBox;
        private System.Windows.Forms.TextBox rePassTxtBox;
    }
}