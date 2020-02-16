using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace BL
{


    public static class PuttingAtJob
    {
        public static DAL.IdialEntities3 DB = new DAL.IdialEntities3();
        public static HttpResponseMessage RegisterToSingJob(int idjob, int iduser)
        {
            try
            {
      
                Entities.Sign newSign = new Entities.Sign();
                newSign.SignDate = DateTime.Now;
                newSign.SignUserId = iduser;
                newSign.SignJobId = idjob;
                newSign.SignStatusSend = false;
                DB.Sign.Add(Entities.Sign.SignDAL(newSign));
                DB.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK) { };

            }
            catch(Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
            }
        }

        public static List<Entities.JobView> getJobsUserSigned(int userId)
        {
            try
            {
                List<int> signedUser = new List<int>();
                foreach (var item in DB.Sign)
                {
                    if (item.SignUserId == userId)
                        signedUser.Add(Convert.ToInt32(item.SignJobId));
                }
                return BL.SmartAgentLogic.getSomeJob(signedUser);
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }
        public static List<Entities.JobView> getJobsByBossId(int bossId)
        {
            try
            {
                List<int> myJobs = new List<int>();
                foreach (var item in DB.Job)
                {
                    if (item.JobBossId == bossId)
                        myJobs.Add(Convert.ToInt32(item.JobBossId));
                }
                return BL.SmartAgentLogic.getSomeJob(myJobs);
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }
    
      public static List<Entities.JobView>  CloseJob(int jobId,bool isByUs)
        {
            try
            {
                var job = DB.Job.FirstOrDefault(p => p.JobId == jobId);
                job.JobIsByUs = isByUs;
                job.JobDateCaughtJob = DateTime.Today.Date;
                Entities.PutInJob put = new Entities.PutInJob();
                put.PutJobId = jobId;
                put.PutDate = DateTime.Today.Date;
                DB.PutInJob.Add(Entities.PutInJob.PutInJobDAL(put));
                DB.SaveChanges();
                return BL.SelectorJob.getJobsByBossId(job.JobBossId);
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }
        }

    }
}

