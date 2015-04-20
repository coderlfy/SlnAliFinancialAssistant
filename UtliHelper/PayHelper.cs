using HtmlAgilityPack; 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using UtliHelper;

namespace MoneyCalculator
{
    public class PayHelper
    {
        static PayHelper()
        {
            payXPath = xpathString + "/div[@class=\"loan-product fn-clear\"]/div[@class=\"several-months fn-clear\"]/div[@class=\"book-and-buy fn-clear\"]";

            pXpath = payXPath + "/div[@class=\"product-book fn-clear\"]/ul/li[1]/div/p[2]";
            p2Xpath = payXPath + "/div[@class=\"product-buy fn-clear\"]/ul/li[1]";
        }

        #region 购买和变现利率
        public static string url = "https://zhaocaibao.alipay.com/pf/productList.htm";

        private static string xpathString = "/html[1]/body/div[@id=\"container\"]/div[@class=\"content-container\"]"
                + "/div[@class=\"main-content fn-clear\"]/div[@class=\"zcb-product\"]";
        private static string payXPath = string.Empty;
        private static string wangNengXPath = string.Empty; //万能险 product-block fn-clear


        static List<string> result = new List<string>();
        //个贷约定
        static string pXpath = string.Empty;
        //个贷购买
        static string p2Xpath = string.Empty;
        static HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        /// <summary>
        /// 获取个贷信息
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns></returns>
        public static List<string> GetPayInfo()
        {
            result.Clear();
            string html = GetHtmlStr(url);
            doc.LoadHtml(html);
            HtmlNode rootNode = doc.DocumentNode;
            HtmlNodeCollection p1Node = rootNode.SelectNodes(pXpath);
            foreach (var item in p1Node)
            {
                result.Add(HttpHelper.RemoveFormat(item.InnerText));
            }
            p1Node = rootNode.SelectNodes(p2Xpath);
            foreach (var item in p1Node)
            {
                result.Add(HttpHelper.RemoveFormat(item.InnerText));
            }

            return result;
        }

        public static string GetPayJsonInfo()
        {
            string json = string.Empty;
            try
            {
                List<string> infos = GetPayInfo();

                StringBuilder sb = new StringBuilder();
                sb.Append("{");
                sb.Append(string.Format("'currentTime':'{0}',", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));
                sb.Append(string.Format("'monthLess3':'{0}',", infos[0]));
                sb.Append(string.Format("'month3To6':'{0}',", infos[1]));
                sb.Append(string.Format("'month6To12':'{0}',", infos[2]));
                sb.Append(string.Format("'month12To24':'{0}',", infos[3]));
                sb.Append(string.Format("'monthMore24':'{0}'", infos[5]));
                sb.Append("}");
                json = sb.ToString();
            }
            catch (Exception ex)
            {


            }

            return json;

        }
        private static string GetHtmlStr(string url)
        {
            try
            {
                WebRequest rGet = WebRequest.Create(url);
                WebResponse rSet = rGet.GetResponse();
                Stream s = rSet.GetResponseStream();
                StreamReader reader = new StreamReader(s, Encoding.Default);
                return reader.ReadToEnd();
            }
            catch (WebException)
            {
                //连接失败
                return null;
            }

        }
        #endregion

    }
}
