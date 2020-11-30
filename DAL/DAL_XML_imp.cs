using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;

namespace DAL
{
    class DAL_XML_imp : IDAL
    {
        XElement TempRoot;
        string TempPath = @"TempXml.xml";
       

        XElement TesterRoot;
        string TesterPath = @"TesterXml.xml";


        XElement TraineeRoot;
        string TraineePath = @"TraineeXml.xml";


        XElement TestRoot;
        string TestPath = @"TestXml.xml";

        XElement DrivingInstructorsAndSchoolsRoot;
        string DrivingInstructorsAndSchoolsPath = @"DrivingInstructorsAndSchoolsXml.xml";

        public DAL_XML_imp()
        {
            if (!File.Exists(TempPath))
                CreateFileTemp();
            XElement help = XElement.Load(TempPath);
            Configuration.NumOfTEST = int.Parse(help.Element("NumOfTest").Value);
            if (!File.Exists(TesterPath))
                CreateFileTester();
            if (!File.Exists(TraineePath))
                CreateFileTrainee();
            if (!File.Exists(TestPath))
                CreateFileTest();
            if (!File.Exists(DrivingInstructorsAndSchoolsPath))
                CreateFileTeacher();
            LoadData();
        }

        private void CreateFileTeacher()
        {
            DrivingInstructorsAndSchoolsRoot = new XElement("DrivingInstructorsAndSchool");
            DrivingInstructorsAndSchoolsRoot.Save(DrivingInstructorsAndSchoolsPath);
            #region updateDrivingInstructorsAndSchoolsRoot
            XElement TeacherName = new XElement("TeacherName", "דני אסייג");
            XElement DrivingSchool = new XElement("DrivingSchool", "מעוף");
            XElement complete = new XElement("DrivingInstructorsAndSchools", TeacherName, DrivingSchool);
            DrivingInstructorsAndSchoolsRoot.Add(complete);
            TeacherName = new XElement("TeacherName", "עוז שמעוני");
            DrivingSchool = new XElement("DrivingSchool", "על גלגלים");
            complete = new XElement("DrivingInstructorsAndSchools", TeacherName, DrivingSchool);
            DrivingInstructorsAndSchoolsRoot.Add(complete);
            TeacherName = new XElement("TeacherName", "משה פלג");
            DrivingSchool = new XElement("DrivingSchool", "אור ירוק");
            complete = new XElement("DrivingInstructorsAndSchools", TeacherName, DrivingSchool);
            DrivingInstructorsAndSchoolsRoot.Add(complete);
            TeacherName = new XElement("TeacherName", "טוהר שלם");
            DrivingSchool = new XElement("DrivingSchool", "שרייבר");
            complete = new XElement("DrivingInstructorsAndSchools", TeacherName, DrivingSchool);
            DrivingInstructorsAndSchoolsRoot.Add(complete);
            TeacherName = new XElement("TeacherName", "רננה צוברי");
            DrivingSchool = new XElement("DrivingSchool", "איזי-דרייב");
            complete = new XElement("DrivingInstructorsAndSchools", TeacherName, DrivingSchool);
            DrivingInstructorsAndSchoolsRoot.Add(complete);
            TeacherName = new XElement("TeacherName", "שולמית קורן");
            DrivingSchool = new XElement("DrivingSchool", "על גלגלים");
            complete = new XElement("DrivingInstructorsAndSchools", TeacherName, DrivingSchool);
            DrivingInstructorsAndSchoolsRoot.Add(complete);
            TeacherName = new XElement("TeacherName", "אורי קורן");
            DrivingSchool = new XElement("DrivingSchool", "סמארטדרייב");
            complete = new XElement("DrivingInstructorsAndSchools", TeacherName, DrivingSchool);
            DrivingInstructorsAndSchoolsRoot.Add(complete);
            TeacherName = new XElement("TeacherName", "טל כהן");
            DrivingSchool = new XElement("DrivingSchool", "אופיר");
            complete = new XElement("DrivingInstructorsAndSchools", TeacherName, DrivingSchool);
            DrivingInstructorsAndSchoolsRoot.Add(complete);
            TeacherName = new XElement("TeacherName", "תהל מרדכי");
            DrivingSchool = new XElement("DrivingSchool", "דרייב2000");
            complete = new XElement("DrivingInstructorsAndSchools", TeacherName, DrivingSchool);
            DrivingInstructorsAndSchoolsRoot.Add(complete);
            TeacherName = new XElement("TeacherName", "רונן ישראל");
            DrivingSchool = new XElement("DrivingSchool", "עוז");
            complete = new XElement("DrivingInstructorsAndSchools", TeacherName, DrivingSchool);
            DrivingInstructorsAndSchoolsRoot.Add(complete);
            TeacherName = new XElement("TeacherName", "איתי בן שלום");
            DrivingSchool = new XElement("DrivingSchool", "על גלגלים");
            complete = new XElement("DrivingInstructorsAndSchools", TeacherName, DrivingSchool);
            DrivingInstructorsAndSchoolsRoot.Add(complete);
            TeacherName = new XElement("TeacherName", "תהילה לוי");
            DrivingSchool = new XElement("DrivingSchool", "אור ירוק");
            complete = new XElement("DrivingInstructorsAndSchools", TeacherName, DrivingSchool);
            DrivingInstructorsAndSchoolsRoot.Add(complete);
            DrivingInstructorsAndSchoolsRoot.Save(DrivingInstructorsAndSchoolsPath);
            #endregion
        }
        private void CreateFileTest()
        {
            TestRoot = new XElement("Tests");
            TestRoot.Save(TestPath);
         
        }
        private void CreateFileTester()
        {
            TesterRoot = new XElement("Testers");
            TesterRoot.Save(TesterPath);
        }
        private void CreateFileTrainee()
        {
            TraineeRoot = new XElement("Trainees");
            TraineeRoot.Save(TraineePath);
        }
        private void CreateFileTemp()
        {
            TempRoot = new XElement("Number");
            TempRoot.Save(TempPath);
            XElement NumOfTest = new XElement("NumOfTest", "10010101");
            TempRoot.Add(NumOfTest);
            TempRoot.Save(TempPath);
            XElement help = XElement.Load(TempPath);
            Configuration.NumOfTEST = int.Parse(help.Element("NumOfTest").Value);
        }
        private void LoadData()
        {
            try
            {
                TesterRoot = XElement.Load(TesterPath);
                TraineeRoot = XElement.Load(TraineePath);
                TestRoot = XElement.Load(TestPath);
                DrivingInstructorsAndSchoolsRoot = XElement.Load(DrivingInstructorsAndSchoolsPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        #region convert
        XElement convertTesterToXL(Tester tester)
        {
            if (tester == null)
                return null;
            XElement testerElement = new XElement("Tester");
            foreach (PropertyInfo item in typeof(Tester).GetProperties())
                testerElement.Add(new XElement(item.Name, item.GetValue(tester, null)));
            return testerElement;
        }


        Tester convertXLToTester(XElement exle)
        {
            if (exle == null)
                return null;
            Tester tester = new Tester();

            foreach (PropertyInfo item in typeof(Tester).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                if (item.Name == "TesterAddress")
                {
                    tester.TesterAddress = Address.Parse(exle.Element(item.Name).Value);
                }
                else
                {
                    object convertValue = typeConverter.ConvertFromString(exle.Element(item.Name).Value);
                    if (item.CanWrite)
                        item.SetValue(tester, convertValue);
                }
            }
            return tester;
        }
        XElement convertTraineeToXL(Trainee trainee)
        {
            if (trainee == null)
                return null;
            XElement traineeElement = new XElement("Trainee");
            foreach (PropertyInfo item in typeof(Trainee).GetProperties())
                traineeElement.Add(new XElement(item.Name, item.GetValue(trainee, null)));
            return traineeElement;
        }

        Trainee convertXLToTrainee(XElement exle)
        {
            if (exle == null)
                return null;
            Trainee trainee = new Trainee();
            foreach (PropertyInfo item in typeof(Tester).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                if (item.Name == "TraineeAddress")
                {
                    trainee.TraineeAddress = Address.Parse(exle.Element(item.Name).Value);
                }
                else
                {
                    object convertValue = typeConverter.ConvertFromString(exle.Element(item.Name).Value);
                    if (item.CanWrite)
                        item.SetValue(trainee, convertValue);
                }
            }
            return trainee;
        }
        XElement convertTestToXL(Test test)
        {
            if (test == null)
                return null;
            XElement testElement = new XElement("Test");
            foreach (PropertyInfo item in typeof(Test).GetProperties())
                testElement.Add(new XElement(item.Name, item.GetValue(test, null)));
            return testElement;
        }

        Test convertXLToTest(XElement exle)
        {
            if (exle == null)
                return null;
            Test test = new Test();
            foreach (PropertyInfo item in typeof(Test).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                if (item.Name != "criterion") {
                    if (item.Name == "TestExitAddress")
                    {
                        test.TestExitAddress = Address.Parse(exle.Element(item.Name).Value);
                    }
                    else
                    {
                        object convertValue = typeConverter.ConvertFromString(exle.Element(item.Name).Value);
                        if (item.CanWrite)
                            item.SetValue(test, convertValue);
                    } }
                } 
            return test;
        }
        XElement convertTeacherToXL(DrivingInstructorsAndSchools teacher)
        {
            if (teacher == null)
                return null;
            XElement teacherElement = new XElement("DrivingInstructorsAndSchools");
            foreach (PropertyInfo item in typeof(DrivingInstructorsAndSchools).GetProperties())
                teacherElement.Add(new XElement(item.Name, item.GetValue(teacher, null)));
            return teacherElement;
        }

        DrivingInstructorsAndSchools convertXLToTeacher(XElement exle)
        {
            if (exle == null)
                return null;
            DrivingInstructorsAndSchools teacher = new DrivingInstructorsAndSchools();
            foreach (PropertyInfo item in typeof(DrivingInstructorsAndSchools).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(exle.Element(item.Name).Value);
                item.SetValue(teacher, convertValue);
            }
            return teacher;
        }
        #endregion

        #region load
        private void LoadDataTest()
        {
            try
            {
                TestRoot = XElement.Load(TestPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        private void LoadDataTester()
        {
            try
            {
                TesterRoot = XElement.Load(TesterPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        private void LoadDataTrainee()
        {
            try
            {
                TraineeRoot = XElement.Load(TraineePath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        private void LoadDataTeachar()
        {
            try
            {
                DrivingInstructorsAndSchoolsRoot = XElement.Load(DrivingInstructorsAndSchoolsPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        #endregion

        #region Get
        public Trainee GetTrainee(string id, TypeOfCar car)
        {
            LoadDataTrainee();
            Trainee returnT = new Trainee();
            returnT = (from TElement in TraineeRoot.Elements()
                       where (TElement.Element("TraineeId").Value == id) && ((TypeOfCar)Enum.Parse(typeof(TypeOfCar), (TElement.Element("TraineeLearingCar").Value)) == car)
                       select new Trainee
                       {
                           TraineeId = TElement.Element("TraineeId").Value,
                           TraineeFirstName = TElement.Element("TraineeFirstName").Value,
                           TraineeLastName = TElement.Element("TraineeLastName").Value,
                           TraineeGender = (Gender)Enum.Parse(typeof(Gender),TElement.Element("TraineeGender").Value),
                           TraineePhoneNumber = TElement.Element("TraineePhoneNumber").Value,
                           TraineeEmailAddress = TElement.Element("TraineeEmailAddress").Value,
                           TraineeAddress = Address.Parse(TElement.Element("TraineeAddress").Value),
                           TraineeDateOfBirth =DateTime.Parse(TElement.Element("TraineeDateOfBirth").Value),
                           TraineeLearingCar = (TypeOfCar)Enum.Parse(typeof(TypeOfCar),TElement.Element("TraineeLearingCar").Value),
                           TraineeGearbox = (TypeOfGearbox)Enum.Parse(typeof(TypeOfGearbox),TElement.Element("TraineeGearbox").Value),
                           TraineeNameOfSchool = TElement.Element("TraineeNameOfSchool").Value,
                           TraineeNameOfTeacher = TElement.Element("TraineeNameOfTeacher").Value,
                           TraineeNumOfDrivingLessons = int.Parse(TElement.Element("TraineeNumOfDrivingLessons").Value),
                           TraineeHasGlasses = bool.Parse(TElement.Element("TraineeHasGlasses").Value),
                           IfTraineePassedAnInternalTest = bool.Parse(TElement.Element("IfTraineePassedAnInternalTest").Value)
                       }).FirstOrDefault();
            return returnT;
        }
        public Tester GetTester(string id)
        {
            LoadDataTester();
            Tester returnT = new Tester();
            returnT = (from TElement in TesterRoot.Elements()
                       where TElement.Element("TesterId").Value == id
                       select new Tester
                       {
                           isActive = bool.Parse(TElement.Element("isActive").Value),
                           TesterId = TElement.Element("TesterId").Value,
                           TesterLastName = TElement.Element("TesterLastName").Value,
                           TesterFirstName = TElement.Element("TesterFirstName").Value,
                           TesterDateOfBirth = DateTime.Parse(TElement.Element("TesterDateOfBirth").Value),
                           TesterFamilyStatus = (FamilyStatus)Enum.Parse(typeof(FamilyStatus), TElement.Element("TesterFamilyStatus").Value),
                           TesterGender = (Gender)Enum.Parse(typeof(Gender), TElement.Element("TesterGender").Value),
                           TesterHasGlasses = bool.Parse(TElement.Element("TesterHasGlasses").Value),
                           TesterPhoneNumber = TElement.Element("TesterPhoneNumber").Value,
                           TesterEmailAddress = TElement.Element("TesterEmailAddress").Value,
                           TesterAddress = Address.Parse(TElement.Element("TesterAddress").Value),
                           TesterYearsOfExperience = int.Parse(TElement.Element("TesterYearsOfExperience").Value),
                           TesterMaxNumOfTestsPerWeek = int.Parse(TElement.Element("TesterMaxNumOfTestsPerWeek").Value),
                           TesterSpecialization = (TypeOfCar)Enum.Parse(typeof(TypeOfCar), TElement.Element("TesterSpecialization").Value),
                           MaxiDistanceFromAddress = double.Parse(TElement.Element("MaxiDistanceFromAddress").Value),
                           Help_Matrix = TElement.Element("MatrixTesterworkdays").Value,
                       }).FirstOrDefault();
            return returnT;
        }
        public Test GetTest(int testNum)
        {
            LoadDataTest();
            Test returnT = new Test();
            returnT = (from TElement in TestRoot.Elements()
                       where int.Parse(TElement.Element("TestNumber").Value) == testNum
                       select new Test
                       {
                           TestNumber = int.Parse(TElement.Element("TestNumber").Value),
                           TestExitAddress = Address.Parse(TElement.Element("TestExitAddress").Value),
                           TestCriterion = Criterion.Parse(TElement.Element("TestCriterion").Value),
                           TesterId = TElement.Element("TesterId").Value,
                           TraineeId = TElement.Element("TraineeId").Value,
                           DateTimeOfTest = DateTime.Parse(TElement.Element("DateTimeOfTest").Value),
                           TestResult = (PassOrFail)Enum.Parse(typeof(PassOrFail), TElement.Element("TestResult").Value),
                           TestTypeOfCar = (TypeOfCar)Enum.Parse(typeof(TypeOfCar), TElement.Element("TestTypeOfCar").Value),
                           TestTypeOfGearbox = (TypeOfGearbox)Enum.Parse(typeof(TypeOfGearbox), TElement.Element("TestTypeOfGearbox").Value),
                           TesterNote = TElement.Element("TesterNote").Value,
                       }).FirstOrDefault();
            return returnT;
        }
        #endregion

        #region SearchTest
        public Test SearchTest(int number)
        {
            LoadDataTest();
            return GetTest(number);
        }
        #endregion

        #region SearchTester
        public Tester SearchTester(string id)
        {
            LoadDataTester();
            return GetTester(id);
        }
        #endregion

        #region SearchTrainee
        public Trainee SearchTrainee(string id, TypeOfCar mytype)
        {
            LoadDataTrainee();
            return GetTrainee(id, mytype);
        }
        #endregion

        #region AddTest
        public void AddTest(Test mytest)
        {
            LoadDataTest();
            Test test = GetTest(mytest.TestNumber);
            if (test != null)
                throw new Exception("The test already exists in the system");

            mytest.TestNumber = mytest.TestNumber;
            XElement help = XElement.Load(TempPath);
            help.Element("NumOfTest").Value = Configuration.NumOfTEST.ToString();
            help.Save(TempPath);

            XElement TestNumber = new XElement("TestNumber", mytest.TestNumber);
            XElement TesterId = new XElement("TesterId", mytest.TesterId);
            XElement TraineeId = new XElement("TraineeId", mytest.TraineeId);
            XElement DateTimeOfTest = new XElement("DateTimeOfTest", mytest.DateTimeOfTest);
            XElement TestExitAddress = new XElement("TestExitAddress", mytest.TestExitAddress);
            XElement testResult = new XElement("TestResult", mytest.TestResult);
            XElement TestTypeOfCar = new XElement("TestTypeOfCar", mytest.TestTypeOfCar);
            XElement TestTypeOfGearbox = new XElement("TestTypeOfGearbox", mytest.TestTypeOfGearbox);
            XElement TesterNote = new XElement("TesterNote", mytest.TesterNote);
            XElement criterion = new XElement("TestCriterion", mytest.TestCriterion);
            XElement complete = new XElement("Test", TestNumber, TesterId, TraineeId, DateTimeOfTest, TestExitAddress, testResult, TestTypeOfCar, TestTypeOfGearbox, TesterNote, criterion);
            TestRoot.Add(complete);
            TestRoot.Save(TestPath);
        }
        #endregion

        #region AddTester
        public void AddTester(Tester mytester)
        {
            LoadDataTester();
            Tester tester = GetTester(mytester.TesterId);
            if (tester != null)
                throw new Exception("The tester already exists in the system");
            Trainee trainee = GetTrainee(mytester.TesterId, mytester.TesterSpecialization);
            if(trainee != null)
                throw new Exception("The id already exists in the system");
            XElement isActive = new XElement("isActive", mytester.isActive);
            XElement TesterId = new XElement("TesterId", mytester.TesterId);
            XElement TesterLastName = new XElement("TesterLastName", mytester.TesterLastName);
            XElement TesterFirstName = new XElement("TesterFirstName", mytester.TesterFirstName);
            XElement TesterDateOfBirth = new XElement("TesterDateOfBirth", mytester.TesterDateOfBirth);
            XElement TesterFamilyStatus = new XElement("TesterFamilyStatus", mytester.TesterFamilyStatus);
            XElement TesterGender = new XElement("TesterGender", mytester.TesterGender);
            XElement TesterHasGlasses = new XElement("TesterHasGlasses", mytester.TesterHasGlasses);
            XElement TesterPhoneNumber = new XElement("TesterPhoneNumber", mytester.TesterPhoneNumber);
            XElement TesterEmailAddress = new XElement("TesterEmailAddress", mytester.TesterEmailAddress);
            XElement TesterAddress = new XElement("TesterAddress", mytester.TesterAddress);
            XElement TesterYearsOfExperience = new XElement("TesterYearsOfExperience", mytester.TesterYearsOfExperience);
            XElement TesterMaxNumOfTestsPerWeek = new XElement("TesterMaxNumOfTestsPerWeek", mytester.TesterMaxNumOfTestsPerWeek);
            XElement TesterSpecialization = new XElement("TesterSpecialization", mytester.TesterSpecialization);
            XElement MaxiDistanceFromAddress = new XElement("MaxiDistanceFromAddress", mytester.MaxiDistanceFromAddress);
            XElement MatrixTesterworkdays = new XElement("MatrixTesterworkdays", mytester.Help_Matrix);
            XElement complete = new XElement("Tester", isActive, TesterId, TesterLastName, TesterFirstName, TesterDateOfBirth, TesterFamilyStatus, TesterGender, TesterHasGlasses, TesterPhoneNumber, TesterEmailAddress, TesterAddress, TesterYearsOfExperience, TesterMaxNumOfTestsPerWeek, TesterSpecialization, MaxiDistanceFromAddress, MatrixTesterworkdays);
            TesterRoot.Add(complete);
            TesterRoot.Save(TesterPath);

        }
#endregion

        #region AddTrainee
        public void AddTrainee(Trainee mytrainee)
        {
            LoadDataTrainee();
            Trainee trainee = GetTrainee(mytrainee.TraineeId, mytrainee.TraineeLearingCar);
            if (trainee != null)
                throw new Exception("The trainee already exists in the system");
            Tester tester = GetTester(mytrainee.TraineeId);
            if (tester != null)
                throw new Exception("The id already exists in the system");
            XElement TraineeId = new XElement("TraineeId", mytrainee.TraineeId);
            XElement TraineeFirstName = new XElement("TraineeFirstName", mytrainee.TraineeFirstName);
            XElement TraineeLastName = new XElement("TraineeLastName", mytrainee.TraineeLastName);
            XElement TraineeGender = new XElement("TraineeGender", mytrainee.TraineeGender);
            XElement TraineePhoneNumber = new XElement("TraineePhoneNumber", mytrainee.TraineePhoneNumber);
            XElement TraineeEmailAddress = new XElement("TraineeEmailAddress", mytrainee.TraineeEmailAddress);
            XElement TraineeDateOfBirth = new XElement("TraineeDateOfBirth", mytrainee.TraineeDateOfBirth);
            XElement TraineeLearingCar = new XElement("TraineeLearingCar", mytrainee.TraineeLearingCar);
            XElement TraineeGearbox = new XElement("TraineeGearbox", mytrainee.TraineeGearbox);
            XElement TraineeNameOfSchool = new XElement("TraineeNameOfSchool", mytrainee.TraineeNameOfSchool);
            XElement TraineeNameOfTeacher = new XElement("TraineeNameOfTeacher", mytrainee.TraineeNameOfTeacher);
            XElement TraineeNumOfDrivingLessons = new XElement("TraineeNumOfDrivingLessons", mytrainee.TraineeNumOfDrivingLessons);
            XElement TraineeHasGlasses = new XElement("TraineeHasGlasses", mytrainee.TraineeHasGlasses);
            XElement IfTraineePassedAnInternalTest = new XElement("IfTraineePassedAnInternalTest", mytrainee.IfTraineePassedAnInternalTest);
            XElement TraineeAddress = new XElement("TraineeAddress", mytrainee.TraineeAddress);

            XElement complete = new XElement("Trainee", TraineeId, TraineeFirstName, TraineeLastName, TraineeGender, TraineePhoneNumber, TraineeEmailAddress, TraineeDateOfBirth, TraineeLearingCar, TraineeGearbox, TraineeNameOfSchool, TraineeNameOfTeacher, TraineeNumOfDrivingLessons, TraineeHasGlasses, IfTraineePassedAnInternalTest, TraineeAddress);
            TraineeRoot.Add(complete);
            TraineeRoot.Save(TraineePath);
        }
        #endregion

        #region DeleteTester
        public void DeleteTester(Tester mytester)
        {
            LoadDataTester();
            XElement toDelete = (from item in TesterRoot.Elements()
                                 where item.Element("TesterId").Value == mytester.TesterId
                                 select item).FirstOrDefault();
            if (toDelete == null)
                throw new Exception("The tester don't exists in the system");
            toDelete.Remove();
            TesterRoot.Save(TesterPath);
        }
        #endregion

        #region DeleteTrainee
        public void DeleteTrainee(Trainee mytrainee)
        {
            LoadDataTrainee();
            XElement toDelete = (from item in TraineeRoot.Elements()
                                 where item.Element("TraineeId").Value == mytrainee.TraineeId
                                 select item).FirstOrDefault();
            if (toDelete == null)
                throw new Exception("The trainee don't exists in the system");
            toDelete.Remove();
            TraineeRoot.Save(TraineePath);
        }
        #endregion

        #region DeleteTest
        public void DeletTest(Test mytest)
        {
            LoadDataTest();
            XElement toDelete = (from item in TestRoot.Elements()
                                 where int.Parse(item.Element("TestNumber").Value) == mytest.TestNumber
                                 select item).FirstOrDefault();
            if (toDelete == null)
                throw new Exception("The test don't exists in the system");
            if (mytest.DateTimeOfTest > DateTime.Now)
            {
                toDelete.Remove();
                // מחיקת הטסט במטריצת הבוחן
                Tester mytester = SearchTester(mytest.TesterId);
                int index1 = -1;
                int i = mytest.DateTimeOfTest.Hour - 9;
                int j = (int)mytest.DateTimeOfTest.DayOfWeek;
                index1 = mytester.MatrixTesterworkdays[i, j].Available.IndexOfKey(mytest.DateTimeOfTest);
                if (index1 != -1)
                {
                    mytester.MatrixTesterworkdays[i, j].Available.RemoveAt(index1);
                    UpdateTester(mytester);
                }
            }
            else
            {
                throw new Exception("Test date already passed - can not be deleted");
            }
            TestRoot.Save(TestPath);
        }
        #endregion

        #region UpdateTest
        public void UpdateTest(Test mytest)
        {
            LoadDataTest();
            XElement toUpdate = (from item in TestRoot.Elements()
                                 where int.Parse(item.Element("TestNumber").Value) == mytest.TestNumber
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Test with the same number was not found");
            toUpdate.Element("TestNumber").Value = mytest.TestNumber.ToString();
            toUpdate.Element("TesterId").Value = mytest.TesterId;
            toUpdate.Element("TraineeId").Value = mytest.TraineeId;
            toUpdate.Element("DateTimeOfTest").Value = mytest.DateTimeOfTest.ToString();
            toUpdate.Element("TestExitAddress").Value =  mytest.TestExitAddress.ToString();
            toUpdate.Element("TestResult").Value = mytest.TestResult.ToString();
            toUpdate.Element("TestTypeOfCar").Value =  mytest.TestTypeOfCar.ToString();
            toUpdate.Element("TestTypeOfGearbox").Value = mytest.TestTypeOfGearbox.ToString();
            toUpdate.Element("TesterNote").Value = mytest.TesterNote;
            toUpdate.Element("TestCriterion").Value = mytest.TestCriterion.ToString();
            TestRoot.Save(TestPath);
        }
        #endregion

        #region UpdateTester
        public void UpdateTester(Tester mytester)
        {
            LoadDataTester();
            XElement toUpdate = (from item in TesterRoot.Elements()
                                 where item.Element("TesterId").Value == mytester.TesterId
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Tester with the same id was not found...");
            toUpdate.Element("isActive").Value = mytester.isActive.ToString();
            toUpdate.Element("TesterLastName").Value = mytester.TesterLastName;
            toUpdate.Element("TesterFirstName").Value = mytester.TesterFirstName;
            toUpdate.Element("TesterDateOfBirth").Value = mytester.TesterDateOfBirth.ToString();
            toUpdate.Element("TesterFamilyStatus").Value = mytester.TesterFamilyStatus.ToString();
            toUpdate.Element("TesterGender").Value = mytester.TesterGender.ToString();
            toUpdate.Element("TesterHasGlasses").Value = mytester.TesterHasGlasses.ToString();
            toUpdate.Element("TesterPhoneNumber").Value = mytester.TesterPhoneNumber;
            toUpdate.Element("TesterEmailAddress").Value = mytester.TesterEmailAddress;
            toUpdate.Element("TesterAddress").Value = mytester.TesterAddress.ToString();
            toUpdate.Element("TesterYearsOfExperience").Value =  mytester.TesterYearsOfExperience.ToString();
            toUpdate.Element("TesterMaxNumOfTestsPerWeek").Value = mytester.TesterMaxNumOfTestsPerWeek.ToString();
            toUpdate.Element("TesterSpecialization").Value = mytester.TesterSpecialization.ToString();
            toUpdate.Element("MaxiDistanceFromAddress").Value = mytester.MaxiDistanceFromAddress.ToString();
            toUpdate.Element("MatrixTesterworkdays").Value = mytester.Help_Matrix;
            TesterRoot.Save(TesterPath);
        }
        #endregion

        #region UpdateTrainee
        public void UpdateTrainee(Trainee mytrainee)
        {
            LoadDataTrainee();
            XElement toUpdate = (from item in TraineeRoot.Elements()
                                 where item.Element("TraineeId").Value == mytrainee.TraineeId
                                 select item).FirstOrDefault();

            if (toUpdate == null)
                throw new Exception("Trainee with the same id was not found...");
            toUpdate.Element("TraineeId").Value = mytrainee.TraineeId;
            toUpdate.Element("TraineeFirstName").Value = mytrainee.TraineeFirstName;
            toUpdate.Element("TraineeLastName").Value = mytrainee.TraineeLastName;
            toUpdate.Element("TraineeGender").Value = mytrainee.TraineeGender.ToString();
            toUpdate.Element("TraineePhoneNumber").Value =  mytrainee.TraineePhoneNumber;
            toUpdate.Element("TraineeEmailAddress").Value =  mytrainee.TraineeEmailAddress;
            toUpdate.Element("TraineeDateOfBirth").Value =  mytrainee.TraineeDateOfBirth.ToString();
            toUpdate.Element("TraineeLearingCar").Value =  mytrainee.TraineeLearingCar.ToString();
            toUpdate.Element("TraineeGearbox").Value = mytrainee.TraineeGearbox.ToString();
            toUpdate.Element("TraineeNameOfSchool").Value = mytrainee.TraineeNameOfSchool;
            toUpdate.Element("TraineeNameOfTeacher").Value = mytrainee.TraineeNameOfTeacher;
            toUpdate.Element("TraineeNumOfDrivingLessons").Value = mytrainee.TraineeNumOfDrivingLessons.ToString();
            toUpdate.Element("TraineeHasGlasses").Value = mytrainee.TraineeHasGlasses.ToString();
            toUpdate.Element("IfTraineePassedAnInternalTest").Value = mytrainee.IfTraineePassedAnInternalTest.ToString();
            toUpdate.Element("TraineeAddress").Value = mytrainee.TraineeAddress.ToString();
            TraineeRoot.Save(TraineePath);
        }
        #endregion

        #region GetAllTeachers
        public IEnumerable<DrivingInstructorsAndSchools> GetAllTeachers(Func<DrivingInstructorsAndSchools, bool> predicat = null)
        {
            LoadDataTeachar();
            if (predicat == null)
            {
                return (from item in DrivingInstructorsAndSchoolsRoot.Elements()
                        select convertXLToTeacher(item)).ToList();
            }

            return (from item in DrivingInstructorsAndSchoolsRoot.Elements()
                    let s = convertXLToTeacher(item)
                    where predicat(s)
                    select s).ToList();
        }
        #endregion

        #region GetAllTest
        public IEnumerable<Test> GetAllTest(Func<Test, bool> predicat = null)
        {
            LoadDataTest();
            IEnumerable<Test> allTest = from TElement in TestRoot.Elements()
                                        select new Test()
                                        {
                                            TestNumber = int.Parse(TElement.Element("TestNumber").Value),
                                            TesterId = TElement.Element("TesterId").Value,
                                            TraineeId = TElement.Element("TraineeId").Value,
                                            DateTimeOfTest = DateTime.Parse(TElement.Element("DateTimeOfTest").Value),
                                            TestExitAddress = Address.Parse(TElement.Element("TestExitAddress").Value),
                                            TestCriterion = Criterion.Parse(TElement.Element("TestCriterion").Value),
                                            TestResult = (PassOrFail)Enum.Parse(typeof(PassOrFail), TElement.Element("TestResult").Value),
                                            TestTypeOfCar = (TypeOfCar)Enum.Parse(typeof(TypeOfCar), TElement.Element("TestTypeOfCar").Value),
                                            TestTypeOfGearbox = (TypeOfGearbox)Enum.Parse(typeof(TypeOfGearbox), TElement.Element("TestTypeOfGearbox").Value),
                                            TesterNote = TElement.Element("TesterNote").Value,
                                        };
            if (predicat == null)//no condition
                return allTest;
            else
                return allTest.Where(predicat);
        }
    
        #endregion

        #region GetAllTesters
        public IEnumerable<Tester> GetAllTesters(Func<Tester, bool> predicat = null)
        {
            LoadDataTester();
            IEnumerable<Tester> allTester = from TElement in TesterRoot.Elements()
                                            select new Tester()
                                            {
                                                isActive = bool.Parse(TElement.Element("isActive").Value),
                                                TesterId = TElement.Element("TesterId").Value,
                                                TesterLastName = TElement.Element("TesterLastName").Value,
                                                TesterFirstName = TElement.Element("TesterFirstName").Value,
                                                TesterDateOfBirth = DateTime.Parse(TElement.Element("TesterDateOfBirth").Value),
                                                TesterFamilyStatus = (FamilyStatus)Enum.Parse(typeof(FamilyStatus), TElement.Element("TesterFamilyStatus").Value),
                                                TesterGender = (Gender)Enum.Parse(typeof(Gender), TElement.Element("TesterGender").Value),
                                                TesterHasGlasses = bool.Parse(TElement.Element("TesterHasGlasses").Value),
                                                TesterPhoneNumber = TElement.Element("TesterPhoneNumber").Value,
                                                TesterEmailAddress = TElement.Element("TesterEmailAddress").Value,
                                                TesterAddress = Address.Parse(TElement.Element("TesterAddress").Value),
                                                TesterYearsOfExperience = int.Parse(TElement.Element("TesterYearsOfExperience").Value),
                                                TesterMaxNumOfTestsPerWeek = int.Parse(TElement.Element("TesterMaxNumOfTestsPerWeek").Value),
                                                TesterSpecialization = (TypeOfCar)Enum.Parse(typeof(TypeOfCar), TElement.Element("TesterSpecialization").Value),
                                                MaxiDistanceFromAddress = double.Parse(TElement.Element("MaxiDistanceFromAddress").Value),
                                                Help_Matrix = TElement.Element("MatrixTesterworkdays").Value,
                                            };
            if (predicat == null)//no condition
                return allTester;
            else
                return allTester.Where(predicat);
        }
        #endregion

        #region GetAllTrainee
        public IEnumerable<Trainee> GetAllTrainee(Func<Trainee, bool> predicat = null)
        {
            LoadDataTrainee();
            IEnumerable<Trainee> allTrainee = from TElement in TraineeRoot.Elements()
                                              select new Trainee()
                                              {

                                                  TraineeId = TElement.Element("TraineeId").Value,
                                                  TraineeFirstName = TElement.Element("TraineeFirstName").Value,
                                                  TraineeLastName = TElement.Element("TraineeLastName").Value,
                                                  TraineeGender = (Gender)Enum.Parse(typeof(Gender), TElement.Element("TraineeGender").Value),
                                                  TraineePhoneNumber = TElement.Element("TraineePhoneNumber").Value,
                                                  TraineeEmailAddress = TElement.Element("TraineeEmailAddress").Value,
                                                  TraineeAddress = Address.Parse(TElement.Element("TraineeAddress").Value),
                                                  TraineeDateOfBirth = DateTime.Parse(TElement.Element("TraineeDateOfBirth").Value),
                                                  TraineeLearingCar = (TypeOfCar)Enum.Parse(typeof(TypeOfCar), TElement.Element("TraineeLearingCar").Value),
                                                  TraineeGearbox = (TypeOfGearbox)Enum.Parse(typeof(TypeOfGearbox), TElement.Element("TraineeGearbox").Value),
                                                  TraineeNameOfSchool = TElement.Element("TraineeNameOfSchool").Value,
                                                  TraineeNameOfTeacher = TElement.Element("TraineeNameOfTeacher").Value,
                                                  TraineeNumOfDrivingLessons = int.Parse(TElement.Element("TraineeNumOfDrivingLessons").Value),
                                                  TraineeHasGlasses = bool.Parse(TElement.Element("TraineeHasGlasses").Value),
                                                  IfTraineePassedAnInternalTest = bool.Parse(TElement.Element("IfTraineePassedAnInternalTest").Value)

                                              };
            if (predicat == null)//no condition
                return allTrainee;
            else
                return allTrainee.Where(predicat); 
        }
        #endregion
    }
}
