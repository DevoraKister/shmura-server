using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class ForumLogic
    {
        public static DAL.IdialEntities3 db = new DAL.IdialEntities3();

        public static List<Entities.Question> getAllQuestion()
        {
            try
            {
                List<Entities.Question> questions = new List<Entities.Question>();
                foreach (var item in db.Question)
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
        public static List<Entities.TopicQuestion> getTopicQuestion()
        {
            try
            {
                List<Entities.TopicQuestion> topicQuestions = new List<Entities.TopicQuestion>();
                foreach (var item in db.TopicQuestion)
                {
                    topicQuestions.Add(Entities.TopicQuestion.TopicQuestionEntities(item));


                }
                return topicQuestions;
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }
        public static bool AddQuestion(Entities.Question question)
        {
            try
            {
                db.Question.Add(Entities.Question.QuestionDAL(question));
                db.SaveChanges();
                var user = db.User.FirstOrDefault(p => p.UserId == question.QueUserId);
                var topic = db.TopicQuestion.FirstOrDefault(t => t.TopicId == question.QueTopicId);
                BL.SendMail.QuestionToRav(user.UserName, user.UserMail, user.UserTel, question.Question1, topic.TopicName);
                return true;
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return false;
            }

        }
        
        public static bool AddAnswer(int id,string answer)
        {
            try
            {
                var w = db.Question.FirstOrDefault(p => p.QueId == id);
                w.Answer = answer;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return false;
            }

        }
        public static HttpResponseMessage OkTheCheck(int idJob)
        {
            try
            {
                db.Job.FirstOrDefault(p => p.JobId == idJob).JobStatus = true;
                //db.Job.FirstOrDefault(p => p.JobId == idJob).JobStatus = true;
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
        //public static List<Entities.JobView> deleteJob(int jobId)
        //{

          
        //    var job1 = db.Job.FirstOrDefault(c => c.JobId == jobId);
        //    db.Job.Remove(job1);
        //    db.SaveChanges();

        //    return BL.SelectorJob.//משלייייייייי 
        //        getNewjobs();
        //}

    }
}
