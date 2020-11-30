using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpateTester.xaml
    /// </summary>
    public partial class UpdateTester : Window
    {
        IBL bl;
        Tester temp_tester;
        public UpdateTester()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_tester = new Tester();
            this.GendercomboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.FamiltSatus.ItemsSource = Enum.GetValues(typeof(BE.FamilyStatus));
            this.CarcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfCar));
            grid1.IsEnabled = false;
        
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Window Addschedule = new TesterScheduleWendow();
            //Addschedule.Show();
        }
       
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void searchIcon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IdtextBox.Text.Length < 9)
                {
                    IdtextBox.BorderBrush = Brushes.Red;
                    throw new Exception("Id - Not enough digits");
                }
                temp_tester = bl.SearchTester(IdtextBox.Text);
                if (temp_tester == null)
                    throw new Exception("The tester does not exist in the database");
                yearsOfExperience.Value = temp_tester.TesterYearsOfExperience;
                testPerWeek.Value = temp_tester.TesterMaxNumOfTestsPerWeek;
                MaxDis.Text = Convert.ToString(temp_tester.MaxiDistanceFromAddress);
                grid1.DataContext = temp_tester;
                grid1.IsEnabled = true;
                IdtextBox.IsEnabled = false;
                OKbutton.IsEnabled = true;
                button.IsEnabled = true;
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                IdtextBox.Text = "";
                IdtextBox.BorderBrush = Brushes.Black;
            }
        }

        private void OKbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IdtextBox.Text.Length < 9)
                {
                    IdtextBox.BorderBrush = Brushes.Red;
                    throw new Exception("id - Not enough digits");
                }
                if (PhoneNumbertextBox.Text.Length < 10)
                {
                    PhoneNumbertextBox.BorderBrush = Brushes.Red;
                    throw new Exception("Phone Number - Not enough digits");
                }
                if (EmailtextBox.Text.Length == 0)
                {
                    EmailtextBox.BorderBrush = Brushes.Red;
                    throw new Exception("Not enough digits");
                }
                if (EmailtextBox.Text.IndexOf('@') != EmailtextBox.Text.LastIndexOf('@') || EmailtextBox.Text.IndexOf('@') == -1)
                {
                    EmailtextBox.BorderBrush = Brushes.Red;
                    throw new Exception("The email is not currect - does not contain the value @");
                }
                if (EmailtextBox.Text.IndexOf(".") == -1)
                {
                    EmailtextBox.BorderBrush = Brushes.Red;
                    throw new Exception("The email is not currect");
                }
                temp_tester.TesterYearsOfExperience = (int)yearsOfExperience.Value;
                temp_tester.TesterMaxNumOfTestsPerWeek = (int)testPerWeek.Value;
                bl.UpdateTester(temp_tester);
                OKbutton.IsEnabled = false;
                button.IsEnabled = false;
                throw new Exception("Your details have been updated on the system");
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                IdtextBox.BorderBrush = Brushes.Black;
                PhoneNumbertextBox.BorderBrush = Brushes.Black;
                EmailtextBox.BorderBrush = Brushes.Black;
                yearsOfExperience.Value = 0;
                testPerWeek.Value = 0;
                temp_tester = new BE.Tester();
                grid1.DataContext = temp_tester;
                grid1.IsEnabled = false;
                IdtextBox.IsEnabled = true;
                IdtextBox.Text = "";
            }
        }
    }
}
