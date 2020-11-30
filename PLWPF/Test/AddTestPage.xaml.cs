 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddTestPage.xaml
    /// </summary>
    public partial class AddTestPage : Page
    {
        IBL bl;
        Test temp_test;
        public AddTestPage()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_test = new Test();
            TestNum.Text = Convert.ToString(Configuration.NumOfTEST++);
            DataContext = temp_test;
        }
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
            if (TraineeId.Text.Length == 9)
            {
                IEnumerable<Trainee> mytrainee = bl.GetAllTrainee(t => t.TraineeId == TraineeId.Text);
                if (mytrainee.Count() == 0)
                {
                    MessageBox.Show("Trainee is not exists");
                }
                else
                {
                    foreach (Trainee item in mytrainee)
                    {
                        ComboBoxItem newItem = new ComboBoxItem();
                        newItem.Content = item.TraineeLearingCar;
                        CarcomboBox.Items.Add(newItem);
                      
                    }
                    CarcomboBox.IsEnabled = true;
                }

            }
            
        }

        private void OKbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TraineeId.Text.Length < 9)
                {
                    TraineeId.BorderBrush = Brushes.Red;
                    throw new Exception("Id - Not enough digits");
                }
                if (TraineeId.Text.Length > 9)
                {
                    TraineeId.BorderBrush = Brushes.Red;
                    throw new Exception("Id - To much digits");
                }
                temp_test.TestNumber = int.Parse(TestNum.Text);
                bl.AddTest(temp_test);
                temp_test = bl.SearchTest(temp_test.TestNumber);
                Tester temp = bl.SearchTester(temp_test.TesterId);
                TesterId.Text = temp_test.TesterId;
                TesterNameText.Text = temp.TesterFirstName + " " + temp.TesterLastName;
                throw new Exception("Test successfully added");
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                TestPage t = new TestPage();
                this.NavigationService.Navigate(t);
            }
        }
            
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TesterId.Text = "";
            TesterNameText.Text = "";
            try
            {
                if (TraineeId.Text.Length < 9)
                {
                    TraineeId.BorderBrush = Brushes.Red;
                    throw new Exception("id - Not enough digits");
                }
                if (TraineeId.Text.Length > 9)
                {
                    TraineeId.BorderBrush = Brushes.Red;
                    throw new Exception("Id - To much digits");
                }
                if (TraineeId.Text.Length > 9)
                {
                    TraineeId.BorderBrush = Brushes.Red;
                    throw new Exception("id - To much digits");
                }
                if (DateOfTest.SelectedDate <= DateTime.Now)
                {
                    DateOfTest.BorderBrush = Brushes.Red;
                    throw new Exception("The date isn't correct");
                }
                DateTime date = (DateTime)DateOfTest.SelectedDate;
                string x = (comboBoxHour.SelectedItem as ComboBoxItem).Content.ToString();
                date = new DateTime(date.Year, date.Month, date.Day, int.Parse(x), 0, 0);
                temp_test.DateTimeOfTest = date;
                temp_test.TestNumber = int.Parse(TestNum.Text);
                temp_test.TestExitAddress = new Address(CitytextBox.Text, StreettextBox.Text, int.Parse(HousetextBox.Text));
                Tester temp = bl.findMeAtester(TraineeId.Text, temp_test);
                if (temp == null)
                {
                    IEnumerable<Tester> alltesters = bl.GetAllTesters(t => t.isActive == true && t.TesterSpecialization == temp_test.TestTypeOfCar);
                    if (alltesters.Count() == 0)
                    {
                        throw new Exception("Tester was not found");
                    }
                    DateTime date1 = new DateTime();
                    Test lastTest = bl.FindLastTest(temp_test.TraineeId, temp_test.TestTypeOfCar);
                    foreach (Tester item in alltesters)
                        date1 = bl.AnotherDateForTheTest(item, temp_test, lastTest);
                    throw new Exception("Tester was not found try at " + date1.ToString());
                }
                TesterId.Text = temp.TesterId;
                TesterNameText.Text = temp.TesterFirstName + " " + temp.TesterLastName;
                temp_test.TesterId = temp.TesterId;
                temp_test.DateTimeOfTest = date;
                OKbutton.IsEnabled = true;
                TraineeId.IsEnabled = false;
                CarcomboBox.IsEnabled = false;
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
            }
        }

        private void CarcomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxGear.Items.Clear();
            string ezer = (CarcomboBox.SelectedItem as ComboBoxItem).Content.ToString();
            TypeOfCar car = TypeOfCar.PrivateCar;
            if (ezer == "PrivateCar")
                car = TypeOfCar.PrivateCar;
            if (ezer == "TwoWheeledVehicles")
                car = TypeOfCar.TwoWheeledVehicles;
            if (ezer == "MediumTruck")
                car = TypeOfCar.MediumTruck;
            if (ezer == "HeavyTruck")
                car = TypeOfCar.HeavyTruck;
            if (ezer == "CarService")
                car = TypeOfCar.CarService;
            if (ezer == "SecurityVehicle")
                car = TypeOfCar.SecurityVehicle;
            IEnumerable<Trainee> myTests = bl.GetAllTrainee(t => t.TraineeLearingCar == car && t.TraineeId== TraineeId.Text);
            if (myTests.Count() != 0)
            {
                Trainee temp = myTests.First();
                comboBoxGear.IsEnabled = true;
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = temp.TraineeGearbox;
                comboBoxGear.Items.Add(newItem);
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
