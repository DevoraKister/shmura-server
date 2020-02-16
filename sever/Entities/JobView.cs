using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class JobView:Job
    {


        public Nullable<int> JobId { get; set; }

        public Nullable<System.DateTime> JobDateAdv { get; set; }
        public Nullable<System.DateTime> JobDateCaughtJob { get; set; }
        public string JobDateShow { get; set; }
        public string CompanyName { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BossId { get; set; }
       public string JobRole { get; set; }
        public string PartName { get; set; }
        public string SubjectName { get; set; }
        public string OutNetName { get; set; }
        public string WSName { get; set; }
       public Nullable<int> JobExperience { get; set; }
       public Nullable<int> JobStars { get; set; }
       public string JobDescribe { get; set; }
        public string AreaName { get; set; }
        public string CityName { get; set; }
        public string JobRequire { get; set; }
        //public JobView():base()
        //{

        //}
        public static Entities.JobView CreateJobView(DAL.Area a,DAL.Company c,DAL.Job j,DAL.SubjectJob s,DAL.Workspace w,DAL.Part p,DAL.OutNet o,DAL.City ci,string diff)
        {
            return new Entities.JobView()
            {

                JobDateAdv = j.JobDateAdv,
                JobDateShow=diff,
                CompanyName = c.CompanyName,
                CompanyId=c.CompanyId,
                JobRole = j.JobRole,
                JobDateCaughtJob=j.JobDateCaughtJob,
                PartName = p.PartName,
                OutNetName = o.OutNetName,
                WSName = w.WSName,
                JobExperience = j.JobExperience,
                JobStars = j.JobStars,
                JobDescribe = j.JobDescribe,
                AreaName = a.AreaName,
                BossId=j.JobBossId,
                CityName = ci.CityName,
                SubjectName = s.SubName,
                JobRequire=j.JobRequire,
                JobId=j.JobId

            };
        }

    }
}
