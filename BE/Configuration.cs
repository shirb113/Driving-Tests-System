using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration
    {
        /// <summary>
        /// NumOfTest - מספר מבחן, 8 ספרות
        /// MinNumberOfLessons - מספר שיעורים מינמלי שיש לעשות על מנת לגשת לטסט
        /// MinTesterAge  - גיל מינימלי לטסטר
        /// MaxTesterAge - גיל מקסימלי לטסטר
        /// MinTraineeAge - גיל מינימלי לנבחן 
        /// MinNumOfDaysBetweenTests - מספר ימים מינימלי בין 2 טסטים עוקבים
        /// </summary>
        private static int NumOfTest = 10010101;
        private static int MinNumberOfLessons = 20;
        private static int MinTesterAge = 40;
        private static int MaxTesterAge = 60;
        private static int MinTraineeAge = 18;
        private static int MinNumOfDaysBetweenTests = 7;
        private static double maxdistance = 33.124;

        public static int NumOfTEST { get { return NumOfTest; } set { NumOfTest = value; } }
        public static int MINNumberOfLessons { get { return MinNumberOfLessons; } private set { MinNumberOfLessons = value; } }
        public static int MINTesterAge { get { return MinTesterAge; } private set { MinTesterAge = value; } }
        public static int MAXTesterAge { get { return MaxTesterAge; } private set { MaxTesterAge = value; } }
        public static int MINTraineeAge { get { return MinTraineeAge; } private set { MinTraineeAge = value; } }
        public static int MINNumOfDaysBetweenTests { get { return MinNumOfDaysBetweenTests; } private set { MinNumOfDaysBetweenTests = value; } }
        public static double Maxdistance { get { return maxdistance; } set { maxdistance = value; } }



    }


}

