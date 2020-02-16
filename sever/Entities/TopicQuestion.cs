using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
 public  class TopicQuestion
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }

        public virtual List<Question> Question { get; set; }
        public static Entities.TopicQuestion TopicQuestionEntities(DAL.TopicQuestion t)
        {
            return new Entities.TopicQuestion()
            {
                TopicId = t.TopicId,
                TopicName = t.TopicName
            };
        }
        public static DAL.TopicQuestion TopicQuestionDAL(Entities.TopicQuestion t)
        {
            return new DAL.TopicQuestion()
            {
                TopicId = t.TopicId,
                TopicName = t.TopicName
            };
        }
    }
}
