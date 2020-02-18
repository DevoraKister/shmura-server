using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SubjectJob
    {
        public int SubId { get; set; }
        public string SubName { get; set; }

        public virtual List<Boss> Boss { get; set; }
        public virtual List<Job> Job { get; set; }
        public virtual List<User> User { get; set; }
        public static Entities.SubjectJob SubjectJobEntities(DAL.SubjectJob s)
        {
            return new Entities.SubjectJob()
            {
                SubId = s.SubId,
                SubName = s.SubName

            };
        }
        public static DAL.SubjectJob SubjectJobDAL(Entities.SubjectJob s)
        {
            return new DAL.SubjectJob()
            {
                SubId = s.SubId,
                SubName = s.SubName

            };
        }
    }
}
