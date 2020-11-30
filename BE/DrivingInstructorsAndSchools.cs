using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DrivingInstructorsAndSchools
    {
        public string TeacherName { get; set; }
        public string DrivingSchool { get; set; }

        public DrivingInstructorsAndSchools() { }
        public DrivingInstructorsAndSchools(DrivingInstructorsAndSchools d)
        {
            this.TeacherName = d.TeacherName;
            this.DrivingSchool = d.DrivingSchool;
        }

        public override string ToString()
        {
            string str = "";
            str += TeacherName + " " + DrivingSchool;
            return str;
        }

    }
    


}
