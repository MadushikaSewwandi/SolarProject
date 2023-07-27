using MimeKit;
using MailKit.Net.Smtp;

namespace UmbracoSolarProject1.Email
{
	public class EmailSender
	{
		private readonly EmailConfigurations _emailConfig;
		public EmailSender(EmailConfigurations emailConfig)
		{
			_emailConfig = emailConfig;
		}
		public void SendEmail(EmailMessage message)
		{
			var emailMessage = CreateEmailMessage(message);
			Send(emailMessage);
		}

		private MimeMessage CreateEmailMessage(EmailMessage message)
		{

			var emailMessage = new MimeMessage();
			emailMessage.From.Add(new MailboxAddress(_emailConfig.From, _emailConfig.UserName));
			emailMessage.To.AddRange(message.To);
			emailMessage.Subject = message.Subject;

			var builder = new BodyBuilder();
			builder.HtmlBody = message.Content;
			emailMessage.Body = builder.ToMessageBody();

			//emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };
			return emailMessage;
		}

		private async void Send(MimeMessage mailMessage)
		{
			using (var client = new SmtpClient())
			{
				try
				{
					client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
					client.AuthenticationMechanisms.Remove("XOAUTH2");
					client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
					await client.SendAsync(mailMessage);
				}
				catch
				{
					//log an error message or throw an exception or both.
					throw;
				}
				finally
				{
					client.Disconnect(true);
					client.Dispose();
				}
			}
		}
	}
}
