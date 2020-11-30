using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Net;
using System.Xml;
using BE;
using System.Threading;

namespace BL
{
    public class BL_basic : IBL
    {
        DAL.IDAL dal;
       
        public BL_basic()
        {
            dal = DAL.FactoryDAL.GetDal();

        }

        #region SearchTester
        /// <summary>
        /// חיפוש טסטר לפי תעודת זהות, אם מצא מחזיר את הטסטר עצמו אם לא מחזיר ערך ברירת מחדל
        /// </summary>
        /// <param name="id">תעודת זהות</param>
        /// <returns></returns>
        public Tester SearchTester(string id)
        {
            return dal.SearchTester(id);
        }
        #endregion

        #region SearchTrainee
        /// <summary>
        /// חיפוש נבחן לפי תעודת זהות וסוג רכב עליו לומד, אם מצא מחזיר את הנבחן עצמו אם לא מחזיר ערך ברירת מחדל
        /// </summary>
        /// <param name="id">תעודת זהות</param>
        /// <param name="mytype">סוג רכב</param>
        /// <returns></returns>
        public Trainee SearchTrainee(string id, TypeOfCar mytype)
        {
            return dal.SearchTrainee(id, mytype);
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
            return dal.SearchTest(number);
        }
        #endregion

        #region AddTester
        /// <summary>
        /// הוספת בוחן חדש לרשימת הבחונים כאשר: הבוחן נמצא בגיל המתאים וכמו כן הבוחן לא נמצא כבר ברשימה
        /// אם הבוחן נמצא כבר ברשימה פרטיו נשלחים לעדכון
        /// </summary>
        /// <param name="mytester">בוחן</param>
        public void AddTester(Tester mytester)
        {
            DateTime date = DateTime.Now;
            int age = date.Year - mytester.TesterDateOfBirth.Year;
            if (age < Configuration.MINTesterAge)
                throw new Exception("ERROR - You are to young to be a tester");
            if (age > Configuration.MAXTesterAge)
                throw new Exception("ERROR - You are to old to be a tester");
            if(mytester.isActive==false)
                throw new Exception("ERROR - You are not active");
            try
            {
                dal.AddTester(mytester);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region DeleteTester
        /// <summary>
        /// מחיקת בוחן מרשימת הבוחנים
        /// </summary>
        /// <param name="mytester">הבוחן למחיקה</param>
        public void DeleteTester(Tester mytester)
        {
            try
            {
                IEnumerable<Test> deleteTest = GetAllTest(t => (t.TesterId == mytester.TesterId) && (t.DateTimeOfTest > DateTime.Now));
                if (deleteTest.Count() == 0)
                {
                    dal.DeleteTester(mytester);
                    throw new Exception("You have been deleted");
                }
                else
                {
                    mytester.isActive = false;

                    UpdateTester(mytester);
                    DateTime last = DateTime.Now;
                    foreach (Test item in deleteTest)
                    {
                        if (item.DateTimeOfTest > last)
                            last = item.DateTimeOfTest;
                    }
                    last.AddDays(1);
                    throw new Exception("We have update your status to not active - please try to remove yourself from the system in: " + last.ToString("dd/MM/yyyy"));
                }
            }
            catch (Exception e)
            { throw e; }
        }
        #endregion

        #region UpdateTester
        /// <summary>
        /// עדכון פרטי בוחן
        /// </summary>
        /// <param name="mytester">בוחן מעודכן</param>
        public void UpdateTester(Tester mytester)
        {
            DateTime date = DateTime.Now;
            int age = date.Year - mytester.TesterDateOfBirth.Year;
            if (age < Configuration.MINTesterAge)
                throw new Exception("ERROR - You are to young to be a tester");
            if (age > Configuration.MAXTesterAge)
                throw new Exception("ERROR - You are to old to be a tester");
            try
            {
                dal.UpdateTester(mytester);
               
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion

        #region SearchTeacher
        /// <summary>
        /// חיפוש מורה לפי שם ושיוכו לבית ספר לנהיגה
        /// </summary>
        /// <param name="name">שם המורה</param>
        /// <param name="school">שם בית הספר</param>
        /// <returns></returns>
        public bool SearchTeacher(string name, string school)
        {
            IEnumerable<DrivingInstructorsAndSchools> Teachers = GetAllTeachers(t => t.TeacherName == name);
            if (Teachers.Count() == 0)
            {
                return false;
            }
            DrivingInstructorsAndSchools item = Teachers.First();
            if (item.DrivingSchool == school)
                return true;
            return false;
        }
        #endregion

        #region AddTrainee
        /// <summary>
        /// הוספת נבחן חדש לרשימת הנבחנים כאשר: הנבחן בגיל המתאים ואינו נמצא כבר ברשימה
        /// אם כבר נמצא ברשימה נשלח התלמיד לפונקציית עדכון פרטיו
        /// </summary>
        /// <param name="mytrainee">נבחן</param>
        public void AddTrainee(Trainee mytrainee)
        {
            DateTime date = DateTime.Now;
            int age = date.Year - mytrainee.TraineeDateOfBirth.Year;
            if (age < Configuration.MINTraineeAge)
                throw new Exception("ERROR - You are to young to be a trainee");
            if (SearchTeacher(mytrainee.TraineeNameOfTeacher, mytrainee.TraineeNameOfSchool) == false)
                throw new Exception("Techer information is incorrect");
            try
            {
                dal.AddTrainee(mytrainee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region DeleteTrainee
        /// <summary>
        /// מחיקת נבחן מרשימת הנבחנים
        /// </summary>
        /// <param name="mytrainee">נבחן למחיקה</param>
        public void DeleteTrainee(Trainee mytrainee)
        {
            try
            {
                dal.DeleteTrainee(mytrainee);
                DateTime today = DateTime.Now;
                IEnumerable<Test> deleteTest = GetAllTest(t => (t.TraineeId == mytrainee.TraineeId)&&(t.DateTimeOfTest>DateTime.Now));
                if (deleteTest.Count() != 0)
                {
                    foreach (Test item in deleteTest)
                    {
                        try
                        {
                            dal.DeletTest(item);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                }
            }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region UpdateTrainee
        /// <summary>
        /// עדכון פרטי נבחן 
        /// </summary>
        /// <param name="mytrainee">נבחן מעודכן</param>
        public void UpdateTrainee(Trainee mytrainee)
        {
            DateTime date = DateTime.Now;
            int age = date.Year - mytrainee.TraineeDateOfBirth.Year;
            if (age < Configuration.MINTraineeAge)
                throw new Exception("ERROR - You are to young to be a trainee");
            if (SearchTeacher(mytrainee.TraineeNameOfTeacher, mytrainee.TraineeNameOfSchool) == false)
                throw new Exception("Techer information is incorrect");
            try
            {
                dal.UpdateTrainee(mytrainee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region FindLastTest
        /// <summary>
        /// מציאת טסט אחרון של נבחן 
        /// </summary>
        /// <param name="id">תעודת זהות</param>
        /// <returns></returns>
        public Test FindLastTest(string id, TypeOfCar mytype)
        {
            IEnumerable<Test> allTest = GetAllTest(t => t.TraineeId == id && t.TestTypeOfCar == mytype);
            if (allTest.Count() == 0)
                return null;
            Test ansTest = null;
            DateTime today = new DateTime();
            foreach (Test item in allTest)
            {
                if (item.DateTimeOfTest > today)
                {
                    today = item.DateTimeOfTest;
                    ansTest = item;
                }
            }
            return ansTest;
        }

        #endregion

        #region AddTest
        /// <summary>
        /// הוספת מבחן חדש לרשימת המבחנים, תוך בדיקת מקרי קיצון שונים
        /// </summary>
        /// <param name="mytest"></param>
        public void AddTest(Test mytest)
        {
            //בדיקה שהמורה קיים במערכת
            Trainee mytrainee = dal.SearchTrainee(mytest.TraineeId, mytest.TestTypeOfCar);
            if (mytrainee == null)
                throw new Exception("ERROR - The trainee does not exist");
            //בדיקת תקינות של בוחן
            Tester mytester = SearchTester(mytest.TesterId);
            if (mytester == null)
                throw new Exception("ERROR - The tester does not exist");
            //מציאת טסט אחרון של נבחן
            Test lastTest = FindLastTest(mytest.TraineeId, mytest.TestTypeOfCar);
            //אם נמצא מבחן אחרון על סוג רכב זה יש לוודא שעברו מספיק ימים בין המבחן האחרון למבחן החדש
            if (lastTest != null)
            { //תקינות התלמיד
                TimeSpan seven = mytest.DateTimeOfTest - lastTest.DateTimeOfTest;
                if (seven.TotalDays < 7)
                    throw new Exception("Not enough days has passed between the last test and the current test");
         
                // אם הטסט הקודם ללא תוצאה יש לעדכן את תוצאת הטסט האחרון
                if (lastTest.TestResult == PassOrFail.Nun)
                    throw new Exception("You need to update the result of the last test");

                //בדיקה האם התלמיד כבר עבר טסט על סוג רכב זה וישנה טעות במערכת
                if (lastTest.TestResult == PassOrFail.Pass)
                    throw new Exception("The trainee has already passed a test");
            }

            //בדיקת מספר שיעורי התלמיד - יש לוודא שאכן עשה לפחות את המינימום הנדרש
            if (mytrainee.TraineeNumOfDrivingLessons < Configuration.MINNumberOfLessons)
                throw new Exception("The trainee did not do enough driving lessons to attend the test");

            //בדיקה האם התלמיד עבר מבחן נהיגה פנימי - טסט פנימי
            if (mytrainee.IfTraineePassedAnInternalTest == false)
                throw new Exception("The trainee did not pass an Internal Test");

            // בדיקה האם סוג הרכב שעליו התלמיד למד וכעת נבחן זהים או לא
            if (mytrainee.TraineeLearingCar != mytest.TestTypeOfCar)
                throw new Exception("The trainee and the type of car in test dont fit");

            //בדיקת תקינות תאריך הטסט
            DateTime date = mytest.DateTimeOfTest.Date;
            DateTime temp = DateTime.Now;
            TimeSpan cheakDate = date - temp;
            if (cheakDate.TotalDays <= 0)
                throw new Exception("The date that you enterd already pass");
            if ((date.Day.ToString() == "Friday") || (date.Day.ToString() == "Saturday"))
                throw new Exception("The date that you enterd is worng");

            bool flag = true;
            while (flag == true)
            {
                //מאגר בוחנים שעונים על 5 התנאים
                //התמחות, מקסימום טסטים, עובדים ופנויים
                IEnumerable<Tester> searchForATester = GetAllTesters(t => t.isActive == true && t.TesterSpecialization == mytest.TestTypeOfCar);
                List <Tester> mylist = searchForATester.ToList();
                searchForATester = mylist.FindAll(t => cheakAll(mytester, mytrainee, mytest));
                //בדיקה האם סוג התמחות הבוחן מתאים לסוג הרכב שעליו התלמיד נבחן
                bool specialization = mytester.TesterSpecialization == mytrainee.TraineeLearingCar;

                //הרשימה לא ריקה 
                if (searchForATester.Count() != 0)
                {
                    //בדיקה האם הטסטר שהוכנס למבחן עומד בכל התנאים ופנוי לטסט
                    IEnumerable<Tester> testers = searchForATester.Where<Tester>(t => t.TesterId == mytest.TesterId);

                    // הטסטר שלי לא ברשימה- והרשימה לא ריקה אז אחליף לתלמיד טסטר
                    if (testers.Count() == 0)
                    {
                        //נחפש טסטר אחר למבחן בתאריך הנל - אם הרשימה שלי לא ריקה ניקח את הראשון
                        Tester Atester = searchForATester.First<Tester>();
                        mytest.TesterId = Atester.TesterId;
                        try { dal.AddTest(mytest); }
                        catch (Exception e)
                        {
                            throw (e);
                        }
                        try { UpdateTesteravailability(mytest, Atester, mytest.DateTimeOfTest, mytest.DateTimeOfTest.Hour, true);}
                        catch (Exception e)
                        {
                            throw (e);
                        }
                        flag = false;
                        return;
                    }
                    //הטסטר הנוכחי נמצא פנוי וכו - ניתן להכניס את המבחן לרשימת המבחנים הכל תקין
                    if ((testers.Count() == 1) && (testers.First() != null))
                    {
                        try { dal.AddTest(mytest); }
                        catch (Exception ex)
                        { throw (ex); }
                        try { UpdateTesteravailability(mytest, mytester, mytest.DateTimeOfTest, mytest.DateTimeOfTest.Hour, true); }
                        catch (Exception e)
                        {
                            throw (e);
                        }
                        flag = false;
                        return;
                    }
                    if (testers.Count() > 1)
                        throw new Exception("ERROR - The tester was put on the list more then once");
                }
                //אם רשימת הטסטרים שעונים על 4 התנאים - ריקה
                else
                {
                    // בדיקה על מה הטסטר שלי נפל
                    // אם התחום התמחות והמרחק בסדר אז אחפש לטסטר זה תאריך חדש
                    if ((specialization == true)&&(Distance(mytester,mytest.TestExitAddress)<mytester.MaxiDistanceFromAddress))
                    {
                        // נחפש עבור טסטר נוכחי תאריך אחר למבחן
                        // נחפש שעה אחרת ליום נוכחי, אם לא נמצא נחפש יום חדש לגמרי
                        DateTime update = AnotherDateForTheTest(mytester, mytest, mytest);
                        throw new Exception(update.ToString());
                    }
                    // אם הרשימה ריקה וגם הטססטר שלי נפל על מרחק או התמחות מה שאומר שלעולם לא יוכל לבחון את התלמיד הנל
                    // יש לבצע את כל התהליך מחדש אך הפעם לשנות את התאריך - או את שעתו או את יומו בהתאם למצב הנוכחי
                    // ואת התאריך החדש לבדוק על שאר הטסטרים 
                    DateTime newDate = mytest.DateTimeOfTest.AddHours(1);
                    if (newDate.Hour > 14)
                    {
                        if ((newDate.DayOfWeek.ToString() != "Friday") && (newDate.DayOfWeek.ToString() != "Saturday"))
                            newDate = new DateTime(mytest.DateTimeOfTest.Year, mytest.DateTimeOfTest.Month, mytest.DateTimeOfTest.Day + 1, 10, 00, 00);
                        if (newDate.DayOfWeek.ToString() == "Friday")
                            newDate = new DateTime(mytest.DateTimeOfTest.Year, mytest.DateTimeOfTest.Month, mytest.DateTimeOfTest.Day + 2, 10, 00, 00);
                        if (newDate.DayOfWeek.ToString() == "Saturday")
                            newDate = new DateTime(mytest.DateTimeOfTest.Year, mytest.DateTimeOfTest.Month, mytest.DateTimeOfTest.Day + 3, 10, 00, 00);
                    }
                    else
                    {
                        newDate = new DateTime(mytest.DateTimeOfTest.Year, mytest.DateTimeOfTest.Month, mytest.DateTimeOfTest.Day, mytest.DateTimeOfTest.Hour + 1, 00, 00);
                    }
                    mytest.DateTimeOfTest = newDate;
                }
            }
        }
        #endregion

        #region Distance
        /// <summary>
        /// פונקציה המחשבת מרחק מכתובת בין הנבחן לבוחן.
        /// מחזירה אמת אם המרחק אפשרי, אחרת יחזיר שקר
        /// </summary>
        /// <param name="mytester">בוחן</param>
        /// <param name="numOfTest">מספר מבחן</param>
        /// <returns></returns> 
        public double Distance(Tester mytester, Address testAddress)
        {
            string origin = mytester.TesterAddress.Street+" "+ mytester.TesterAddress.HouseNumber+" "+ mytester.TesterAddress.City;
            string destination = testAddress.Street+" "+ testAddress.HouseNumber+" "+ testAddress.City;
            string KEY = @"OjGRqdd2o4fJbNRBL6LGSxIY7JPplV5C";
            string url = @"https://www.mapquestapi.com/directions/v2/route" +
            @"?key=" + KEY +
            @"&from=" + origin +
            @"&to=" + destination +
            @"&outFormat=xml" +
            @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
            @"&enhancedNarrative=false&avoidTimedConditions=false";
            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {
                //display the returned distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                // Console.WriteLine("Distance In KM: " + distInMiles * 1.609344);
                return (distInMiles * 1.609344);
                ////display the returned driving time
                //XmlNodeList formattedTime = xmldoc.GetElementsByTagName("formattedTime");
                //string fTime = formattedTime[0].ChildNodes[0].InnerText;
                //Console.WriteLine("Driving Time: " + fTime);
            }
            else if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
            //we have an answer that an error occurred, one of the addresses is not found
            {
                return Configuration.Maxdistance;
            }
            else //busy network or other error...
            {
                return Configuration.Maxdistance;
               // throw new Exception("We have'nt got an answer, maybe the net is busy...");
            }
        }
        #endregion

        #region numOfTestForTester
        /// <summary>
        /// פונקציה המחשבת את מספר הטסטים לשבוע לטסטס מסויים בשבוע מסויים
        /// </summary>
        /// <param name="mytester">הבוחן</param>
        /// <param name="date">תאריך</param>
        /// <returns>מספר טסטים</returns>
        private int numOfTestForTester(Tester mytester, DateTime date)
        {
            int count = 0;
            DayOfWeek day = date.DayOfWeek;
            if (day.ToString() != "sunday")
            {
                if (day.ToString() == "Monday")
                    date = date.AddDays(-1);
                if (day.ToString() == "Tuesday")
                    date = date.AddDays(-2);
                if (day.ToString() == "Wednesday")
                    date = date.AddDays(-3);
                if (day.ToString() == "Thursday")
                    date = date.AddDays(-4);
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (mytester.MatrixTesterworkdays[i, j].Available != null)
                        if (mytester.MatrixTesterworkdays[i, j].Available.ContainsKey(date) == true)
                            count++;    
                }
                date = date.AddDays(1);
            }
            return count;     
        }
        #endregion

        #region cheakAll
        /// <summary>
        /// פונקציית עזר - בודקת 5 תנאים שונים 
        /// </summary>
        /// <param name="mytester">בוחן</param>
        /// <param name="mytrainee">נבחן</param>
        /// <param name="mytest">מבחן</param>
        /// <returns>ערך בוליאני</returns>
        private bool cheakAll(Tester mytester, Trainee mytrainee, Test mytest)
        {
            //הפוקציה בודקת על בוחן ספציפי האם:
            // סוג ההתמחות מתאים
            // לא עבר מספר מקסימלי של טסטים לשבוע
            // עובד בשעה זו ופנוי בשעה זו

            bool flag;
            flag = ((mytester.isActive == true)
                && (mytester.TesterSpecialization == mytrainee.TraineeLearingCar)
                && (numOfTestForTester(mytester, mytest.DateTimeOfTest) < mytester.TesterMaxNumOfTestsPerWeek)
                && (DoesTasterHaveTestInThatTime(mytester, mytest.DateTimeOfTest, mytest.DateTimeOfTest.Hour)));
            double dis = -1.1;
            Thread th;
            try
            {
                th = new Thread(() =>
               {
                   dis = Distance(mytester, mytest.TestExitAddress);
               });
                th.Start();
                th.Join();
            }
            catch (Exception message)
            {
                throw message;
            }

            flag = (flag && (dis < mytester.MaxiDistanceFromAddress));
            return flag;
        }
        #endregion

        #region DoesTesterWork
        /// <summary>
        ///הפונקציה מחזירה אמת אם הבוחן שנשלח לפונקציה עובד ביום ושעה זו 
        ///האם שעה זו היא אחת משעות העבודה של הבוחן
        /// </summary>
        /// <param name="mytester">בוחן</param>
        /// <param name="date">תאריך</param>
        /// /// <param name="hour">שעה</param>
        /// <returns></returns>
        private bool DoesTesterWork(Tester mytester, DateTime date, int hour)
        {
            if (hour < 9)
                throw new Exception("ERROR - the hour is too early");
            int j = -1;
            if (((int)date.DayOfWeek == 5) || ((int)date.DayOfWeek == 6))
                throw new Exception("ERROR - We do not work on Fridays and Saturdays");
            j = (int)date.DayOfWeek;
            if (j == -1)
                throw new Exception("ERROR - this day don't exist");
            int i = hour - 9;
            return mytester.MatrixTesterworkdays[i, j].DoesWork;
        }
        #endregion

        #region DoesTasterHaveTestInThatTime
        /// <summary>
        /// הפונקציה מחזירה שקר אם התאריך והשעה תפוסים כבר ואמת אחרת
        /// </summary>
        /// <param name="mytester">בוחן</param>
        /// <param name="date">תאריך</param>
        /// <param name="hour">שעה</param>
        /// <returns></returns>
        private bool DoesTasterHaveTestInThatTime(Tester mytester, DateTime date, int hour)
        {
            if (DoesTesterWork(mytester, date, hour) == true)
            {
                int j = (int)date.DayOfWeek;
                if (mytester.MatrixTesterworkdays[hour - 9, j].Available == null)
                    return true;
                return (!mytester.MatrixTesterworkdays[hour - 9, j].Available.ContainsKey(date));
            }
            return false;
        }
        #endregion

        #region ArrangeTestAtDiffrentTime
        /// <summary>
        /// פונקציה שמקבלת בוחן, מבחן ותאריך ובודקת האם יש שעה פנויה למבחן בתאריך זה.
        /// הפונקציה מחזירה תאריך חדש לטסטס - אותו תאריך רק שעה חדשה
        /// אם לא מצא שעה פנויה יחזיר תאריך ברירת מחדל
        /// </summary>
        /// <param name="mytester">בוחן</param>
        /// <param name="NewDate">תאריך</param>
        /// <returns></returns>
        private DateTime ArrangeTestAtDiffrentTime(Tester mytester, DateTime NewDate)
        {
            DateTime temp = new DateTime();
            for (int time = 9; time < 15; time++)
            {
                if ((DoesTesterWork(mytester, NewDate, time)) && (DoesTasterHaveTestInThatTime(mytester, NewDate, time)))
                {
                    temp = new DateTime(NewDate.Year, NewDate.Month, NewDate.Day, time, NewDate.Minute, NewDate.Second);
                    return temp;
                }
            }
            return temp;
        }
        #endregion

        #region AnotherDateForTheTest
        /// <summary>
        /// הפונקציה מחפשת תאריך אחר לטסט בכל שעה שהיא, ומחזירה תאריך זה
        /// </summary>
        /// <param name="mytester">הבוחן</param>
        /// <param name="lastTest">המבחן</param>
        /// <returns>תאריך</returns>
        public DateTime AnotherDateForTheTest(Tester mytester, Test currentTest, Test lastTest)
        {
            DateTime temp = DateTime.Now;
            DateTime NewDate;
            if (lastTest != null)
            {
                //הבדיקה מתחילה החל מ7 ימים מהטסט האחרון - תוך בדיקה שהתאריך הנל לא חלף כבר ואם כן מתחילה מהתאריך האפשרי
                NewDate = lastTest.DateTimeOfTest.AddDays(7);
                TimeSpan cheakDate = NewDate - temp;
                if (cheakDate.TotalDays <= 0)
                {
                    cheakDate = temp - NewDate;
                    if (cheakDate.Days == 0)
                    {
                        NewDate = NewDate.AddDays(cheakDate.Days + 1);
                    }
                    else
                    {
                        NewDate = NewDate.AddDays(cheakDate.Days);
                    }
                }
            }
            else
            {
                NewDate = currentTest.DateTimeOfTest;
            }
            //שליחת התאריך לחיפוש האם ביום זה בכל שעה שהיא ישנו טסט פנוי
            temp = new DateTime();
            DateTime diffrent = ArrangeTestAtDiffrentTime(mytester, NewDate);
            while ((diffrent == temp) || (numOfTestForTester(mytester, diffrent) >= mytester.TesterMaxNumOfTestsPerWeek))
            {
                NewDate = NewDate.AddDays(1);
                if ((int)NewDate.DayOfWeek == 5)
                {
                    NewDate = NewDate.AddDays(2);
                }
                if ((int)NewDate.DayOfWeek == 6)
                {
                    NewDate = NewDate.AddDays(1);
                }
                diffrent = ArrangeTestAtDiffrentTime(mytester, NewDate);
            }
            return diffrent;
        }
        #endregion

        #region UpdateTest
        /// <summary>
        /// עדכון פרטי טסט
        /// </summary>
        /// <param name="mytest">טסט</param>
        public void UpdateTest(Test mytest)
        {
            if (mytest.TesterId != default(string) &&
               mytest.TraineeId != default(string) &&
               mytest.DateTimeOfTest != default(DateTime) &&
               mytest.TestCriterion != default(Criterion) &&
               mytest.TesterNote != default(string))
                if (sumOfCriterion(mytest) > 3)
                    mytest.TestResult = PassOrFail.Fail;
            try
            {
                dal.UpdateTest(mytest);
            }
            catch (Exception e)
            { throw e; }
        }
        #endregion

        #region DeletTest
        /// <summary>
        /// מחיקת מבחן מהמערכת אם תאריכו עוד לא עבר
        /// </summary>
        /// <param name="mytest"></param>
        public void DeletTest(Test mytest)
        {
            try
            {
                dal.DeletTest(mytest);
                
            }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region UpdateTesterworkdays
        /// <summary>
        /// עדכון פרטי יום ושעות של בוחן
        /// </summary>
        /// <param name="mytester">בוחן</param>
        /// <param name="day">יום</param>
        /// <param name="start">שעת התחלת של עבודה</param>
        /// <param name="finish">שעת סיום של עבודה</param>
        /// <param name="Work">ערך בוליאני להצבה</param>
        public void UpdateTesterworkdays(Tester mytester, DateTime date, int start, int finish, bool Work)
        {
            if (finish < start)
                throw new Exception("ERROR  - finish is smaller then start");
            if (start < 9)
                throw new Exception("ERROR - too late");
            if (finish > 14)
                throw new Exception("ERROR - too late");
            int i; int j = -1;
            if (((int)date.DayOfWeek == 5) || ((int)date.DayOfWeek == 6))
                throw new Exception("ERROR -Not working these days");
            j = (int)date.DayOfWeek;
            if (j == -1)
                throw new Exception("ERROR - this day don't exist");
            for (i = start - 9; i < finish - 9; i++)
            {
                mytester.MatrixTesterworkdays[i, j].DoesWork = Work;
            }
            try { dal.UpdateTester(mytester); }
            catch(Exception message) { throw message; }
        }
        #endregion

        #region UpdateTesteravailability
        /// <summary>
        /// עדכון זמינות בוחן ביום ושעה מסויימים
        /// אם ערך הדגל שווה שקר - ברצוני למחוק מבחן ואם ערכו אמת ברצוני להוסיף מבחן
        /// </summary>
        /// <param name="mytest">המבחן</param>
        /// <param name="mytester">הבוחן</param>
        /// <param name="date">תאריך</param>
        /// <param name="hour">שעה</param>
        /// <param name="flag">שדה בוליאני</param>
        public void UpdateTesteravailability(Test mytest, Tester mytester, DateTime date, int hour, bool flag)
        {
            if (hour < 9)
                throw new Exception("ERROR - too early");
            if (hour > 14)
                throw new Exception("ERROR - too late");
            int i = hour - 9; ;
            int j = -1;
            if (((int)date.DayOfWeek == 5) || ((int)date.DayOfWeek == 6))
                throw new Exception("ERROR - Not working these days");
            j = (int)date.DayOfWeek;
            if (j == -1)
                throw new Exception("ERROR - this day don't exist");
            if (flag == false)
            {
                try
                {
                    mytester.MatrixTesterworkdays[i, j].Available.Remove(mytest.DateTimeOfTest);
                    dal.UpdateTester(mytester);
                }
                catch (Exception)
                {
                    throw new Exception("Failed to delete test");
                }
            }
            if (flag == true)
            {
                //בדיקה שהבוחן אכן עובד בשעה וביום זה וגם שהדגל אמת
                if ((mytester.MatrixTesterworkdays[i, j].DoesWork == true) && (flag == true))
                {
                    mytester.MatrixTesterworkdays[i, j].Available.Add(mytest.DateTimeOfTest, mytest);
                    try { dal.UpdateTester(mytester); }
                    catch(Exception message) { throw message;}
                }
                else
                    throw new Exception("Tester does not work on that time");
            }
        }
        #endregion

        #region sumOfCriterion
        /// <summary>
        /// הפונקציה מחזירה כמה מהקריטריונים הנבחן לא עבר
        /// </summary>
        /// <param name="mytest">מבחן</param>
        /// <returns></returns>
        public int sumOfCriterion(Test mytest)
        {
            int sum = 0;
            if (mytest.TestTypeOfGearbox == TypeOfGearbox.Manual)
            {
                if (mytest.TestCriterion.ALeapInTheRise == false)
                    sum++;
                if (mytest.TestCriterion.ChangeGears == false)
                    sum++;
                if (mytest.TestCriterion.EngineShutdown == false)
                    sum++;
            }
            if (mytest.TestCriterion.Signals == false)
                sum++;
            if (mytest.TestCriterion.LookingAtMirrors == false)
                sum++;
            if (mytest.TestCriterion.Parking == false)
                sum++;
            if (mytest.TestCriterion.ParkingInReverse == false)
                sum++;
            if (mytest.TestCriterion.KeepDistance == false)
                sum++;
            if (mytest.TestCriterion.Speed == false)
                sum++;
            if (mytest.TestCriterion.Bypassing == false)
                sum++;
            if (mytest.TestCriterion.DriveInTheRightLane == false)
                sum++;
            if (mytest.TestCriterion.Bypassing == false)
                sum++;
            if (mytest.TestCriterion.PreemptiveRight == false)
                sum++;
            if (mytest.TestCriterion.Stopping == false)
                sum++;
            if (mytest.TestCriterion.ObedienceToTrafficSigns == false)
                sum++;
            if (mytest.TestCriterion.AddressingPedestrians == false)
                sum++;
            if (mytest.TestCriterion.IntegrationIntoMovement == false)
                sum++;
            if (mytest.TestCriterion.SkillForVehicleOperation == false)
                sum++;
            if (mytest.TestCriterion.AeactionTime == false)
                sum++;
            return sum;
        }
        #endregion

        /// <summary>
        /// יצירת אוסף של כל הטסטרים/הנבחנים/המבחנים אשר עונים על תנאי מסויים
        /// </summary>
        /// <param name="predicat">ביטוי למדה - תנאי</param>
        /// <returns></returns>  bool> predicat = null)
        public IEnumerable<Tester> GetAllTesters(Func<Tester, bool> predicat = null)
        {
            return dal.GetAllTesters(predicat);
        }
        public IEnumerable<Trainee> GetAllTrainee(Func<Trainee, bool> predicat = null)
        {
            return dal.GetAllTrainee(predicat);
        }
        public IEnumerable<Test> GetAllTest(Func<Test, bool> predicat = null)
        {
            return dal.GetAllTest(predicat);
        }
        public IEnumerable<DrivingInstructorsAndSchools> GetAllTeachers(Func<DrivingInstructorsAndSchools, bool> predicat = null)
        {
            return dal.GetAllTeachers(predicat);
        }

        #region GetAllTestersFrom
        /// <summary>
        ///פונקציה שמקבלת כתובת ומחזירה את כל הבוחנים שגרים במרחק במרחק מסויים מהכתובת הנל 
        /// </summary>
        /// <param name="myAddress">כתובת</param>
        /// <returns></returns>
        public IEnumerable<Tester> GetAllTestersFrom(Address myAddress, double X)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            IEnumerable<Tester> allTesters = GetAllTesters();
            var v = from item in allTesters
                    where Distance(item,myAddress)<=X
                    select new Tester
                    { TesterId = item.TesterId,
                        TesterLastName = item.TesterLastName,
                        TesterFirstName = item.TesterFirstName,
                        TesterFamilyStatus = item.TesterFamilyStatus,
                        TesterGender = item.TesterGender,
                        TesterSpecialization = item.TesterSpecialization,
                        isActive =item.isActive
                    };
            return v;
        }
        #endregion

        #region IsTestersAvailable
        /// <summary>
        /// פונקציה שמקבלת תאריך ושעה ומחזירה את כל הבוחנים הפנויים באותה שעה
        /// </summary>
        /// <param name="date">תאריך</param>
        /// <returns>רשימת בוחנים</returns>
        public IEnumerable<Tester> IsTestersAvailable(DateTime date)
        {
            IEnumerable<Tester> allTesters = GetAllTesters(t=>t.isActive);
            var v1 = from item in allTesters
                     where (true == DoesTesterWork(item, date, date.Hour))
                     where (true == DoesTasterHaveTestInThatTime(item, date, date.Hour))
                     select item;
            return v1;
        }
        #endregion

        #region TraineeNumOfNotPassingTests
        /// <summary>
        /// פונקציה שמקבלת תלמיד, ומחזירה את מספר המבחנים שנבחן בהם.
        /// </summary>
        /// <param name="mytrainee">נבחן</param>
        /// <returns></returns>
        public int TraineeNumOfTests(Trainee mytrainee)
        {
            IEnumerable<Test> allTests = GetAllTest();
            var v = from item in allTests
                    where (item.TraineeId == mytrainee.TraineeId) 
                    select item;
            return v.Count();
        }
        #endregion

        #region TraineeEntitledReceiveLicense
        /// <summary>
        /// פונקציה שמקבלת תלמיד ומחזירה האם הוא זכאי לרשיון נהיגה- האם עבר בהצלחה מבחן נהיגה
        /// </summary>
        /// <param name="mytrainee">נבחן</param>
        /// <returns></returns>
        public bool TraineeEntitledReceiveLicense(Trainee mytrainee)
        {
            Test v = FindLastTest(mytrainee.TraineeId, mytrainee.TraineeLearingCar);
            if (v == null)
                throw new Exception("The trainee has not yet taken a test");
            if (v.TestResult == PassOrFail.Fail)
                return false;
            else
                return true;
        }

        #endregion

        #region GetAllTestAtDate
        /// <summary>
        /// פונקציה שמחזירה את רשימת כל המבחנים שמתוכננים לפי חודש 
        /// </summary>
        /// <param name="date">תאריך</param>
        /// <returns>אוסף</returns>
        public IEnumerable<Test> GetAllTestAtDate(DateTime date)
        {
            IEnumerable<Test> allTests = GetAllTest(t => ((t.DateTimeOfTest.Month == date.Month) && (t.DateTimeOfTest.Year == date.Year)));
            var v = from item in allTests
                    orderby item.DateTimeOfTest
                    select item;
            return v;
        }
        #endregion

        /// <summary>
        /// רשימת בוחנים מקובצת ע"פ סוג ההתמחות
        /// </summary>
        /// <param name="predicate">משתנה בוליאני</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<TypeOfCar, Tester>> GetTestersSpecialization(bool flag=false)
        {
            IEnumerable<Tester> allTesters = GetAllTesters();
            if (flag == false)
            {
                var Specialization = from item in allTesters
                                     group item by item.TesterSpecialization;
                return Specialization;
            }
            var Specialization2 = from item in allTesters
                                  orderby item.TesterId
                                  group item by item.TesterSpecialization;
            return Specialization2;
        }
        /// <summary>
        /// רשימת תלמידים מקובצת ע"פ ביה"ס לנהיגה בו לומדים
        /// </summary>
        /// <param name="flag">תנאי בוליאני</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<string, Trainee>> GetTraineeDrivingSchool(bool flag)
        {
            IEnumerable<Trainee> allTrainee = GetAllTrainee();
            if (flag == false)
            {
                var DrivingSchool1 = from item in allTrainee
                                     group item by item.TraineeNameOfSchool;

                return DrivingSchool1;
            }
            var DrivingSchool2 = from item in allTrainee
                                 orderby item.TraineeId
                                 group item by item.TraineeNameOfSchool;

            return DrivingSchool2;
        }
        /// <summary>
        /// רשימת תלמידים מקובצת ע"פ המורה לנהיגה אצלו לומדים
        /// </summary>
        /// <param name="flag">תנאי בוליאני</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<string, Trainee>> GetTraineeTeacher(bool flag)
        {
            IEnumerable<Trainee> allTrainee = GetAllTrainee();
            if (flag == false)
            {
                var Teacher = from item in allTrainee
                              group item by item.TraineeNameOfTeacher;

                return Teacher;
            }
            var Teacher1 = from item in allTrainee
                           orderby item.TraineeId
                           group item by item.TraineeNameOfTeacher;

            return Teacher1;
        }
        /// <summary>
        /// רשימת תלמידים מקובצת ע"פ מספר הטסטים שביצעו
        /// </summary>
        /// <param name="flag">תנאי בוליאני</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, Trainee>> GetTraineeNumOfTest(bool flag)
        {
            IEnumerable<Trainee> allTrainee = GetAllTrainee();

            if (flag == false)
            {
                var num = from item in allTrainee
                          let numOfTest = GetAllTest(t => t.TraineeId == item.TraineeId).Count()
                          group item by numOfTest;
                return num;
            }
            var num1 = from item in allTrainee
                       orderby item.TraineeId
                       let numOfTest = GetAllTest(t => t.TraineeId == item.TraineeId).Count()
                       group item by numOfTest;
            return num1;
        }
        /// <summary>
        /// רשימת מורים מקובצת לפי בית ספר שאליו משויכיים
        /// </summary>
        /// <returns></returns>
        public object GetTeachersSchool()
        {
            IEnumerable<DrivingInstructorsAndSchools> allTeachers = GetAllTeachers();
            var school = from item in allTeachers
                         group item by item.DrivingSchool;
            return school;

        }
        /// <summary>
        /// רשימת בוחנים מקובצת לפי סטטוס משפחתי
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<FamilyStatus, Tester>> GetTestersFamilyStatus()
        {
            IEnumerable<Tester> allTesters = GetAllTesters();
            var family = from item in allTesters
                                  orderby item.TesterId
                                  group item by item.TesterFamilyStatus;
            return family;
        }

        /// <summary>
        /// פונקציה למציאת טסטר למבחן
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <param name="date"></param>
        /// <param name="numOfTest"></param>
        /// <returns></returns>
        public Tester findMeAtester(string id, Test mytest)
        {
            IEnumerable<Tester> alltesters = GetAllTesters(t=>(t.isActive==true) && (t.TesterSpecialization==mytest.TestTypeOfCar));
            Trainee myTrainee = SearchTrainee(id, mytest.TestTypeOfCar);
            foreach (Tester item in alltesters)
            {

                if (cheakAll(item, myTrainee, mytest) == true)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// רשימת בוחנים מקובצת ע"פ פעיל
        /// </summary>
        /// <param name="predicate">משתנה בוליאני</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<bool, Tester>> GetTestersActive(bool flag=false)
        {
            IEnumerable<Tester> allTesters = GetAllTesters();
            if (flag == false)
            {
                var Active = from item in allTesters
                             group item by item.isActive;
                return Active;
            }
            var Active2 = from item in allTesters
                          orderby item.TesterId
                          group item by item.isActive;
            return Active2;
        }

        /// <summary>
        /// רשימת טסטים לפי תוצאה של טסט
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<PassOrFail, Test>> GetAllTestResult()
        {
            IEnumerable<Test> allTest = GetAllTest();
            var result = from item in allTest
                         orderby item.DateTimeOfTest
                         group item by item.TestResult;
            return result;
        }

        /// <summary>
        /// רשימת כל המבחנים מאוגדים לפי חודש  מחודשי השנה
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, Test>> GetAllTestInMounth()
        {
            IEnumerable<Test> allTest = GetAllTest();
            var Month = from item in allTest
                         orderby item.DateTimeOfTest.Month
                         group item by item.DateTimeOfTest.Month;
            return Month;
        }

        /// <summary>
        /// רשימת מבחנים מקובצות לפי טסטר
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<string, Test>> GetAllTestOfTester()
        {
            IEnumerable<Test> allTest = GetAllTest();
            var tester = from item in allTest
                        orderby item.DateTimeOfTest
                        group item by item.TesterId;
            return tester;
        }
    }
}
    


    

