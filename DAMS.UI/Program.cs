using System;
using System.Linq;
using System.Windows.Forms;
using DAMS.UI.Views;
using DAMS.Models.Initialize;
using DAMS.UI.Common;

namespace DAMS.UI
{
    static class Program
    {
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
            //Application.Run(new LoginForm());
            LoginForm loginForm = new LoginForm();//加载登录窗体
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                //Open your main form here
                //MessageBox.Show("Logged in successfully!");
                indexForm = new IndexForm();
                Application.Run(indexForm);//如果登录成功则打开主窗体
            }
        }
    }
}