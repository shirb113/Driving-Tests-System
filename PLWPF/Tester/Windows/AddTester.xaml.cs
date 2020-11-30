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
    /// Interaction logic for AddTester.xaml
    /// </summary>
    public partial class AddTester : Window
    {
        IBL bl;
        Tester temp_tester;
        public AddTester()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_tester = new Tester();
            this.GendercomboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.FamiltSatus.ItemsSource = Enum.GetValues(typeof(BE.FamilyStatus));
            this.CarcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfCar));
            DataContext = temp_tester;

        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Window Addschedule = new TesterScheduleWendow();
            //Addschedule.DataContext = temp_tester.MatrixTesterworkdays;
            //Addschedule.ShowDialog();
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
                    throw new Exception("The email is not currect");
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
                temp_tester.TesterYearsOfExperience = (int)this.YearstextBox.Value;
                temp_tester.TesterMaxNumOfTestsPerWeek = (int)this.AmoutOfTestPerWeek.Value;
                bl.AddTester(temp_tester);
                this.YearstextBox.Value = 0;
                this.AmoutOfTestPerWeek.Value = 0;
                temp_tester = new BE.Tester();
                this.DataContext = temp_tester;
                throw new Exception("Tester successfully added");

            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                IdtextBox.BorderBrush = Brushes.Black;
                PhoneNumbertextBox.BorderBrush = Brushes.Black;
                EmailtextBox.BorderBrush = Brushes.Black;
                
            }
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
