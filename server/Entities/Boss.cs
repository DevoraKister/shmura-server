using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Boss
    {
        public int BossId { get; set; }
        public string BossName { get; set; }
        public string BossTel { get; set; }
        public string BossMail { get; set; }
        public Nullable<int> BossSubId { get; set; }
        public Nullable<int> BossCompanyId { get; set; }
        public string BossPassword { get; set; }

        public virtual SubjectJob SubjectJob { get; set; }

        public virtual List<Job> Job { get; set; }
        public Nullable<bool> BossIsConnection { get; set; }
        public virtual List<Recomend> Recomend { get; set; }
        public Boss()
        {

        }
        public static Entities.Boss BossEntities(DAL.Boss b)
        {
            return new Entities.Boss()
            {

                BossMail = b.BossMail,
                BossId = b.BossId,
                BossName = b.BossName,
                BossSubId = b.BossSubId,
                BossTel = b.BossTel,
                BossPassword = b.BossPassword,
                BossCompanyId = b.BossCompanyId,
                BossIsConnection=b.BossIsConnection



            };
        }

        public static DAL.Boss BossDAL(Entities.Boss b)
        {
            return new DAL.Boss()
            {
                BossMail = b.BossMail,
                BossId = b.BossId,
                BossName = b.BossName,
                BossCompanyId = b.BossCompanyId,
                BossSubId = b.BossSubId,
                BossTel = b.BossTel,
                BossPassword = b.BossPassword,
                BossIsConnection = b.BossIsConnection



            };
        }
    }
}
