using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace UmbracoSolarProject1.Email
{
	public class EmailMessage
	{
		public List<MailboxAddress> To { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }
		public EmailMessage(IEnumerable<EmailAddress> to, string subject, string content)
		{
			To = new List<MailboxAddress>();
			To.AddRange(to.Select(x => new MailboxAddress(x.DisplayName, x.Address)));
			Subject = subject;
			Content = content;
		}
	}
}
