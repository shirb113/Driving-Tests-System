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
    /// Interaction logic for UpdateTrainee.xaml
    /// </summary>
    public partial class UpdateTrainee : Window
    {
        IBL bl;
        Trainee temp_trainee;
        public UpdateTrainee()
        {
            bl = FactoryBL.GetBL();
            temp_trainee = new Trainee();
            InitializeComponent();
            this.GendercomboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.CarcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfCar));
            this.CarcomboBox.SelectedValue = TypeOfCar.PrivateCar;
            this.GearcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfGearbox));
            this.comboBox.ItemsSource = bl.GetAllTeachers();
            this.comboBox1.ItemsSource = bl.GetAllTeachers();
            this.comboBox1.DisplayMemberPath = "TeacherName";
            this.comboBox.DisplayMemberPath = "DrivingSchool";
            this.comboBox.SelectedValuePath = "TeacherName";
            this.comboBox.SelectedValuePath = "DrivingSchool";
            grid1.IsEnabled = false;
            
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
                temp_trainee = bl.SearchTrainee(IdtextBox.Text, (TypeOfCar)CarcomboBox.SelectionBoxItem);
                if (temp_trainee == null)
                    throw new Exception("The trainee does not exist in the database");

                grid1.DataContext = temp_trainee;
                numOfLesson.Value = temp_trainee.TraineeNumOfDrivingLessons;
                grid1.IsEnabled = true;
                IdtextBox.IsEnabled = false;
                CarcomboBox.IsEnabled = false;
                OKbutton.IsEnabled = true;
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                IdtextBox.Text = "";
                IdtextBox.BorderBrush = Brushes.Black;
            }
        }
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
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
                temp_trainee.TraineeNumOfDrivingLessons = (int)numOfLesson.Value;
                bl.UpdateTrainee(temp_trainee);
                temp_trainee = new BE.Trainee();
                grid1.DataContext = temp_trainee;
                grid1.IsEnabled = false;
                IdtextBox.IsEnabled = true;
                IdtextBox.Text = "";
                CarcomboBox.IsEnabled = true;
                OKbutton.IsEnabled = false;
                throw new Exception("Your details have been updated on the system");
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                IdtextBox.BorderBrush = Brushes.Black;
                PhoneNumbertextBox.BorderBrush = Brushes.Black;
                EmailtextBox.BorderBrush = Brushes.Black;
            }

        }
    }
}

