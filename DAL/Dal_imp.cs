using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Dal_imp : IDAL
    {
        public Dal_imp()
        {
            DataSource start = new DataSource();
        }

        #region AddTester
        /// <summary>
        /// הוספת בוחן חדש לרשימת הבוחנים, כולל בדיקה האם קיים במערכת ואם כן שליחת הודעה בהתאם
        /// </summary>
        /// <param name="mytester">הבוחן החדש</param>
        public void AddTester(Tester mytester)
        {
            Tester temp = SearchTester(mytester.TesterId);
            if (temp != null)
                throw new Exception("The tester already exists in the system");
            DataSource.TesterList.Add(mytester);
        }
        #endregion

        #region DeleteTester
        /// <summary>
        /// מחיקת בוחן מרשימת הבוחנים, כולל בדיקה האם הבוחן קיים במערכת ומחיקה
        /// אם לא קיים שליחת הודעה בהתאם 
        /// </summary>
        /// <param name="mytester">הבוחן למחיקה</param>
        public void DeleteTester(Tester mytester)
        {
            Tester temp = DataSource.TesterList.Find(t => t.TesterId == mytester.TesterId);
            if (temp == null)
                throw new Exception("The tester don't exists in the system");
            DataSource.TesterList.Remove(temp);    
        }
        #endregion

        #region UpdateTester
        /// <summary>
        /// עדכון פרטי בוחן, כולל בדיקה האם קיים במערכת ועדכון פרטיו אם כן
        /// אם לא קיים שליחת הודעה בהתאם
        /// </summary>
        /// <param name="mytester">עדכון בוחן</param>
        public void UpdateTester(Tester mytester)
        {
            int index = DataSource.TesterList.FindIndex(t => t.TesterId == mytester.TesterId);
            if (index == -1)
                throw new Exception("The tester don't exists in the system");
            DataSource.TesterList[index].isActive = mytester.isActive;
            DataSource.TesterList[index].TesterId = mytester.TesterId;
            DataSource.TesterList[index].TesterLastName = mytester.TesterLastName;
            DataSource.TesterList[index].TesterFirstName = mytester.TesterFirstName;
            DataSource.TesterList[index].TesterDateOfBirth = mytester.TesterDateOfBirth;
            DataSource.TesterList[index].TesterFamilyStatus = mytester.TesterFamilyStatus;
            DataSource.TesterList[index].TesterGender = mytester.TesterGender;
            DataSource.TesterList[index].TesterHasGlasses = mytester.TesterHasGlasses;
            DataSource.TesterList[index].TesterPhoneNumber = mytester.TesterPhoneNumber;
            DataSource.TesterList[index].TesterEmailAddress = mytester.TesterEmailAddress;
            DataSource.TesterList[index].TesterAddress = mytester.TesterAddress;
            DataSource.TesterList[index].TesterYearsOfExperience = mytester.TesterYearsOfExperience;
            DataSource.TesterList[index].TesterMaxNumOfTestsPerWeek = mytester.TesterMaxNumOfTestsPerWeek;
            DataSource.TesterList[index].TesterSpecialization = mytester.TesterSpecialization;
            DataSource.TesterList[index].MatrixTesterworkdays = (TesterWrokSchedule[,])mytester.Clone();
            DataSource.TesterList[index].MaxiDistanceFromAddress = mytester.MaxiDistanceFromAddress;
            //DataSource.TesterList[index].TesterImageSource = mytester.TesterImageSource;
        }
        #endregion

        #region SearchTester
        /// <summary>
        /// חיפוש טסטר לפי תעודת זהות, אם מצא מחזיר את הטסטר עצמו אם לא מחזיר ערך ברירת מחדל
        /// </summary>
        /// <param name="id">תעודת זהות</param>
        /// <returns></returns>
        public Tester SearchTester(string id)
        {
            Tester temp = DataSource.TesterList.FirstOrDefault(t => t.TesterId == id);
            if (temp == null)
                return null;
            return new Tester(temp);
        }
        #endregion

        #region AddTrainee
        /// <summary>
        /// הוספת נבחן חדש לרשימת הנבחנים, כולל בדיקה האם קיים במערכת ואם כן שליחת הודעה בהתאם
        /// </summary>
        /// <param name="mytester">הנבחן החדש</param>
        public void AddTrainee(Trainee mytrainee)
        {
            Trainee temp = SearchTrainee(mytrainee.TraineeId,mytrainee.TraineeLearingCar);
            if (temp != null)
                throw new Exception("The trainee already exists in the system");
            DataSource.TraineeList.Add(mytrainee);
        }
        #endregion

        #region DeleteTrainee
        /// <summary>
        /// מחיקת נבחן מרשימת הנבחנים, כולל בדיקה האם הנבחן קיים במערכת ומחיקה
        /// אם לא קיים שליחת הודעה בהתאם 
        /// </summary>
        /// <param name="mytester">הנבחן למחיקה</param>
        public void DeleteTrainee(Trainee mytrainee)
        {
            Trainee temp = DataSource.TraineeList.Find(t => t.TraineeId == mytrainee.TraineeId && t.TraineeLearingCar == mytrainee.TraineeLearingCar);
            if (temp == null)
                throw new Exception("The trainee don't exists in the system");
            DataSource.TraineeList.Remove(temp);
        }
        #endregion

        #region UpdateTrainee
        /// <summary>
        /// עדכון פרטי נבחן, כולל בדיקה האם קיים במערכת ועדכון פרטיו אם כן
        /// אם לא קיים שליחת הודעה בהתאם
        /// </summary>
        /// <param name="mytester">עדכון נבחן</param>
        public void UpdateTrainee(Trainee mytrainee)
        {
            int index = DataSource.TraineeList.FindIndex(t => t.TraineeId == mytrainee.TraineeId);
            if (index == -1)
                throw new Exception("The trainee don't exists in the system");
            DataSource.TraineeList[index].TraineeId = mytrainee.TraineeId;
            DataSource.TraineeList[index].TraineeFirstName = mytrainee.TraineeFirstName;
            DataSource.TraineeList[index].TraineeLastName = mytrainee.TraineeLastName;
            DataSource.TraineeList[index].TraineeGender = mytrainee.TraineeGender;
            DataSource.TraineeList[index].TraineePhoneNumber = mytrainee.TraineePhoneNumber;
            DataSource.TraineeList[index].TraineeEmailAddress = mytrainee.TraineeEmailAddress;
            DataSource.TraineeList[index].TraineeAddress = mytrainee.TraineeAddress;
            DataSource.TraineeList[index].TraineeDateOfBirth = mytrainee.TraineeDateOfBirth;
            DataSource.TraineeList[index].TraineeLearingCar = mytrainee.TraineeLearingCar;
            DataSource.TraineeList[index].TraineeGearbox = mytrainee.TraineeGearbox;
            DataSource.TraineeList[index].TraineeNameOfSchool = mytrainee.TraineeNameOfSchool;
            DataSource.TraineeList[index].TraineeNameOfTeacher = mytrainee.TraineeNameOfTeacher;
            DataSource.TraineeList[index].TraineeNumOfDrivingLessons = mytrainee.TraineeNumOfDrivingLessons;
            DataSource.TraineeList[index].TraineeHasGlasses = mytrainee.TraineeHasGlasses;
            DataSource.TraineeList[index].IfTraineePassedAnInternalTest = mytrainee.IfTraineePassedAnInternalTest;
           // DataSource.TraineeList[index].TraineeImageSource = mytrainee.TraineeImageSource;
        }
        #endregion

        #region SearchTrainee
        /// <summary>
        /// חיפוש נבחן לפי תעודת זהות, אם מצא מחזיר את הנבחן עצמו אם לא מחזיר ערך ברירת מחדל
        /// </summary>
        /// <param name="id">תעודת זהות</param>
        /// <returns></returns>
        public Trainee SearchTrainee(string id, TypeOfCar mytype)
        {
            Trainee temp= DataSource.TraineeList.FirstOrDefault(t => (t.TraineeId == id&&t.TraineeLearingCar==mytype));
            if (temp == null)
                return null;
            return new Trainee(temp);
        }
        #endregion

        #region AddTest
        /// <summary>
        /// הוספת מבחן חדש לרשימת המבחנים, כולל בדיקה האם המבחן קיים במערכת ואם כן שליחת הודעה בהתאם
        /// </summary>
        /// <param name="mytester">המבחן החדש</param>
        public void AddTest(Test mytest)
        {
            Test temp = SearchTest(mytest.TestNumber);
            if (temp != null)
                throw new Exception("The test already exists in the system");
            DataSource.TestList.Add(mytest);
        }
        #endregion

        #region UpdateTest
        /// <summary>
        /// עדכון פרטי מבחן, כולל בדיקה האם קיים במערכת ועדכון פרטיו אם כן
        /// אם לא קיים שליחת הודעה בהתאם
        /// </summary>
        /// <param name="mytester">עדכון מבחן</param>
        public void UpdateTest(Test mytest)
        {
            int index = DataSource.TestList.FindIndex(t => t.TestNumber == mytest.TestNumber);
            if (index == -1)
                throw new Exception("The trainee don't exists in the system");
            //DataSource.TestList[index].TestNumber = mytest.TestNumber;
            DataSource.TestList[index].TesterId = mytest.TesterId;
            DataSource.TestList[index].TraineeId = mytest.TraineeId;
            DataSource.TestList[index].DateTimeOfTest = mytest.DateTimeOfTest;
            DataSource.TestList[index].TestExitAddress = mytest.TestExitAddress;
            DataSource.TestList[index].TestCriterion = mytest.TestCriterion;
            DataSource.TestList[index].TestResult = mytest.TestResult;
            DataSource.TestList[index].TestTypeOfCar = mytest.TestTypeOfCar;
            DataSource.TestList[index].TestTypeOfGearbox = mytest.TestTypeOfGearbox;
            DataSource.TestList[index].TesterNote = mytest.TesterNote;

            //עדכון הטסט במטריצת הבוחן
            Tester mytester = SearchTester(mytest.TesterId);
            int index1 = -1;
            int i = mytest.DateTimeOfTest.Hour-9;
            int j = (int)mytest.DateTimeOfTest.DayOfWeek;
            index1 = mytester.MatrixTesterworkdays[i, j].Available.IndexOfKey(mytest.DateTimeOfTest);
            if (index1 != -1)
            {
                mytester.MatrixTesterworkdays[i, j].Available.RemoveAt(index1);
                mytester.MatrixTesterworkdays[i, j].Available.Add(mytest.DateTimeOfTest, mytest);
            }
            else
            {
                mytester.MatrixTesterworkdays[i, j].Available.Add(mytest.DateTimeOfTest, mytest);
            }
        }
        #endregion

        #region DeleteTest
        /// <summary>
        /// מחיקת מבחן מהמערכת אם תאריך המבחן עוד לא עבר
        /// </summary>
        /// <param name="mytrainee"></param>
        public void DeletTest(Test mytest)            
        {
            Test temp = DataSource.TestList.Find(t => t.TestNumber == mytest.TestNumber);
            if (temp == null)
                throw new Exception("The test don't exists in the system");
            if (mytest.DateTimeOfTest > DateTime.Now)
            {
                DataSource.TestList.Remove(temp);
                // מחיקת הטסט במטריצת הבוחן
                Tester mytester = DataSource.TesterList.Find(t => t.TesterId == temp.TesterId);
                int index1 = -1;
                int i = mytest.DateTimeOfTest.Hour-9;
                int j = (int)mytest.DateTimeOfTest.DayOfWeek;
                index1 = mytester.MatrixTesterworkdays[i, j].Available.IndexOfKey(mytest.DateTimeOfTest);
                if (index1 != -1)
                {
                    mytester.MatrixTesterworkdays[i, j].Available.RemoveAt(index1);
                }
            }
            else
            {
                throw new Exception("Test date already passed - can not be deleted");
            }
        }
        #endregion

        #region SearchTest
        /// <summary>
        /// חיפוש נבחן לפי מספר המבחן, אם מצא מחזיר את המבחן עצמו אם לא מחזיר ערך ברירת מחדל
        /// </summary>
        /// <param name="number">מספר מבחן</param>
        /// <returns></returns>
        public Test SearchTest(int number)
        {
            Test temp= DataSource.TestList.FirstOrDefault(t => t.TestNumber == number);
            if (temp == null)
                return null;
            return new Test(temp);
        }
        #endregion

        /// <summary>
        /// יצירת אוסף של כל הטסטרים/הנבחנים/המבחנים/המורים אשר עונים על תנאי מסויים
        /// </summary>
        /// <param name="predicat">ביטוי למדה - תנאי</param>
        /// <returns>אוסף</returns>
        public IEnumerable<Tester> GetAllTesters(Func<Tester, bool> predicat)
        {
            if (predicat == null)
                return DataSource.TesterList.ToList<Tester>();
            return DataSource.TesterList.Where(predicat).ToList<Tester>();
        }
        public IEnumerable<Trainee> GetAllTrainee(Func<Trainee, bool> predicat)
        {
            if (predicat == null)
                return DataSource.TraineeList.ToList<Trainee>();
            return DataSource.TraineeList.Where(predicat).ToList<Trainee>();
        }
        public IEnumerable<Test> GetAllTest(Func<Test, bool> predicat)
        {
            if (predicat == null)
                return DataSource.TestList.ToList<Test>();
            return DataSource.TestList.Where(predicat).ToList<Test>();
        }
        public IEnumerable<DrivingInstructorsAndSchools> GetAllTeachers(Func<DrivingInstructorsAndSchools, bool> predicat)
        {
            if (predicat == null)
                return DataSource.TeacherList.ToList<DrivingInstructorsAndSchools>();
            return DataSource.TeacherList.Where(predicat).ToList<DrivingInstructorsAndSchools>();
        }
    }
}

