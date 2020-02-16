using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GUI.Controllers
{
    [RoutePrefix("Job/api")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class JobController : ApiController
    {
        [Route("getParts")]
        [HttpGet]
        public IHttpActionResult GetAllPart()
        {
            return Ok(BL.SelectorJob.getPart());
        }
        [Route("getArea")]
        [HttpGet]
        public IHttpActionResult getArea()
        {
            return Ok(BL.SelectorJob.getArea());
        }
        [Route("getCity/{AreaId}")]
        [HttpGet]
        public IHttpActionResult getCity(int AreaId)
        {
            return Ok(BL.SelectorJob.getCity(AreaId));
        }
        [Route("getSubjectJob")]
        [HttpGet]
        public IHttpActionResult getSubjectJob()
        {
            return Ok(BL.SelectorJob.getSubjectJob());
        }


        [Route("jobParameters")]
        [HttpGet]
        public IHttpActionResult jobParameters()
        {
            return Ok(BL.SelectorJob.getjobParameters());
        }


        [Route("JobsByParameters/{city1}/{area1}/{part1}/{sub1}")]
        [HttpGet]
        public IHttpActionResult JobsByParameters(int city1, int area1, int part1, int sub1)
        {
            return Ok(BL.SelectorJob.JobsByParameters(city1, area1, part1, sub1));
        }
        [Route("NewJobs")]
        [HttpGet]
        public IHttpActionResult NewJobs()
        {
            return Ok(BL.SelectorJob.getNewJobs());
        }

        [Route("getJobsByBossId/{idBoss}")]
        [HttpGet]
        public IHttpActionResult getJobsByBossId(int idBoss)
        {
            return Ok(BL.SelectorJob.getJobsByBossId(idBoss));
        }
        //[Route("AddJob")]
        //[HttpPost]
        //public IHttpActionResult AddJob([FromBody]Entities.JobView jobView)
        //{
        //    return Ok(BL.SelectorJob.AddNewJob(jobView));
        //}
        [Route("AddJob")]
        [HttpPost]
        public IHttpActionResult AddJob([FromBody]Entities.Job job)
        {
            return Ok(BL.SelectorJob.AddNewJob(job));
        }
        [Route("EditJob")]
        [HttpPost]
        public IHttpActionResult EditJob([FromBody]Entities.JobView editJob)
        {
            return Ok(BL.SelectorJob.EditJobDetails(editJob));
        }

        [Route("AddCompany")]
        [HttpPost]
        public IHttpActionResult AddCompany([FromBody]Entities.Company company)
        {

            return Ok(BL.SelectorJob.AddNewCompany(company));
        }

        [Route("EditCompany")]
        [HttpPost]
        public IHttpActionResult EditCompany([FromBody]Entities.Company editCompany)
        {

            return Ok(BL.SelectorJob.EditCompanyDetails(editCompany));
        }
        [Route("getCompany")]
        [HttpGet]
        public IHttpActionResult getCompany()
        {
            return Ok(BL.SelectorJob.getCompanyName());
        }
        [Route("getSubjectsSurvey")]
        [HttpGet]
        public IHttpActionResult getSubjectsSurvey()
        {
            return Ok(BL.SelectorJob.getSubjectsSurvey());
        }
        [Route("addSurvey")]
        [HttpPost]
        public IHttpActionResult addSurvey([FromBody]Entities.Survey Survey)
        {
            return Ok(BL.SelectorJob.addSurvey(Survey));
        }
        [Route("addNewRecomend")]
        [HttpPost]
        public IHttpActionResult addNewRecomend([FromBody]Entities.Recomend recomend)
        {
            return Ok(BL.SelectorJob.addRecomend(recomend));
        }
        [Route("getRecommendsToCurrentJob/{jobId}")]
        [HttpGet]
        public IHttpActionResult getRecommends(int jobId)
        {
            return Ok(BL.SelectorJob.getRecommendsToCurrentJob(jobId));
        }

        [Route("getSomeJob")]
        [HttpPost]
        public IHttpActionResult getSomeJob([FromBody] List<int> jobsIdList)
        {
            return Ok(BL.SmartAgentLogic.getSomeJob(jobsIdList));
        }

        [Route("signToSomeJob")]
        [HttpPost]
        public IHttpActionResult signToSomeJob([FromBody] List<int> jobsIdList)
        {
            return Ok(BL.SmartAgentLogic.signToSomeJob(jobsIdList));
        }
        
        [Route("getJobsUserSigned/{userId}")]
        [HttpGet]
        public IHttpActionResult getJobsUserSigned(int userId)
        {
            return Ok(BL.PuttingAtJob.getJobsUserSigned(userId));
        }
        //[Route("getJobsByBossId/{bossId}")]
        //[HttpGet]
        //public IHttpActionResult getJobsByBossId(int userId)
        //{
        //    return Ok(BL.PuttingAtJob.getJobsByBossId(userId));
        //}
        [Route("CloseJob/{jobId}/{isByUs}")]
        [HttpGet]
        public IHttpActionResult CloseJob(int jobId,bool isByUs)
        {
            return Ok(BL.PuttingAtJob.CloseJob(jobId,isByUs));
        }


    }
}
