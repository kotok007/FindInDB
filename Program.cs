using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace base_bsmp
{
    static class Program
    {
        public static formFind f3;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formStart());
        }
    }
}
