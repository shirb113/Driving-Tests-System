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
using System.Windows.Shapes;
using BE;
using BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for DeletTrainee.xaml
    /// </summary>
    public partial class DeleteTrainee : Window
    {
        IBL bl;
        Trainee temp_trainee;
        public DeleteTrainee()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_trainee = new Trainee();
            this.comboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfCar));
            comboBox.SelectedValue = TypeOfCar.PrivateCar;
        }

        private void searchIcon_Click(object sender, RoutedEventArgs e)
        {
             try
            {
                if (IdtextBox.Text.Length < 9)
                {
                    IdtextBox.BorderBrush = Brushes.Red;
                    label1.Content = "";
                    button.IsEnabled = false;
                    throw new Exception("Id - Not enough digits");
                }
                object temp = comboBox.SelectedItem;
                if (temp == null)
                {
                    label1.Content = "";
                    button.IsEnabled = false;
                    throw new Exception("The trainee does not lerning on this type of car");
                }
               
                temp_trainee = bl.SearchTrainee(IdtextBox.Text, (TypeOfCar)comboBox.SelectionBoxItem );
                if (temp_trainee == null)
                {
                    label1.Content = "";
                    button.IsEnabled = false;
                    throw new Exception("The trainee does not exist in the database");
                }
                
                button.IsEnabled = true;
                label1.Content = temp_trainee.ToString();
            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                IdtextBox.Text = "";
                IdtextBox.BorderBrush = Brushes.Black;
                comboBox.SelectedValue = TypeOfCar.PrivateCar;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.DeleteTrainee(temp_trainee);
                MessageBox.Show("You have been deleted");
                this.Close();


            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
                
            }
        }
    }
}
