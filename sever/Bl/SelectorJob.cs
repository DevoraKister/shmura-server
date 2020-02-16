using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Diagnostics;

namespace BL
{
    public class SelectorJob
    {
        public static DAL.IdialEntities3 db = new DAL.IdialEntities3();

        public static Entities.JobParameters getjobParameters()
        {
            try
            {


                Entities.JobParameters jp = new Entities.JobParameters();

                jp.Areas = getArea();
                jp.Parts = getPart();
                jp.SubjectJob = getSubjectJob();
                jp.Cities = getAllCity();
                jp.OutNets = getOutNet();
                jp.Workspaces = getWS();


                return jp;
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);

                return null;
            }

        }
        public static List<Entities.Part> getPart()
        {
            try
            {


                db.Configuration.LazyLoadingEnabled = false;

                List<Entities.Part> parts = new List<Entities.Part>();
                var h = db.Part.ToList();
                foreach (var item in h)
                {

                    parts.Add(Entities.Part.PartEntities(item));
                }
                //db.Database.Connection.Close();

                return parts;
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);

                return null;
            }
            //return db.areas();
        }
        public static List<Entities.OutNet> getOutNet()
        {
            try
            {
                List<Entities.OutNet> outNet = new List<Entities.OutNet>();
                var h = db.OutNet.ToList();
                foreach (var item in h)
                {

                    outNet.Add(Entities.OutNet.OutNetEntities(item));
                }
                db.Database.Connection.Close();

                return outNet;
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);

                return null;
            }
        }

        public static List<Entities.Workspace> getWS()
        {
            try
            {
                using (DAL.IdialEntities3 dbn = new DAL.IdialEntities3())
                {
                    dbn.Database.Connection.Open();

                    List<Entities.Workspace> ws = new List<Entities.Workspace>();
                    var h = dbn.Workspace.ToList();
                    foreach (var item in h)
                    {

                        ws.Add(Entities.Workspace.WorkspaceEntities(item));
                    }
                    dbn.Database.Connection.Close();

                    return ws;
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);

                return null;
            }
        }
        public static List<Entities.Area> getArea()
        {
            try
            {
                //db.Database.Connection.Open();
                using (DAL.IdialEntities3 dbn = new DAL.IdialEntities3())
                {
                    dbn.Database.Connection.Open();

                    List<Entities.Area> areas = new List<Entities.Area>();
                    foreach (var item in dbn.Area.ToList())
                    {
                        areas.Add(Entities.Area.AreaEntities(item));
                    }
                    areas = areas.OrderBy(p => p.AreaName).ToList();
                    dbn.Database.Connection.Close();

                    return areas;
                }

            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);

                return null;
            }
        }
        public static int getAreaByCityId(int cityId)
        {
            try
            {
                db.Database.Connection.Open();

                var area = db.City.FirstOrDefault(p => p.CityId == cityId);
                db.Database.Connection.Close();

                return area != null ? Convert.ToInt32(area.CityAreaId) : 1;
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return 0;
            }


        }
        public static List<Entities.Company> getCompanyName()
        {
            try
            {
                using (DAL.IdialEntities3 dbn = new DAL.IdialEntities3())
                {


                    dbn.Database.Connection.Open();

                    List<Entities.Company> companies = new List<Entities.Company>();
                    foreach (var item in dbn.Company.ToList())
                    {
                        companies.Add(Entities.Company.CompanyEntities(item));
                    }
                    companies = companies.OrderBy(p => p.CompanyName).ToList();
                    dbn.Database.Connection.Close();

                    return companies;
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);

                return null;
            }
        }

        public static List<Entities.City> getCity(int areaId)
        {
            try
            {

                using (DAL.IdialEntities3 db = new DAL.IdialEntities3())
                {

                    db.Database.Connection.Open();

                    List<Entities.City> cities = new List<Entities.City>();
                    foreach (var item in db.City.ToList())
                    {
                        cities.Add(Entities.City.CityEntities(item));
                    }
                    cities = cities.Where(p => p.CityAreaId == areaId).ToList();
                    cities = cities.OrderBy(p => p.CityName).ToList();

                    db.Database.Connection.Close();


                    return cities;
                }
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Your Information");
                Trace.TraceError("Your Error");
                Trace.TraceWarning("Your Warning");
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);

                return null;
            }
        }

        public static List<Entities.City> getAllCity()
        {
            try
            {
                using (DAL.IdialEntities3 db = new DAL.IdialEntities3())
                {

                    db.Database.Connection.Open();

                    List<Entities.City> cities = new List<Entities.City>();
                    foreach (var item in db.City.ToList())
                    {
                        cities.Add(Entities.City.CityEntities(item));
                    }
                    cities = cities.OrderBy(p => p.CityName).ToList();
                    db.Database.Connection.Close();

                    return cities;
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);

                return null;
            }
        }
        public static List<Entities.SubjectJob> getSubjectJob()
        {
            try
            {

                using (DAL.IdialEntities3 db = new DAL.IdialEntities3())
                {

                    db.Database.Connection.Open();

                    List<Entities.SubjectJob> subjectJob = new List<Entities.SubjectJob>();
                    foreach (var item in db.SubjectJob.ToList())
                    {
                        subjectJob.Add(Entities.SubjectJob.SubjectJobEntities(item));
                    }
                    subjectJob = subjectJob.OrderBy(p => p.SubName).ToList();
                    //subjectJob.OrderByDescending(p=>p.SubName,ab)
                    db.Database.Connection.Close();

                    return subjectJob;
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }

        }
        public static List<JobView> JobsByParameters(int? city1, int? area1, int? part1, int? sub1)

        {
            try
            {

                using (DAL.IdialEntities3 db = new DAL.IdialEntities3())
                {

                    db.Database.Connection.Open();
                    var com = db.Company.ToList();
                    List<Entities.Job> Job1 = new List<Entities.Job>();
                    List<Entities.Job> Job2 = new List<Entities.Job>();
                    //List<Entities.Company> companies = new List<Entities.Company>();


                    db.Configuration.ProxyCreationEnabled = false;
                    db.Configuration.LazyLoadingEnabled = false;

                    foreach (var item in db.Job.ToList())
                    {
                        Job1.Add(Entities.Job.JobEntities(item));
                    }
                    if (sub1 != 0)
                        Job1 = Job1.Where(j => j.JobSubId == sub1).ToList();
                    if (part1 != 0)
                        Job1 = Job1.Where(j => j.JobPartId == part1).ToList();
                    //if (area1 == 0 && city1 == 0 || city1 == 1 && city1 == 1)
                    //{
                    //    return JobView(Job1);
                    //}
                    if (area1 != 1)
                    {

                        if (city1 != 1)
                            com = com.Where(p => p.CompanyCityId == city1).ToList();
                        else
                            com = com.Where(p => p.CompanyAreaId == area1).ToList();
                    }
                    else
                         if (city1 != 1)
                        com = com.Where(p => p.CompanyCityId == city1).ToList();

                    foreach (var item in com)
                    {
                        Job2.AddRange(Job1.Where(c => c.JobCompanyId == item.CompanyId && c.JobStatus == true).ToList());

                    }
                    db.Database.Connection.Close();

                    return JobView(Job2);
                }
            }

            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return null;
            }

        }
        public static int stars(int? Workspace, int? OutNet)

        {
            try
            {


                int count = 0;
                if (OutNet == 1)
                    count += 5;
                else if (OutNet == 2 || OutNet == 3 || OutNet == 4)
                    count += 4;
                else if (OutNet == 5 || OutNet == 8)
                    count += 2;
                else if (OutNet == 9)
                    count += 1;

                if (Workspace == 1 || Workspace == 2 || Workspace == 3)
                    count += 5;
                else if (Workspace == 4)
                    count += 4;
                else if (Workspace == 5)
                    count += 3;
                //else if (Workspace == 3)
                //    count += 2;
                else if (Workspace == 6)
                    count += 1;

                return count / 2;
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message);
                return 0;
            }

        }

        public static List<JobView> getNewJobs()
        {
            try
            {
                //var context = new DAL.IdialEntities3();
                //context.Database.Initialize(force: false);
                // db.Database.Initialize(force: false);
                using (DAL.IdialEntities3 db = new DAL.IdialEntities3())
                {
                    db.Database.Connection.Open();
                    List<Entities.Job> Job2 = new List<Entities.Job>();
                    var y = from u in db.Job
                            where u.JobStatus == true && u.JobDateCaughtJob == null
                            orderby u.JobDateAdv descending
                            select u;
                    foreach (var item in y)
                    {
                        Job2.Add(Entities.Job.JobEntities(item));
                    }
                    db.Database.Connection.Close();

                    return JobView(Job2);
                }
            }
            catch (Exception e)
            {
                BL.SendMail.SendEmail(e.ToString(), e.Message, "");
                BL.WriteLogError.WriteLogErrors(e.Message + " " + e.Source + " " + e.Data);
                return null;
            }
}
public static List<JobView> getJobsByBossId(int? id)
{
    db.Database.Connection.Open();

    List<Entities.Job> Job2 = new List<Entities.Job>();
    var y = from u in db.Job
            where u.JobStatus == true && u.JobBossId == id && u.JobIsByUs == null
            orderby u.JobDateAdv descending
            select u;
    foreach (var item in y)
    {
        Job2.Add(Entities.Job.JobEntities(item));
    }

    return JobView(Job2);
}

