/* ----------------------------------- File Header -------------------------------------------*
	File				:	MsgBox.cs
	Project Code		:	
	Author	    		:	Nhan Tran
	Created On	    	:	15/12/2007 
	Last Modified	   	:	15/12/2007 
----------------------------------------------------------------------------------------------*
	Type				:	c sharp file
	Description			:   Hàm tiện ích xuất hiện hộp thoại thông báo
	Developer's Note	:	
	Bugs				:	
	See Also			:	
	Revision History	:	
	Traceability        :	
	Necessary Files		:	
---------------------------------------------------------------------------------------------*/


using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.Collections.Generic;
using System.Drawing;

using DevExpress.XtraLayout.ViewInfo;
using Lotus.Libraries;
using Lotus.Base;

namespace Lotus
{
    public static class MsgBox
    {
        public static void OpenDialog<T>() where T : Form
        {
            ShowWaitForm();

            var f = Activator.CreateInstance<T>();
            f.ShowInTaskbar = false;
            f.MinimizeBox = false;
            if (HeThong.DaNgonNgu)
                LanguageHelper.Translate(f);
            CloseWaitForm();

            f.ShowDialog();

            f.Dispose();
        }

        public static void Binding(this BaseEdit editor, object source, string dataMember)
        {
            editor.DataBindings.Clear();
            editor.DataBindings.Add("EditValue", source, dataMember);
        }

        public static DialogResult OpenDialog<T>(object arg) where T : Form
        {
            ShowWaitForm();
            try
            {
                var f = Activator.CreateInstance(typeof(T), arg) as T;
                f.ShowInTaskbar = false;
                f.MinimizeBox = false;
                CloseWaitForm();
                if (HeThong.DaNgonNgu)
                    LanguageHelper.Translate(f);
                f.ShowDialog();

                return f.DialogResult;
            }
            catch 
            {
                return DialogResult.Cancel;
            }
        }

        #region Dialog Message

        /// <summary>
        ///     Hiện msg box (yes/no)
        /// </summary>
        /// <param name="text">Nội dung cần thông báo</param>
        /// <returns>DialogResult</returns>
        public static DialogResult ShowYesNoDialog(string text)
        {
            string s = "Xác nhận";
            if (HeThong.DaNgonNgu)
            {
                text = LanguageHelper.TranslateMsgString(text, text);
                s = LanguageHelper.TranslateMsgString(s, s);
            }

            return XtraMessageBox.Show(text, s, MessageBoxButtons.YesNo, MessageBoxIcon.Question, DevExpress.Utils.DefaultBoolean.True);
        }
        public static DialogResult ShowYesNoDialog(string text, bool translate)
        {
            string s = "Xác nhận";
            if (translate)
            {
                text = LanguageHelper.TranslateMsgString(text, text);
                s = LanguageHelper.TranslateMsgString(s, s);
            }

            return XtraMessageBox.Show(text, s, MessageBoxButtons.YesNo, MessageBoxIcon.Question, DevExpress.Utils.DefaultBoolean.True);
        }

