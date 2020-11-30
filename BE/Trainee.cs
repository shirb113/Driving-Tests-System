using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class Trainee
    {
        /// <summary>
        /// Trainee = מחלקת נבחן
        /// TraineeId = תעודת זהות
        /// TraineeFirstName = שפ פרטי
        /// TraineeLastName = שם משפחה
        /// TraineeGender = מין נבחן
        /// TraineePhoneNumber = מספר פלאפון של נבחן
        /// TraineeEmailAddress = כתובת מייל של נבחן
        /// TraineeAddress = כתובת נבחן
        /// TraineeDateOfBirth = תאריך לידה של נבחן
        /// TraineeLearingCar = מהו סוג הרכב עליו לומד התלמיד
        /// TraineeGearbox = מהו סוג תיבת ההילוכים עליו לומד התלמיד
        /// TraineeNameOfSchool = שם בית ספר לנהיגה של תלמיד
        /// TraineeNameOfTeacher = שם המורה לנהיגה של תלמיד
        /// TraineeNumOfDrivingLessons = מספר שיעורי נהיגה של התלמיד
        /// TraineeHasGlasses = האם לתלמיד יש משקפים
        /// IfTraineePassedAnInternalTest = האם התלמיד עבר את הטסט פנימי או לא
        /// TraineeImageSource = תמונה
        /// ToString = העמסת פונקציות - הדפסה
        /// </summary>
        public string TraineeId { get; set; }
        public string TraineeFirstName { get; set; }
        public string TraineeLastName { get; set; }
        public Gender TraineeGender { get; set; }
        public Address TraineeAddress { get; set; }
        public string TraineePhoneNumber { get; set; }
        public string TraineeEmailAddress { get; set; }
        public DateTime TraineeDateOfBirth { get; set; }
        public TypeOfCar TraineeLearingCar { get; set; }
        public TypeOfGearbox TraineeGearbox { get; set; }
        public string TraineeNameOfSchool { get; set; }
        public string TraineeNameOfTeacher { get; set; }
        public int TraineeNumOfDrivingLessons { get; set; }
        public bool TraineeHasGlasses { get; set; }
        public bool IfTraineePassedAnInternalTest { get; set; }
        

        public Trainee()
        {
            TraineeDateOfBirth = DateTime.Parse("01.01.1990");
            TraineeAddress = new Address();
        }
        public Trainee(Trainee t)
        {
            this.TraineeId = t.TraineeId;
            this.TraineeFirstName = t.TraineeFirstName;
            this.TraineeLastName = t.TraineeLastName;
            this.TraineeGender = t.TraineeGender;
            this.TraineePhoneNumber = t.TraineePhoneNumber;
            this.TraineeEmailAddress = t.TraineeEmailAddress;
            this.TraineeAddress = t.TraineeAddress;
            this.TraineeDateOfBirth = t.TraineeDateOfBirth;
            this.TraineeLearingCar = t.TraineeLearingCar;
            this.TraineeGearbox = t.TraineeGearbox;
            this.TraineeNameOfSchool = t.TraineeNameOfSchool;
            this.TraineeNameOfTeacher = t.TraineeNameOfTeacher;
            this.TraineeNumOfDrivingLessons = t.TraineeNumOfDrivingLessons;
            this.TraineeHasGlasses = t.TraineeHasGlasses;
            this.IfTraineePassedAnInternalTest = t.IfTraineePassedAnInternalTest;
        }
        public override string ToString()
        {
            string str = "";
            str += "Trainee id: " + TraineeId + "\n\n";
            str += "Trainee first name: " + TraineeFirstName + "\n\n";
            str += "Trainee last name: " + TraineeLastName + "\n\n";
            str += "Trainee learing on a: " + TraineeLearingCar + "\n";
            return str;
        }
    }
}