//public static List<JobView> JobView(List<Job> job)
//{
//    List<Entities.JobView> jv = new List<JobView>();

//    foreach (var item in job)
//    {

//        DAL.Workspace w = db.Workspace.FirstOrDefault(p1 => p1.WSId == item.JobWorkspaceId);
//        DAL.SubjectJob s = db.SubjectJob.FirstOrDefault(p1 => p1.SubId == item.JobSubId);
//        DAL.OutNet outNet = db.OutNet.FirstOrDefault(o => o.OutNetId == item.JobPartOutNetId);
//        DAL.Company company = db.Company.FirstOrDefault(q => q.CompanyId == item.JobCompanyId);
//        DAL.City city = db.City.FirstOrDefault(c => c.CityAreaId == company.CompanyCityId);
//        DAL.Area area = db.Area.FirstOrDefault(a => a.AreaId == company.CompanyAreaId);
//        DAL.SubjectJob SubjectJob = db.SubjectJob.FirstOrDefault(o => o.SubId == item.JobSubId);
//        DAL.Part p = db.Part.FirstOrDefault(s2 => s2.PartId == item.JobPartId);
//        DAL.Job job1 = db.Job.FirstOrDefault(j => j.JobId == item.JobId);
//        Entities.JobView v = new JobView();
//        v = Entities.JobView.CreateJobView(area, company, job1, SubjectJob, w, p, outNet, city);
//        jv.Add(v);

