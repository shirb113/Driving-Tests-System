// shir bracya - 207447319
// Ayelet Pollack 206935330

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace TestConsoleApplication
{
    public class Program
    {
        static BL.IBL bl = BL.FactoryBL.GetBL();
        #region CheckPhone
        public static string CheckPhone(string phone)
        {
            while (phone.Length != 10)
            {
                Console.WriteLine("Error - Enter again Phone Number");
                phone = Console.ReadLine();
            }
            return phone;
        }
        #endregion

        #region CheckId
        public static string CheckId(string id)
        {
            while (id.Length != 9)
            {
                Console.WriteLine("Error - Enter again Id");
                id = Console.ReadLine();
            }
            return id;
        }
        #endregion

        #region CheckDate
        public static DateTime CheckDate(int y, int m, int d, int h = 0)
        {
            DateTime date = DateTime.Now;
            while (y > date.Year)
            {
                Console.WriteLine("Error - Enter again Year of Brith");
                y = int.Parse(Console.ReadLine());
            }
            while (m > 12 || m < 1)
            {
                Console.WriteLine("Error - Enter again Month of Brith");
                m = int.Parse(Console.ReadLine());
            }
            int dayinmonth = System.DateTime.DaysInMonth(y, m);
            while ((d < 1) || (d > dayinmonth))
            {
                Console.WriteLine("Error - Enter again Day of Brith");
                d = int.Parse(Console.ReadLine());
            }
            if (h == 0)
            {
                DateTime NewDate = new DateTime(y, m, d);
                return NewDate;
            }
            else
            {
                DateTime NewDate = new DateTime(y, m, d, h, 0, 0);
                return NewDate;
            }
        }
        #endregion

        #region setCriterion
        /// <summary>
        /// הפונקציה מאפשרת לערוך את מחלקת הקריטריונים ולשנות בהתאם ליכולות התלמיד
        /// </summary>
        /// <param name="c">קריטריונים</param>
        /// <returns></returns>
        public static void setCriterion(Criterion c)
        {
            int flag = 0;
            Console.WriteLine("Signals = 1, LookingAtMirrors = 2,  Parking = 3,  ParkingInReverse = 4,  KeepDistance = 5, Speed = 6, ");
            Console.WriteLine("Bypassing = 7, DriveInTheRightLane = 8, PreemptiveRight = 9, Stopping = 10, ObedienceToTrafficSigns = 11, AddressingPedestrians = 12,");
            Console.WriteLine(" ALeapInTheRise = 13, ChangeGears = 14, EngineShutdown = 15,IntegrationIntoMovement = 16, SkillForVehicleOperation = 17, AeactionTime = 18, ");
            Console.WriteLine("to exit enter 0");
            do
            {
                flag = int.Parse(Console.ReadLine());
                switch (flag)
                {
                    case 1:
                        Console.WriteLine("Enter True or False");
                        c.Signals = bool.Parse(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Enter True or False");
                        c.LookingAtMirrors = bool.Parse(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Enter True or False");
                        c.Parking = bool.Parse(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Enter True or False");
                        c.ParkingInReverse = bool.Parse(Console.ReadLine());
                        break;
                    case 5:
                        Console.WriteLine("Enter True or False");
                        c.KeepDistance = bool.Parse(Console.ReadLine());
                        break;
                    case 6:
                        Console.WriteLine("Enter True or False");
                        c.Speed = bool.Parse(Console.ReadLine());
                        break;
                    case 7:
                        Console.WriteLine("Enter True or False");
                        c.Bypassing = bool.Parse(Console.ReadLine());
                        break;
                    case 8:
                        Console.WriteLine("Enter True or False");
                        c.DriveInTheRightLane = bool.Parse(Console.ReadLine());
                        break;
                    case 9:
                        Console.WriteLine("Enter True or False");
                        c.PreemptiveRight = bool.Parse(Console.ReadLine());
                        break;
                    case 10:
                        Console.WriteLine("Enter True or False");
                        c.Stopping = bool.Parse(Console.ReadLine());
                        break;
                    case 11:
                        Console.WriteLine("Enter True or False");
                        c.ObedienceToTrafficSigns = bool.Parse(Console.ReadLine());
                        break;
                    case 12:
                        Console.WriteLine("Enter True or False");
                        c.AddressingPedestrians = bool.Parse(Console.ReadLine());
                        break;
                    case 13:
                        Console.WriteLine("Enter True or False");
                        c.ALeapInTheRise = bool.Parse(Console.ReadLine());
                        break;
                    case 14:
                        Console.WriteLine("Enter True or False");
                        c.ChangeGears = bool.Parse(Console.ReadLine());
                        break;
                    case 15:
                        Console.WriteLine("Enter True or False");
                        c.EngineShutdown = bool.Parse(Console.ReadLine());
                        break;
                    case 16:
                        Console.WriteLine("Enter True or False");
                        c.IntegrationIntoMovement = bool.Parse(Console.ReadLine());
                        break;
                    case 17:
                        Console.WriteLine("Enter True or False");
                        c.SkillForVehicleOperation = bool.Parse(Console.ReadLine());
                        break;
                    case 18:
                        Console.WriteLine("Enter True or False");
                        c.AeactionTime = bool.Parse(Console.ReadLine());
                        break;
                }
            } while (flag != 0);
        }
        #endregion

        #region AddTester
        public static void AddTester()
        {
            string id, firstName, LastName, Phone, Email, City, Street;
            int Experience, year, month, day, NumberHouse, family, gen, typeOfcar, TestsPerWeek;
            double Distance;
            DateTime Date; DateTime temp = DateTime.Now;
            Console.WriteLine("Enter: All Information");
            id = Console.ReadLine();
            id = CheckId(id);
            firstName = Console.ReadLine();
            LastName = Console.ReadLine();
            Phone = Console.ReadLine();
            Phone = CheckPhone(Phone);
            Email = Console.ReadLine();
            TestsPerWeek = int.Parse(Console.ReadLine());
            City = Console.ReadLine();
            Street = Console.ReadLine();
            NumberHouse = int.Parse(Console.ReadLine());
            Experience = int.Parse(Console.ReadLine());
            Distance = int.Parse(Console.ReadLine());
            year = int.Parse(Console.ReadLine());
            month = int.Parse(Console.ReadLine());
            day = int.Parse(Console.ReadLine());
            Date = CheckDate(year, month, day);
            int age = temp.Year - Date.Year;
            if (age < Configuration.MINTesterAge)
                throw new Exception("You're too young to be an tester");
            if (age > Configuration.MAXTesterAge)
                throw new Exception("You're too old to be an tester");
            do
            {
                Console.WriteLine("Single=0, Married=1, Divorcee=3, Widower=4");
                family = int.Parse(Console.ReadLine());
            } while ((family > 5) || (family < 0));
            do
            {
                Console.WriteLine("Male=0 Female=1");
                gen = int.Parse(Console.ReadLine());
            } while ((gen < 0) || (gen > 1));
            do
            {
                Console.WriteLine("Private Car = 0, Two Wheeled Vehicles = 1, Medium Truck = 2, Heavy Truck = 3, CarService = 4, SecurityVehicl = 5");
                typeOfcar = int.Parse(Console.ReadLine());
            } while ((typeOfcar < 0) || (typeOfcar > 5));
            TesterWrokSchedule[,] matrix = new TesterWrokSchedule[5, 6];
            for (int k = 0; k < 5; k++)
                for (int t = 0; t < 6; t++)
                {
                    matrix[k, t] = new TesterWrokSchedule();
                }
            Tester myTester = new Tester()
            {
                TesterId = id,
                TesterLastName = LastName,
                TesterFirstName = firstName,
                TesterDateOfBirth = Date,
                TesterFamilyStatus = (FamilyStatus)family,
                TesterGender = (Gender)gen,
                TesterHasGlasses = true,
                TesterPhoneNumber = Phone,
                TesterEmailAddress = Email,
                // TesterAddress = new Address(Street, NumberHouse, City),
                TesterYearsOfExperience = Experience,
                TesterMaxNumOfTestsPerWeek = TestsPerWeek,
                TesterSpecialization = (TypeOfCar)typeOfcar,
                MatrixTesterworkdays = matrix,
                MaxiDistanceFromAddress = Distance
            };
            bool flag;
            Console.WriteLine("ENTER TRUE if u want to enter a work day, else enter FALSE");
            flag = bool.Parse(Console.ReadLine());
            while (flag == true)
            {
                int Year, Month, Day, start, finish;
                bool yes;
                DateTime DateWork;
                Console.WriteLine("Enter Date, Time start, time finish, and true");
                Year = int.Parse(Console.ReadLine());
                Month = int.Parse(Console.ReadLine());
                Day = int.Parse(Console.ReadLine());
                DateWork = CheckDate(Year, Month, Day);
                start = int.Parse(Console.ReadLine());
                finish = int.Parse(Console.ReadLine());
                yes = bool.Parse(Console.ReadLine());
                bl.UpdateTesterworkdays(myTester, DateWork, start, finish, yes);
                Console.WriteLine("ENTER TRUE if u want to enter a work day, else enter FALSE");
                flag = bool.Parse(Console.ReadLine());
            }
            try
            {
                bl.AddTester(myTester);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        #endregion

        #region AddTrainee
        public static void AddTrainee()
        {
            string Id, FirstName, LastName, Phone, Email, City, Street, TeacherName, driveSchool;
            int DrivingLessons, year, month, day, NumberHouse;
            DateTime Date; DateTime temp = DateTime.Now;
            Console.WriteLine("Enter: All Information");
            Id = Console.ReadLine();
            Id = CheckId(Id);
            FirstName = Console.ReadLine();
            LastName = Console.ReadLine();
            Phone = Console.ReadLine();
            Phone = CheckPhone(Phone);
            Email = Console.ReadLine();
            City = Console.ReadLine();
            Street = Console.ReadLine();
            NumberHouse = int.Parse(Console.ReadLine());
            year = int.Parse(Console.ReadLine());
            month = int.Parse(Console.ReadLine());
            day = int.Parse(Console.ReadLine());
            Date = CheckDate(year, month, day);
            DrivingLessons = int.Parse(Console.ReadLine());
            TeacherName = Console.ReadLine();
            driveSchool = Console.ReadLine();
            int age = temp.Year - Date.Year;
            if (age < Configuration.MINTraineeAge)
                throw new Exception("You're too young to be a trainee");
            int gen, typeGearbox, typeOfcar;
            bool glasses, internalTest;
            do
            {
                Console.WriteLine("Male=0 Female=1");
                gen = int.Parse(Console.ReadLine());
            } while ((gen < 0) || (gen > 1));
            do
            {
                Console.WriteLine("Private Car = 0, Two Wheeled Vehicles = 1, Medium Truck = 2, Heavy Truck = 3, CarService = 4, SecurityVehicl = 5");
                typeOfcar = int.Parse(Console.ReadLine());
            } while ((typeOfcar < 0) || (typeOfcar > 5));
            do
            {
                Console.WriteLine("Manual = 0,  Automatic = 1");
                typeGearbox = int.Parse(Console.ReadLine());
            } while ((typeGearbox < 0) || (typeGearbox > 1));
            Console.WriteLine("If has glasses 1, else 0");
            glasses = bool.Parse(Console.ReadLine());
            Console.WriteLine("Enter 1 if passed the internal test, else 0");
            internalTest = bool.Parse(Console.ReadLine());
            Trainee myTrainee = new Trainee
            {
                TraineeId = Id,
                TraineeFirstName = FirstName,
                TraineeLastName = LastName,
                TraineeGender = (Gender)gen,
                TraineePhoneNumber = Phone,
                TraineeEmailAddress = Email,
                //TraineeAddress = new Address(Street, NumberHouse, City),
                TraineeDateOfBirth = Date,
                TraineeLearingCar = (TypeOfCar)typeOfcar,
                TraineeGearbox = (TypeOfGearbox)typeGearbox,
                TraineeNameOfSchool = driveSchool,
                TraineeNameOfTeacher = TeacherName,
                TraineeNumOfDrivingLessons = DrivingLessons,
                TraineeHasGlasses = glasses,
                IfTraineePassedAnInternalTest = internalTest
                //TraineeImageSource*/
            };
            try
            {
                bl.AddTrainee(myTrainee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        #region AddTest
        public static void AddTest()
        {
            string TesterId, TraineeId, City, Street, note;
            int result, year, month, day, hour, typeOfcar, gear, NumberHouse;
            DateTime Date; bool flag;
            Console.WriteLine("Enter: All Information");
            TesterId = Console.ReadLine();
            TesterId = CheckId(TesterId);
            TraineeId = Console.ReadLine();
            TraineeId = CheckId(TraineeId);
            City = Console.ReadLine();
            Street = Console.ReadLine();
            NumberHouse = int.Parse(Console.ReadLine());
            year = int.Parse(Console.ReadLine());
            month = int.Parse(Console.ReadLine());
            day = int.Parse(Console.ReadLine());
            hour = int.Parse(Console.ReadLine());
            Date = CheckDate(year, month, day, hour);
            note = Console.ReadLine();
            do
            {
                Console.WriteLine("Private Car = 0, Two Wheeled Vehicles = 1, Medium Truck = 2, Heavy Truck = 3, CarService = 4, SecurityVehicl = 5");
                typeOfcar = int.Parse(Console.ReadLine());
            } while ((typeOfcar < 0) || (typeOfcar > 5));
            do
            {
                Console.WriteLine("Manual=0, Automatic=1");
                gear = int.Parse(Console.ReadLine());
            } while ((gear < 0) || (gear > 1));
            Test mytest = new Test
            {
                TestNumber = Configuration.NumOfTEST++,
                TesterId = TesterId,
                TraineeId = TraineeId,
                DateTimeOfTest = Date,
                //TestExitAddress = new Address(Street, NumberHouse, City),
                TestCriterion = new Criterion(),
                TestResult = PassOrFail.Nun,
                TestTypeOfCar = (TypeOfCar)typeOfcar,
                TestTypeOfGearbox = (TypeOfGearbox)gear,
                TesterNote = note,
            };
            DateTime now = DateTime.Now;
            TimeSpan HasPass = mytest.DateTimeOfTest - now;
            // עבר תאריך הטסט
            if (HasPass.TotalDays < 0)
            {
                Console.WriteLine("If you whant to update test Criterion enter TRUE, else enter FALSE");
                flag = bool.Parse(Console.ReadLine());
                if (flag == true)
                {
                    setCriterion(mytest.TestCriterion);
                }

                result = bl.sumOfCriterion(mytest);
                if (result > 3)
                {
                    mytest.TestResult = PassOrFail.Fail;
                }
                else
                {
                    mytest.TestResult = PassOrFail.Pass;
                }
            }
            try
            {
                bl.AddTest(mytest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion



        public static void Main(string[] args)
        {
            //        IEnumerable<DrivingInstructorsAndSchools> tttt = bl.GetAllTeachers(t => t.DrivingSchool == "מעוף");

            //        string id; int choise; int typeOfcar;
            //        do
            //        {
            //            Console.WriteLine("out=0, new tester=1, new trainee=2, new test=3, delete teset=4, delete trainee=5, update tester=6, update trainee=7");
            //            choise = int.Parse(Console.ReadLine());
            //            switch (choise)
            //            {
            //                case 1:
            //                    Console.WriteLine("Enter a new tester");
            //                    AddTester();
            //                    break;
            //                case 2:
            //                    Console.WriteLine("Enter a new trainee");
            //                    AddTrainee();
            //                    break;
            //                case 3:
            //                    Console.WriteLine("Enter a new tast");
            //                    AddTest();
            //                    break;
            //                case 4:
            //                    Console.WriteLine("Delete a tester");
            //                    id = Console.ReadLine();
            //                    Tester t = bl.SearchTester(id);
            //                    if (t != null)
            //                    {
            //                        try { bl.DeleteTester(t); }
            //                        catch (Exception e) { Console.WriteLine(e.Message); }
            //                    }
            //                    break;
            //                case 5:
            //                    Console.WriteLine("Delete a trainee");
            //                    id = Console.ReadLine();
            //                    do
            //                    {
            //                        Console.WriteLine("Private Car = 0, Two Wheeled Vehicles = 1, Medium Truck = 2, Heavy Truck = 3, CarService = 4, SecurityVehicl = 5");
            //                        typeOfcar = int.Parse(Console.ReadLine());
            //                    } while ((typeOfcar < 0) || (typeOfcar > 5));
            //                    Trainee u = bl.SearchTrainee(id, (TypeOfCar)typeOfcar);
            //                    if (u != null)
            //                    {
            //                        try { bl.DeleteTrainee(u); }
            //                        catch (Exception e) { Console.WriteLine(e.Message); }
            //                    }
            //                    break;
            //                case 6:
            //                    Console.WriteLine("Update a tester");
            //                    id = Console.ReadLine();
            //                    Tester p = bl.SearchTester(id);
            //                    id = Console.ReadLine();
            //                    Tester p1 = bl.SearchTester(id);
            //                    try { bl.UpdateTester(p); }
            //                    catch (Exception e) { Console.WriteLine(e.Message); }
            //                    break;
            //                case 7:
            //                    Console.WriteLine("Update a trainee");
            //                    id = Console.ReadLine();
            //                    do
            //                    {
            //                        Console.WriteLine("Private Car = 0, Two Wheeled Vehicles = 1, Medium Truck = 2, Heavy Truck = 3, CarService = 4, SecurityVehicl = 5");
            //                        typeOfcar = int.Parse(Console.ReadLine());
            //                    } while ((typeOfcar < 0) || (typeOfcar > 5));
            //                    Trainee o = bl.SearchTrainee(id, (TypeOfCar)typeOfcar);
            //                    o.TraineeLearingCar = TypeOfCar.SecurityVehicle;
            //                    try { bl.UpdateTrainee(o); }
            //                    catch (Exception e) { Console.WriteLine(e.Message); }
            //                    break;
            //                default:
            //                    break;
            //            }

            //        } while (choise != 0);

            //        object t1 = bl.GetTestersSpecialization();
            //        IEnumerable<IGrouping<string, Trainee>> t2 = bl.GetTraineeDrivingSchool();
            //        IEnumerable<IGrouping<string, Trainee>> t3 = bl.GetTraineeTeacher();
            //        IEnumerable<IGrouping<int, Trainee>> t4 = bl.GetTraineeNumOfTest();

            //       // Address a = new Address("המלך דוד", 13, "ירושלים");
            //       // IEnumerable<Tester> v1 = bl.GetAllTestersFrom(a,3.7);
            //        DateTime d = new DateTime(2018, 12, 12, 13, 0, 0);
            //        IEnumerable<Tester> v2 = bl.IsTestersAvailable(d);
            //        Trainee mytrainee = bl.SearchTrainee("111111112",0);
            //        int v3 = bl.TraineeNumOfTests(mytrainee);
            //        bool v4 = bl.TraineeEntitledReceiveLicense(mytrainee);
            //        IEnumerable<Test> v5 = bl.GetAllTestAtDate(d);


            //    }
            //}
        }
    }
}

