namespace Lab4
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
            this.Hints = new System.Windows.Forms.CheckBox();
            this.Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Hints
            // 
            this.Hints.AutoSize = true;
            this.Hints.Location = new System.Drawing.Point(38, 36);
            this.Hints.Name = "Hints";
            this.Hints.Size = new System.Drawing.Size(72, 24);
            this.Hints.TabIndex = 0;
            this.Hints.Text = "Hints";
            this.Hints.UseVisualStyleBackColor = true;
            this.Hints.CheckedChanged += new System.EventHandler(this.Hints_CheckedChanged);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(152, 31);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(121, 32);
            this.Clear.TabIndex = 1;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 944);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Hints);
            this.Name = "Form1";
            this.Text = "Eight Queens by Hannah Hebert";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Hints;
        private System.Windows.Forms.Button Clear;
    }
}