//    }
//    return jv;
//}
public static List<JobView> JobView(List<Job> job)
{
    try
    {
        using (DAL.IdialEntities3 dbn = new DAL.IdialEntities3())
        {
            //new connection to the database 
            dbn.Database.Connection.Open();
            String diff2 = "";
            List<Entities.JobView> jv = new List<JobView>();
            DateTime temp;
            foreach (var item in job)
            {

                DAL.Workspace w = dbn.Workspace.FirstOrDefault(p1 => p1.WSId == item.JobWorkspaceId);
                DAL.SubjectJob s = dbn.SubjectJob.FirstOrDefault(p1 => p1.SubId == item.JobSubId);
                DAL.OutNet outNet = dbn.OutNet.FirstOrDefault(o => o.OutNetId == item.JobPartOutNetId);
                DAL.Company company = dbn.Company.FirstOrDefault(q => q.CompanyId == item.JobCompanyId);
                DAL.City city = dbn.City.FirstOrDefault(c => c.CityId == company.CompanyCityId);
                DAL.Area area = dbn.Area.FirstOrDefault(a => a.AreaId == company.CompanyAreaId);
                DAL.SubjectJob SubjectJob = dbn.SubjectJob.FirstOrDefault(o => o.SubId == item.JobSubId);
                DAL.Part p = dbn.Part.FirstOrDefault(s2 => s2.PartId == item.JobPartId);
                DAL.Job job1 = dbn.Job.FirstOrDefault(j => j.JobId == item.JobId);
                Entities.JobView v = new JobView();
                DateTime.TryParse(item.JobDateAdv.ToString(), out temp);
                if (temp != null)
                {
                    diff2 = Convert.ToInt32((DateTime.Today - temp).TotalDays).ToString();
                }

                v = Entities.JobView.CreateJobView(area, company, job1, SubjectJob, w, p, outNet, city, diff2);
                jv.Add(v);

            }
            return jv;

        }
        //DAL.IdialEntities3.Connection.Open();

    }
    catch (Exception e)
    {
        BL.SendMail.SendEmail(e.ToString(), e.Message, "");
        BL.WriteLogError.WriteLogErrors(e.Message);
        return null;
    }
}
//public static HttpResponseMessage AddNewJob(JobView jobView)
//{
//    try
//    {
//        Job newjob = new Job();

