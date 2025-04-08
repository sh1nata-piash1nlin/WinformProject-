namespace FinaWFProject
{
    partial class ResetPasswordForm
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
            this.resetpasswordLabel = new System.Windows.Forms.Label();
            this.newpasswordLabel = new System.Windows.Forms.Label();
            this.confirmpasswordLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.newpasswordTextBox = new System.Windows.Forms.TextBox();
            this.confirmpasswordTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // resetpasswordLabel
            // 
            this.resetpasswordLabel.AutoSize = true;
            this.resetpasswordLabel.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetpasswordLabel.Location = new System.Drawing.Point(280, 39);
            this.resetpasswordLabel.Name = "resetpasswordLabel";
            this.resetpasswordLabel.Size = new System.Drawing.Size(194, 31);
            this.resetpasswordLabel.TabIndex = 0;
            this.resetpasswordLabel.Text = "Reset Password";
            // 
            // newpasswordLabel
            // 
            this.newpasswordLabel.AutoSize = true;
            this.newpasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newpasswordLabel.Location = new System.Drawing.Point(120, 156);
            this.newpasswordLabel.Name = "newpasswordLabel";
            this.newpasswordLabel.Size = new System.Drawing.Size(139, 20);
            this.newpasswordLabel.TabIndex = 1;
            this.newpasswordLabel.Text = "New Password:";
            // 
            // confirmpasswordLabel
            // 
            this.confirmpasswordLabel.AutoSize = true;
            this.confirmpasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpasswordLabel.Location = new System.Drawing.Point(90, 236);
            this.confirmpasswordLabel.Name = "confirmpasswordLabel";
            this.confirmpasswordLabel.Size = new System.Drawing.Size(169, 20);
            this.confirmpasswordLabel.TabIndex = 2;
            this.confirmpasswordLabel.Text = "Confirm Password:";
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Location = new System.Drawing.Point(294, 356);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(180, 50);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // newpasswordTextBox
            // 
            this.newpasswordTextBox.Location = new System.Drawing.Point(286, 154);
            this.newpasswordTextBox.Name = "newpasswordTextBox";
            this.newpasswordTextBox.Size = new System.Drawing.Size(252, 22);
            this.newpasswordTextBox.TabIndex = 4;
            // 
            // confirmpasswordTextBox
            // 
            this.confirmpasswordTextBox.Location = new System.Drawing.Point(286, 234);
            this.confirmpasswordTextBox.Name = "confirmpasswordTextBox";
            this.confirmpasswordTextBox.Size = new System.Drawing.Size(252, 22);
            this.confirmpasswordTextBox.TabIndex = 5;
            // 
            // ResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.confirmpasswordTextBox);
            this.Controls.Add(this.newpasswordTextBox);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.confirmpasswordLabel);
            this.Controls.Add(this.newpasswordLabel);
            this.Controls.Add(this.resetpasswordLabel);
            this.Name = "ResetPasswordForm";
            this.Text = "ResetPasswordForm";
            this.Load += new System.EventHandler(this.ResetPasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resetpasswordLabel;
        private System.Windows.Forms.Label newpasswordLabel;
        private System.Windows.Forms.Label confirmpasswordLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TextBox newpasswordTextBox;
        private System.Windows.Forms.TextBox confirmpasswordTextBox;
    }
}