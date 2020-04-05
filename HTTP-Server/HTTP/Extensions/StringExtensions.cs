namespace HTTP.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class StringExtensions
    {
        public static string Capitalize(this string str)
        {
            List<string> result = new List<string>();
            string[] arr = str.Split(' ');

            foreach (var s in arr)
            {
                result.Add(s[0].ToString().ToUpper() + s.Substring(1).ToLower());
            }

            return String.Join(" ", result);
        }
    }
}
