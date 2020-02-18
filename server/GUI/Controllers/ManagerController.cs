using BL.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GUI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/manager")]
    public class ManagerController : ApiController
    {

        [Route("JobsToCheck")]
        [HttpGet]
        public IHttpActionResult JobsToCheck()
        {
            return Ok(BL.ManagerLogic.JobToCheck());
        }
        [Route("OkTheCheck/{idJob}")]
        [HttpGet]
        public IHttpActionResult OkTheCheck(int idJob)
        {
            return Ok(BL.ManagerLogic.OkTheCheck(idJob));
        }
        [Route("removeCompany/{companyId}")]
        [HttpGet]
        public IHttpActionResult removeCompany(int companyId)
        {
            return Ok(BL.ManagerLogic.removeCompany(companyId));
        }
        [Route("getBoss/{bossId}")]
        [HttpGet]
        public IHttpActionResult getBoss(int bossId)
        {
            return Ok(BL.ManagerLogic.GetBoss(bossId));
        }
        [Route("removeBoss/{bossId}")]
        [HttpGet]
        public IHttpActionResult removeBoss(int bossId)
        {
            return Ok(BL.ManagerLogic.removeBoss(bossId));
        }

        [Route("removeUser/{userId}")]
        [HttpGet]
        public IHttpActionResult removeUser(int userId)
        {
            return Ok(BL.ManagerLogic.removeUser(userId));
        }
        //[Route("jobsSign")]
        //[HttpGet]
        //public IHttpActionResult jobsSign()
        //{
        //    return Ok(BL.ManagerLogic.jobsSign());
        //}
        [Route("addAnswerfromRav")]
        [HttpPost]
        public IHttpActionResult addAnswerfromRav([FromBody]Entities.Question question)
        {
            return Ok(BL.ManagerLogic.addAnswerfromRav(question));
        }

        [Route("getTopicQuestion")]
        [HttpGet]
        public IHttpActionResult getTopicQuestion()
        {
            return Ok(BL.ManagerLogic.getTopicQuestion());
        }

        [Route("jobsSign")]
        [HttpGet]
        public IHttpActionResult jobsSign()
        {
            return Ok(BL.ManagerLogic.jobsSign());
        }


        [Route("userToSpecificJob/{jobId}")]
        [HttpGet]
        public IHttpActionResult getListSignUsers(int jobId)
        {
            return Ok(BL.ManagerLogic.getListSignUsers(jobId));
        }


        [Route("EditUser")]
        [HttpPost]
        public IHttpActionResult EditUser([FromBody]Entities.User editUser)
        {
            return Ok(BL.UserLogic.EditDetailsUser(editUser));
        }

        [Route("EdiBoss")]
        [HttpPost]
        public IHttpActionResult EditBoss([FromBody]Entities.Boss editBoss)
        {
            return Ok(BL.UserLogic.EditDetailsBoss(editBoss));
        }
        //api/manager/jobsSign

        //[Route("getUsersSingToJob/{id}")]
        //[HttpGet]
        //public IHttpActionResult getUsersSingToJob(int id)
        //{

        //    //return Ok(BL.ManagerLogic.getUsersSingToJob(id));
        //}

        [Route("getknowledge/")]
        [HttpGet]
        public IHttpActionResult getknowledge()
        {
            return Ok(BL.ManagerLogic.getknowledge());
        }
        [Route("addNewSubjectJob/{subjectName}")]
        [HttpGet]
        public IHttpActionResult addNewSubjectJob(string subjectName)
        {
            return Ok(BL.DataBaseLogic.addNewSubjectJob(subjectName));
        }

        [Route("deleteSubjectJob/{subjectId}")]
        [HttpGet]
        public IHttpActionResult deleteSubjectJob(int subjectId)
        {
            return Ok(BL.DataBaseLogic.deleteSubjectJob(subjectId));
        }

        [Route("removeQuestion/{questionId}")]
        [HttpGet]
        public IHttpActionResult removeQuestion(int questionId)
        {
            return Ok(BL.DataBaseLogic.removeQuestion(questionId));
        }
        [Route("sendCv/{jobId}/{userId}")]
        [HttpGet]
        public IHttpActionResult SendCv(int jobId,int userId)
        {
            return Ok(BL.ManagerLogic.SendCv(userId,jobId));
        }
        [Route("addAdv")]//הוספת פרסומת
        [HttpPost]
        public IHttpActionResult addAdv([FromBody]Entities.Advs adv)
        {
            return Ok(BL.DataBaseLogic.addAdv(adv));
        }
        [Route("fileAdv")]//uplodeFile מקבלת קובץ (קורות חיים)  ושומר בתקית
        [HttpPost]
        public HttpResponseMessage UploadJsonFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            string temp = "~/UploadFile/Adv/";
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath(temp + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    //postedFile.SaveAs(@"C:/ideal");
                    BL.DataBaseLogic.addAdvImg(postedFile.FileName);
                }
            }
            return response;
        }
        [Route("removeAdv/{advId}")]
        [HttpGet]
        public IHttpActionResult removeAdv(int advId)
        {
            return Ok(BL.Adv.removeAdv(advId));
        }
        




        //שנוי
        [Route("addQuestion")]
        [HttpPost]
        public IHttpActionResult addQuestion([FromBody]Entities.Question question)
        {
            return Ok(BL.DataBaseLogic.addQuestion(question));
        }

        [Route("addNewOutNet/{outNetName}")]
        [HttpGet]
        public IHttpActionResult addNewOutNet(string outNetName)
        {
            return Ok(BL.DataBaseLogic.addNewOutNet(outNetName));
        }
        [Route("removeOutNet/{id}")]
        [HttpGet]
        public IHttpActionResult removeOutNet(int id)
        {
            return Ok(BL.DataBaseLogic.removeOutNet(id));
        }
        [Route("addWorkspace/{ws}")]
        [HttpGet]
        public IHttpActionResult addWorkspace(string ws)
        {
            return Ok(BL.DataBaseLogic.addWorkspace(ws));
        }
        [Route("removeWorkspace/{id}")]
        [HttpGet]
        public IHttpActionResult removeWorkspace(int id)
        {
            return Ok(BL.DataBaseLogic.removeWorkspace(id));
        }

        //[Route("removeJob/{id}")]
        //[HttpGet]
        //public IHttpActionResult removeJob(int id)
        //{
        //    return Ok(BL.DataBaseLogic.removeJob(id));
        //}

        [Route("addPart/{partName}")]
        [HttpGet]
        public IHttpActionResult addPart(string partName)
        {
            return Ok(BL.DataBaseLogic.addPart(partName));
        }

        [Route("removePart/{id}")]
        [HttpGet]
        public IHttpActionResult removePart(int id)
        {
            return Ok(BL.DataBaseLogic.removePart(id));
        }
        //-----------------database----------------------
        [Route("getAllUsers")]
        [HttpGet]
        public IHttpActionResult getAllUsers()
        {
            return Ok(BL.DataBaseLogic.getAllUsers());
        }

        [Route("geBossList/")]
        [HttpGet]
        public IHttpActionResult geBossList()
        {
            return Ok(BL.DataBaseLogic.geBossList());
        }
        [Route("getJobsList/")]
        [HttpGet]
        public IHttpActionResult getJobsList()
        {
            return Ok(BL.DataBaseLogic.getJobsList());
        }
        [Route("removeJob/{jobId}")]
        [HttpGet]
        public IHttpActionResult removeJob(int jobId)
        {
            return Ok(BL.DataBaseLogic.removeJob(jobId));
        }


        [Route("getJobById/{jobId}")]
        [HttpGet]
        public IHttpActionResult getJobById(int id)
        {
            return Ok(BL.DataBaseLogic.getJobById(id));
        }

    }
}
//api/manager/getListSignUsers/44