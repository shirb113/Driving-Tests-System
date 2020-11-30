using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BE
{
    public class Test : INotifyPropertyChanged
    {
        /// <summary>
        /// מחלקת בחינה
        /// TestNumber = מספר המבחן
        /// TesterId = תעודת זהות של בוחן
        /// TraineeId = תעודת זהות של נבחן 
        /// DateTimeOfTest = תאריך ושעה שנקבע לטסט
        /// TestExitAddress = כתובת היציאה לטסט
        /// TestCriterion = קריטריונים למעבר בטסט
        /// TestResult = תוצאת הטסט -עבר או נכשל
        /// TestTypeOfCar = מהו סוג הרכב עליו עשו טסט
        /// TesterNote = הערות הבוחן
        /// ToString = העמסת פונקציות - הדפסה
        /// </summary>
        public int TestNumber{ get; set; }
        public string TesterId { get; set; }
        public string TraineeId { get; set; }
        public DateTime DateTimeOfTest { get; set; }
        public Address TestExitAddress { get; set; }
        private Criterion criterion = new Criterion();
        private PassOrFail testResult;
        public event PropertyChangedEventHandler PropertyChanged;

        public PassOrFail TestResult {
            get { return testResult; }
            set { testResult = (PassOrFail)value;
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("TestResult"));
            }
        }
        public TypeOfCar TestTypeOfCar { get; set; }
        public TypeOfGearbox TestTypeOfGearbox { get; set; }
        public string TesterNote { get; set; }

        public Test()
        {
            DateTime temp= DateTime.Now;
            temp = temp.AddDays(1);
            string ezer = temp.ToString();
            DateTimeOfTest = DateTime.Parse(ezer);
            TestExitAddress = new Address();
        }
        public Test(Test t)
        {
            this.TestNumber = t.TestNumber;
            this.TesterId = t.TesterId;
            this.TraineeId = t.TraineeId;
            this.DateTimeOfTest = t.DateTimeOfTest;
            this.TestExitAddress = t.TestExitAddress;
            this.TestCriterion = t.criterion;
            this.TestResult = t.TestResult;
            this.TestTypeOfCar = t.TestTypeOfCar;
            this.TestTypeOfGearbox = t.TestTypeOfGearbox;
            this.TesterNote = t.TesterNote;
        }

        public Criterion TestCriterion
        {
            get { return criterion; }
            set { this.criterion = value; }
        }

        public override string ToString()
        {
            string str = "";
            str += "Test number:" + TestNumber + ",\n\n";
            str += "Identity card of tester:" + TesterId + ",\n\n";
            str += "Identity card of trainee:" + TraineeId + ",\n\n";
            str += "Date of test:" + DateTimeOfTest + ",\n\n";
            str += "Test result:" + TestResult + ",\n\n";
            str += "Type Of Car:" + TestTypeOfCar + ",\n\n";
            str+= "Type of gear:"+TestTypeOfGearbox+ ",\n";
            return str;
        }
        public static Test Parse(string s)
        {
            Test returnTest = new Test();
            string[] values = s.Split(',');
            string[] values2;
            for (int i = 0; i < values.Length; i++)
            {
                values2 = values[i].Split(':');
                if (i == 0)
                {
                    returnTest.TestNumber = int.Parse(values2[1]);
                }
                if (i == 1)
                {
                    returnTest.TesterId = values2[1];
                }
                if (i == 2)
                {
                    returnTest.TraineeId = values2[1];
                }
                if (i == 3)
                {
                    returnTest.DateTimeOfTest = DateTime.ParseExact(values2[1], "dd/MM/yyyy HH", System.Globalization.CultureInfo.InvariantCulture);
                }
                if (i == 4)
                {
                    returnTest.testResult = (PassOrFail)Enum.Parse(typeof(PassOrFail), values2[1]);
                }
                if (i == 5)
                {
                    returnTest.TestTypeOfCar = (TypeOfCar)Enum.Parse(typeof(TypeOfCar),values2[1]);
                }
                if (i == 6)
                {
                    returnTest.TestTypeOfGearbox = (TypeOfGearbox)Enum.Parse(typeof(TypeOfGearbox), values2[1]);
                }
            }
            return returnTest;
        }
    }
}
