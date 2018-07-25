using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBDC.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin f = new FrmLogin();
            //以模式对话框方式打开
            if (f.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FrmBBDC());
            }
            //Application.Run(new FrmGame());
        }
    }
}
