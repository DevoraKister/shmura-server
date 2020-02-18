using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Advs
    {

        public int AdvId { get; set; }
        public Nullable<bool> AdvStatus { get; set; }
        public string AdvLink { get; set; }
        public string AdvTitle { get; set; }
        public string AdvContent { get; set; }
        public string AdvMail { get; set; }
        public string AdvPhone { get; set; }
        public Nullable<int> CountUsers { get; set; }

        public static Entities.Advs AdvsEntities(DAL.Adv c)
        {
            return new Entities.Advs()
            {
                AdvId = c.AdvId,
                AdvStatus = c.AdvStatus,
                AdvLink = c.AdvLink,
                AdvTitle = c.AdvTitle,
                AdvContent = c.AdvContent,
                AdvMail = c.AdvMail,
                AdvPhone = c.AdvPhone,
                CountUsers = c.CountUsers,
            };
        }
        public static DAL.Adv AdvsDAL(Entities.Advs c)
        {
            return new DAL.Adv()
            {
                AdvId = c.AdvId,
                AdvStatus = c.AdvStatus,
                AdvLink = c.AdvLink,
                AdvTitle = c.AdvTitle,
                AdvContent = c.AdvContent,
                AdvMail = c.AdvMail,
                AdvPhone = c.AdvPhone,
                CountUsers = c.CountUsers,
            };
        }
    }
}
