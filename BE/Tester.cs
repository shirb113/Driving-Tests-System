using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
   
    public class Tester : ICloneable
    {
        /// <summary>
        /// isActive = האם הבוחן פעיל או לא
        /// Tester = מחלקת בוחן
        /// TesterId = תעודת זהות
        /// TesterLastName = שם משפחה
        /// TesterFirstName = שם פרטי
        /// TesterDateOfBirth = תאריך לידה של בוחן
        /// TesterFamilyStatus = סטטוס משפחתי של בוחן
        /// TesterGender = מין בוחן
        /// TesterHasGlasses = האם לטסטר יש משקפיים
        /// TesterPhoneNumber = מספר פלאפון של בוחן
        /// TesterEmailAddress = כתובת מייל של בוחן
        /// TesterAddress = כתובת בוחן
        /// TesterYearsOfExperience = מספר שנות ניסיון של בוחן
        /// TesterMaxNumOfTestsPerWeek = מספר טסטים בשבוע לבוחן
        /// TesterSpecialization = סוג הרכב בו מתמחה הבוחן
        /// MaxiDistanceFromAddress = מרחק מקסימלי מהכתובת שלו שבו הבוחן יכול לבחון
        /// ToString = העמסת פונקציות - הדפסה
        /// Testerworkdays = מטריצת שעות עבודה של בוחן
        /// TesterImageSource = תמונה
        /// </summary>
        public bool isActive { get; set; }
        public string TesterId { get; set; }
        public string TesterLastName { get; set; }
        public string TesterFirstName { get; set; }
        public DateTime TesterDateOfBirth { get; set; }
        public FamilyStatus TesterFamilyStatus { get; set; }
        public Gender TesterGender { get; set; }
        public bool TesterHasGlasses { get; set; }
        public string TesterPhoneNumber { get; set; }
        public string TesterEmailAddress { get; set; }
        public Address TesterAddress { get; set; }
        public int TesterYearsOfExperience { get; set; }
        public int TesterMaxNumOfTestsPerWeek { get; set; }
        public TypeOfCar TesterSpecialization { get; set; }
        public double MaxiDistanceFromAddress { get; set; }

        public Tester()
        {
            TesterAddress = new Address();
            TesterDateOfBirth = DateTime.Parse("01.01.1960");
            for (int k = 0; k < 6; k++)
                for (int t = 0; t < 5; t++)
                {
                    this.Testerworkdays[k, t] = new TesterWrokSchedule();
                }
        }
        public Tester(Tester t)
        {
            isActive = t.isActive;
            TesterId = t.TesterId;
            TesterLastName = t.TesterLastName;
            TesterFirstName = t.TesterFirstName;
            TesterDateOfBirth = t.TesterDateOfBirth;
            TesterFamilyStatus = t.TesterFamilyStatus;
            TesterGender = t.TesterGender;
            TesterHasGlasses = t.TesterHasGlasses;
            TesterPhoneNumber = t.TesterPhoneNumber;
            TesterEmailAddress = t.TesterEmailAddress;
            TesterAddress = t.TesterAddress;
            TesterYearsOfExperience = t.TesterYearsOfExperience;
            TesterMaxNumOfTestsPerWeek = t.TesterMaxNumOfTestsPerWeek;
            TesterSpecialization = t.TesterSpecialization;
            MaxiDistanceFromAddress = t.MaxiDistanceFromAddress;
            Testerworkdays = (TesterWrokSchedule[,])t.Clone();
        }

        public TesterWrokSchedule[,] MatrixTesterworkdays
        {
            get { return Testerworkdays; }
            set { this.Testerworkdays = value; }
        }

        private string printMatrix()
        {
            string str = "";
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    str += MatrixTesterworkdays[i, j].ToString();
                }
            }
            return str;
        }

        public override string ToString()
        {
            string str = "";
            str += "Tester id: " + TesterId + "\n\n";
            str += "Tester first name: " + TesterFirstName + "\n\n";
            str += "Tester last name: " + TesterLastName + "\n\n";
            str += "Tester specialization: " + TesterSpecialization + "\n\n";
            str += "Is active: " + isActive + "\n";
            return str;
        }

        public object Clone()
        {
            TesterWrokSchedule[,] copy = new TesterWrokSchedule[6, 5];
            for (int k = 0; k < 6; k++)
                for (int t = 0; t < 5; t++)
                {
                    copy[k, t] = new TesterWrokSchedule();
                }

            for (int k = 0; k < 6; k++)
            {
                for (int t = 0; t < 5; t++)
                {
                    copy[k, t].DoesWork = this.MatrixTesterworkdays[k, t].DoesWork;
                    if (this.MatrixTesterworkdays[k, t].Available != null)
                        copy[k, t].Clone();
                }
            }
            return copy;
        }
      
        [XmlIgnore]
        private TesterWrokSchedule[,] Testerworkdays = new TesterWrokSchedule[6, 5];
        public string Help_Matrix
        {
            get
            {
                string result = "";
                if (Testerworkdays != null)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            result += MatrixTesterworkdays[i, j].DoesWork;
                            if (MatrixTesterworkdays[i, j].Available != null)
                            {
                                for (int k = 0; k < MatrixTesterworkdays[i, j].Available.Count(); k++)
                                {
                                    result += "," + MatrixTesterworkdays[i, j].Available.Values[k].ToString() + " ";
                                }
                            }
                            result += "! ";
                        }
                        
                    }

                }
                return result;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    string[] values = value.Split('!');
                    string[] values2;
                    int t = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            values2 = values[t++].Split(',');
                            MatrixTesterworkdays[i, j].DoesWork = bool.Parse(values2[0]);
                            if (values2.Length > 1)
                            {
                                string str = "";
                                for (int k = 1; k < values2.Length; k++)
                                {
                                    str += values2[k] + ",";
                                }
                                Test temp = Test.Parse(str);
                                MatrixTesterworkdays[i, j].Available.Add(temp.DateTimeOfTest, temp);
                            }
                        }
                    }
                }
            }
        }
    }
}
