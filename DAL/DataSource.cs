using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BE;

namespace DAL
{ 
    public class DataSource
    {

        /// <summary>
        /// הגדרת 3 רשימות - כאשר כל רשימה מכילה טיפוס שונה - טסטר/נבחן/מבחן
        /// </summary>
        public static List<Tester> TesterList = new List<Tester>();
        public static List<Trainee> TraineeList =new List<Trainee>();
        public static List<Test> TestList = new List<Test>();

        /// <summary>
        /// אתחול רשימה שתכיל את כל המורי לנהיגה ותשייך אותם לבית ספר אחד 
        /// </summary>
        public static List<DrivingInstructorsAndSchools> TeacherList = new List<DrivingInstructorsAndSchools>();


        /// <summary>
        ///  DataSoure בנאי של המחלקה 
        ///  אתחול 3 הרשימות
        /// </summary>
        public DataSource()
        {
            #region start TeacherList
            DrivingInstructorsAndSchools t1 = new DrivingInstructorsAndSchools
            {
                TeacherName = "דני אסייג",
                DrivingSchool = "מעוף"
            };
            TeacherList.Add(t1);
            DrivingInstructorsAndSchools t2 = new DrivingInstructorsAndSchools
            {
                TeacherName = "עוז שמעוני",
                DrivingSchool = "על גלגלים"
            };
            TeacherList.Add(t2);
            DrivingInstructorsAndSchools t3 = new DrivingInstructorsAndSchools
            {
                TeacherName = "משה פלג",
                DrivingSchool = "אור ירוק"
            };
            TeacherList.Add(t3);
            DrivingInstructorsAndSchools t4 = new DrivingInstructorsAndSchools
            {
                TeacherName = "טוהר שלם",
                DrivingSchool = "שרייבר"
            };
            TeacherList.Add(t4);
            DrivingInstructorsAndSchools t5 = new DrivingInstructorsAndSchools
            {
                TeacherName = "רננה צוברי",
                DrivingSchool = "איזי-דרייב"
            };
            TeacherList.Add(t5);
            DrivingInstructorsAndSchools t6 = new DrivingInstructorsAndSchools
            {
                TeacherName = "שולמית קורן",
                DrivingSchool = "על גלגלים"
            };
            TeacherList.Add(t6);
            DrivingInstructorsAndSchools t7 = new DrivingInstructorsAndSchools
            {
                TeacherName = "אורי קורן",
                DrivingSchool = "סמארטדרייב"
            };
            TeacherList.Add(t7);
            DrivingInstructorsAndSchools t8 = new DrivingInstructorsAndSchools
            {
                TeacherName = "טל כהן",
                DrivingSchool = "אופיר"
            };
            TeacherList.Add(t8);
            DrivingInstructorsAndSchools t9 = new DrivingInstructorsAndSchools
            {
                TeacherName = "תהל מרדכי",
                DrivingSchool = "דרייב2000"
            };
            TeacherList.Add(t9);
            DrivingInstructorsAndSchools t10 = new DrivingInstructorsAndSchools
            {
                TeacherName = "רונן ישראל",
                DrivingSchool = "עוז"
            };
            TeacherList.Add(t10);
            DrivingInstructorsAndSchools t11 = new DrivingInstructorsAndSchools
            {
                TeacherName = "איתי בן שלום",
                DrivingSchool = "על גלגלים"
            };
            TeacherList.Add(t11);
            DrivingInstructorsAndSchools t12 = new DrivingInstructorsAndSchools
            {
                TeacherName = "תהילה לוי",
                DrivingSchool = "אור ירוק"
            };
            TeacherList.Add(t12);
            #endregion

            #region start list
            TesterList = new List<Tester>();
            TraineeList = new List<Trainee>();
            TestList = new List<Test>();

            Tester mytester = new Tester();
            {
                mytester.isActive = true;
                mytester.TesterId = "111111111";
                mytester.TesterLastName = "לב";
                mytester.TesterFirstName = "אלעד";
                mytester.TesterDateOfBirth = new DateTime(1975, 3, 12);
                mytester.TesterFamilyStatus = FamilyStatus.Married;
                mytester.TesterGender = Gender.Male;
                mytester.TesterHasGlasses = true;
                mytester.TesterPhoneNumber = "0504477332";
                mytester.TesterEmailAddress = "Eladch158@gamil.com";
                mytester.TesterAddress = new Address("ירושלים","דוד המלך",23);
                mytester.TesterYearsOfExperience = 12;
                mytester.TesterMaxNumOfTestsPerWeek = 10;
                mytester.TesterSpecialization = TypeOfCar.PrivateCar;
                mytester.MaxiDistanceFromAddress = 12;
                //TesterImageSource
            };
            TesterList.Add(mytester);
            Tester mytester1 = new Tester();
            {
                mytester1.isActive = true;
                mytester1.TesterId = "222222222";
                mytester1.TesterLastName = "פולק";
                mytester1.TesterFirstName = "איילת";
                mytester1.TesterDateOfBirth = new DateTime(1970, 5, 28);
                mytester1.TesterFamilyStatus = FamilyStatus.Single;
                mytester1.TesterGender = Gender.Female;
                mytester1.TesterHasGlasses = true;
                mytester1.TesterPhoneNumber = "0504452932";
                mytester1.TesterEmailAddress = "Ayelet115@gamil.com";
                mytester1.TesterAddress = new Address("חיפה", "יזרעאל", 3);
                mytester1.TesterYearsOfExperience = 5;
                mytester1.TesterMaxNumOfTestsPerWeek = 3;
                mytester1.TesterSpecialization = TypeOfCar.PrivateCar;
                mytester1.MaxiDistanceFromAddress = 32.7;
                //TesterImageSource
            };
            TesterList.Add(mytester1);
            Tester mytester3 = new Tester();
            {
                mytester3.isActive = false;
                mytester3.TesterId = "444444444";
                mytester3.TesterLastName = "אלי";
                mytester3.TesterFirstName = "תומר";
                mytester3.TesterDateOfBirth = new DateTime(1970, 11, 4);
                mytester3.TesterFamilyStatus = FamilyStatus.Widower;
                mytester3.TesterGender = Gender.Male;
                mytester3.TesterHasGlasses = true;
                mytester3.TesterPhoneNumber = "0509852932";
                mytester3.TesterEmailAddress = "tttt@gamil.com";
                mytester3.TesterAddress = new Address("תל אביב","טוהר", 52);
                mytester3.TesterYearsOfExperience = 5;
                mytester3.TesterMaxNumOfTestsPerWeek = 10;
                mytester3.TesterSpecialization = TypeOfCar.TwoWheeledVehicles;
                mytester3.MaxiDistanceFromAddress = 12.7;
                //TesterImageSource
            };
            TesterList.Add(mytester3);
            Tester mytester2 = new Tester();
            {
                mytester2.isActive = true;
                mytester2.TesterId = "333333333";
                mytester2.TesterLastName = "כהן";
                mytester2.TesterFirstName = "רות";
                mytester2.TesterDateOfBirth = new DateTime(1970, 5, 28);
                mytester2.TesterFamilyStatus = FamilyStatus.Single;
                mytester2.TesterGender = Gender.Female;
                mytester2.TesterHasGlasses = true;
                mytester2.TesterPhoneNumber = "0504452932";
                mytester2.TesterEmailAddress = "Ayelet115@gamil.com";
                mytester2.TesterAddress = new Address("באר שבע", "שרון", 6);
                mytester2.TesterYearsOfExperience = 5;
                mytester2.TesterMaxNumOfTestsPerWeek = 8;
                mytester2.TesterSpecialization = TypeOfCar.HeavyTruck;
                mytester2.MaxiDistanceFromAddress = 32.7;
                //TesterImageSource
            };
            TesterList.Add(mytester2);
            Tester mytester4 = new Tester();
            {
                mytester4.isActive = true;
                mytester4.TesterId = "555555555";
                mytester4.TesterLastName = "רונן";
                mytester4.TesterFirstName = "שחר";
                mytester4.TesterDateOfBirth = new DateTime(1975, 3, 12);
                mytester4.TesterFamilyStatus = FamilyStatus.Married;
                mytester4.TesterGender = Gender.Female;
                mytester4.TesterHasGlasses = true;
                mytester4.TesterPhoneNumber = "0504477332";
                mytester4.TesterEmailAddress = "Eladch158@gamil.com";
                mytester4.TesterAddress = new Address("ירושלים", "שמשון", 986);
                mytester4.TesterYearsOfExperience = 12;
                mytester4.TesterMaxNumOfTestsPerWeek = 10;
                mytester4.TesterSpecialization = TypeOfCar.CarService;
                mytester4.MaxiDistanceFromAddress = 120;
                //TesterImageSource
            };
            TesterList.Add(mytester4);
            Trainee mytrainee = new Trainee
            {
                TraineeId = "111111112",
                TraineeFirstName = "שרה",
                TraineeLastName = "לוי",
                TraineeGender = Gender.Female,
                TraineePhoneNumber = "0543811241",
                TraineeEmailAddress = "Sara922@walla.co.il",
                TraineeAddress = new Address("ירושלים", "תכלת", 23),
                TraineeDateOfBirth = new DateTime(1997, 5, 17),
                TraineeLearingCar = TypeOfCar.PrivateCar,
                TraineeGearbox = TypeOfGearbox.Manual,
                TraineeNameOfSchool = "מעוף",
                TraineeNameOfTeacher = "דני אסייג",
                TraineeNumOfDrivingLessons = 30,
                TraineeHasGlasses = false,
                IfTraineePassedAnInternalTest = true
                //TraineeImageSource
            };
            TraineeList.Add(mytrainee);
            Trainee mytrainee5 = new Trainee
            {
                TraineeId = "111111112",
                TraineeFirstName = "שרה",
                TraineeLastName = "לוי",
                TraineeGender = Gender.Female,
                TraineePhoneNumber = "0543811241",
                TraineeEmailAddress = "Sara922@walla.co.il",
                TraineeAddress = new Address("מודיעין", "תכלת", 23),
                TraineeDateOfBirth = new DateTime(1997, 5, 17),
                TraineeLearingCar = TypeOfCar.SecurityVehicle,
                TraineeGearbox = TypeOfGearbox.Automatic,
                TraineeNameOfSchool = "מעוף",
                TraineeNameOfTeacher = "דני אסייג",
                TraineeNumOfDrivingLessons = 30,
                TraineeHasGlasses = false,
                IfTraineePassedAnInternalTest = true
                //TraineeImageSource
            };
            TraineeList.Add(mytrainee5);
            Trainee mytrainee1 = new Trainee
            {
                TraineeId = "222222223",
                TraineeFirstName = "דביר",
                TraineeLastName = "יוחאי",
                TraineeGender = Gender.Male,
                TraineePhoneNumber = "0504832716",
                TraineeEmailAddress = "DvirY@walla.co.il",
                TraineeAddress = new Address("תל אביב", "רבין", 123),
                TraineeDateOfBirth = new DateTime(1999, 10, 23),
                TraineeLearingCar = TypeOfCar.TwoWheeledVehicles,
                TraineeGearbox = TypeOfGearbox.Manual,
                TraineeNameOfSchool = "על גלגלים",
                TraineeNameOfTeacher ="עוז שמעוני",
                TraineeNumOfDrivingLessons = 23,
                TraineeHasGlasses = false,
                IfTraineePassedAnInternalTest = false
                //TraineeImageSource
            };
            TraineeList.Add(mytrainee1);
            Trainee mytrainee2 = new Trainee
            {
                TraineeId = "333333334",
                TraineeFirstName = "sosh",
                TraineeLastName = "levi",
                TraineeGender = Gender.Female,
                TraineePhoneNumber = "0504832116",
                TraineeEmailAddress = "Y@walla.co.il",
                TraineeAddress = new Address("רמות", "תכלת", 23),
                TraineeDateOfBirth = new DateTime(1980, 10, 23),
                TraineeLearingCar = TypeOfCar.HeavyTruck,
                TraineeGearbox = TypeOfGearbox.Manual,
                TraineeNameOfSchool = "שרייבר",
                TraineeNameOfTeacher = "טוהר שלם",
                TraineeNumOfDrivingLessons = 27,
                TraineeHasGlasses = true,
                IfTraineePassedAnInternalTest = true
                //TraineeImageSource
            };
            TraineeList.Add(mytrainee2);
            Criterion c = new Criterion();
            c.AddressingPedestrians = false;
            c.AeactionTime = false;
            c.ALeapInTheRise = false;
            c.Bypassing = false;
            Test mytest = new Test
            {
                TestNumber = Configuration.NumOfTEST++,
                TesterId = "222222222",
                TraineeId = "111111112",
                DateTimeOfTest = new DateTime(2018, 12, 25, 10, 0, 0),
                TestExitAddress = new Address("ירושלים", "תכלת", 23),
                TestCriterion = c,
                TestResult = PassOrFail.Fail,
                TestTypeOfCar = TypeOfCar.PrivateCar,
                TestTypeOfGearbox = TypeOfGearbox.Manual,
                TesterNote = "not good",
            };
            TestList.Add(mytest);
            Test mytest1 = new Test
            {
                TestNumber = Configuration.NumOfTEST++,
                TesterId = "444444444",
                TraineeId = "222222223",
                DateTimeOfTest = new DateTime(2018, 12, 12, 13, 0, 0),
                TestExitAddress = new Address("חיפה", "יהודה", 23),
                TestCriterion = new Criterion(),
                TestResult = PassOrFail.Pass,
                TestTypeOfCar = TypeOfCar.TwoWheeledVehicles,
                TestTypeOfGearbox = TypeOfGearbox.Manual,
                TesterNote = "נסע מהר מידי, לקח פניות במהירות גבוהה, יש לחזק שימוש באיתות",
            };
            TestList.Add(mytest1);
            Test mytest2 = new Test
            {
                TestNumber = Configuration.NumOfTEST++,
                TesterId = "333333333",
                TraineeId = "333333334",
                DateTimeOfTest = new DateTime(2018, 12, 19, 13, 0, 0),
                TestExitAddress = new Address("תל אביב", "תכלת", 23),
                TestCriterion = new Criterion(),
                TestResult = PassOrFail.Fail,
                TestTypeOfCar = TypeOfCar.HeavyTruck,
                TestTypeOfGearbox = TypeOfGearbox.Manual,
                TesterNote = "נסע מהר מידי, לקח פניות במהירות גבוהה, יש לחזק שימוש באיתות",
            };
            TestList.Add(mytest2);
            Test mytest3 = new Test
            {
                TestNumber = Configuration.NumOfTEST++,
                TesterId = "111111111",
                TraineeId = "111111112",
                DateTimeOfTest = new DateTime(2018, 12, 2, 10, 0, 0),
                TestExitAddress = new Address("מודיעין", "ורד", 23),
                TestCriterion = new Criterion(),
                TestResult = PassOrFail.Fail,
                TestTypeOfCar = TypeOfCar.PrivateCar,
                TestTypeOfGearbox = TypeOfGearbox.Manual,
                TesterNote = "not good",
            };
            TestList.Add(mytest3);
            TesterWrokSchedule[,] matrix = new TesterWrokSchedule[6, 5];
            TesterWrokSchedule[,] matrix1 = new TesterWrokSchedule[6, 5];
            TesterWrokSchedule[,] matrix2 = new TesterWrokSchedule[6, 5];
            for (int k = 0; k < 6; k++)
                for (int t = 0; t < 5; t++)
                {
                    matrix[k, t] = new TesterWrokSchedule();
                    matrix1[k, t] = new TesterWrokSchedule();
                    matrix2[k, t] = new TesterWrokSchedule();
                }
            for (int k = 0; k < 6; k++)
                for (int t = 0; t < 5; t++)
                {
                    matrix[k, t].DoesWork = true;
                }
            mytester4.MatrixTesterworkdays = matrix;
            mytester1.MatrixTesterworkdays = matrix;
            matrix[1, 0].Available.Add(mytest.DateTimeOfTest, mytest);
            matrix[1, 0].Available.Add(mytest3.DateTimeOfTest, mytest3);
            mytester.MatrixTesterworkdays = matrix;
            
            for (int k = 0; k < 5; k++)
                for (int t = 1; t < 4; t++)
                {
                    matrix1[k, t].DoesWork = true;
                }
            
            matrix1[4,3].Available.Add(mytest1.DateTimeOfTest, mytest1);
            mytester3.MatrixTesterworkdays = matrix1;
            
            for (int k = 0; k < 5; k++)
                for (int t = 1; t < 4; t++)
                {
                    matrix2[k, t].DoesWork = true;
                }
            matrix2[4, 3].Available.Add(mytest2.DateTimeOfTest, mytest2);
            mytester2.MatrixTesterworkdays = matrix2;
            #endregion
        }

    }

}
