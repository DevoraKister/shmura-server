using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    public class Survey
    {

        public int SurveyId { get; set; }
        public Nullable<int> SurveySubLearnId { get; set; }
        public Nullable<bool> SurveyIsWork { get; set; }
        public Nullable<int> SurveySubTodayId { get; set; }
        public string SurveySeminar { get; set; }
        public string SurveySubLearnedTxt { get; set; }
        public string SurveySubTodayTxt { get; set; }
        public virtual SubjectJob SubjectJob { get; set; }
        public virtual SubjectJob SubjectJob1 { get; set; }
        public static Entities.Survey SurveyEntities(DAL.Survey b)
        {
            return new Entities.Survey()
            {
                SurveyId = b.SurveyId,
                SurveyIsWork = b.SurveyIsWork,
                SurveySeminar = b.SurveySeminar,
                SurveySubLearnId = b.SurveySubLearnId,
                SurveySubTodayId = b.SurveySubTodayId,
                SurveySubLearnedTxt = b.SurveySubLearnedTxt,
                SurveySubTodayTxt=b.SurveySubTodayTxt


            };
        }

        public static DAL.Survey SurveyDAL(Entities.Survey b)
        {
            return new DAL.Survey()
            {
                SurveyId = b.SurveyId,
                SurveyIsWork = b.SurveyIsWork,
                SurveySeminar = b.SurveySeminar,
                SurveySubLearnId = b.SurveySubLearnId,
                SurveySubTodayId = b.SurveySubTodayId,
                SurveySubLearnedTxt = b.SurveySubLearnedTxt,
                SurveySubTodayTxt = b.SurveySubTodayTxt


            };
        }
    }
}
