using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PutInJob
    {
        public int PutId { get; set; }
        public Nullable<int> PutJobId { get; set; }
        public Nullable<int> PutUserId { get; set; }
        public Nullable<System.DateTime> PutDate { get; set; }

        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
        public static Entities.PutInJob PutInJobEntities(DAL.PutInJob p)
        {
            return new Entities.PutInJob()
            {
                PutDate = p.PutDate,
                PutId = p.PutId,
                PutJobId = p.PutJobId,
                PutUserId = p.PutUserId,


            };
        }

        public static DAL.PutInJob PutInJobDAL(Entities.PutInJob p)
        {
            return new DAL.PutInJob()
            {
                PutDate = p.PutDate,
                PutId = p.PutId,
                PutJobId = p.PutJobId,
                PutUserId = p.PutUserId,


            };
        }
    }
}
