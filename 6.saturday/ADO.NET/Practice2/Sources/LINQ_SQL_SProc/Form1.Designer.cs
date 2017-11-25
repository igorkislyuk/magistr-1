namespace LINQ_SQL_SProc
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clientTextField = new System.Windows.Forms.TextBox();
            this.codeTextField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "Order detail";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client code";
            // 
            // clientTextField
            // 
            this.clientTextField.Location = new System.Drawing.Point(241, 204);
            this.clientTextField.Name = "clientTextField";
            this.clientTextField.Size = new System.Drawing.Size(194, 31);
            this.clientTextField.TabIndex = 2;
            // 
            // codeTextField
            // 
            this.codeTextField.Location = new System.Drawing.Point(241, 270);
            this.codeTextField.Name = "codeTextField";
            this.codeTextField.Size = new System.Drawing.Size(194, 31);
            this.codeTextField.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Order code";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(513, 368);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 61);
            this.button2.TabIndex = 3;
            this.button2.Text = "Order history";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 591);
            this.Controls.Add(this.codeTextField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.clientTextField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox clientTextField;
        private System.Windows.Forms.TextBox codeTextField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}

