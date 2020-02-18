using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Request
    {
        public int ReqId { get; set; }
        public Nullable<int> ReqUserId { get; set; }
        public string ReqContents { get; set; }
        public Nullable<int> ReqTypeConectId { get; set; }

        public virtual TypeConnect TypeConnect { get; set; }
        public virtual User User { get; set; }
        public static Entities.Request RequestEntities(DAL.Request r)
        {
            return new Entities.Request()
            {
                ReqContents = r.ReqContents,
                ReqId = r.ReqId,
                ReqTypeConectId = r.ReqTypeConectId,
                ReqUserId = r.ReqUserId
            };
        }
        public static DAL.Request RequestDAL(Entities.Request r)
        {
            return new DAL.Request()
            {
                ReqContents = r.ReqContents,
                ReqId = r.ReqId,
                ReqTypeConectId = r.ReqTypeConectId,
                ReqUserId = r.ReqUserId
            };
        }
    }
}
