using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public static class StringExtension
    {
        public static String Upper(this String s)
        {
            s = s[0].ToString().ToUpper() + s.Substring(1,s.Length-1);
            return s;
        }
    }
}
