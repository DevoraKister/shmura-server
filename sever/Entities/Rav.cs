using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Rav
    {
        public int RavId { get; set; }
        public string RavName { get; set; }

        public virtual List<Question> Question { get; set; }
        public static Entities.Rav RavEntities(DAL.Rav r)
        {
            return new Entities.Rav()
            {
                RavId = r.RavId,
                RavName = r.RavName

            };
        }
        public static DAL.Rav RavDAL(Entities.Rav r)
        {
            return new DAL.Rav()
            {
                RavId = r.RavId,
                RavName = r.RavName

            };
        }
    }
}
