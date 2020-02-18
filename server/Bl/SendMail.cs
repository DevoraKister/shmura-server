using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;





namespace BL
{
    public static class SendMail
    {
        static string fromMail = "idealtojob@gmail.com";
        static string ToMail = "idealtojob@gmail.com";
        static string clientURL = "http://localhost:5200/";

        public static MailMessage SendEmail(string htmlText, string subject, string toMail)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential("idealtojob@gmail.com", "963852741+");// Enter senders User name and password
                AlternateView plainView = AlternateView
                .CreateAlternateViewFromString("Some plaintext", Encoding.UTF8, "text/plain");
                // We have something to show in real old mail clients.
                smtp.EnableSsl = true;
                if (toMail == "")
                    toMail = ToMail;
                MailMessage mail = new MailMessage(fromMail, toMail, subject, htmlText);
                mail.AlternateViews.Add(plainView);
                System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment(@"http://localhost:53790/UploadFile/a.pdf");

                //mail.Attachments.Add(new Attachment("D:/1@.JPG"));

                // Add file as attachment.



                AlternateView htmlView =
                       AlternateView.CreateAlternateViewFromString(htmlText, Encoding.UTF8, "text/html");
                mail.AlternateViews.Add(htmlView); // And a html attachment to make sure.
                mail.IsBodyHtml = true;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                smtp.Send(mail);
                return new MailMessage();
            }
            catch (Exception ex)
            {
                var x = ex.Message;

                return new MailMessage();

            }
        }
        public static bool register(string name, string password, string mail)
        {
            //var filePath = HttpContext.Current.Server.MapPath("~/UploadFile/.JPG" );

            //var inlineLogo = new LinkedResource(Microsoft.SqlServer.Server.MapPath("~/UploadFile/.JPG"), "image/png");
            //inlineLogo.ContentId = Guid.NewGuid().ToString();

            LinkedResource LinkedImage = new LinkedResource(@"G:\ל סיון\C#IDEAL\GUI\UploadFile\.JPG");
            LinkedImage.ContentId = "MyPic";
            //Added the patch for Thunderbird as suggested by Jorge
            //LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

            string htmlText = @"
                
                    <head> 
                        <style> 
                            body{background-color:cadetblue;direction:rtl;text-align:center;}
                            h1,h3,p{font-size:100px; text-align:center;color:red;}
                        </style>
                    </head>
                    <body>";
            htmlText += "<h1>שלום לך " + name + "</h1><p>" + "אנו שמחים בהצטרפותך לאתרינו</p>" + "<h3>סיסמתך היא:</h3>" + password + "<br/>" + "<h3>נשמח תמיד לעמוד לשרותך ו" + "אנו מאחלים לך שימוש פורה באתר:)  בהצלחה!!!" + "</h3><br>";
            htmlText += " <img src=cid:MyPic/></body>";
            //htmlText += " <img src='cid:G:/ל סיון/C#IDEAL/GUI/UploadFile/.JPG'></body>";
            SendEmail(htmlText, "ברוך בואך למאגר המשרות הכשר ", mail);

            return true;
        }

        public static bool CreateConnect(string mail, string phone, string name, string details, string subject)
        {
            string htmlText = @"
                    <head> 
                        <style> 
                            
                            h1{text-align:center;color:gray;}
                            p,h3{text-align:right}
                            #border{padding: 30px 40px 0 40px;
                            padding-top: 35px;
                             width: 518px;}
                        </style>
                    </head>
                    <body style='background-color:background-color:#e8e8e8;width:70%;text-align:right;'><div id='border'> ";
            //< h1 > פרטי הפונה:</ h1 >
            htmlText += "<p><b>שם:  </p>" + name + "<p><b>מייל: </p>" + mail + "<p><b>טלפון: </p>" + phone;
            htmlText += "<h1>תוכן הפניה: </h1>" + details + "</div>";
            SendEmail(htmlText, "יצירת קשר בנושא " + subject, "");
            return true;
        }

        public static bool SmartAgent(Entities.User user, List<Entities.JobView> jobs)
        {
            string htmlText = @"
                    <head> 
                        <style> 
                        
                          a{
                            padding: 12px 45px;
                             font-size: 14px;
                              color: #ffffff;
                                line-height: 22px;
                                background-color: #003399;
                                font-weight: bold;
                                border-radius: 2px;}
                            td{
                            display: inline-block;
                            }
                            #conteiner:{height:100%}
                        </style>
                    </head>
                    <body style='background-color:gray;height: 1009px;
                    '><img src='http://localhost:53790/UploadFile/Adv/unnamed.jpg'>";
            htmlText += "<div id=\"conteiner\">";
            htmlText += "<h2>שלום " + user.UserName + @", </h2><br><h4>קטגוריה: "
+ jobs[0].SubjectName + @"<h4/><p><b>ברגעים אלו מעסיק העלה משרה חמה
                    שנמצאה מתאימה להגדרות החיפוש שלך. <br/>
                    עדכון זה מאפשר לך להיות הראשון לשלוח קורות חיים ובכך להגדיל את סיכוייך למצוא עבודה.  </b></p>
                 <p><b>פרטי המשרה: </b></p>";
            //List<int?> vs = new List<int?>();
            string str = "";

            foreach (var job in jobs)
            {

                htmlText += @"<table style='z-index: 1000;
    padding: 39px 40px 40px 40px;
    padding-top: 35px;
    width: 518px;
    border: none;
    direction: rtl;
    font-family: Arial;
    font-size: 13px;
    background-color: white;
    margin-right: 25px;
    float: right;
    margin-bottom: 70px;
    border-radius: 6px;'>
                   <tr><b>תפקיד:    </b>  <td>" + job.JobRole + "</td> </tr>" +
                    "<tr><b>תאור:    </b>  <td>" + job.JobDescribe + "</td> </tr>" +
                    "<tr><b>דרישות:    </b>  <td>" + job.JobRequire + "</td> </tr>" +
                    "<tr><b>מקום:    </b>  <td>" + job.AreaName + "</td> </tr>" +
                    "<tr><b>סוג משרה:    </b>  <td>" + job.PartName + "</td> </tr> " +
                    "<tr><b>סוג חסימה:    </b>  <td>" + job.OutNetName + "</td> </tr> " +
                    "<tr><b>סביבת עבודה:    </b>  <td>" + job.WSName + "</td> </tr> " +
                 "<a href=\""+clientURL+ "show-jobs/" + job.JobId.ToString() + "A\" style='padding: 12px 45px;font-size: 14px;color: #ffffff;line-height: 22px;background-color: #003399;font-weight: bold;border-radius: 2px;'" +
                 ">לצפיה במשרה באתר</a>" + "</table>";

                //vs.Add(job.JobId);
                str += job.JobId.ToString() + 'A';
            }
            //var jobIds = new JavaScriptSerializer().Serialize(vs);
            //htmlText += "<a href=\"http://localhost:4200/show-jobs?list=";
            //JsonArrayAttribute jsonArrayAttribute = new JsonArrayAttribute();
            //htmlText += jobIds + "\">לצפיה במשרה</a> ";
            htmlText += "<a href=\"" + clientURL + "show-jobs/" + str + "\"  style='padding: 12px 45px;font-size: 14px;color: #ffffff;line-height: 22px;background-color: #003399;font-weight: bold;border-radius: 2px;'>לכל המשרות</a></div></body> ";
            if (jobs.Count == 1) SendEmail(htmlText, "משרה לוהטת: " + jobs[0].JobRole, user.UserMail);
            else SendEmail(htmlText, "נמצאו  " + jobs.Count.ToString() + " משרות המתאימות לך", user.UserMail);
            return true;
        }
        public static MailMessage SendCv(string cvlink, string toMail, string subject)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential("idealtojob@gmail.com", "963852741+");// Enter senders User name and password
                AlternateView plainView = AlternateView
                .CreateAlternateViewFromString("Some plaintext", Encoding.UTF8, "text/plain");
                // We have something to show in real old mail clients.
                smtp.EnableSsl = true;
                if (toMail == "")
                    toMail = ToMail;
                string htmlText = "<div> מצורף קובץ קורות חיים למשרה הנל</div>";
                MailMessage mail = new MailMessage(fromMail, toMail, subject, htmlText);
                mail.AlternateViews.Add(plainView);

                System.Net.Mail.Attachment attachment;
                string temp = "~/UploadFile/";
                var filePath = HttpContext.Current.Server.MapPath(temp + cvlink);
                attachment = new System.Net.Mail.Attachment(filePath);
                mail.Attachments.Add(attachment);

                // Add file as attachment.


                AlternateView htmlView =
                       AlternateView.CreateAlternateViewFromString(htmlText, Encoding.UTF8, "text/html");
                mail.AlternateViews.Add(htmlView); // And a html attachment to make sure.
                mail.IsBodyHtml = true;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                smtp.Send(mail);
                return new MailMessage();
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return new MailMessage();

            }
        }
        //QuestionToRav
        public static bool QuestionToRav(string UserName, string UserMail, string UserTel, string Question1, string TopicName)
        {
            string html = @"<h3> שאלה חדשה בנושא " + TopicName + " .נוספה למערכת </h3> השואלת:" + UserName + ", " + UserTel + ", " + UserMail + "<br/>";
            html += "<h2>" + Question1 + "</h2>";
            SendEmail(html, "שאל את הרב", "idealToJob@gmail.com")
                ; return true;
        }
        public static bool Admin()
        {
            SendEmail("<a href='" + clientURL + "nbvladmin'>כניסה</a>", "כניסה לעריכת אתר", "idealToJob@gmail.com")
                ; return true;
        }
        public static bool resetMail(string email)
        {

            SendEmail("<a href='" + clientURL + "login/reset-password'>לאיפוס</a> <img src='https://www.photo-art.co.il/wp-content/uploads/2015/06/IMG_40661.jpg'>", "איפוס סיסמה לאתר ", email);
            return true;

        }
    }
}