        /// <summary>
        ///     Hiện msg box thông báo thao tác thành công
        /// </summary>
        /// <param name="message">Lưu/Xóa/Sửa/...</param>
        /// <returns>DialogResult</returns>
        public static DialogResult ShowSuccessfulDialog(string text)
        {
            string s = "Thông báo";
            if (HeThong.DaNgonNgu)
            {
                text = LanguageHelper.TranslateMsgString(text, text);
                s = LanguageHelper.TranslateMsgString(s, s);
            }

            return XtraMessageBox.Show(text, s, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowSuccessfulDialog(string text, bool translate)
        {
            string s = "Thông báo";
            if (translate)
                text = LanguageHelper.TranslateMsgString(text, text);

            return XtraMessageBox.Show(text, s, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        ///     Hiện msg box thông báo thao tác không thành công
        /// </summary>
        /// <param name="action">Lưu/Xóa/Sửa/...</param>
        /// <returns>DialogResult</returns>
        public static DialogResult ShowUnsuccessfulDialog(string text)
        {
            string s = "Thông báo";
            if (HeThong.DaNgonNgu)
            {
                text = LanguageHelper.TranslateMsgString(text, text);
                s = LanguageHelper.TranslateMsgString(s, s);
            }

            return XtraMessageBox.Show(text, s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        ///     Hiện msg box thông báo lỗi
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult ShowErrorDialog(string text)
        {
            if (text.Contains("Cannot delete or update a parent row: a foreign key constraint fails")
                || text.Contains("includes related records")
                || text.Contains("violation of FOREIGN KEY constraint")
                || text.Contains("DELETE statement conflicted with the REFERENCE constraint"))
                text = "Không thể xóa dữ liệu quan hệ";
            else if (text.Contains("Unable to open database"))
                text = "Không thể kết nối CSDL";
            else if (text.Contains("cannot open or write to the file"))
                text = "Tập tin đang được sử dụng bởi chương trình khác";
            else if (text.Contains("These columns don't currently have unique values"))
                text = "Dữ liệu trùng";


            if (HeThong.DaNgonNgu)
                text = LanguageHelper.TranslateMsgString(text, text);

            return XtraMessageBox.Show(text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult ShowErrorDialog(string text, bool translate)
        {
            if (text.Contains("Cannot delete or update a parent row: a foreign key constraint fails")
                || text.Contains("includes related records")
                || text.Contains("violation of FOREIGN KEY constraint")
                || text.Contains("DELETE statement conflicted with the REFERENCE constraint"))
                text = "Không thể xóa dữ liệu quan hệ";
            else if (text.Contains("Unable to open database"))
                text = "Không thể kết nối CSDL";
            else if (text.Contains("cannot open or write to the file"))
                text = "Tập tin đang được sử dụng bởi chương trình khác";
            else if (text.Contains("These columns don't currently have unique values"))
                text = "Dữ liệu trùng";

            string s = "Thông báo";
            if (HeThong.DaNgonNgu && translate)
            {
                text = LanguageHelper.TranslateMsgString(text, text);
                s = LanguageHelper.TranslateMsgString(s, s);
            }
            return XtraMessageBox.Show(text, s, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        ///     Hiện msg box cảnh báo
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult ShowWarningDialog(string text)
        {
            string s = "Thông báo";
            if (HeThong.DaNgonNgu)
            {
                text = LanguageHelper.TranslateMsgString(text, text);
                s = LanguageHelper.TranslateMsgString(s, s);
            }

            return XtraMessageBox.Show(text, s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowYesNoCancelDialog(string text)
        {
            string s = "Xác nhận";
            if (HeThong.DaNgonNgu)
            {
                text = LanguageHelper.TranslateMsgString(text, text);
                s = LanguageHelper.TranslateMsgString(s, s);
            }

            return XtraMessageBox.Show(text, s, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static DialogResult ShowYesNoCancelDialog(string caption, string text)
        {
            if (HeThong.DaNgonNgu)
                text = LanguageHelper.TranslateMsgString(text, text);

            return XtraMessageBox.Show(text, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }


        public struct DialogButton
        {
            public DialogResult Button;
            public string ButtonText;
        }

        /// <summary>
        /// HIỆN HỘP THOẠI VỚI CÁC NÚT TỰ ĐIỀU CHỈNH
        /// </summary>
        /// <param name="text">Nội dung thông báo</param>
        /// <param name="caption">Tiêu đề thông báo</param>
        /// <param name="icon">System.Drawing.SystemIcons (Icon)</param>
        /// <param name="buttons">Nút muốn hiện thị (nút, giá trị)</param>
        /// <returns>DialogResult</returns>
        public static DialogResult ShowCustomBox(string text,string caption, Icon icon, params DialogButton[] buttons)
        {
            DialogResult[] b = new DialogResult[buttons.Length];
            for (int i = 0; i < buttons.Length; i++)
                b[i] = buttons[i].Button;

            if (HeThong.DaNgonNgu)
            {
                text = LanguageHelper.TranslateMsgString(text, text);
                caption = LanguageHelper.TranslateMsgString(caption, caption);
            }

            var f = new Libraries.CustomBox(buttons);
            return f.ShowMessageBoxDialog(new DevExpress.XtraEditors.XtraMessageBoxArgs(
                Application.OpenForms[0]
                , text
                , caption
                , b
                , icon
                , 0));
        }



        #endregion

        #region WaitForm

        public static void ShowWaitForm()
        {
            if (SplashScreenManager.Default != null) return;
            SplashScreenManager.ShowForm(typeof (FrmWait));
        }

        public static void ShowWaitForm<T>()
        {
            if (SplashScreenManager.Default != null) return;
            SplashScreenManager.ShowForm(typeof (T));
        }


        public static void ShowWaitForm(string description)
        {
            if (SplashScreenManager.Default != null)
                if (SplashScreenManager.Default.IsSplashFormVisible)
                {
                    if (HeThong.DaNgonNgu)
                        description = LanguageHelper.TranslateMsgString(description, description);

                    SplashScreenManager.Default.SetWaitFormDescription(description);
                    return;
                }
            SplashScreenManager.ShowForm(typeof (FrmWait));
            if (SplashScreenManager.Default != null) SplashScreenManager.Default.SetWaitFormDescription(description);
        }

        public static void ShowWaitForm(string description, Form parentForm)
        {
            if (SplashScreenManager.Default != null)
                if (SplashScreenManager.Default.IsSplashFormVisible)
                {
                    if (HeThong.DaNgonNgu)
                        description = LanguageHelper.TranslateMsgString(description, description);

                    SplashScreenManager.Default.SetWaitFormDescription(description);
                    return;
                }

            SplashScreenManager.ShowForm(parentForm, typeof (FrmWait));
            if (SplashScreenManager.Default != null) SplashScreenManager.Default.SetWaitFormDescription(description);
        }

        public static void SetWaitFormDescription(string description)
        {
            if (HeThong.DaNgonNgu)
                description = LanguageHelper.TranslateMsgString(description, description);

            if (SplashScreenManager.Default != null)
                if (SplashScreenManager.Default.IsSplashFormVisible)
                    SplashScreenManager.Default.SetWaitFormDescription(description);
        }

        public static void CloseWaitForm()
        {
            if (SplashScreenManager.Default != null)
                if (SplashScreenManager.Default.IsSplashFormVisible)
                {
                    SplashScreenManager.CloseForm();
                }
        }

        #endregion

        #region SplashForm

        public static void ShowSplashForm()
        {
            if (SplashScreenManager.Default != null) return;
            SplashScreenManager.ShowForm(typeof (FrmSplash));
        }

        public static void ShowSplashForm(string description)
        {
            if (SplashScreenManager.Default != null && SplashScreenManager.Default.IsSplashFormVisible)
            {
                if (HeThong.DaNgonNgu)
                    description = LanguageHelper.TranslateMsgString(description, description);

                SplashScreenManager.Default.SendCommand(null, description);
                return;
            }
            SplashScreenManager.ShowForm(typeof (FrmSplash));
        }

        public static void CloseSplashForm()
        {
            if (SplashScreenManager.Default != null)
                SplashScreenManager.CloseForm();
        }

        #endregion
    }


}