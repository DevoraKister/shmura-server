using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Bl
{
    public static class SessionManager
    {
        static HttpSessionState session = HttpContext.Current.Session;
        public static int BossId
        {

            get
            {
                if (session != null&& session["BossUserId"] != null)
                 
                    return int.Parse(session["BossUserId"].ToString());
                return 0;
            }
            set
            {
                session["BossUserId"] = value;
            }


        }


        public static int UserId
        {
            get
            {
                if (session["userId"] != null)
                    return int.Parse(session["userId"].ToString());
                return 0;
            }
            set
            {
                session["userId"] = value;
            }
        }

    }
    
}
