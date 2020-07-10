using System;
using System.Linq;
using System.Windows.Forms;
using DAMS.UI.Views;
using DAMS.Models.Initialize;
using DAMS.UI.Common;
using DAMS.Common;

namespace DAMS.UI
{
    static class Program
    {
        private static System.Threading.Mutex mutex;

        private static IndexForm indexForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DatabaseInitializer.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mutex = new System.Threading.Mutex(true, "DAMSRUNONLY");
            if (mutex.WaitOne(0, false))
            {
                LoginForm loginForm = new LoginForm();//加载登录窗体
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    indexForm = new IndexForm();
                    Application.Run(indexForm);//如果登录成功则打开主窗体
                }
            }

            else
            {
                MessageUtil.ShowMessage("程序已经在运行！", EnumData.MessageType.Warning);
                Application.Exit();
            }
        }
    }
}