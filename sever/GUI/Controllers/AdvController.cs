using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GUI.Controllers
{
    [RoutePrefix("Api/Adv")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdvController : ApiController
    {
        [Route("getAdvs")]//מחזיר פרסומות
        [HttpGet]
        public IHttpActionResult getAdvs()
        {
            return Ok(BL.Adv.getAdvs());
        }

        [Route("editAdvs")]//מעדכן פרסומות
        [HttpGet]
        public IHttpActionResult editAdvs()
        {
            return Ok(BL.Adv.getAdvs());
        }




        // ---------------------
        [Route("createUser")]
        [HttpPost]
        public IHttpActionResult addUser()
        {
            return Ok(BL.Adv.getAdvs());
        }

        [Route("editUser")]
        [HttpPut]
        public IHttpActionResult editUser()
        {
            return Ok(BL.Adv.getAdvs());
        }

        [Route("deleteUser")]
        [HttpDelete]
        public IHttpActionResult deleteUser()
        {
            return Ok(BL.Adv.getAdvs());

        }
        [Route("getUser")]
        [HttpGet]
        public int getUer()
        {
            return 2;
        }
    }
}
