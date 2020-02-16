using Bl;
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
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        //    [Route("login")]
        //    [HttpPost]

        //    public async Task<IHttpActionResult> Login([FromBody] Entities.User user)
        //    {

        //        return Ok(await BL.UserLogic.GetUserAsync(user,Request.RequestUri));

        //    }
        [Route("login")]//מקבלת אובייקט משתמש ובודקת אם קיים
        [HttpPost]
        public IHttpActionResult Login([FromBody] Entities.User user)
        {
            //SessionManager.BossId = 123;
            return Ok(BL.UserLogic.CheckIsLogin(user));

        }
        [Route("GetUser/{id}")]//user ומחזירה  id  מקבלת 
        [HttpGet]
        public IHttpActionResult Login(int id)
        {
            //int a = SessionManager.BossId;
            return Ok(BL.UserLogic.GetUser(id));
        }
        //[HttpGet]
        //[Route("getLoggedUser")]
        //public IHttpActionResult GetLoggedUser([UserLogged] User user)
        //{
        //    return Ok(user);
        //}
        [Route("GetBoss/{id}")]//Boss ומחזירה  id  מקבלת 
        [HttpGet]
        public Entities.Boss LoginBoss(int id)
        {
            return BL.UserLogic.GetBoss(id);
        }
        [Route("loginBoss")]//מקבלת אובייקט Boss ובודקת אם קיים
        [HttpPost]
        public Entities.Boss loginBoss([FromBody] Entities.Boss boss)
        {
        
            return BL.UserLogic.IsRegistered(boss);

        }
        [Route("loginAdmin")]//מקבלת אובייקט Boss ובודקת אם קיים
        [HttpGet]
        public IHttpActionResult loginAdmin()
        {

            return Ok( BL.SendMail.Admin());

        }
        [Route("registerBoss")]//ורושמת אותו Boss מקבלת
        [HttpPost]
        public Entities.Boss registerBoss([FromBody] Entities.Boss boss)
        {
            bool x = BL.UserLogic.NotValidPasswordBoss(boss.BossMail);
            if (x == true)
            {
              
                return BL.UserLogic.registerBoss(boss) ;
            }
            else
                return null;
        }
        [Route("registerUser")]//ורושמת אותו User מקבלת
        [HttpPost]
        public Entities.User register([FromBody] Entities.User user)
        {

            bool x = BL.UserLogic.NotValidPasswordUser(user.UserMail);
            if (x == true)
            {
                return BL.UserLogic.registerUser(user);

            }
            else
                return null;

        }
        [Route("GetUserById/{id}")]//id לפי user  מחזירה אוביקט 
        [HttpGet]
        public Entities.User GetUserById(int id)
        {
            return BL.UserLogic.GetUser(id);
        }
        [Route("GetBossById/{id}")]//id לפי Boss  מחזירה אוביקט 
        [HttpGet]
        public Entities.Boss GetBossById(int id)
        {
            return BL.UserLogic.GetBoss(id);
        }
        [Route("EditUser")]//עריכת פרטי משתמש
        [HttpPost]
        public IHttpActionResult EditUser([FromBody]Entities.User editUser)
        {
            return Ok(BL.UserLogic.EditDetailsUser(editUser));
        }
        [Route("EdiBoss")]//עריכת פרטי מפרסם
        [HttpPost]
        public IHttpActionResult EditBoss([FromBody]Entities.Boss editBoss)
        {
            return Ok(BL.UserLogic.EditDetailsBoss(editBoss));
        }
        [Route("file")]//uplodeFile מקבלת קובץ (קורות חיים)  ושומר בתקית
        [HttpPost]
        public HttpResponseMessage UploadJsonFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            string temp = "~/UploadFile/";
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath(temp + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    //postedFile.SaveAs(@"C:/ideal");
                    BL.UserLogic.addCv(postedFile.FileName);
                }
            }
            return response;
        }
        [Route("registerToJob/{idJob}/{idUser}")]//משתמש נרשם למשרה ספציפית
        [HttpGet]
        public IHttpActionResult registerToJob(int idJob, int idUser)
        {
            return Ok(BL.PuttingAtJob.RegisterToSingJob(idJob, idUser));
        }
        [Route("connect/{mail}/{phone}/{name}/{details}/{subject}")]//יצירת קשר
        [HttpGet]
        public IHttpActionResult connect(string mail, string phone, string name, string details, string subject)
        {
            return Ok(BL.SendMail.CreateConnect(mail, phone, name, details, subject));
        }
        [Route("getCv/{idUser}")]//מחזיר קורות חיים של משתמש מסויים
        [HttpGet]
        public string getCv(int idUser)
        {
            return BL.UserLogic.getCv(idUser);
        }

        [Route("GetBossDetails/{id}/{password}")]//
        [HttpGet]
        public Entities.Boss GetBossDetails(int id, string password)
        {
            return BL.UserLogic.GetBossDetailsByIdPassword(id, password);
        }
        [Route("GetUserDetails/{id}/{password}")]
        [HttpGet]
        public IHttpActionResult GetUserDetails(int id, string password)
        {
            return Ok(BL.UserLogic.GetUserDetailsByIdPassword(id, password));
        }
        [Route("UserSmartAgent/{timeNumber}")]//העדפת משתמש לתדירות סוכן חכם
        [HttpGet]
        public IHttpActionResult UserSmartAgent(int timeNumber)
        {
            return Ok(BL.SmartAgentLogic.UserSmartAgent(timeNumber));
        }
        [Route("changePassword/{email}/{p1}")]
        [HttpGet]
        public IHttpActionResult changePassword(string email, string p1)
        {
            return Ok(BL.UserLogic.changePassword(email, p1));
        }
        //לאיפוס למייל
        [Route("resetMail")]
        [HttpPost]
        public IHttpActionResult resetMail([FromBody]Entities.User email)
        {
            return Ok(BL.SendMail.resetMail(email.UserMail));

        }
        [Route("countEnterUser/")]
        [HttpGet]
        public IHttpActionResult countEnterUser()
        {
            return Ok(BL.DataBaseLogic.countUser());
        }


    }




}




//[Route("sendMail")]
//[HttpPost]
//public string sendMail()
//{
//    return BL.SendMail.SendEmail("dsfdsf","sdfsdfer","kister1010@gmail.com");
//}
//[Route("SmartAgent")]
//[HttpGet]
//public IHttpActionResult SmartAgent()
//{
//    return Ok(BL.SmartAgentLogic.);

//}


