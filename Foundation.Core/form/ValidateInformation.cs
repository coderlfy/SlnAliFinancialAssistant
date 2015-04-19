using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Fundation.Core
{
    class ValidateInformation
    {
        public string Content = "";
        public ValidateType ValidType = ValidateType.None;
        public string Subject = "";
        public Control WillValidateControl = null;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsNotEmpty()
        {
            #region
            string message = string.Format("{0}的内容不能为空", this.Subject);
            return valid(() =>
            {
                return (string.IsNullOrEmpty(this.Content));
            }, message);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsNumber()
        {
            #region
            string message = string.Format("{0}必须为数字", this.Subject);
            return valid(() =>
            {
                int tmp = 0;
                return (!int.TryParse(this.Content, out tmp));
            }, message);
            #endregion
        }

        private delegate bool DLIsValid();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fun"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool valid(DLIsValid fun, string message)
        {
            #region
            if (fun())
            {
                ExtMessage.Show(message);
                this.WillValidateControl.Focus();
                return false;
            }
            return true;
            #endregion
        }
    }
}