//public static MailMessage SendEmail(string text, string subject, string toMail)
//{
//    try
//    {
//        SmtpClient smtp = new SmtpClient();
//        smtp.Host = "smtp.gmail.com";
//        smtp.Port = 587;
//        smtp.UseDefaultCredentials = true;
//        smtp.Credentials = new System.Net.NetworkCredential("idealtojob@gmail.com", "963852741+");// Enter senders User name and password
//        smtp.EnableSsl = true;
//        if (toMail == "")
//            toMail = ToMail;
//        MailMessage mail = new MailMessage(fromMail, , subjetoMailct, text);
//        AlternateView plainView = AlternateView
//     .CreateAlternateViewFromString("Some plaintext", Encoding.UTF8, "text/plain");
//        // We have something to show in real old mail clients.
//        mail.AlternateViews.Add(plainView);

//        string htmlText = @"
//<body  style='background-color:cadetblue' >
//<head> 
//<style> 
//body{
//background-color:cadetblue;direction:rtl;}
//p{ font - family: Arial;  font - size:30px; text - align:center;color:aqua}</style> </head>";
//        htmlText += "The <b style='background-color:red'>fancy</b> part.";

//        htmlText += "<h1>שלום מותק:</h1>" + text + "<br/>" + "<h3>" + "אנו מאחלים לך שימוש פורה באתר:)  בהצלחה!!!" + "</h3><br>";
//        htmlText += "<img src='D:/C#IDEAL/GUI/UploadFile/025@gamail.com.JPG'>";
//        htmlText += "< /body >";


