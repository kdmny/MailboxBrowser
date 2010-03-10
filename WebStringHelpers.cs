using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MailboxBrowser
{
    public static class WebStringHelpers
    {
        private static Dictionary<string, string> JS_ESCAPE_MAP;
        static WebStringHelpers()
        {
            JS_ESCAPE_MAP = new Dictionary<string, string>();
            JS_ESCAPE_MAP.Add("\\", "\\\\");
            JS_ESCAPE_MAP.Add("</", "<\\/");
            JS_ESCAPE_MAP.Add("\r\n", "");
            JS_ESCAPE_MAP.Add("\n", "");
            JS_ESCAPE_MAP.Add("\r", "");
            JS_ESCAPE_MAP.Add("\"", "\\\"");
            JS_ESCAPE_MAP.Add("'", "\\'");
        }

        public static string EscapeJavascript(string javascript)
        {
            var pattern = new Regex("(\\|<\\/|\r\n|[\n\r\"'])", RegexOptions.None);
            var jsEvaluator = new MatchEvaluator(MatchJs);
            return pattern.Replace(javascript, jsEvaluator);
        }

        public static string MatchJs(Match m)
        {
            return JS_ESCAPE_MAP[m.Value];
        }
    }
}
