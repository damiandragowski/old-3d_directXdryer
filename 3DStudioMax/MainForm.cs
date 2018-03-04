using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.Direct3D;

namespace _DStudioMax
{
    public partial class MainForm : Form
    {
        public bool bIsClosing = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void InvokeRender()
        {
            dxControl.Refresh();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
		    bIsClosing = true;
        }

        private void textureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.DefaultExt = "*.txt";
            if (opfd.ShowDialog() == DialogResult.OK)
                dxControl.LoadTexture(opfd.FileName);
        }

        private void alphablendToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            dxControl.alpha = !dxControl.alpha;
        }

        private void flatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dxControl.device.RenderState.ShadeMode = ShadeMode.Flat;
            phongToolStripMenuItem.Checked = false;
            guardToolStripMenuItem.Checked = false;
        }

        private void phongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dxControl.device.RenderState.ShadeMode = ShadeMode.Phong;
            flatToolStripMenuItem.Checked = false;
            guardToolStripMenuItem.Checked = false;
        }

        private void guardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dxControl.device.RenderState.ShadeMode = ShadeMode.Gouraud;
            flatToolStripMenuItem.Checked = false;
            phongToolStripMenuItem.Checked = false;
        }

        private void anisotropingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anisotropingToolStripMenuItem.Checked = !anisotropingToolStripMenuItem.Checked;
            if (anisotropingToolStripMenuItem.Checked)
            {
                dxControl.device.SamplerState[0].MinFilter = TextureFilter.Anisotropic;
                dxControl.device.SamplerState[0].MagFilter = TextureFilter.Anisotropic;

                dxControl.device.SamplerState[0].AddressU = TextureAddress.Mirror;
                dxControl.device.SamplerState[0].AddressV = TextureAddress.Mirror;
            }
            else
            {
                dxControl.device.SamplerState[0].MinFilter = TextureFilter.None;
                dxControl.device.SamplerState[0].MagFilter = TextureFilter.None;
            }
            
        }

        private void pixelVertexShaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dxControl.vertexpixelshader = !dxControl.vertexpixelshader;
            pixelVertexShaderToolStripMenuItem.Checked = !pixelVertexShaderToolStripMenuItem.Checked;
        }

        private void objectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.DefaultExt = "*.txt";
            if (opfd.ShowDialog() == DialogResult.OK)
                dxControl.LoadSusz(opfd.FileName);
        }

    }
}