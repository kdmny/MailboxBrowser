using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace MailboxBrowser
{
    internal class ImapDataProvider
    {
        public virtual string Fetch(NameValueCollection parms)
        {
            return "";
        }

        public virtual string FetchMessage(string msgId)
        {
            return "";
        }
    }
}
