namespace Lab5
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawChoice = new System.Windows.Forms.Panel();
            this.FillCheckbox = new System.Windows.Forms.CheckBox();
            this.OutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.PenWidthLabel = new System.Windows.Forms.Label();
            this.PenWidth = new System.Windows.Forms.ListBox();
            this.FillColor = new System.Windows.Forms.Label();
            this.FillColorListBox = new System.Windows.Forms.ListBox();
            this.PenColor = new System.Windows.Forms.Label();
            this.PenColorListBox = new System.Windows.Forms.ListBox();
            this.radioButtonGroup = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Line = new System.Windows.Forms.RadioButton();
            this.Textrb = new System.Windows.Forms.RadioButton();
            this.Rectangle = new System.Windows.Forms.RadioButton();
            this.Ellipse = new System.Windows.Forms.RadioButton();
            this.DrawingPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.DrawChoice.SuspendLayout();
            this.radioButtonGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(972, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(136, 30);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(141, 30);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // DrawChoice
            // 
            this.DrawChoice.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DrawChoice.Controls.Add(this.FillCheckbox);
            this.DrawChoice.Controls.Add(this.OutlineCheckbox);
            this.DrawChoice.Controls.Add(this.PenWidthLabel);
            this.DrawChoice.Controls.Add(this.PenWidth);
            this.DrawChoice.Controls.Add(this.FillColor);
            this.DrawChoice.Controls.Add(this.FillColorListBox);
            this.DrawChoice.Controls.Add(this.PenColor);
            this.DrawChoice.Controls.Add(this.PenColorListBox);
            this.DrawChoice.Controls.Add(this.radioButtonGroup);
            this.DrawChoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.DrawChoice.Location = new System.Drawing.Point(0, 33);
            this.DrawChoice.Name = "DrawChoice";
            this.DrawChoice.Size = new System.Drawing.Size(972, 360);
            this.DrawChoice.TabIndex = 1;
            // 
            // FillCheckbox
            // 
            this.FillCheckbox.AutoSize = true;
            this.FillCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FillCheckbox.Location = new System.Drawing.Point(532, 253);
            this.FillCheckbox.Name = "FillCheckbox";
            this.FillCheckbox.Size = new System.Drawing.Size(62, 29);
            this.FillCheckbox.TabIndex = 11;
            this.FillCheckbox.Text = "Fill";
            this.FillCheckbox.UseVisualStyleBackColor = true;
            // 
            // OutlineCheckbox
            // 
            this.OutlineCheckbox.AutoSize = true;
            this.OutlineCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutlineCheckbox.Location = new System.Drawing.Point(532, 223);
            this.OutlineCheckbox.Name = "OutlineCheckbox";
            this.OutlineCheckbox.Size = new System.Drawing.Size(100, 29);
            this.OutlineCheckbox.TabIndex = 10;
            this.OutlineCheckbox.Text = "Outline";
            this.OutlineCheckbox.UseVisualStyleBackColor = true;
            this.OutlineCheckbox.CheckedChanged += new System.EventHandler(this.OutlineCheckbox_CheckedChanged);
            // 
            // PenWidthLabel
            // 
            this.PenWidthLabel.AutoSize = true;
            this.PenWidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PenWidthLabel.Location = new System.Drawing.Point(707, 29);
            this.PenWidthLabel.Name = "PenWidthLabel";
            this.PenWidthLabel.Size = new System.Drawing.Size(103, 25);
            this.PenWidthLabel.TabIndex = 9;
            this.PenWidthLabel.Text = "Pen Width";
            // 
            // PenWidth
            // 
            this.PenWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PenWidth.FormattingEnabled = true;
            this.PenWidth.ItemHeight = 25;
            this.PenWidth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.PenWidth.Location = new System.Drawing.Point(711, 62);
            this.PenWidth.Name = "PenWidth";
            this.PenWidth.Size = new System.Drawing.Size(190, 254);
            this.PenWidth.TabIndex = 8;
            // 
            // FillColor
            // 
            this.FillColor.AutoSize = true;
            this.FillColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FillColor.Location = new System.Drawing.Point(559, 29);
            this.FillColor.Name = "FillColor";
            this.FillColor.Size = new System.Drawing.Size(88, 25);
            this.FillColor.TabIndex = 7;
            this.FillColor.Text = "Fill Color";
            // 
            // FillColorListBox
            // 
            this.FillColorListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FillColorListBox.FormattingEnabled = true;
            this.FillColorListBox.ItemHeight = 25;
            this.FillColorListBox.Items.AddRange(new object[] {
            "White",
            "Black",
            "Red",
            "Blue",
            "Green"});
            this.FillColorListBox.Location = new System.Drawing.Point(563, 62);
            this.FillColorListBox.Name = "FillColorListBox";
            this.FillColorListBox.Size = new System.Drawing.Size(101, 129);
            this.FillColorListBox.TabIndex = 6;
            // 
            // PenColor
            // 
            this.PenColor.AutoSize = true;
            this.PenColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PenColor.Location = new System.Drawing.Point(423, 29);
            this.PenColor.Name = "PenColor";
            this.PenColor.Size = new System.Drawing.Size(99, 25);
            this.PenColor.TabIndex = 5;
            this.PenColor.Text = "Pen Color";
            // 
            // PenColorListBox
            // 
            this.PenColorListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PenColorListBox.FormattingEnabled = true;
            this.PenColorListBox.ItemHeight = 25;
            this.PenColorListBox.Items.AddRange(new object[] {
            "Black",
            "Red",
            "Blue",
            "Green"});
            this.PenColorListBox.Location = new System.Drawing.Point(427, 62);
            this.PenColorListBox.Name = "PenColorListBox";
            this.PenColorListBox.Size = new System.Drawing.Size(91, 104);
            this.PenColorListBox.TabIndex = 4;
            // 
            // radioButtonGroup
            // 
            this.radioButtonGroup.Controls.Add(this.textBox1);
            this.radioButtonGroup.Controls.Add(this.Line);
            this.radioButtonGroup.Controls.Add(this.Textrb);
            this.radioButtonGroup.Controls.Add(this.Rectangle);
            this.radioButtonGroup.Controls.Add(this.Ellipse);
            this.radioButtonGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGroup.Location = new System.Drawing.Point(52, 39);
            this.radioButtonGroup.Name = "radioButtonGroup";
            this.radioButtonGroup.Size = new System.Drawing.Size(328, 269);
            this.radioButtonGroup.TabIndex = 3;
            this.radioButtonGroup.TabStop = false;
            this.radioButtonGroup.Text = "Draw";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 156);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(294, 113);
            this.textBox1.TabIndex = 6;
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Line
            // 
            this.Line.AutoSize = true;
            this.Line.Location = new System.Drawing.Point(34, 36);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(74, 29);
            this.Line.TabIndex = 2;
            this.Line.TabStop = true;
            this.Line.Text = "Line";
            this.Line.UseVisualStyleBackColor = true;
            // 
            // Textrb
            // 
            this.Textrb.AutoSize = true;
            this.Textrb.Location = new System.Drawing.Point(34, 126);
            this.Textrb.Name = "Textrb";
            this.Textrb.Size = new System.Drawing.Size(76, 29);
            this.Textrb.TabIndex = 5;
            this.Textrb.TabStop = true;
            this.Textrb.Text = "Text";
            this.Textrb.UseVisualStyleBackColor = true;
            // 
            // Rectangle
            // 
            this.Rectangle.AutoSize = true;
            this.Rectangle.Location = new System.Drawing.Point(34, 66);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(124, 29);
            this.Rectangle.TabIndex = 3;
            this.Rectangle.TabStop = true;
            this.Rectangle.Text = "Rectangle";
            this.Rectangle.UseVisualStyleBackColor = true;
            // 
            // Ellipse
            // 
            this.Ellipse.AutoSize = true;
            this.Ellipse.Location = new System.Drawing.Point(34, 96);
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.Size = new System.Drawing.Size(94, 29);
            this.Ellipse.TabIndex = 4;
            this.Ellipse.TabStop = true;
            this.Ellipse.Text = "Ellipse";
            this.Ellipse.UseVisualStyleBackColor = true;
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.BackColor = System.Drawing.SystemColors.Window;
            this.DrawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawingPanel.Location = new System.Drawing.Point(0, 0);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(972, 751);
            this.DrawingPanel.TabIndex = 3;
            this.DrawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPanel_Paint);
            this.DrawingPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(74, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 751);
            this.Controls.Add(this.DrawChoice);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.DrawingPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Lab5 - Hannah Hebert Solution";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.DrawChoice.ResumeLayout(false);
            this.DrawChoice.PerformLayout();
            this.radioButtonGroup.ResumeLayout(false);
            this.radioButtonGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.Panel DrawChoice;
        private System.Windows.Forms.GroupBox radioButtonGroup;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton Line;
        private System.Windows.Forms.RadioButton Textrb;
        private System.Windows.Forms.RadioButton Rectangle;
        private System.Windows.Forms.RadioButton Ellipse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox FillCheckbox;
        private System.Windows.Forms.CheckBox OutlineCheckbox;
        private System.Windows.Forms.Label PenWidthLabel;
        private System.Windows.Forms.ListBox PenWidth;
        private System.Windows.Forms.Label FillColor;
        private System.Windows.Forms.ListBox FillColorListBox;
        private System.Windows.Forms.Label PenColor;
        private System.Windows.Forms.ListBox PenColorListBox;
        private System.Windows.Forms.Panel DrawingPanel;
    }
}

