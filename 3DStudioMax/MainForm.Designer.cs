namespace _DStudioMax
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alphablendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anisotropingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelVertexShaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dxControl = new _DStudioMax.DXControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(671, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTextureToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openTextureToolStripMenuItem
            // 
            this.openTextureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textureToolStripMenuItem,
            this.objectToolStripMenuItem});
            this.openTextureToolStripMenuItem.Name = "openTextureToolStripMenuItem";
            this.openTextureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openTextureToolStripMenuItem.Text = "&Open";
            // 
            // textureToolStripMenuItem
            // 
            this.textureToolStripMenuItem.Name = "textureToolStripMenuItem";
            this.textureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.textureToolStripMenuItem.Text = "Texture";
            this.textureToolStripMenuItem.Click += new System.EventHandler(this.textureToolStripMenuItem_Click);
            // 
            // objectToolStripMenuItem
            // 
            this.objectToolStripMenuItem.Name = "objectToolStripMenuItem";
            this.objectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.objectToolStripMenuItem.Text = "Object";
            this.objectToolStripMenuItem.Click += new System.EventHandler(this.objectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alphablendToolStripMenuItem,
            this.shadingToolStripMenuItem,
            this.anisotropingToolStripMenuItem,
            this.pixelVertexShaderToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // alphablendToolStripMenuItem
            // 
            this.alphablendToolStripMenuItem.CheckOnClick = true;
            this.alphablendToolStripMenuItem.Name = "alphablendToolStripMenuItem";
            this.alphablendToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.alphablendToolStripMenuItem.Text = "Alphablend";
            this.alphablendToolStripMenuItem.CheckedChanged += new System.EventHandler(this.alphablendToolStripMenuItem_CheckedChanged);
            // 
            // shadingToolStripMenuItem
            // 
            this.shadingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flatToolStripMenuItem,
            this.phongToolStripMenuItem,
            this.guardToolStripMenuItem});
            this.shadingToolStripMenuItem.Name = "shadingToolStripMenuItem";
            this.shadingToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.shadingToolStripMenuItem.Text = "Shading";
            // 
            // flatToolStripMenuItem
            // 
            this.flatToolStripMenuItem.Name = "flatToolStripMenuItem";
            this.flatToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.flatToolStripMenuItem.Text = "Flat";
            this.flatToolStripMenuItem.Click += new System.EventHandler(this.flatToolStripMenuItem_Click);
            // 
            // phongToolStripMenuItem
            // 
            this.phongToolStripMenuItem.Name = "phongToolStripMenuItem";
            this.phongToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.phongToolStripMenuItem.Text = "Phong";
            this.phongToolStripMenuItem.Click += new System.EventHandler(this.phongToolStripMenuItem_Click);
            // 
            // guardToolStripMenuItem
            // 
            this.guardToolStripMenuItem.Name = "guardToolStripMenuItem";
            this.guardToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.guardToolStripMenuItem.Text = "Gouraud";
            this.guardToolStripMenuItem.Click += new System.EventHandler(this.guardToolStripMenuItem_Click);
            // 
            // anisotropingToolStripMenuItem
            // 
            this.anisotropingToolStripMenuItem.Name = "anisotropingToolStripMenuItem";
            this.anisotropingToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.anisotropingToolStripMenuItem.Text = "Anisotroping";
            this.anisotropingToolStripMenuItem.Click += new System.EventHandler(this.anisotropingToolStripMenuItem_Click);
            // 
            // pixelVertexShaderToolStripMenuItem
            // 
            this.pixelVertexShaderToolStripMenuItem.Name = "pixelVertexShaderToolStripMenuItem";
            this.pixelVertexShaderToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.pixelVertexShaderToolStripMenuItem.Text = "Pixel & vertex Shader";
            this.pixelVertexShaderToolStripMenuItem.Click += new System.EventHandler(this.pixelVertexShaderToolStripMenuItem_Click);
            // 
            // dxControl
            // 
            this.dxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dxControl.Location = new System.Drawing.Point(0, 24);
            this.dxControl.Name = "dxControl";
            this.dxControl.Size = new System.Drawing.Size(671, 493);
            this.dxControl.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 517);
            this.Controls.Add(this.dxControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "3D Studio Max ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private DXControl dxControl;
        private System.Windows.Forms.ToolStripMenuItem openTextureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphablendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anisotropingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelVertexShaderToolStripMenuItem;
    }
}

