using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GUI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/timer")]
    public class TimerController : ApiController
    {
        [Route("SetTimer")]
        [HttpGet]
        public void SetTimer()
        {
            BL.LoadProjectBL.useFuncToLoadThisClass();
        }

    }
}
