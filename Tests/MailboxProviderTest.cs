using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Core;
using NUnit.Framework;
using System.Collections.Specialized;

namespace MailboxProvider.Tests
{
    [TestFixture]
    class MailboxProviderTest
    {
        [Test]
        public void FetchTest()
        {
            var crashMessage = @"<table width='613px'><tr><td><center>Could not fetch email. Please try again later.</center></td></tr></table>";
            var coll = new NameValueCollection();
            coll.Add("contact", "kdmny30@gmail.com");
            coll.Add("page", "1");
            Assert.True(MailboxBrowser.MailboxProvider.Fetch(coll).Length > 0);

            coll.Remove("contact");
            coll.Add("contact", "kdmny30+crash@gmail.com");
            Assert.AreEqual(crashMessage, MailboxBrowser.MailboxProvider.Fetch(coll));
            
        }
    }
}
