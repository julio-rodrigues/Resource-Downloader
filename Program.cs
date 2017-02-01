using Functions;
using System;
using System.Windows.Forms;
using Base.Factories;

namespace ResourceDownloader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoggerFactory.GetLogger().LogInfo("===============================");
            LoggerFactory.GetLogger().LogInfo("ResourceDownloader 1.2.5.0");
            LoggerFactory.GetLogger().LogInfo("===============================");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
        }
    }
}
