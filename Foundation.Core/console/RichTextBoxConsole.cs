using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Fundation.Core
{

    public class RichTextBoxConsole
    {
        /// <summary>
        /// 
        /// </summary>
        private FlowDocument _richFlowDocument 
            = new FlowDocument();
        /// <summary>
        /// 
        /// </summary>
        private Paragraph _richFlowParagraph 
            = new Paragraph();
        /// <summary>
        /// 
        /// </summary>
        private RichTextBox _richTextBox = null;
        public RichTextBoxConsole(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;

            _richFlowDocument.Blocks.Add(_richFlowParagraph);

            _richTextBox.Document = _richFlowDocument;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="option"></param>
        private void append(string content, RichRunOption option)
        {
            Run myRun = new Run(content);
            myRun.Foreground = option._Foreground;
            myRun.FontWeight = option._FontWeight;
            myRun.FontSize = option._FontSize;
            myRun.FontFamily = option._FontFamily;
            _richFlowParagraph.Inlines.Add(myRun);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="option"></param>
        public void Append(string content, RichRunOption option)
        {
            append(content, option);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="option"></param>
        public void AppendLine(string content, RichRunOption option)
        {
            append(content + Environment.NewLine, option);
        }
    }
}
