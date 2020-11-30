using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
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
        /// עדכון פרטי יום ושעות של בוחן
        /// </summary>
        /// <param name="mytester">בוחן</param>
        /// <param name="day">יום</param>
        /// <param name="start">שעת התחלת של עבודה</param>
        /// <param name="finish">שעת סיום של עבודה</param>
        /// <param name="Work">ערך בוליאני להצבה</param>
        void UpdateTesterworkdays(Tester mytester, DateTime date, int start, int finish, bool Work);

        /// <summary>
        /// עדכון זמינות בוחן ביום ושעה מסויימים
        /// אם ערך הדגל שווה שקר - ברצוני למחוק מבחן ואם ערכו אמת ברצוני להוסיף מבחן
        /// </summary>
        /// <param name="mytest">המבחן</param>
        /// <param name="mytester">הבוחן</param>
        /// <param name="date">תאריך</param>
        /// <param name="hour">שעה</param>
        /// <param name="flag">שדה בוליאני</param>
        void UpdateTesteravailability(Test mytest, Tester mytester, DateTime date, int hour, bool flag);

        /// <summary>
        /// חיפוש נבחן לפי תעודת זהות וסוג רכב עליו לומד, אם מצא מחזיר את הנבחן עצמו אם לא מחזיר ערך ברירת מחדל
        /// </summary>
        /// <param name="id">תעודת זהות</param>
        /// <param name="mytype">סוג רכב</param>
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
        /// הפונקציה מחזירה כמה מהקריטריונים הנבחן לא עבר
        /// </summary>
        /// <param name="mytest">מבחן</param>
        /// <returns></returns>
        int sumOfCriterion(Test mytest);

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


        IEnumerable<Tester> GetAllTestersFrom(Address myAddress, double X);
        IEnumerable<Tester> IsTestersAvailable(DateTime date);
        int TraineeNumOfTests(Trainee mytrainee);
        bool TraineeEntitledReceiveLicense(Trainee mytrainee);
        IEnumerable<Test> GetAllTestAtDate(DateTime date);

        /// <summary>
        /// רשימת בוחנים מקובצת ע"פ סוג ההתמחות
        /// </summary>
        /// <param name="predicate">משתנה בוליאני</param>
        /// <returns></returns>
        IEnumerable<IGrouping<TypeOfCar, Tester>> GetTestersSpecialization(bool flag = false);

        /// <summary>
        /// רשימת תלמידים מקובצת ע"פ ביה"ס לנהיגה בו לומדים
        /// </summary>
        /// <param name="flag">תנאי בוליאני</param>
        /// <returns></returns>
        IEnumerable<IGrouping<string, Trainee>> GetTraineeDrivingSchool(bool flag = false);

        /// <summary>
        /// רשימת תלמידים מקובצת ע"פ המורה לנהיגה אצלו לומדים
        /// </summary>
        /// <param name="flag">תנאי בוליאני</param>
        /// <returns></returns>
        IEnumerable<IGrouping<string, Trainee>> GetTraineeTeacher(bool flag = false);

        /// <summary>
        /// רשימת תלמידים מקובצת ע"פ מספר הטסטים שביצעו
        /// </summary>
        /// <param name="flag">תנאי בוליאני</param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, Trainee>> GetTraineeNumOfTest(bool flag = false);

        /// <summary>
        /// רשימת בוחנים מקובצת לפי סטטוס משפחתי
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<FamilyStatus, Tester>> GetTestersFamilyStatus();

        /// <summary>
        /// רשימת מורים מקובצת לפי בית ספר שאליו משויכיים
        /// </summary>
        /// <returns></returns>
        object GetTeachersSchool();

        /// <summary>
        /// פונקציה למציאת טסטר למבחן
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <param name="date"></param>
        /// <param name="numOfTest"></param>
        /// <returns></returns>
        Tester findMeAtester(string id, Test mytest);

        /// <summary>
        /// רשימת בוחנים מקובצת ע"פ פעיל
        /// </summary>
        /// <param name="predicate">משתנה בוליאני</param>
        /// <returns></returns>
        IEnumerable<IGrouping<bool, Tester>> GetTestersActive(bool flag = false);

        /// <summary>
        /// רשימת טסטים לפי תוצאה של טסט
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<PassOrFail, Test>> GetAllTestResult();

        /// <summary>
        /// רשימת כל המבחנים מאוגדים לפי חודש  מחודשי השנה
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<int, Test>> GetAllTestInMounth();

        /// <summary>
        /// רשימת מבחנים מקובצות לפי טסטר
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<string, Test>> GetAllTestOfTester();

        /// <summary>
        /// הפונקציה מחפשת תאריך אחר לטסט בכל שעה שהיא, ומחזירה תאריך זה
        /// </summary>
        /// <param name="mytester">הבוחן</param>
        /// <param name="lastTest">המבחן</param>
        /// <returns>תאריך</returns>
        DateTime AnotherDateForTheTest(Tester mytester, Test currentTest, Test lastTest);

        /// <summary>
        /// מציאת טסט אחרון של נבחן 
        /// </summary>
        /// <param name="id">תעודת זהות</param>
        /// <returns></returns>
        Test FindLastTest(string id, TypeOfCar mytype);

        /// <summary>
        /// פונקציה המחשבת מרחק מכתובת בין הנבחן לבוחן.
        /// מחזירה אמת אם המרחק אפשרי, אחרת יחזיר שקר
        /// </summary>
        /// <param name="mytester">בוחן</param>
        /// <param name="numOfTest">מספר מבחן</param>
        /// <returns></returns> 
        double Distance(Tester mytester, Address testAddress);
    }
}
