namespace OpenTKControlGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.glControl1 = new OpenTK.GLControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.zoomInTool = new System.Windows.Forms.ToolStripButton();
            this.zoomOutTool = new System.Windows.Forms.ToolStripButton();
            this.resetTool = new System.Windows.Forms.ToolStripButton();
            this.handTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gridToolComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageOutlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(0, 52);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1282, 526);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1306, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageToolStripMenuItem,
            this.PrintToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // PrintToolStripMenuItem
            // 
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.PrintToolStripMenuItem.Text = "Print";
            this.PrintToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.saveImageToolStripMenuItem.Text = "Save";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInTool,
            this.zoomOutTool,
            this.resetTool,
            this.handTool,
            this.toolStripSeparator1,
            this.gridToolComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1306, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // zoomInTool
            // 
            this.zoomInTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInTool.Image = ((System.Drawing.Image)(resources.GetObject("zoomInTool.Image")));
            this.zoomInTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInTool.Name = "zoomInTool";
            this.zoomInTool.Size = new System.Drawing.Size(23, 22);
            this.zoomInTool.Text = "Zoom in";
            this.zoomInTool.Click += new System.EventHandler(this.zoomInTool_Click);
            // 
            // zoomOutTool
            // 
            this.zoomOutTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutTool.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutTool.Image")));
            this.zoomOutTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutTool.Name = "zoomOutTool";
            this.zoomOutTool.Size = new System.Drawing.Size(23, 22);
            this.zoomOutTool.Text = "Zoom out";
            this.zoomOutTool.Click += new System.EventHandler(this.zoomOutTool_Click);
            // 
            // resetTool
            // 
            this.resetTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resetTool.Image = ((System.Drawing.Image)(resources.GetObject("resetTool.Image")));
            this.resetTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetTool.Name = "resetTool";
            this.resetTool.Size = new System.Drawing.Size(23, 22);
            this.resetTool.Text = "Reset";
            this.resetTool.Click += new System.EventHandler(this.resetTool_Click);
            // 
            // handTool
            // 
            this.handTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.handTool.Image = ((System.Drawing.Image)(resources.GetObject("handTool.Image")));
            this.handTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.handTool.Name = "handTool";
            this.handTool.Size = new System.Drawing.Size(23, 22);
            this.handTool.Text = "Move";
            this.handTool.Click += new System.EventHandler(this.handTool_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // gridToolComboBox
            // 
            this.gridToolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gridToolComboBox.DropDownWidth = 121;
            this.gridToolComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gridToolComboBox.Items.AddRange(new object[] {
            "None",
            "16 x 10",
            "14 x 8",
            "14 x 5"});
            this.gridToolComboBox.Name = "gridToolComboBox";
            this.gridToolComboBox.Size = new System.Drawing.Size(80, 25);
            this.gridToolComboBox.ToolTipText = "Select Grid";
            this.gridToolComboBox.SelectedIndexChanged += new System.EventHandler(this.gridToolComboBox_SelectedIndexChanged);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewportToolStripMenuItem,
            this.axisToolStripMenuItem,
            this.pageOutlineToolStripMenuItem,
            this.gridToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // viewportToolStripMenuItem
            // 
            this.viewportToolStripMenuItem.Name = "viewportToolStripMenuItem";
            this.viewportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewportToolStripMenuItem.Text = "Viewport";
            // 
            // axisToolStripMenuItem
            // 
            this.axisToolStripMenuItem.Name = "axisToolStripMenuItem";
            this.axisToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.axisToolStripMenuItem.Text = "Axes";
            // 
            // pageOutlineToolStripMenuItem
            // 
            this.pageOutlineToolStripMenuItem.Name = "pageOutlineToolStripMenuItem";
            this.pageOutlineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pageOutlineToolStripMenuItem.Text = "Page Outline";
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 602);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Form1_Layout);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton zoomInTool;
        private System.Windows.Forms.ToolStripButton zoomOutTool;
        private System.Windows.Forms.ToolStripButton resetTool;
        private System.Windows.Forms.ToolStripButton handTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox gridToolComboBox;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem axisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pageOutlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
    }
}

