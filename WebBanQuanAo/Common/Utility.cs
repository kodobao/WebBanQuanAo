using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;

namespace WebBanQuanAo.Common
{
    public class Utility
    {

        #region "sinh chuoi van ban ngau nhien"

        public string RandomText(int n)
        {
            string str = "";
            try
            {
                Random r = new Random();
                for (int i = 0; i < n; i++)
                {
                    char ch = Convert.ToChar(r.Next(65, 90));
                    str += ch.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }

        #endregion

        #region Chuan hoa ten, tieu de cho SEO

        private static string[] a = new string[] { "à", "á", "ạ", "ả", "ã", "â", "ầ", "ấ", "ẩ", "ậ", "ẫ", "ă", "ằ", "ắ", "ẳ", "ặ", "ẵ" };
        private static string[] d = new string[] { "đ", "d" };
        private static string[] e = new string[] { "e", "è", "é", "ẻ", "ẹ", "ẽ", "ê", "ề", "ế", "ể", "ệ", "ễ" };
        private static string[] ii = new string[] { "i", "ì", "í", "ị", "ĩ", "ỉ" };
        private static string[] y = new string[] { "y", "ý", "ỳ", "ỵ", "ỷ", "ỹ" };
        private static string[] o = new string[] { "o", "ò", "ó", "ọ", "õ", "ỏ", "ô", "ồ", "ố", "ổ", "ộ", "ỗ", "ơ", "ờ", "ớ", "ở", "ỡ", "ợ" };
        private static string[] u = new string[] { "u", "ù", "ú", "ụ", "ũ", "ủ", "ư", "ừ", "ứ", "ự", "ử", "ữ" };

        public static string ConvertTitle(string Name)
        {
            string result = "";
            string currentchar = "";

            Name = Name.Replace(" ", "-");
            Name = Name.Replace(")", "");
            Name = Name.Replace("(", "");
            Name = Name.Replace("'", "");
            Name = Name.Replace("&", "");
            Name = Name.Replace("%", "");
            Name = Name.Replace("#", "");
            Name = Name.Replace("<", "");
            Name = Name.Replace(">", "");
            Name = Name.Replace("[", "");
            Name = Name.Replace("]", "");
            Name = Name.Replace("{", "");
            Name = Name.Replace("}", "");
            Name = Name.Replace("@", "");
            Name = Name.Replace("/", "");
            Name = Name.Replace("\\", "");
            Name = Name.Replace("?", "");
            Name = Name.Replace(",", "");
            Name = Name.Replace(".", "");
            Name = Name.Replace(";", "");
            Name = Name.Replace(":", "");
            Name = Name.Replace("^", "");
            Name = Name.Replace("~", "");
            Name = Name.Replace("|", "");
            Name = Name.Replace("=", "");

            Name = Name.ToLower();
            int len = Name.Length;
            if (len > 0)
            {
                int i;
                for (i = 0; i < len; i++)
                {
                    currentchar = Name.Substring(i, 1);
                    result = result + ChangeChar(currentchar);

                }
            }
            else
            {
                result = "";
            }
            return result;
        }

        #endregion

        #region Chuyen ky tu tieng Viet co dau thanh khong dau

        public static string ChangeChar(string charinput)
        {
            int i;
            for (i = 0; i < a.Length; i++)
            {
                if (a[i].Equals(charinput))
                {
                    return "a";
                }
            }
            for (i = 0; i < d.Length; i++)
            {
                if (d[i].Equals(charinput))
                {
                    return "d";
                }
            }
            for (i = 0; i < e.Length; i++)
            {
                if (e[i].Equals(charinput))
                {
                    return "e";
                }
            }
            for (i = 0; i < ii.Length; i++)
            {
                if (ii[i].Equals(charinput))
                {
                    return "i";
                }
            }
            for (i = 0; i < o.Length; i++)
            {
                if (o[i].Equals(charinput))
                {
                    return "o";
                }
            }
            for (i = 0; i < u.Length; i++)
            {
                if (u[i].Equals(charinput))
                {
                    return "u";
                }
            }
            return charinput;
        }

        #endregion

        #region Viết hoa chữ cái đầu

        public static string VietHoa( string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            string result = "";

            //lấy danh sách các từ  

            string[] words = s.Split(' ');

            foreach (string word in words)
            {
                // từ nào là các khoảng trắng thừa thì bỏ  
                if (word.Trim() != "")
                {
                    if (word.Length > 1)
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                    else
                        result += word.ToUpper() + " ";
                }

            }
            return result.Trim();
        }

        #endregion
    }
}