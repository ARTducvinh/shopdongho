using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace shopdongho
{
    public static class estring
    {
        public static String Tobase64(this String s)
        {
            if(s!=null)
            {
                var bytes = Encoding.UTF8.GetBytes(s);
                return Convert.ToBase64String(bytes);
            }
            return s;
        }
        public static string Str_Slug(string s)
        {
        String[][] Symbols =
        {
            new String[] {"[aáàảạăắằẳặâấẩầậ]", "a"},
            new String[] {"[đ]", "d"},
            new String[] {"[eéèẻẹêếềểệ]", "e"},
            new String[] {"[iíìỉị]", "i"},
            new String[] {"[uúùủụưứừửự]", "u"},
            new String[] {"yýỳỷỵ", "y"},
            new String[] {"[\\s'\";,]", "-"}
        };
        s = s.ToLower();
        foreach(var ss in Symbols)
        {
            s = Regex.Replace(s, ss[0], ss[1]);
        }
        return s;
        }
    }
}