//        AlternateView htmlView =
//             AlternateView.CreateAlternateViewFromString(htmlText, Encoding.UTF8, "text/html");
//        mail.AlternateViews.Add(htmlView); // And a html attachment to make sure.
//        mail.Body = htmlText;  // But the basis is the html body
//        mail.IsBodyHtml = true; // But the basis is the html body
//        mail.BodyEncoding = UTF8Encoding.UTF8;
//        //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

//        smtp.Send(mail);
//        return new MailMessage();
//    }
//    catch (Exception ex)
//    {
//        var x = ex.Message;
//        return new MailMessage();

//    }
//}
//   public static class SendMail
//   {
//       static string fromMail = "idealtojob@gmail.com";
//       static string ToMail = "idealtojob@gmail.com";

//       public static MailMessage SendEmail(string text, string subject, string toMail)
//       {
//           try
//           {
//               SmtpClient smtp = new SmtpClient();
//               smtp.Host = "smtp.gmail.com";
//               smtp.Port = 587;
//               smtp.UseDefaultCredentials = true;
//               smtp.Credentials = new System.Net.NetworkCredential("idealtojob@gmail.com", "963852741+");// Enter senders User name and password
//               smtp.EnableSsl = true;
//               if (toMail == "")
//                   toMail = ToMail;
//               MailMessage mail = new MailMessage(fromMail, toMail, subject, text);
//               AlternateView plainView = AlternateView
//            .CreateAlternateViewFromString("Some plaintext", Encoding.UTF8, "text/plain");
//               // We have something to show in real old mail clients.
//               mail.AlternateViews.Add(plainView);

