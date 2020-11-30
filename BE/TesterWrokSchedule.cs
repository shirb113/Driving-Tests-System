using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// מחלקה המכילה 2 שדות בוליאניים
    /// ממחלקה זו ניצור את מטריצת שעות העבודה של הבוחן, כל תא במטריצה מכיל 2 שדות בוליאניים
    /// </summary>
    public class TesterWrokSchedule :ICloneable
    {
        /// <summary>
        /// DoesWork - האם בוחן עובד בשעה וביום זה
        /// Available - האם הבוחן פנוי ביום ושעה זו או שכבר יש לו טסט קבוע
        /// </summary>
        public bool DoesWork { get; set; }
        public SortedList<DateTime,Test> Available { get; set; }

        public TesterWrokSchedule()
        {
            DoesWork = false;
            Available = new SortedList<DateTime, Test>();
        }

        public override string ToString()
        {
            string str = "";
            str += "does work: " + DoesWork.ToString();
            str += "\t";
            if (Available.Count() == 0)
                str += "available" + "\n";
            else
            {
                foreach (DateTime item in Available.Keys)
                    str += "not available in: " + item + "\t";
                str += "\n";
            }
            return str;
        }

        public object Clone()
        {
            TesterWrokSchedule copy = new TesterWrokSchedule();
            copy.DoesWork = this.DoesWork;
            for (int i = 0; i < this.Available.Count(); i++)
            {
                copy.Available.Add(this.Available.Keys[i], this.Available.Values[i]);
            }
            return copy;
        }
    }

}
