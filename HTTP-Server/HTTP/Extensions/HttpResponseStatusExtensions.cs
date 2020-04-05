namespace HTTP.Extensions
{
    using HTTP.Enums;
    using System.Text.RegularExpressions;

    public static class HttpResponseStatusExtensions
    {
        private static Regex UpperCamelCaseRegex = new Regex(@"(?<!^)((?<!\d)\d|(?(?<=[A-Z])[A-Z](?=[a-z])|[A-Z]))", RegexOptions.Compiled);

        /// <summary>
        /// Get response status code value and name
        /// </summary>
        /// <returns></returns>
        public static string GetResponseLine(this HttpResponseStatusCode code)
        {
            short codeValue = (short)code;
            string codeName = codeValue == 200 ? "OK" : code.AsUpperCamelCaseName();

            return $"{codeValue} {codeName}";
        }

        private static string AsUpperCamelCaseName(this HttpResponseStatusCode code)
        {
            return UpperCamelCaseRegex.Replace(code.ToString(), " $1").Capitalize();
        }
    }
}
