using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SaccoBook.AppResources
{
    static class RegexFunctions
    {
       /**
       * Function validates email address
       */
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
        /**
        * Function validates phone number
        */
        public static bool IsValidPhoneNumber(this string s)
        {
            Regex regex = new Regex("(\\+?254)7(\\d){8}");
            return regex.IsMatch(s);
        }
    }
}