//        newjob.JobDateAdv = DateTime.Now;
//        newjob.JobDescribe = jobView.JobDescribe;
//        newjob.JobExperience = jobView.JobExperience;
//        newjob.JobPartId = db.Part.FirstOrDefault(p => p.PartName == jobView.PartName).PartId;
//        newjob.JobPartOutNetId = db.OutNet.FirstOrDefault(p => p.OutNetName == jobView.OutNetName).OutNetId;
//        newjob.JobRole = jobView.JobRole;
//        newjob.JobCompanyId = jobView.CompanyId;
//        newjob.JobBossId = jobView.BossId;
//        //newjob.JobStars

//        newjob.JobStatus = false;

//        newjob.JobSubId = db.SubjectJob.FirstOrDefault(p => p.SubName == jobView.SubjectName).SubId;
//        newjob.JobWorkspaceId = db.Workspace.FirstOrDefault(p => p.WSName == jobView.WSName).WSId;
//        newjob.JobRequire = jobView.JobRequire;
//        db.Job.Add(Entities.Job.JobDAL(newjob));
//        db.SaveChanges();

//        //SendToSmart(newjob);
//        return new HttpResponseMessage(HttpStatusCode.OK) { };
//    }
//    catch
//    {
//        return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
//    }
//}
public static HttpResponseMessage AddNewJob(Job jobView)
{
    try
    {
        db.Database.Connection.Open();


        Job newjob = new Job();

        newjob.JobDateAdv = DateTime.Now;
        newjob.JobDescribe = jobView.JobDescribe;
        newjob.JobExperience = jobView.JobExperience;
        newjob.JobPartId = jobView.JobPartId;
        newjob.JobPartOutNetId = jobView.JobPartOutNetId;
        newjob.JobRole = jobView.JobRole;
        newjob.JobCompanyId = jobView.JobCompanyId;
        newjob.JobBossId = jobView.JobBossId;
        newjob.JobStars = stars(jobView.JobWorkspaceId, jobView.JobPartOutNetId);

        newjob.JobStatus = false;

        newjob.JobSubId = jobView.JobSubId;
        newjob.JobWorkspaceId = jobView.JobWorkspaceId;
        newjob.JobRequire = jobView.JobRequire;
        db.Job.Add(Entities.Job.JobDAL(newjob));
        db.SaveChanges();

        //SendToSmart(newjob);
        return new HttpResponseMessage(HttpStatusCode.OK) { };
    }
    catch (Exception e)
    {
        BL.SendMail.SendEmail(e.ToString(), e.Message, "");
        BL.WriteLogError.WriteLogErrors(e.Message);
        return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
    }
}
public static void SendToSmart(Job newjob)
{
    var job = db.Job.FirstOrDefault(p => p.JobDescribe == newjob.JobDescribe && p.JobExperience == newjob.JobExperience && p.JobRole == newjob.JobRole);
    BL.SmartAgentLogic.SendImmediatelySmartAgent(Entities.Job.JobEntities(job));
}
public static List<Entities.Company> AddNewCompany(Company company)
{
    try
    {
        db.Database.Connection.Open();

        Company newCompany = new Company();
        newCompany.CompanyMail = company.CompanyMail;
        newCompany.CompanyName = company.CompanyName;
        newCompany.CompanyStreet = company.CompanyStreet;
        newCompany.CompanyTel = company.CompanyTel;
        newCompany.CompanyNumBuild = company.CompanyNumBuild;
        newCompany.CompanyAreaId = company.CompanyAreaId;
        newCompany.CompanyCityId = company.CompanyCityId;

        db.Company.Add(Entities.Company.CompanyDAL(newCompany));
        db.SaveChanges();


        //  return new HttpResponseMessage(HttpStatusCode.OK) { };
    }
    catch (Exception e)
    {
        BL.SendMail.SendEmail(e.ToString(), e.Message, "");
        BL.WriteLogError.WriteLogErrors(e.Message);
        //  return new HttpResponseMessage(HttpStatusCode.BadRequest) { };
    }
    List<Entities.Company> c = new List<Entities.Company>();
    var h = db.Company.ToList();
    foreach (var item in h)
    {

        c.Add(Entities.Company.CompanyEntities(item));
    }
    return c;

}


