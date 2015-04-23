using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtliHelper
{
    class HttpHelper
    {
        /// <summary>
        /// 移除换行
        /// </summary>
        /// <param name="contenct"></param>
        /// <returns></returns>
        public static string RemoveNewLine(string contenct)
        {
            if (string.IsNullOrEmpty(contenct))
            {
                return contenct;
            }
            string result = contenct;
            result = result.Replace(System.Environment.NewLine, "");
            result = result.Replace("\n", "");
            result = result.Replace("\t", "");
            return result;
        }
        /// <summary>
        /// 移除空格
        /// </summary>
        /// <param name="contenct"></param>
        /// <returns></returns>
        public static string RemoveSpace(string contenct)
        {
            if (string.IsNullOrEmpty(contenct))
            {
                return contenct;
            }
            string result = contenct;
            result = result.Replace(" ", "");

            return result;
        }
        public static string RemoveFormat(string contenct)
        {
            return RemoveSpace(RemoveNewLine(contenct));
        }
    }
}
