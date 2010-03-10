using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using System.IO;
using System.Collections.Specialized;

namespace MailboxBrowser
{
    public class MailboxProvider
    {
        private static ImapDataProvider imapProvider;
        

        static MailboxProvider()
        {
            if (ConfigurationManager.AppSettings["UseMockImapProvider"] == "true")
            {
                imapProvider = new MockImapDataProvider();
            }
            else
            {
                imapProvider = new ImapDataProvider();
            }
        }

        public static string Fetch(NameValueCollection parms)
        {
            return imapProvider.Fetch(parms);
        }

        public static string FetchMessage(string msgId)
        {
            return imapProvider.FetchMessage(msgId);
        }
    }
}
