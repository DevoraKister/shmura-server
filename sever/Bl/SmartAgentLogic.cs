using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Entities;
namespace BL
{
    public class SmartAgentLogic
    {

        public static DAL.IdialEntities3 db = new DAL.IdialEntities3();
        public static bool UserSmartAgent(int timeNumber)
        {
            try
            {
                
                //HttpContext.Current.Session["BossUserId"] = 1;
                //HttpContext.Current.Session["UserId"] = 2;
                List<Entities.User> users = new List<Entities.User>();
                var h = db.User.ToList();
                foreach (var item in h)
                {

                    if (item.UserIsSmartAgent == true)//if the user login to the smartAgent
                    {
                        if (item.UserSmartAgentTime == timeNumber)
                        {
                            users.Add(Entities.User.UserEntities(item));
                            int areaId = BL.SelectorJob.getAreaByCityId(Convert.ToInt32(item.UserCityId));
                            //a list of jobs that can be ok to the user
                            List<JobView> jobsView = SelectorJob.JobsByParameters(item.UserCityId, areaId, item.UserPartId, item.UserSubId);
                            List<Job> jobs = new List<Job>();
                            foreach (var j in jobsView)
                            {
                                var currentJob = db.Job.FirstOrDefault(p => p.JobId == j.JobId);
                                if (currentJob != null)
                                {
                                    jobs.Add(Entities.Job.JobEntities(currentJob));
                                }

                            }
                            List<Job> jobToSend = new List<Job>();
                            foreach (var i in jobs)
                            {

                                if (i.JobStatus != null && i.JobStatus == true)
                                {
                                    int timePastFromAdv;
                                    DateTime temp;
                                    DateTime.TryParse(i.JobDateAdv.ToString(), out temp);
                                    if (temp != null)
                                    {
                                        double diff = (DateTime.Today - temp).TotalDays;

                                        switch (timeNumber)
                                        {
                                            case 1:
                                                timePastFromAdv = 1;
                                                break;
                                            case 2:
                                                timePastFromAdv = 7;
                                                break;
                                            case 3:
                                                timePastFromAdv = 30;
                                                break;
                                            default:
                                                timePastFromAdv = 30;
                                                break;
                                        }
                                        if (Convert.ToInt32(diff) <= timePastFromAdv)
                                        {
                                            jobToSend.Add(i);
                                        }
                                    }

                                }


                            }
                            if (jobToSend.Count > 0)
                                BL.SendMail.SmartAgent(Entities.User.UserEntities(item), BL.SelectorJob.JobView(jobToSend));
                        }
                    }


                }
                return true;

            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return false;
            }
        }


        public static List<Entities.JobView> getSomeJob(List<int> jobsId)
        {
            try
            {
                List<Entities.Job> jobs = new List<Job>();
                foreach (var item in jobsId)
                {
                    var job = db.Job.FirstOrDefault(p => p.JobId == item);
                    if (job != null &&job.JobDateCaughtJob!=null)
                        jobs.Add(Entities.Job.JobEntities(job));
                }

                return SelectorJob.JobView(jobs);

            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }

        }

        public static bool signToSomeJob(List<int> jobsId)
        {
            try
            {
                int userId = jobsId[0];
                for (int i = 1; i < jobsId.Count; i++)
                {
                    var r = jobsId[i];
                    var id = db.Job.FirstOrDefault(p => p.JobId == r && p.JobStatus == true);
                    if (id != null)

                        BL.PuttingAtJob.RegisterToSingJob(jobsId[i], userId);
                }

                return true;
            }

            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return false;
            }
        }
        public static bool SendImmediatelySmartAgent(Entities.Job newJob)
        {
            try
            {
                var company = db.Company.FirstOrDefault(p => p.CompanyId == newJob.JobCompanyId);
                List<Entities.User> userEnt = new List<User>();
                List<DAL.User> users =
                    db.User.Where(p => p.UserIsSmartAgent == true && p.UserSmartAgentTime == 4
                    && p.UserPartId == newJob.JobPartId && p.UserSubId == newJob.JobSubId).ToList();

                List<Entities.City> cities = SelectorJob.getAllCity();
                foreach (var item in users)
                {
                    var cityid = cities.FirstOrDefault(c => c.CityId == item.UserCityId);
                    if (cityid.CityAreaId == company.CompanyAreaId)
                        userEnt.Add(Entities.User.UserEntities(item));
                }
                List<Entities.Job> jobs = new List<Job>();
                jobs.Add(newJob);
                var jobView = SelectorJob.JobView(jobs);
                foreach (var item in userEnt)
                {
                    SendMail.SmartAgent(item, jobView);
                }
                return true;
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return false;
            }
        }

    }

}




