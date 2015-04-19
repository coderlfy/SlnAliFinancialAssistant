
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Fundation.Core
{
    
    public class FormVerifier
    {
        private List<ValidateInformation> _validateList = new List<ValidateInformation>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="subject"></param>
        public string AddTextBoxNotEmpty(TextBox tb
            , string subject)
        {
            #region
            ValidateInformation obj = new ValidateInformation();
            obj.Content = tb.Text.Trim();
            obj.ValidType = ValidateType.NotEmpty;
            obj.Subject = subject;
            obj.WillValidateControl = tb;
            _validateList.Add(obj);

            return obj.Content;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="subject"></param>
        public string AddComboboxNotEmpty(ComboBox cb
            , string subject)
        {
            #region
            ValidateInformation obj = new ValidateInformation();
            obj.Content = cb.SelectedValue.ToString();
            obj.ValidType = ValidateType.NotEmpty;
            obj.Subject = subject;
            obj.WillValidateControl = cb;

            _validateList.Add(obj);
            return obj.Content;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="subject"></param>
        public string AddIsNumber(TextBox tb
            , string subject)
        {
            #region
            ValidateInformation obj = new ValidateInformation();
            obj.Content = tb.Text.Trim();
            obj.ValidType = ValidateType.IsNumber;
            obj.Subject = subject;
            obj.WillValidateControl = tb;

            _validateList.Add(obj);
            return obj.Content;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <param name="subject"></param>
        public void AddNumberLengthLimit(TextBox tb
            , int minLength, int maxLength
            , string subject)
        {
            #region
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            #region
            foreach (ValidateInformation validateinfor 
                in _validateList)
            {
                switch (validateinfor.ValidType)
                { 
                    case ValidateType.NotEmpty:
                        if (!validateinfor.IsNotEmpty()) return false;
                        break;
                    case ValidateType.IsNumber:
                        if (!validateinfor.IsNumber()) return false;
                        break;
                    default:
                        break;
                }
            }
            return true;
            #endregion
        }
    }
}
