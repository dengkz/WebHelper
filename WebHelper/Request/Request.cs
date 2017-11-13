using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebHelper.Request
{
    public class Request
    {
        /// <summary>
        /// 获取Request信息
        /// </summary>
        /// <param name="str">key</param>
        /// <returns></returns>
        public static string get(string str)
        {
            if (HttpContext.Current.Request[str] != null)
            {
                str = HttpContext.Current.Request[str].ToString();

                str = replaceString(str);
            }
            else
            {
                str = "";
            }

            return str;
        }


        /// <summary>
        /// 获取Request信息,已处理特殊字符
        /// </summary>
        /// <param name="str">key</param>
        /// <returns></returns>
        public static string getStr(string str)
        {
            if (HttpContext.Current.Request[str] != null)
            {
                str = HttpContext.Current.Request[str].ToString();

                str = replaceString(str);

                str = HTML.Format.EndCode(str);
            }
            else
            {
                str = "";
            }

            return str;
        }

        public static string get2(string str)
        {
            string[] f = HttpContext.Current.Request.Form.GetValues(str);
            string[] s = HttpContext.Current.Request.QueryString.GetValues(str);
            string[] r = (f == null ? s : f);

            if (r == null)
            {
                return "";
            }

            if (r.Length == 1)
            {

                str = replaceString(r.GetValue(0).ToString().Replace("'", "''").Trim());

                str = HTML.Format.EndCode(str);
                return str;
            }
            else if (r.Length > 1)
            {
                string rStr = "";
                for (int i = 0; i < r.Length; i++)
                {
                    if (i == 0)
                    {
                        rStr = rStr + r.GetValue(0);
                    }
                    else if (i > 0)
                    {
                        rStr = rStr + "|@@|" + r.GetValue(i).ToString().Trim();
                    }
                }

                rStr = replaceString(rStr);

                rStr = HTML.Format.EndCode(rStr);

                return rStr;
            }
            else
            {
                return "";
            }

            return "";
        }

        public static int getToInt(string str)
        {
            int k = 1;

            if (HttpContext.Current.Request[str] != null)
            {
                str = HttpContext.Current.Request[str].ToString();
                str = replaceString(str);
            }

            try
            {
                k = int.Parse(str);
            }
            catch { }

            return k;
        }




        private static string replaceString(string str)
        {
            str = str.Replace("'", "''");
            //str = str.Replace(" ", "");

            return str;
        }


        public static string getID(string str)
        {
            Random rd = new Random();

            string s = DateTime.Now.ToString("yyyyMMddHHmmss");

            str = str + s + rd.Next(10000, 99999);

            return str;
        }

        public static void cache(object parent)
        {
            HttpResponse r;
            try
            {
                r = ((System.Web.UI.Page)parent).Response;
            }
            catch
            {
                r = ((System.Web.UI.UserControl)parent).Response;
            }


            r.Expires = -1;
            r.AddHeader("Pragma", "no-cache");
            r.AddHeader("cache-ctrol", "no-cache");
        }
    }
}
