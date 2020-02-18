using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using BL;
using Entities;
namespace BL
{
    public static class LoadProjectBL
    {

        //הקצאת הטימר
        private readonly static System.Timers.Timer _checkTimer = new System.Timers.Timer();
        //הטימר יופעל בכל יום פעם אחת בלבד
        public static readonly int CheckTimerInterval = 1000 * 60 * 60 * 24;
        //public static readonly int CheckTimerInterval = 1000 * 60 *60*24;
        /// <summary>
        /// הבונה של הטימר מאתחלת לאיזה פונקציה להפעיל
        /// </summary>
        static LoadProjectBL()//בונה סטטית
        {
            _checkTimer.Elapsed += CheckTimerElapsed;
            _checkTimer.Interval = CheckTimerInterval;
            _checkTimer.Enabled = true;
        }

        static void CheckTimerElapsed(object source, ElapsedEventArgs e)
        {
            BL.SmartAgentLogic.UserSmartAgent(1);
            //אם היום  הראשון לחדוש
            if (DateTime.Today.Day == 1)
                BL.SmartAgentLogic.UserSmartAgent(3);
            //שולח כל יום בשעה 9
            if ((int)DateTime.Today.Hour == 9)
                BL.SmartAgentLogic.UserSmartAgent(1);
            if ((DateTime.Today.Date.DayOfWeek).ToString() == "Wednesday")
                BL.SmartAgentLogic.UserSmartAgent(2);
            //if ((int)DateTime.Today.da == 22)
            //    BL.SmartAgentLogic.UserSmartAgent(1);

        }

        public static void useFuncToLoadThisClass()
        {
            int x = 5;
        }

    }
}
