using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GUI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [System.Web.Http.RoutePrefix("api/forum")]
    public class ForumController : ApiController
    {
        [Route("getAllQuestion")]//מחזיר את כל השאלות שבפורום
        [HttpGet]
        public IHttpActionResult getAllQuestion()
        {
            return Ok(BL.ForumLogic.getAllQuestion());
        }

        [Route("getTopicQuestion")]//מחזיר את כל השאלות שבפורום
        [HttpGet]
        public IHttpActionResult getTopicQuestion()
        {
            return Ok(BL.ForumLogic.getTopicQuestion());
        }

        [Route("AddQuestion")]//הוספת שאלה 
        [HttpPost]
        public IHttpActionResult AddQuestion([FromBody]Entities.Question question)
        {
            return Ok(BL.ForumLogic.AddQuestion(question));
        }
        [Route("AddAnswer")]//הוספת שאלה 
        [HttpPost]
        public IHttpActionResult AddAnswer([FromBody] Entities.Question answer)
        {
            return Ok(BL.ForumLogic.AddAnswer(answer.QueId, answer.Answer));
        }

        //[Route("deleteJob{jobId}")]
        //[HttpDelete]
        //public IHttpActionResult deleteJob(int jobId)
        //{
        //    return Ok(BL.ForumLogic.deleteJob(jobId));
        //}
        // GET: Forum


        //[System.Web.Http.HttpPost]
        //public async Task<IHttpActionResult> add([FromBody] Entities.Question question)
        //{
        //   BL.Forum.update(question);
        //    return Ok(await BL.Add.GetUserAsync(user));

    }
}