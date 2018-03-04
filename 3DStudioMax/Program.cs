using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _DStudioMax
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm frm = new MainForm();
            frm.KeyPreview = true;
            if (!frm.bIsClosing)
            {

                frm.Show();
                while (!frm.IsDisposed)
                {
                    frm.InvokeRender();
                    if (frm.bIsClosing)
                    {
                        frm.Close();
                        Application.Exit();
                    }
                    Application.DoEvents();
                }
            }

        }
    }
}