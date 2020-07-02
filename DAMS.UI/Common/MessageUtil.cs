using DAMS.Common;
using DAMS.UI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace DAMS.UI.Common
{
    public class MessageUtil
    {
        #region 消息提示框
        /// <summary>
        /// 消息提示框
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="messagetype"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static DialogResult ShowMessage(string strMessage, EnumData.MessageType messagetype, Control parent = null)
        {
            try
            {
                switch (messagetype)
                {
                    case EnumData.MessageType.Error:
                        return ShowErrorMessage(strMessage, parent);
                    case EnumData.MessageType.Information:
                        ShowDesktopAlertMessage(strMessage, parent);
                        return DialogResult.OK;
                    case EnumData.MessageType.Warning:
                        return ShowWarningMessage(strMessage, parent);
                    case EnumData.MessageType.Ask:
                        return ShowAskMessage(strMessage, parent);
                    case EnumData.MessageType.Confirm:
                        return ShowConfirmMessage(strMessage, parent);
                    case EnumData.MessageType.DialogInfo:
                        return ShowDialogInfoMessage(strMessage, parent);
                    default:
                        return DialogResult.Yes;
                }
            }
            catch
            {
                return DialogResult.Yes;
            }
        }

        /// <summary>
        /// 错误消息提示框
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private static DialogResult ShowErrorMessage(string strMessage, Control parent)
        {
            if (parent != null && parent.InvokeRequired)
            {
                Func<Control, string, string, MessageBoxButtons, RadMessageIcon, DialogResult> fun = new Func<Control, string, string, MessageBoxButtons, RadMessageIcon, DialogResult>(RadMessageBox.Show);

                object obj = parent.Invoke(fun, parent, strMessage, "错误提示", MessageBoxButtons.OK, RadMessageIcon.Error);

                return (DialogResult)obj;
            }
            else
            {
                if (parent == null)
                    return RadMessageBox.Show(strMessage, "错误提示", MessageBoxButtons.OK, RadMessageIcon.Error);
                else
                    return RadMessageBox.Show(parent, strMessage, "错误提示", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        /// <summary>
        /// 警告消息提示框
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private static DialogResult ShowWarningMessage(string strMessage, Control parent)
        {
            //return RadMessageBox.Show(parent, strMessage, "警告消息提示", MessageBoxButtons.OK, RadMessageIcon.Exclamation);

            if (parent != null && parent.InvokeRequired)
            {
                Func<Control, string, string, MessageBoxButtons, RadMessageIcon, DialogResult> fun = new Func<Control, string, string, MessageBoxButtons, RadMessageIcon, DialogResult>(RadMessageBox.Show);

                object obj = parent.Invoke(fun, parent, strMessage, "警告消息提示", MessageBoxButtons.OK, RadMessageIcon.Exclamation);

                return (DialogResult)obj;
            }
            else
            {
                if (parent == null)
                    return RadMessageBox.Show(strMessage, "警告消息提示", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                else
                    return RadMessageBox.Show(parent, strMessage, "警告消息提示", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            }
        }

        /// <summary>
        /// 确认消息提示框
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private static DialogResult ShowConfirmMessage(string strMessage, Control parent)
        {
            //return RadMessageBox.Show(parent, strMessage, "确认消息提示", MessageBoxButtons.YesNo, RadMessageIcon.Question);

            if (parent != null && parent.InvokeRequired)
            {
                Func<Control, string, string, MessageBoxButtons, RadMessageIcon, DialogResult> fun = new Func<Control, string, string, MessageBoxButtons, RadMessageIcon, DialogResult>(RadMessageBox.Show);

                object obj = parent.Invoke(fun, parent, strMessage, "确认消息提示", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                return (DialogResult)obj;
            }
            else
            {
                if (parent == null)
                    return RadMessageBox.Show(strMessage, "确认消息提示", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                else
                    return RadMessageBox.Show(parent, strMessage, "确认消息提示", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            }
        }

        private static DialogResult ShowDialogInfoMessage(string strMessage, Control parent)
        {
            //return RadMessageBox.Show(parent, strMessage, "消息提示", MessageBoxButtons.OK, RadMessageIcon.Info);

            if (parent != null && parent.InvokeRequired)
            {
                Func<Control, string, string, MessageBoxButtons, RadMessageIcon, DialogResult> fun = new Func<Control, string, string, MessageBoxButtons, RadMessageIcon, DialogResult>(RadMessageBox.Show);

                object obj = parent.Invoke(fun, parent, strMessage, "消息提示", MessageBoxButtons.OK, RadMessageIcon.Info);

                return (DialogResult)obj;
            }
            else
            {
                if (parent == null)
                    return RadMessageBox.Show(strMessage, "消息提示", MessageBoxButtons.OK, RadMessageIcon.Info);
                else
                    return RadMessageBox.Show(parent, strMessage, "消息提示", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        /// <summary>
        /// 询问消息提示框
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private static DialogResult ShowAskMessage(string strMessage, Control parent)
        {
            //return RadMessageBox.Show(parent, strMessage, "询问消息提示框", MessageBoxButtons.YesNoCancel, RadMessageIcon.Question);

            if (parent != null && parent.InvokeRequired)
            {
                Func<Control, string, string, MessageBoxButtons, RadMessageIcon, DialogResult> fun = new Func<Control, string, string, MessageBoxButtons, RadMessageIcon, DialogResult>(RadMessageBox.Show);

                object obj = parent.Invoke(fun, parent, strMessage, "询问消息提示框", MessageBoxButtons.YesNoCancel, RadMessageIcon.Question);

                return (DialogResult)obj;
            }
            else
            {
                if (parent == null)
                    return RadMessageBox.Show(strMessage, "询问消息提示框", MessageBoxButtons.YesNoCancel, RadMessageIcon.Question);
                else
                    return RadMessageBox.Show(parent, strMessage, "询问消息提示框", MessageBoxButtons.YesNoCancel, RadMessageIcon.Question);
            }
        }
        //声明一个弹出框的委托
        public delegate void ActionDelegate(string message,Control parent);
        public static void ShowDesktopAlertMessage(string message, Control parent)
        {
            if (parent != null && parent.InvokeRequired)
            {
                parent.Invoke(new ActionDelegate(delegate(string s,  Control p)
                {
                    var alert = new RadDesktopAlert();
                    alert.ShowOptionsButton = true;
                    alert.ShowPinButton = false;
                    alert.ThemeName = "Office2010Blue";
                    alert.CaptionText = "消息提示";
                    alert.ContentImage = Resources.flat_inform_2525;
                    alert.ContentText = message;
                    alert.Show();
                }), message, parent);
            }
            else
            {
                var alert = new RadDesktopAlert();
                alert.ShowOptionsButton = true;
                alert.ShowPinButton = false;
                alert.ThemeName = "Office2010Blue";
                alert.CaptionText = "消息提示";
                alert.ContentImage = Resources.flat_inform_2525;
                alert.ContentText = message;
                alert.Show();
            }
        }
        #endregion
    }
}
