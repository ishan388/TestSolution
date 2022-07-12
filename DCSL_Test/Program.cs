using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCSL_BusinessLayer;

namespace DCSL_Test
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IDCSL_BL dCSL_BL = new DCSL_BL();
            Application.Run(new Form1(dCSL_BL));
        }
    }
}
