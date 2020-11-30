using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DAL
{
    public interface IDAL
    {

        /// <summary>
        /// Tester - בוחן
        /// AddTester - הוספת בוחן חדש למערכת
        /// DeleteTester - מחיקת בוחן מהמערכת
        /// UpdateTester - עדכון פרטי בוחן שקיים במערכת
        /// </summary>
        /// <param name="mytester">בוחן</param>
        void AddTester(Tester mytester);
        void DeleteTester(Tester mytester);
        void UpdateTester(Tester mytester);

        /// <summary>
        /// חיפוש טסטר לפי תעודת זהות, אם מצא מחזיר את הטסטר עצמו אם לא מחזיר ערך ברירת מחדל
        /// </summary>
        /// <param name="id">תעודת זהות</param>
        /// <returns></returns>
        Tester SearchTester(string id);

        /// <summary>
        /// Trainee - נבחן
        /// AddTrainee - הוספת נבחן חדש למערכת
        /// DeleteTrainee - מחיקת נבחן מהמערכת
        /// UpdateTrainee - עדכון פרטי נבחן שקיים במערכת
        /// </summary>
        /// <param name="mytrainee">נבחן</param>
        void AddTrainee(Trainee mytrainee);
        void DeleteTrainee(Trainee mytrainee);
        void UpdateTrainee(Trainee mytrainee);

        /// <summary>
        /// חיפוש נבחן לפי תעודת זהות, אם מצא מחזיר את הנבחן עצמו אם לא מחזיר ערך ברירת מחדל
        /// </summary>
        /// <param name="id">תעודת זהות</param>
        /// <returns></returns>
        Trainee SearchTrainee(string id, TypeOfCar mytype);

        /// <summary>
        /// Test - מבחן
        /// AddTest - הופסת מבחן חדש למערכת
        /// UpdateTest - עדכון פרטי מבחן במערכת
        /// DeletTest - מחיקת מבחן מהמערכת
        /// </summary>
        /// <param name="mytest">מבחן</param>
        void AddTest(Test mytest);
        void UpdateTest(Test mytest);
        void DeletTest(Test mytest);

        /// <summary>
        /// חיפוש נבחן לפי מספר המבחן, אם מצא מחזיר את המבחן עצמו אם לא מחזיר ערך ברירת מחדל
        /// </summary>
        /// <param name="number">מספר מבחן</param>
        /// <returns></returns>
        Test SearchTest(int number);

        /// <summary>
        /// יצירת אוסף של כל הטסטרים/הנבחנים/המבחנים/המורים אשר עונים על תנאי מסויים
        /// </summary>
        /// <param name="predicat">ביטוי למדה - תנאי</param>
        /// <returns>אוסף</returns>
        IEnumerable<Tester> GetAllTesters(Func<Tester, bool> predicat = null);
        IEnumerable<Trainee> GetAllTrainee(Func<Trainee, bool> predicat = null);
        IEnumerable<Test> GetAllTest(Func<Test, bool> predicat = null);
        IEnumerable<DrivingInstructorsAndSchools> GetAllTeachers(Func<DrivingInstructorsAndSchools, bool> predicat = null);
    }
}

