
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foundation.Core
{
    public class JsonException
    {
        public delegate string BusinessWithJsonInvoker();
        public delegate void BusinessWithoutJsonInvoker();
        public static string Wrap(
            BusinessWithJsonInvoker fun)
        {
            #region
            string json = "";
            try
            {
                if (fun != null)
                    json = fun();
                else
                    throw new Exception("当前代码调用错误！");
            }
            catch (Exception e)
            {
                json = JsonHelper.GetErrorJson(e.Message);
                Console.WriteLine(json);
            }
            return json;
            #endregion
        }
        public static string Wrap(
            BusinessWithoutJsonInvoker fun)
        {
            #region
            string json = "";
            JsonHelper jsonhlp = new JsonHelper();
            try
            {
                if (fun != null)
                {
                    fun();
                    jsonhlp.AddObjectToJson("success", "true");
                    json = jsonhlp.ToString();
                }
                else
                    throw new Exception("当前代码调用错误！");
            }
            catch (Exception e)
            {
                json = JsonHelper.GetErrorJson(e.Message);
                Console.WriteLine(json);
            }
            return json;
            #endregion
        }
    }
}
