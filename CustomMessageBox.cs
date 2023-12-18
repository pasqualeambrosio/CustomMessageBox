using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomMessageBox
{
    public partial class CustomMessageBox : Form
    {
        private bool closeForm = false;

        public static class CustomMessageDictionay
        {
            public static string btnOk = "Ok";
            public static string btnYes = "Yes";
            public static string btnNo = "No";
            public static string btnCancel = "Cancel";
            public static string btnAbort = "Abort";
            public static string btnRetry = "Retry";
            public static string btnIgnore = "Ignore";
            public static string btnDetails = "Details";
        }

        public class CustomMessageBoxParams
        {
            public string text { get; set; }
            public string caption { get; set; }
            public string details { get; set; }
            public MessageBoxButtons buttons { get; set; }
            public MessageBoxIcon icon { get; set; }
            public MessageBoxDefaultButton buttonsDefault { get; set; }
        }

        public CustomMessageBox()
        {
            InitializeComponent();

            Height -= pnlDetails.Height + 5;

            #region Button text

            btnOk.Text = CustomMessageDictionay.btnOk;
            btnYes.Text = CustomMessageDictionay.btnYes;
            btnNo.Text = CustomMessageDictionay.btnNo;
            btnCancel.Text = CustomMessageDictionay.btnCancel;
            btnAbort.Text = CustomMessageDictionay.btnAbort;
            btnRetry.Text = CustomMessageDictionay.btnRetry;
            btnIgnore.Text = CustomMessageDictionay.btnIgnore;
            btnDetails.Text = CustomMessageDictionay.btnDetails;

            #endregion

            #region Buttons events

            btnOk.Click += (s, e) => { btnClick(s, e, "ok"); };
            btnYes.Click += (s, e) => { btnClick(s, e, "yes"); };
            btnNo.Click += (s, e) => { btnClick(s, e, "no"); };
            btnCancel.Click += (s, e) => { btnClick(s, e, "cancel"); };
            btnAbort.Click += (s, e) => { btnClick(s, e, "abort"); };
            btnRetry.Click += (s, e) => { btnClick(s, e, "retry"); };
            btnIgnore.Click += (s, e) => { btnClick(s, e, "ignore"); };

            #endregion
        }

        private void btnClick(object sender, EventArgs e, string btnType)
        {
            switch (btnType)
            {
                case "ok":
                    DialogResult = DialogResult.OK;
                    break;

                case "yes":
                    DialogResult = DialogResult.Yes;
                    break;

                case "no":
                    DialogResult = DialogResult.No;
                    break;

                case "cancel":
                    DialogResult = DialogResult.Cancel;
                    break;

                case "abort":
                    DialogResult = DialogResult.Abort;
                    break;

                case "retry":
                    DialogResult = DialogResult.Retry;
                    break;

                case "ignore":
                    DialogResult = DialogResult.Ignore;
                    break;
            }

            closeForm = true;
            Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if ((string)btnDetails.Tag == "1")
            {
                btnDetails.Tag = "0";
                Height -= pnlDetails.Height + 5;
            }
            else
            {
                btnDetails.Tag = "1";
                Height += pnlDetails.Height + 5;
            }
        }

        public static DialogResult Show(string text)
        {
            return Show(text, "", "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption)
        {
            return Show(text, caption, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, string details)
        {
            return Show(text, caption, details, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, string details, MessageBoxButtons buttons)
        {
            return Show(text, caption, details, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, string details, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(text, caption, details, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(CustomMessageBoxParams messageBoxParams)
        {
            return Show(messageBoxParams.text,
                        messageBoxParams.caption,
                        messageBoxParams.details,
                        messageBoxParams.buttons,
                        messageBoxParams.icon,
                        messageBoxParams.buttonsDefault);
        }

        public static DialogResult Show(
            string text,
            string caption = "",
            string details = "",
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.None,
            MessageBoxDefaultButton buttonsDefault = MessageBoxDefaultButton.Button1
            )
        {
            CustomMessageBox f = new CustomMessageBox();
            f.Text = caption;
            f.txtText.Text = text;
            f.txtDetails.Text = details;
            f.btnDetails.Visible = !String.IsNullOrEmpty(details);

            #region Buttons

            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    f.btnAbort.Visible = f.btnIgnore.Visible = true;

                    if (buttonsDefault == MessageBoxDefaultButton.Button1)
                        f.btnAbort.Select();

                    if (buttonsDefault == MessageBoxDefaultButton.Button2)
                        f.btnRetry.Select();

                    break;

                case MessageBoxButtons.OK:
                    f.btnOk.Visible = true;

                    if (buttonsDefault == MessageBoxDefaultButton.Button1)
                        f.btnOk.Select();

                    break;

                case MessageBoxButtons.OKCancel:
                    f.btnOk.Visible = f.btnCancel.Visible = true;

                    if (buttonsDefault == MessageBoxDefaultButton.Button1)
                        f.btnOk.Select();

                    if (buttonsDefault == MessageBoxDefaultButton.Button2)
                        f.btnCancel.Select();

                    break;

                case MessageBoxButtons.RetryCancel:
                    f.btnRetry.Visible = f.btnCancel.Visible = true;

                    if (buttonsDefault == MessageBoxDefaultButton.Button1)
                        f.btnRetry.Select();

                    if (buttonsDefault == MessageBoxDefaultButton.Button2)
                        f.btnCancel.Select();
                    break;

                case MessageBoxButtons.YesNo:
                    f.btnYes.Visible = f.btnNo.Visible = true;

                    if (buttonsDefault == MessageBoxDefaultButton.Button1)
                        f.btnYes.Select();

                    if (buttonsDefault == MessageBoxDefaultButton.Button2)
                        f.btnNo.Select();

                    break;

                case MessageBoxButtons.YesNoCancel:
                    f.btnYes.Visible = f.btnNo.Visible = f.btnCancel.Visible = true;

                    if (buttonsDefault == MessageBoxDefaultButton.Button1)
                        f.btnYes.Select();

                    if (buttonsDefault == MessageBoxDefaultButton.Button2)
                        f.btnNo.Select();

                    if (buttonsDefault == MessageBoxDefaultButton.Button3)
                        f.btnCancel.Select();

                    break;
            }

            #endregion

            #region Icon

            switch (icon)
            {
                case MessageBoxIcon.Information:
                    f.imgDialog.Image = SystemIcons.Information.ToBitmap();
                    break;

                case MessageBoxIcon.Warning:
                    f.imgDialog.Image = SystemIcons.Warning.ToBitmap();
                    break;

                case MessageBoxIcon.Error:
                    f.imgDialog.Image = SystemIcons.Error.ToBitmap();
                    break;

                case MessageBoxIcon.Question:
                    f.imgDialog.Image = SystemIcons.Question.ToBitmap();
                    break;

                default:
                    f.imgDialog.Image = SystemIcons.Information.ToBitmap();
                    break;
            }

            #endregion

            f.ShowDialog();
            return f.DialogResult;
        }

        private void CustomMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !closeForm;
        }
    }
}
