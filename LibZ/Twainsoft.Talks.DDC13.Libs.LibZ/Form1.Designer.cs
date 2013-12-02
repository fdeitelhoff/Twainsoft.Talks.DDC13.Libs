namespace Twainsoft.Talks.DDC13.Libs.LibZ
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
            this.doIt = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // doIt
            // 
            this.doIt.Location = new System.Drawing.Point(12, 12);
            this.doIt.Name = "doIt";
            this.doIt.Size = new System.Drawing.Size(75, 23);
            this.doIt.TabIndex = 1;
            this.doIt.Text = "DoIt";
            this.doIt.UseVisualStyleBackColor = true;
            this.doIt.Click += new System.EventHandler(this.doIt_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 41);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(420, 239);
            this.textBox.TabIndex = 2;
            this.textBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 292);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.doIt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button doIt;
        private System.Windows.Forms.RichTextBox textBox;
    }
}

