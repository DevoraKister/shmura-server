using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DataBaseLogic
    {
        public static DAL.IdialEntities3 db = new DAL.IdialEntities3();
        public static HttpResponseMessage addNewSubjectJob(string subjectJobName)
        {
            Entities.SubjectJob subjectJob = new SubjectJob();
            subjectJob.SubName = subjectJobName;
            try
            {
                db.SubjectJob.Add(Entities.SubjectJob.SubjectJobDAL(subjectJob));
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK) { };
            }
            catch(Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
            }
        }
        public static List<Entities.SubjectJob> deleteSubjectJob(int subjectId)
        {
            var subject = db.SubjectJob.FirstOrDefault(a => a.SubId == subjectId);
            db.SubjectJob.Remove(subject);
            db.SaveChanges();
            return BL.SelectorJob.getSubjectJob();
        }

        public static HttpResponseMessage addQuestion(Entities.Question question)
        {
            Entities.Question q = new Entities.Question();

            try
            {
                q.Answer = question.Answer;
                q.QueTopicId = question.QueTopicId;
                q.QueUserId = question.QueUserId;
                q.Question1 = question.Question1;
                db.Question.Add(Entities.Question.QuestionDAL(q));
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK) { };
            }
            catch(Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
            }

        }
        public static List<Entities.Question> removeQuestion(int questionId)
        {
            List<Entities.Question> que = new List<Question>();
            var q = db.Question.FirstOrDefault(q1 => q1.QueId == questionId);
            db.Question.Remove(q);
            db.SaveChanges();
            foreach (var item in db.Question)
            {
                que.Add(Entities.Question.QuestionEntities(item));
            }
            return que;



            throw new NotImplementedException();
        }
        public static HttpResponseMessage addNewOutNet(string outNetName)
        {
            Entities.OutNet outNet = new OutNet();
            outNet.OutNetName = outNetName;
            try
            {
                db.OutNet.Add(Entities.OutNet.OutNetDAL(outNet));
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK) { };
            }
            catch(Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
            }
        }
        public static List<Entities.OutNet> removeOutNet(int outNetId)
        {
            var outNet = db.OutNet.FirstOrDefault(a => a.OutNetId == outNetId);
            db.OutNet.Remove(outNet);
            db.SaveChanges();
            return BL.SelectorJob.getOutNet();
        }

        public static HttpResponseMessage addWorkspace(string workspace)
        {
            Entities.Workspace newWorkspace = new Workspace();
            newWorkspace.WSName = workspace;
            try
            {
                db.Workspace.Add(Entities.Workspace.WorkspaceDAL(newWorkspace));
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK) { };
            }
            catch(Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
            }
        }

        public static List<Entities.Workspace> removeWorkspace(int workspaceId)
        {
            var w = db.Workspace.FirstOrDefault(a => a.WSId == workspaceId);
            db.Workspace.Remove(w);
            db.SaveChanges();
            return BL.SelectorJob.getWS();

        }
        //שנוייייייי
        //public static List<Entities.Job> removeJob(int id)
        //{
        //    List<Entities.Job> jobs = new List<Job>();
        //    var j = db.Job.FirstOrDefault(a => a.JobId == id);
        //    db.Job.Remove(j);
        //    db.SaveChanges();
        //    foreach (var item in db.Job)
        //    {
        //        jobs.Add(Entities.Job.JobEntities(item));
        //    }
        //    return jobs.ToList();

        //}
        public static List<Entities.JobView> removeJob(int jobId)
        {
            var x = db.Job.FirstOrDefault(j => j.JobId == jobId);
            db.Job.Remove(x);
            db.SaveChanges();

            return BL.DataBaseLogic.getJobsList();
        }
        public static HttpResponseMessage addPart(string part)

        {
            try
            {
                Entities.Part p = new Entities.Part();
                p.PartName = part;
                db.Part.Add(Entities.Part.PartDAL(p));
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK) { };
            }
            catch(Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
            }

        }

        public static List<Entities.Part> removePart(int id)
        {
            List<Entities.Part> parts = new List<Part>();
            var p = db.Part.FirstOrDefault(a => a.PartId == id);
            db.Part.Remove(p);
            db.SaveChanges();
            return BL.SelectorJob.getPart();
        }

        public static object addAdv(Advs adv)
        {
            try
            {
                DAL.Adv a = new DAL.Adv();
                a.AdvContent = adv.AdvContent;
                a.AdvLink = adv.AdvLink;
                a.AdvPhone = adv.AdvPhone;
                a.AdvMail = adv.AdvMail;
                a.AdvTitle = adv.AdvTitle;
                a.AdvStatus = adv.AdvStatus;
                a.CountUsers = 0;
                //a.AdvStatus = false;
                //a.AdvLink = "li";
                db.Adv.Add(a);

                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK) { };
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
            }
        }
        public static object addAdvImg(string advPath)
        {
            try
            {
                DAL.Adv a = new DAL.Adv();

                a.AdvLink = "http://localhost:53790/UploadFile/Adv/"+ advPath;
         
                a.AdvStatus = true;
                a.CountUsers = 0;
                //a.AdvStatus = false;
                //a.AdvLink = "li";
                db.Adv.Add(a);

                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK) { };
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
            }
        }

        public static List<Entities.User> getAllUsers()
        {

            List<Entities.User> users = new List<Entities.User>();

            foreach (var item in db.User)
            {
                users.Add(Entities.User.UserEntities(item));
            }

            return users;

        }

        public static List<Entities.Boss> geBossList()
        {


            List<Entities.Boss> bosses = new List<Entities.Boss>();
            foreach (var item in db.Boss)
            {
                bosses.Add(Entities.Boss.BossEntities(item));
            }
            return bosses;

        }

        public static List<Entities.JobView> getJobsList()
        {
            List<Entities.Job> jobs = new List<Entities.Job>();
            List<Entities.JobView> jobsView = new List<Entities.JobView>();
            foreach (var item in db.Job)
            {
                jobs.Add(Entities.Job.JobEntities(item));
            }
            jobsView = BL.SelectorJob.JobView(jobs);
            return jobsView;
        }




        public static Entities.Job getJobById(int id)
        {
            var x = db.Job.FirstOrDefault(j => j.JobId == id);
            return Entities.Job.JobEntities(x);
        }
        public static HttpResponseMessage countUser()
        {
            try
            {
                int x1;
                int.TryParse(db.Count.FirstOrDefault(c => c.Counts == 1).CountUser.ToString(), out x1);
                if (x1 != null)
                {
                    x1 += 1;
                    db.Count.FirstOrDefault(c => c.Counts == 1).CountUser = x1;
                }
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK) { };

            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
            }
        }


    }
}
