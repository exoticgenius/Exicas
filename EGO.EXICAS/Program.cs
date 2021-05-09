using EGO.SolidUI;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EGO.EXICAS
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SolidSettings.DarkTheme = true;
            SolidSettings.ThemeColor = Color.LightSteelBlue;
            Core core = new Core();

            Application.Run(new Main(core));
        }
    }
}
