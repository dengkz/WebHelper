using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebHelper.HTML
{
    public class Format
    {

        public static string EndCode(string str)
        {
            str = HttpContext.Current.Server.HtmlEncode(str);

            return str;
        }

        public static string NoHtml(string Htmlstring)
        {
            if (!string.IsNullOrEmpty(Htmlstring))
            {
                //删除脚本 
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //删除HTML 
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"([/r/n])[/s]+", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"-->", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<!--.*", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(quot|#34);", "/", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(amp|#38);", "&", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(lt|#60);", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(gt|#62);", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(iexcl|#161);", "/xa1", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(cent|#162);", "/xa2", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(pound|#163);", "/xa3", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(copy|#169);", "/xa9", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&#(/d+);", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"(^\\s*)|(\\s*$)", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"^( )+|^[\\s　]+|( )+$|[\\s　]+$", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Htmlstring = Htmlstring.Replace("<", "");
                Htmlstring = Htmlstring.Replace(">", "");
                Htmlstring = Htmlstring.Replace("\r\n", "");
                Htmlstring = Htmlstring.Replace("\r", "");
                Htmlstring = Htmlstring.Replace("\n", "");
                Htmlstring = Htmlstring.Replace("\t", "");
                Htmlstring = Htmlstring.Replace("//r", "");
                Htmlstring = Htmlstring.Replace("//n", "");
                Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            }
            else
            {
                Htmlstring = null;
            }

            return Htmlstring;
        }


        public static string getMoney(object str)
        {
            string s = "";

            try
            {
                double d = double.Parse(str.ToString());
                s = String.Format("{0:N2}", d);
            }
            catch { }

            //select convert(varchar(50),@money,1)


            return s;
        }

        public static string getShortDate(object str)
        {
            string s = "";

            try
            {
                DateTime d = DateTime.Parse(str.ToString());
                s = String.Format("{0:yyyy-MM-dd}", d);
            }
            catch { }

            //select convert(varchar(50),@money,1)


            return s;
        }

        public static string getDateFormat(object str, string cFormat)
        {
            string s = "";

            try
            {
                DateTime d = DateTime.Parse(str.ToString());
                s = String.Format("{0:" + cFormat + "}", d);
            }
            catch { }

            //select convert(varchar(50),@money,1)


            return s;
        }

    }
}
