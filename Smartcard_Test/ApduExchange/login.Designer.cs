namespace TestGemCard
{
    partial class login
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
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.password_input = new System.Windows.Forms.TextBox();
            this.username_input = new System.Windows.Forms.TextBox();
            this.log_box = new System.Windows.Forms.RichTextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label13.Location = new System.Drawing.Point(303, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 39);
            this.label13.TabIndex = 35;
            this.label13.Text = "کلمه عبور:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label15.Location = new System.Drawing.Point(297, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 39);
            this.label15.TabIndex = 34;
            this.label15.Text = "نام کاربری:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // password_input
            // 
            this.password_input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.password_input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_input.Font = new System.Drawing.Font("B Roya", 13.8F);
            this.password_input.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.password_input.Location = new System.Drawing.Point(19, 115);
            this.password_input.Margin = new System.Windows.Forms.Padding(10);
            this.password_input.Name = "password_input";
            this.password_input.PasswordChar = '*';
            this.password_input.Size = new System.Drawing.Size(265, 39);
            this.password_input.TabIndex = 33;
            this.password_input.Text = "cityslicka";
            this.password_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // username_input
            // 
            this.username_input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.username_input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username_input.Font = new System.Drawing.Font("B Roya", 13.8F);
            this.username_input.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.username_input.Location = new System.Drawing.Point(19, 49);
            this.username_input.Margin = new System.Windows.Forms.Padding(10);
            this.username_input.Name = "username_input";
            this.username_input.Size = new System.Drawing.Size(265, 39);
            this.username_input.TabIndex = 29;
            this.username_input.Text = "eve.holt@reqres.in";
            this.username_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // log_box
            // 
            this.log_box.BackColor = System.Drawing.Color.Gray;
            this.log_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.log_box.Location = new System.Drawing.Point(19, 174);
            this.log_box.Margin = new System.Windows.Forms.Padding(10);
            this.log_box.Name = "log_box";
            this.log_box.Size = new System.Drawing.Size(373, 202);
            this.log_box.TabIndex = 24;
            this.log_box.Text = "";
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_btn.Location = new System.Drawing.Point(19, 396);
            this.login_btn.Margin = new System.Windows.Forms.Padding(10);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(373, 58);
            this.login_btn.TabIndex = 15;
            this.login_btn.Text = "ورود";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(411, 473);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.username_input);
            this.Controls.Add(this.log_box);
            this.Controls.Add(this.password_input);
            this.Controls.Add(this.login_btn);
            this.Font = new System.Drawing.Font("B Roya", 13.8F);
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox password_input;
        private System.Windows.Forms.TextBox username_input;
        private System.Windows.Forms.RichTextBox log_box;
        private System.Windows.Forms.Button login_btn;
    }
}