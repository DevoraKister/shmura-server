using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sign
    {

        public int SignId { get; set; }
        public Nullable<int> SignJobId { get; set; }
        public Nullable<int> SignUserId { get; set; }
        public Nullable<System.DateTime> SignDate { get; set; }
        public Nullable<bool> SignStatusSend { get; set; }
        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
        public static Entities.Sign SignEntities(DAL.Sign s)
        {
            return new Entities.Sign()
            {
                SignDate = s.SignDate,
                SignId = s.SignId,
                SignJobId = s.SignJobId,
                SignUserId = s.SignUserId,
                SignStatusSend = s.SignStatusSend
            };
        }
        public static DAL.Sign SignDAL(Entities.Sign s)
        {
            return new DAL.Sign()
            {
                SignDate = s.SignDate,
                SignId = s.SignId,
                SignJobId = s.SignJobId,
                SignUserId = s.SignUserId,
                SignStatusSend = s.SignStatusSend



            };
        }
    }
}
