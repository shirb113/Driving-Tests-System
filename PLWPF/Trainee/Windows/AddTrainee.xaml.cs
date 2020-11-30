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
    /// Interaction logic for AddTrainee.xaml
    /// </summary>
    public partial class AddTrainee : Window
    {
        IBL bl;
        Trainee temp_trainee;
        public AddTrainee()
        {
            
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_trainee = new Trainee();
            InitializeComponent();
            this.GendercomboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.CarcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfCar));
            this.GearcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfGearbox));
            this.comboBox.ItemsSource = bl.GetAllTeachers();
            this.comboBox1.ItemsSource = bl.GetAllTeachers();
            this.comboBox1.DisplayMemberPath = "TeacherName";
            this.comboBox.DisplayMemberPath = "DrivingSchool";
            this.comboBox.SelectedValuePath = "TeacherName";
            this.comboBox.SelectedValuePath = "DrivingSchool";
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
                if (comboBox.SelectedItem==null)
                {
                    throw new Exception("Please choose driving school");
                }
                if (comboBox1.SelectedItem == null)
                {
                    throw new Exception("Please choose teacher name");
                }
                temp_trainee.TraineeNumOfDrivingLessons = (int)LessonstextBox.Value;
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
            }
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
