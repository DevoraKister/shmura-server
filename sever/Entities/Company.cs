using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyStreet { get; set; }
        public Nullable<int> CompanyCityId { get; set; }
        public Nullable<int> CompanyNumBuild { get; set; }
        public string CompanyTel { get; set; }
        public string CompanyMail { get; set; }
        public Nullable<int> CompanyAreaId { get; set; }

        public virtual Area Area { get; set; }

        public virtual List<Boss> Boss { get; set; }
        public virtual City City { get; set; }
        public virtual List<Job> Job { get; set; }

        public virtual List<Recomend> Recomend { get; set; }

        public static Entities.Company CompanyEntities(DAL.Company r)
        {
            return new Entities.Company()
            {

                CompanyAreaId = r.CompanyAreaId,
                CompanyCityId = r.CompanyCityId,
                CompanyId = r.CompanyId,
                CompanyMail = r.CompanyMail,
                CompanyName = r.CompanyName,
                CompanyNumBuild = r.CompanyNumBuild,
                CompanyStreet = r.CompanyStreet,
                CompanyTel = r.CompanyTel,


            };
        }
        public static DAL.Company CompanyDAL(Entities.Company r)
        {
            return new DAL.Company()
            {
                CompanyAreaId = r.CompanyAreaId,
                CompanyCityId = r.CompanyCityId,
                CompanyId = r.CompanyId,
                CompanyMail = r.CompanyMail,
                CompanyName = r.CompanyName,
                CompanyNumBuild = r.CompanyNumBuild,
                CompanyStreet = r.CompanyStreet,
                CompanyTel = r.CompanyTel,
            };
        }

    }
}
