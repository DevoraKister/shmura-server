using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Question
    {
        public int QueId { get; set; }
        public Nullable<int> QueUserId { get; set; }
        public string Question1 { get; set; }
        public string Answer { get; set; }
        public Nullable<int> RavId { get; set; }
        public Nullable<int> QueTopicId { get; set; }

        public virtual Rav Rav { get; set; }
        public virtual TopicQuestion TopicQuestion { get; set; }
        public virtual User User { get; set; }
        public static Entities.Question QuestionEntities(DAL.Question q)
        {
            return new Entities.Question()
            {
                QueId = q.QueId,
                Question1 = q.Question1,
                QueTopicId = q.QueTopicId,
                QueUserId = q.QueUserId,
                Answer = q.Answer
            };
        }

        public static DAL.Question QuestionDAL(Entities.Question q)
        {
            return new DAL.Question()
            {
                QueId = q.QueId,
                Question1 = q.Question1,
                QueTopicId = q.QueTopicId,
                QueUserId = q.QueUserId,
                Answer=q.Answer
            };
        }

    }
}
