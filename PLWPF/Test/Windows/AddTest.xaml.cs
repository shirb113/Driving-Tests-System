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
    /// Interaction logic for AddTest.xaml
    /// </summary>
    public partial class AddTest : Window
    {
        IBL bl;
        Test temp_test;
        public AddTest()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_test = new Test();
            this.CarcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfCar));
            this.GearcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfGearbox));
            TestNum.Text = Convert.ToString(Configuration.NumOfTEST++);
            DataContext = temp_test;
        }
     
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void OKbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TraineeId.Text.Length < 9)
                {
                    TraineeId.BorderBrush = Brushes.Red;
                    throw new Exception("id - Not enough digits");
                }

            }
            catch (Exception message)
            {
                MessageBox.Show(message.Message);
            }
        }
    }
}
