using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Collections.Specialized;

namespace MailboxBrowser
{    
    internal class MockImapDataProvider : ImapDataProvider
    {
        private static string mockDataPage1;
        private static string mockDataPage2;
        private static string mockMessage;
        static MockImapDataProvider()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            mockDataPage1 = new StreamReader(assembly.GetManifestResourceStream("MailboxBrowser.imap_sample_data")).ReadToEnd();
            mockDataPage2 = new StreamReader(assembly.GetManifestResourceStream("MailboxBrowser.imap_sample_data_2")).ReadToEnd();
            mockMessage = new StreamReader(assembly.GetManifestResourceStream("MailboxBrowser.message")).ReadToEnd();
        }

        public override string Fetch(NameValueCollection parms)
        {
            if (String.IsNullOrEmpty(parms["contact"]) || parms["contact"] == "kdmny30+crash@gmail.com")
            {
                return "<table width='613px'><tr><td><center>Could not fetch email. Please try again later.</center></td></tr></table>";
            }
            else
            {
                if (parms["page"] == "2")
                {
                    return mockDataPage2;
                }
                return mockDataPage1;
            }
        }

        public override string FetchMessage(string msgId)
        {
            return mockMessage;
        }
    }
}