public static List<Entities.SubjectJob> getSubjectsSurvey()
{
    db.Database.Connection.Open();

    List<Entities.SubjectJob> subjectJob = new List<Entities.SubjectJob>();
    foreach (var item in db.SubjectJob.ToList())
    {
        subjectJob.Add(Entities.SubjectJob.SubjectJobEntities(item));
    }
    return subjectJob;
}

public static HttpResponseMessage addSurvey(Survey survey)
{

    try
    {
        db.Database.Connection.Open();

        Entities.Survey newSurvey = new Entities.Survey();
        newSurvey.SurveyIsWork = survey.SurveyIsWork;
        if (survey.SurveySeminar != null)
            newSurvey.SurveySeminar = survey.SurveySeminar;
        if (survey.SurveySubLearnId != null)
            newSurvey.SurveySubLearnId = survey.SurveySubLearnId;
        if (survey.SurveySubTodayId != null)
            newSurvey.SurveySubTodayId = survey.SurveySubTodayId;

        if (survey.SurveySubTodayTxt != null)
            newSurvey.SurveySubTodayTxt = survey.SurveySubTodayTxt;
        if (survey.SurveySubLearnedTxt != null)
            newSurvey.SurveySubLearnedTxt = survey.SurveySubLearnedTxt;
        var _survey = Entities.Survey.SurveyDAL(newSurvey);
        db.Survey.Add(_survey);
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

//edit job
public static HttpResponseMessage EditJobDetails(JobView editJob)
{
    try
    {
        db.Database.Connection.Open();

        var y = from u in db.Job
                where u.JobId == editJob.JobId
                select u;
        foreach (var item in y)
        {
            item.JobIsByUs = editJob.JobIsByUs;
            //item.JobOfferId = editJob.JobOfferId;
            item.JobPartId = editJob.JobPartId;
            item.JobPartOutNetId = editJob.JobPartOutNetId;
            item.JobWorkspaceId = editJob.JobWorkspaceId;
            item.JobDateCaughtJob = editJob.JobDateCaughtJob;
            item.JobDateAdv = editJob.JobDateAdv;
            item.JobBossId = editJob.JobBossId;
            item.JobCompanyId = editJob.JobCompanyId;
            item.JobDescribe = editJob.JobDescribe;
            item.JobExperience = editJob.JobExperience;
            //item.JobCVId = editJob.JobCVId;
            item.JobRole = editJob.JobRole;
            item.JobStatus = editJob.JobStatus;
            item.JobStars = editJob.JobStars;
            item.JobSubId = editJob.JobSubId;
            item.JobRequire = editJob.JobRequire;

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



public static HttpResponseMessage EditCompanyDetails(Company editCompany)
{
    try
    {
        db.Database.Connection.Open();

        var y = from u in db.Company
                where u.CompanyId == editCompany.CompanyId
                select u;
        foreach (var item in y)
        {
            item.CompanyAreaId = editCompany.CompanyAreaId;
            item.CompanyCityId = editCompany.CompanyCityId;
            item.CompanyMail = editCompany.CompanyMail;
            item.CompanyName = editCompany.CompanyName;
            item.CompanyNumBuild = editCompany.CompanyNumBuild;
            item.CompanyStreet = editCompany.CompanyStreet;
            item.CompanyTel = editCompany.CompanyTel;
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
public static HttpResponseMessage addRecomend(Recomend recomend)
{

    try
    {
        db.Database.Connection.Open();

        Entities.Recomend newRecomend = new Recomend();
        newRecomend.RecomemdCompanyId = recomend.RecomemdCompanyId;
        newRecomend.RecomendUserId = recomend.RecomendUserId;
        newRecomend.RecomendInfo = recomend.RecomendInfo;
        db.Recomend.Add(Entities.Recomend.RecomendDAL(newRecomend));
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


public static List<Entities.Recomend> getRecommendsToCurrentJob(int jobId)
{
    List<Entities.Recomend> recommendList = new List<Recomend>();
    int? companyId = db.Job.FirstOrDefault(j => j.JobId == jobId).JobCompanyId;
    if (companyId == null)
        return null;
    foreach (var item in db.Recomend)
    {
        if (item.RecomemdCompanyId == companyId)
            recommendList.Add(Entities.Recomend.RecomendEntities(item));
    }

    return recommendList;

}


    }

}

