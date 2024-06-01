using System;
using System.Windows.Forms;

namespace ProcessManager
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
            Application.Run(new ProcessViewForm()); // Start the application with ProcessViewForm
        }
    }
}
