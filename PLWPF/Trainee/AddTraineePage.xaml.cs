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
using BL;
using BE;
using System.Text.RegularExpressions;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddTraineePage.xaml
    /// </summary>
    public partial class AddTraineePage : Page
    {
        IBL bl;
        Trainee temp_trainee;
        public AddTraineePage()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_trainee = new Trainee();
            InitializeComponent();
            this.GendercomboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.CarcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfCar));
            this.GearcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfGearbox));
            this.comboBox.ItemsSource = (from item in bl.GetAllTeachers()
                                         select item.DrivingSchool).Distinct();
            
            DataContext = temp_trainee;
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
                if (IdtextBox.Text.Length > 9)
                {
                    IdtextBox.BorderBrush = Brushes.Red;
                    throw new Exception("id - To much digits");
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
                    throw new Exception("The email is not currect - does not contain the value .");
                }
                if (comboBox.SelectedItem == null)
                {
                    throw new Exception("Please choose driving school");
                }
                if (comboBox1.SelectedItem == null)
                {
                    throw new Exception("Please choose teacher name");
                }
                if (((int)LessonstextBox.Value < Configuration.MINNumberOfLessons)&&(InternalTestcheckBox.IsChecked == true))
                {
                    InternalTestcheckBox.IsChecked = false;
                    throw new Exception("Error - Not enough lessons to pass an internal test ");
                }
                temp_trainee.TraineeNumOfDrivingLessons = (int)LessonstextBox.Value;
                temp_trainee.IfTraineePassedAnInternalTest = InternalTestcheckBox.IsChecked.Value;
                bl.AddTrainee(temp_trainee);
                temp_trainee = new BE.Trainee();
                this.DataContext = temp_trainee;
                LessonstextBox.Value = 0;
                throw new Exception("Trainee successfully added");

            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                IdtextBox.BorderBrush = Brushes.Black;
                PhoneNumbertextBox.BorderBrush = Brushes.Black;
                EmailtextBox.BorderBrush = Brushes.Black;
                if(message.Message== "Trainee successfully added")
                {
                    TraineePage t = new TraineePage();
                    this.NavigationService.Navigate(t);
                }
            }
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        { 
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.comboBox1.IsEnabled = true;
            string ezer = (comboBox.SelectedValue as string);
            this.comboBox1.ItemsSource = bl.GetAllTeachers(t => t.DrivingSchool == ezer);
            this.comboBox1.DisplayMemberPath = "TeacherName";
            this.comboBox1.SelectedValuePath = "TeacherName";
        }
    }
}
