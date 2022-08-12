
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;



namespace emailSendgrid
{
    class Program
    {
        static void Main(string[] args)
        {
            sendEmail().Wait();
        }

        static async Task sendEmail()
        {


            var client = new SendGridClient("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");//Put your sendgrid api key;

            Console.Write("To: ");
            var to = Console.ReadLine();

            Console.Write("Subject: "); 
            var subject = Console.ReadLine();

            Console.Write("Body: ");
            var body = Console.ReadLine();




            var message = new SendGridMessage()
            {
                From = new EmailAddress("afrath4964@gmail.com", "afraath"),//Put the email which is used in sengrid api key creation
                Subject = subject,
                PlainTextContent = body
            };
            message.AddTo(new EmailAddress(to));




            var response = await client.SendEmailAsync(message);

            Console.WriteLine(response.IsSuccessStatusCode ? "Email sent successfully!" : "Something went wrong!");
        }


    }
}