//               string htmlText = @"
//     <body  style='background-color:cadetblue' >
//           <head> 
//       <style> 
//body{
// background-color:cadetblue;direction:rtl;}
//  p{ font - family: Arial;  font - size:30px; text - align:center;color:aqua}</style> </head>";
//               htmlText += "The <b style='background-color:red'>fancy</b> part.";

//               htmlText += "<h1>שלום מותק:</h1>" + text + "<br/>" + "<h3>" + "אנו מאחלים לך שימוש פורה באתר:)  בהצלחה!!!" + "</h3><br>";
//               htmlText += "<img src='D:/C#IDEAL/GUI/UploadFile/025@gamail.com.JPG'>";
//               htmlText += "< /body >";


//               AlternateView htmlView =
//                    AlternateView.CreateAlternateViewFromString(htmlText, Encoding.UTF8, "text/html");
//               mail.AlternateViews.Add(htmlView); // And a html attachment to make sure.
//               mail.Body = htmlText;  // But the basis is the html body
//               mail.IsBodyHtml = true; // But the basis is the html body
//               mail.BodyEncoding = UTF8Encoding.UTF8;
//               //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

//               smtp.Send(mail);
//               return new MailMessage();
//           }
//           catch (Exception ex)
//           {
//               var x = ex.Message;
//               return new MailMessage();

//           }
//       }

//       //public static MailMessage SendEmail(string text, string subject, string toMail)
//       //{
//       //    try
//       //    {
//       //        SmtpClient smtp = new SmtpClient();
//       //        smtp.Host = "smtp.gmail.com";
//       //        smtp.Port = 587;
//       //        smtp.UseDefaultCredentials = true;
//       //        smtp.Credentials = new System.Net.NetworkCredential("idealtojob@gmail.com", "963852741+");// Enter senders User name and password
//       //        smtp.EnableSsl = true;
//       //        if (toMail == "")
//       //            toMail = ToMail;
//       //        MailMessage mail = new MailMessage(fromMail, toMail, subject, text);

//       //        mail.BodyEncoding = UTF8Encoding.UTF8;
//       //        //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

//       //        smtp.Send(mail);
//       //        return new MailMessage();
//       //    }
//       //    catch (Exception ex)
//       //    {
//       //        var x = ex.Message;
//       //        return new MailMessage();

//       //    }
//       //}

//       public static bool CreateConnect(string mail, string phone, string name, string details, string subject)
//       {

//           //מייל מעוצב 
//           //לרדת שורה
//           string sub = "הודעה ליצור קשר";

//           string data = "שם הפונה:" + " " + name + " " + " המייל:" + mail + " " + "הטלפון:" + " " + phone + "תוכן הפניה: " + details + " הנושא" + subject;
//           //SendEmail(details);
//           return true;




//       }
//   }

//}

