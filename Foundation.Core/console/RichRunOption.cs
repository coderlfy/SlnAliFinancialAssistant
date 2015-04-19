using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Fundation.Core
{
    public class RichRunOption
    {
        private SolidColorBrush _foreground = Brushes.Black;
        private FontFamily _fontFamily = new FontFamily("宋体, Comic Sans MS, Verdana");
        private FontWeight _fontWeight = FontWeights.Normal;
        private int _fontSize = 12;
        /// <summary>
        /// 
        /// </summary>
        public FontWeight _FontWeight
        {
            #region
            get
            {
                return _fontWeight;
            }
            set
            {
                _fontWeight = value;
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public SolidColorBrush _Foreground
        {
            #region
            get
            {
                return _foreground;
            }
            set
            {
                _foreground = value;
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public FontFamily _FontFamily
        {
            #region
            get
            {
                return _fontFamily;
            }
            set
            {
                _fontFamily = value;
            }
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        public int _FontSize
        {
            #region
            get
            {
                return _fontSize;
            }
            set
            {
                _fontSize = value;
            }
            #endregion
        }
    }
}
