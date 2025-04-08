namespace FinaWFProject
{
    partial class SendCodeForm
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
            this.forgotpasswordLabel = new System.Windows.Forms.Label();
            this.backLinkLabel = new System.Windows.Forms.LinkLabel();
            this.emailLabel = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.sendcodeButton = new System.Windows.Forms.Button();
            this.verifyButton = new System.Windows.Forms.Button();
            this.sendcodeTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // forgotpasswordLabel
            // 
            this.forgotpasswordLabel.AutoSize = true;
            this.forgotpasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotpasswordLabel.Location = new System.Drawing.Point(223, 30);
            this.forgotpasswordLabel.Name = "forgotpasswordLabel";
            this.forgotpasswordLabel.Size = new System.Drawing.Size(338, 46);
            this.forgotpasswordLabel.TabIndex = 0;
            this.forgotpasswordLabel.Text = "Forgot Password";
            // 
            // backLinkLabel
            // 
            this.backLinkLabel.AutoSize = true;
            this.backLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backLinkLabel.Location = new System.Drawing.Point(12, 30);
            this.backLinkLabel.Name = "backLinkLabel";
            this.backLinkLabel.Size = new System.Drawing.Size(47, 20);
            this.backLinkLabel.TabIndex = 1;
            this.backLinkLabel.TabStop = true;
            this.backLinkLabel.Text = "Back";
            this.backLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.backLinkLabel_LinkClicked);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.BackColor = System.Drawing.Color.LightSalmon;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(126, 140);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(66, 25);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Email:";
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLabel.Location = new System.Drawing.Point(126, 210);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(66, 25);
            this.codeLabel.TabIndex = 3;
            this.codeLabel.Text = "Code:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(231, 131);
            this.emailTextBox.Multiline = true;
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(252, 34);
            this.emailTextBox.TabIndex = 4;
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(231, 203);
            this.codeTextBox.Multiline = true;
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(252, 32);
            this.codeTextBox.TabIndex = 5;
            // 
            // sendcodeButton
            // 
            this.sendcodeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sendcodeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendcodeButton.Location = new System.Drawing.Point(521, 131);
            this.sendcodeButton.Name = "sendcodeButton";
            this.sendcodeButton.Size = new System.Drawing.Size(154, 38);
            this.sendcodeButton.TabIndex = 6;
            this.sendcodeButton.Text = "Send Code";
            this.sendcodeButton.UseVisualStyleBackColor = false;
            this.sendcodeButton.Click += new System.EventHandler(this.sendcodeButton_Click);
            // 
            // verifyButton
            // 
            this.verifyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.verifyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyButton.Location = new System.Drawing.Point(317, 337);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(166, 44);
            this.verifyButton.TabIndex = 7;
            this.verifyButton.Text = "Verify Code";
            this.verifyButton.UseVisualStyleBackColor = false;
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // SendCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.verifyButton);
            this.Controls.Add(this.sendcodeButton);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.backLinkLabel);
            this.Controls.Add(this.forgotpasswordLabel);
            this.Name = "SendCodeForm";
            this.Text = "SendCodeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label forgotpasswordLabel;
        private System.Windows.Forms.LinkLabel backLinkLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Button sendcodeButton;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.Timer sendcodeTimer;
    }
}