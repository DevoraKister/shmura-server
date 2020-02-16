using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Job
    {
        public int JobId { get; set; }
        public Nullable<System.DateTime> JobDateAdv { get; set; }
        public Nullable<int> JobSubId { get; set; }
        public Nullable<int> JobCompanyId { get; set; }
        public string JobRole { get; set; }
        public Nullable<int> JobPartId { get; set; }
        public Nullable<int> JobPartOutNetId { get; set; }
        public Nullable<int> JobWorkspaceId { get; set; }
        public Nullable<int> JobExperience { get; set; }
        public Nullable<int> JobCVId { get; set; }
        public Nullable<int> JobOfferId { get; set; }
        public Nullable<int> JobStars { get; set; }
        public Nullable<int> JobBossId { get; set; }
        public Nullable<bool> JobStatus { get; set; }
        public Nullable<System.DateTime> JobDateCaughtJob { get; set; }
        public Nullable<bool> JobIsByUs { get; set; }


        public string JobRequire { get; set; }

        public virtual Boss Boss { get; set; }

        public virtual OutNet OutNet { get; set; }
        public virtual Part Part { get; set; }
        public virtual SubjectJob SubjectJob { get; set; }
        public virtual Workspace Workspace { get; set; }
        public virtual List<PutInJob> PutInJob { get; set; }
        public virtual List<Sign> Sign { get; set; }
        public virtual Company Company { get; set; }

        public Job()
        {

        }
        public string JobDescribe { get; set; }
        public static Entities.Job JobEntities(DAL.Job j)
        {
            return new Entities.Job()
            {
                JobBossId = j.JobBossId,
                JobCVId = j.JobCVId,
                JobDateAdv = j.JobDateAdv,
                JobDateCaughtJob = j.JobDateCaughtJob,
                JobExperience = j.JobExperience,
                JobId = j.JobId,
                JobIsByUs = j.JobIsByUs,
                JobOfferId = j.JobOfferId,
                JobPartId = j.JobPartId,
                JobPartOutNetId = j.JobPartOutNetId,
                JobRole = j.JobRole,
                JobStars = j.JobStars,
                JobStatus = j.JobStatus,
                JobSubId = j.JobSubId,
                JobWorkspaceId = j.JobWorkspaceId,
                JobCompanyId = j.JobCompanyId,
                JobDescribe = j.JobDescribe,
                JobRequire = j.JobRequire
            };
        }
        public static DAL.Job JobDAL(Entities.Job j)
        {
            return new DAL.Job()
            {

                JobBossId = j.JobBossId,
                JobCVId = j.JobCVId,
                JobDateAdv = j.JobDateAdv,
                JobDateCaughtJob = j.JobDateCaughtJob,
                JobExperience = j.JobExperience,
                JobId = j.JobId,
                JobIsByUs = j.JobIsByUs,
                JobOfferId = j.JobOfferId,
                JobPartId = j.JobPartId,
                JobPartOutNetId = j.JobPartOutNetId,
                JobRole = j.JobRole,
                JobStars = j.JobStars,
                JobStatus = j.JobStatus,
                JobSubId = j.JobSubId,
                JobWorkspaceId = j.JobWorkspaceId,
                JobCompanyId = j.JobCompanyId,
                JobDescribe = j.JobDescribe,
                JobRequire = j.JobRequire
            };
        }
        //public Job(int JobBossId,int JobCompanyId,string JobDescribe,DateTime JobDateAdv,int JobStars,string JobRole,string JobRequire)
        //{
        //    this.JobBossId = JobBossId;
        //    this.JobCompanyId = JobCompanyId;
        //    this.JobDescribe = JobDescribe;
        //    this.JobExperience = JobExperience;
        //    this.JobDateAdv = JobDateAdv;
        //    this.JobStars = JobStars;
        //    this.JobRole = JobRole;
        //    this.JobRequire = JobRequire;

        //}
    }
}
