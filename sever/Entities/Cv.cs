using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Cv
    {



        public int CvId { get; set; }
        public string CvLink { get; set; }
        public Nullable<int> CvUserId { get; set; }

        public virtual List<Job> Job { get; set; }
        public static Entities.Cv CvEntities(DAL.Cv r)
        {
            return new Entities.Cv()
            {
                CvId = r.CvId,
                CvLink = r.CvLink,
               CvUserId=r.CvUserId


            };
        }
        public static DAL.Cv CvDAL(Entities.Cv r)
        {
            return new DAL.Cv()
            {

                CvId = r.CvId,
                CvLink = r.CvLink,
                CvUserId = r.CvUserId

            };
        }
    }
}
