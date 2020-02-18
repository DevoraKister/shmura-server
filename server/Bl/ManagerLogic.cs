using Entities;
using Microsoft.AspNet.SignalR.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
//using System.

namespace BL
{
    public class ManagerLogic
    {
        public static string baseURL = "http://localhost:53790/UploadFile/";
        public static DAL.IdialEntities3 db = new DAL.IdialEntities3();
        public static List<JobView> JobToCheck()
        {
            try
            {
                using (DAL.IdialEntities3 db = new DAL.IdialEntities3())
                {

                    List<Entities.Job> Jobs = new List<Entities.Job>();
                    foreach (var item in db.Job.ToList())
                    {
                        if (item.JobStatus == false)
                            Jobs.Add(Entities.Job.JobEntities(item));
                    }
                    //Jobs.OrderBy(p => p.JobDateAdv);
                    var jobsVeiw = BL.SelectorJob.JobView(Jobs);
                    return jobsVeiw;
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }


        public static HttpResponseMessage OkTheCheck(int idJob)
        {
            try
            {
                db.Job.FirstOrDefault(p => p.JobId == idJob).JobStatus = true;
                //db.Job.FirstOrDefault(p => p.JobId == idJob).JobStatus = true;
                db.SaveChanges();
                BL.SmartAgentLogic.SendImmediatelySmartAgent(Entities.Job.JobEntities(db.Job.FirstOrDefault(p => p.JobId == idJob)));
                return new HttpResponseMessage(HttpStatusCode.OK) { };
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
            }
        }



        public static List<Entities.Sign> UsersSignToJob(int idJob)
        {
            try
            {
                using (DAL.IdialEntities3 db = new DAL.IdialEntities3())
                {

                    List<Entities.Sign> signs = new List<Sign>();
                    foreach (var item in db.Sign.ToList())
                    {
                        signs.Add(Entities.Sign.SignEntities(item));
                    }

                    return signs;
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }

        }



        public static List<Entities.Company> removeCompany(int companyId)
        {
            try
            {
                using (DAL.IdialEntities3 db = new DAL.IdialEntities3())
                {

                    var company = db.Company.FirstOrDefault(c => c.CompanyId == companyId);
                    //מחיקת כל המשרות של החברה
                    foreach (var item in db.Job)
                    {
                        if (item.JobCompanyId == companyId)
                        {
                            //מחיקת הנרשמים למשרות של החברה

                            foreach (var s in db.Sign)
                            {
                                if (s.SignJobId == item.JobId)
                                    db.Sign.Remove(s);
                            }
                            db.Job.Remove(item);

                        }
                    }
                    //מחיקת כל ההמלצות על החברה
                    foreach (var item in db.Recomend)
                    {
                        if (item.RecomemdCompanyId == companyId)
                            db.Recomend.Remove(item);
                    }
                    db.Company.Remove(company);
                    db.SaveChanges();
                    return BL.SelectorJob.getCompanyName();
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }
        public static Entities.Boss GetBoss(int id)
        {
            var boss = db.Boss.FirstOrDefault(p => p.BossId == id);

            return Entities.Boss.BossEntities(boss);
        }
        public static List<Entities.Boss> removeBoss(int bossId)
        {
            try
            {
                using (DAL.IdialEntities3 db = new DAL.IdialEntities3())
                {

                    List<Entities.Boss> bossList = new List<Boss>();
                    var boss = db.Boss.FirstOrDefault(b => b.BossId == bossId);
                    //מחיקת המשרות שפרסם
                    foreach (var item in db.Job)
                    {
                        if (item.JobBossId == bossId)
                        {
                            //מחיקת הנרשמים למשרות שפרסם

                            foreach (var s in db.Sign)
                            {
                                if (s.SignJobId == item.JobId)
                                    db.Sign.Remove(s);
                            }
                            db.Job.Remove(item);

                        }
                    }

                    db.Boss.Remove(boss);
                    db.SaveChanges();
                    foreach (var item in db.Boss)
                    {
                        bossList.Add(Entities.Boss.BossEntities(item));
                    }
                    return bossList;
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }

        public static List<Entities.User> removeUser(int userId)
        {
            try
            {

                using (DAL.IdialEntities3 db = new DAL.IdialEntities3())
                {

                    List<Entities.User> userList = new List<User>();
                    var user = db.User.FirstOrDefault(c => c.UserId == userId);
                    //מחיקת הקו"ח שלו
                    foreach (var item in db.Cv)
                    {
                        if (item.CvUserId == userId)
                            db.Cv.Remove(item);
                    }
                    //הסרה מרשימת הנרשמים לעבודה
                    foreach (var item in db.Sign)
                    {
                        if (item.SignUserId == userId)
                            db.Sign.Remove(item);
                    }
                    //הסרה מרשימת השמות עבודה
                    foreach (var item in db.PutInJob)
                    {
                        if (item.PutUserId == userId)
                            db.PutInJob.Remove(item);
                    }
                    //הסרת ההמלצות שפירסם-         check!!!!
                    foreach (var item in db.Recomend)
                    {
                        if (item.RecomendUserId == userId)
                            db.Recomend.Remove(item);
                    }
                    //הסרת ההמלצות שפירסם-          check!!!!
                    foreach (var item in db.Question)
                    {
                        if (item.QueUserId == userId)
                            db.Question.Remove(item);
                    }

                    //
                    db.User.Remove(user);
                    db.SaveChanges();
                    foreach (var item in db.User)
                    {
                        userList.Add(Entities.User.UserEntities(item));
                    }

                    return userList;
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }


        //רשימת העבודות שיש להן השמותתתתתתתתתתתתתתתתתתתתתתתתתתתתתתתתתתתתתת
        //מחזירה את העבודות שיש להם השמות 
        public static List<Entities.JobView> jobsSign()
        {
            try
            {

                using (DAL.IdialEntities3 db = new DAL.IdialEntities3())
                {

                    var jobs = db.Job.Where(job => job.Sign.Count > 0).ToList();
                    List<DAL.Job> j = new List<DAL.Job>();

                    foreach (var item in jobs)
                    {

                        var pw = db.Sign.FirstOrDefault(p => p.SignJobId == item.JobId && p.SignStatusSend != true);
                        if (pw != null)
                            j.Add(db.Job.FirstOrDefault(w => w.JobId == pw.SignJobId));

                    }
                    var temp = j?.Select(job => Entities.Job.JobEntities(job)).ToList();
                    return BL.SelectorJob.JobView(temp);
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }
        //מחזיר רשימת עובדים שנרשמו למשרה כלשהיא 
        public static List<Entities.User> getListSignUsers(int jobId)
        {
            try
            {

                using (DAL.IdialEntities3 db = new DAL.IdialEntities3())
                {
                    db.Database.Connection.Open();
                    List<Entities.User> userList = new List<User>();
                    var users = db.User.Where(u => u.Sign.Count > 0).ToList();

                    foreach (var item in users)
                    {
                        var temp = item.Sign.FirstOrDefault(a => a.SignJobId == jobId && a.SignStatusSend != true);
                        if (temp != null)
                            userList.Add(Entities.User.UserEntities(item));

                    }
            foreach (var item in userList)
                    {
                        var cv = db.Cv.FirstOrDefault(p => p.CvUserId == item.UserId);
                        if (cv != null)
                            item.cvURL = baseURL  + cv.CvLink;
                        else
                            item.cvURL = "";

                    }
                    db.Database.Connection.Close();

                    return userList;
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                db.Database.Connection.Close();

                return null;
            }
        }

        //מחזיר את הנושאים של השאלות לרבנים
        public static List<Entities.TopicQuestion> getTopicQuestion()
        {
            List<Entities.TopicQuestion> topics = new List<TopicQuestion>();
            foreach (var item in db.TopicQuestion.ToList())
            {
                topics.Add(Entities.TopicQuestion.TopicQuestionEntities(item));
            }
            return topics;
        }

        public static List<JobView> SendCv(int userId, int jobId)
        {
            try
            {
                var cv = db.Cv.FirstOrDefault(p => p.CvUserId == userId);
                if (cv == null)
                    return null;

                var job = db.Job.FirstOrDefault(p => p.JobId == jobId);
                var boss = db.Boss.FirstOrDefault(o => o.BossId == job.JobBossId);
                if (boss.BossIsConnection == true)
                {

                    BL.SendMail.SendCv(cv.CvLink, boss.BossMail, job.JobRole);
                }
                else
                {

                    var company = db.Company.FirstOrDefault(w => w.CompanyId == job.JobCompanyId);
                    BL.SendMail.SendCv(cv.CvLink, company.CompanyMail, job.JobRole);
                }

                var y = db.Sign.Where(o => o.SignUserId == userId && o.SignJobId == jobId);
                foreach (var item in y)
                {
                    item.SignStatusSend = true;
                }
                db.SaveChanges();
                return jobsSign();
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }

        public static List<Entities.Question> addAnswerfromRav(Entities.Question question)
        {
            try
            {
                List<Entities.Question> questions = new List<Question>();
                db.Question.Add(Entities.Question.QuestionDAL(question));
                db.SaveChanges();
                foreach (var item in db.Question.ToList())
                {
                    questions.Add(Entities.Question.QuestionEntities(item));
                }
                return questions;
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }


        public static Entities.Statistics getknowledge()
        {
            try
            {
                Entities.Statistics statistics = new Statistics();
                statistics.CountUser = 0 + db.User.Count() + db.Boss.Count();
                DateTime temp;
                String diff2;
                int t;
                List<Entities.PutInJob> p = new List<PutInJob>();
                foreach (var item in db.PutInJob)
                {
                    DateTime.TryParse(item.PutDate.ToString(), out temp);
                    if (temp != null)
                    {
                        diff2 = (DateTime.Today - temp).TotalDays.ToString();
                        int.TryParse(diff2, out t);
                        if (t < 30)
                            p.Add(Entities.PutInJob.PutInJobEntities(item));
                    }


                }
                double temp1 = (Double)db.Survey.Count();
                double x = db.Survey.Count(f => f.SurveySubLearnId == f.SurveySubTodayId);
                statistics.AverageSurvey = ((x / temp1) * 100) % 100;
                statistics.PuttingAtJob = p.Count();
                statistics.CountEnterUsers = Convert.ToInt32(db.Count.FirstOrDefault(c => c.Counts == 1).CountUser);
                return statistics;
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }

        public static Boolean ExportExcel()
        {
            //Create the data set and table
            DataSet ds = new DataSet("New_DataSet");
            DataTable dt = new DataTable("New_DataTable");

            //Set the locale for each
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            dt.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

            //Open a DB connection (in this example with OleDB)
            OleDbConnection con = new OleDbConnection("metadata = res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-DTDQQNG;" +
                "initial catalog=idial;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");
            con.Open();

            //Create a query and fill the data table with the data from the DB
            string sql = "SELECT * FROM City;";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataAdapter adptr = new OleDbDataAdapter();

            adptr.SelectCommand = cmd;
            adptr.Fill(dt);
            con.Close();

            //Add the table to the data set
            ds.Tables.Add(dt);

            //Here's the easy part. Create the Excel worksheet from the data set
            ExcelLibrary.DataSetHelper.CreateWorkbook("MyExcelFile.xls", ds);
            return true;




            //var dt = BL.SelectorJob.getAllCity();//your datatable
            //string attachment = "attachment; filename=city.xls";
            //Response.ClearContent();
            //Response.AddHeader("content-disposition", attachment);
            //Response.ContentType = "application/vnd.ms-excel";
            //string tab = "";
            //foreach (DataColumn dc in dt.Columns)
            //{
            //    Response.Write(tab + dc.ColumnName);
            //    tab = "\t";
            //}
            //Response.Write("\n");
            //int i;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    tab = "";
            //    for (i = 0; i < dt.Columns.Count; i++)
            //    {
            //        Response.Write(tab + dr[i].ToString());
            //        tab = "\t";
            //    }
            //    Response.Write("\n");
            //}
            //Response.End();
        }

    }
}
