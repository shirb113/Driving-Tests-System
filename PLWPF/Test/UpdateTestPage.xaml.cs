using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for UpDateTestPage.xaml
    /// </summary>
    public partial class UpdateTestPage : Page
    {
        IBL bl;
        Test temp_test;
        public UpdateTestPage(string id)
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_test = new Test();
            this.CarcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfCar));
            this.GearcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfGearbox));

            this.comboBox.ItemsSource = bl.GetAllTest(t => t.TesterId == id && t.DateTimeOfTest<DateTime.Now && t.TestResult == PassOrFail.Nun);
            this.comboBox.SelectedValuePath = "TestNumber";
            this.comboBox.DisplayMemberPath = "TestNumber";
            DataContext = temp_test;
        }
        private void Criterionbutton_Click(object sender, RoutedEventArgs e)
        {
            Window mycriterion = new CriterionTest(temp_test.TestCriterion);
            mycriterion.DataContext = temp_test.TestCriterion;
            mycriterion.ShowDialog();
            int result = bl.sumOfCriterion(temp_test);
            if (result > 3)
                temp_test.TestResult = PassOrFail.Fail;
            else
                temp_test.TestResult = PassOrFail.Pass;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.comboBox.SelectedItem is Test)
            {
                temp_test = ((Test)this.comboBox.SelectedItem);
                this.DataContext = temp_test;
                textboxHour.Text = temp_test.DateTimeOfTest.Hour.ToString();
                TesterNote.IsEnabled = true;
                Testernote.IsEnabled = true;
                Criterionbutton.IsEnabled = true;
                OKbutton.IsEnabled = true;
            }
        }

        private void OKbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TestResultText.Text == "Pass")
                    temp_test.TestResult = PassOrFail.Pass;
                if (TestResultText.Text == "Fail")
                    temp_test.TestResult = PassOrFail.Fail;
                if (TestResultText.Text == "Nun")
                    temp_test.TestResult = PassOrFail.Nun;
                bl.UpdateTest(temp_test);
                Tester mytester = bl.SearchTester(temp_test.TesterId);
                bl.UpdateTesteravailability(temp_test, mytester, temp_test.DateTimeOfTest, temp_test.DateTimeOfTest.Hour, false);
                throw new Exception("Test Has Been Successfully Updated");
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
            }
        }
    }
    }
