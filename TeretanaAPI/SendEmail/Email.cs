//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Threading;
//using System.Threading.Tasks;
////using FluentEmail.Core.Defaults;
////using FluentEmail.Core.Interfaces;
////using FluentEmail.Core.Models;
////using FluentEmail.Smtp;

//namespace FluentEmail.Core
//{
//    public class Email 
//    {
//        public EmailData Data { get; set; }
//        public ITemplateRenderer Renderer { get; set; }
//        public ISender Sender { get; set; }

//        public static ITemplateRenderer DefaultRenderer = new ReplaceRenderer();
//        public static ISender DefaultSender = new SaveToDiskSender("/");

//        public static void sendEmail(string emailToBeSent)
//        {
//            var sendEmail = Email
//                 .From("tajci994@gmail.com")
//                 .To(emailToBeSent)
//                 .Subject("hows it going bob")
//                 .Body("yo dawg, sup?");

//            //send normally
//            sendEmail.Send();

//            //send asynchronously
//            await sendEmail.SendAsync();
//        }
       
//    }

