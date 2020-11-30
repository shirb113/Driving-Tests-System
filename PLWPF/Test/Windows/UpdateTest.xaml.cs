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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateTest.xaml
    /// </summary>
    public partial class UpdateTest : Window
    {
        public UpdateTest()
        {
            InitializeComponent();
            this.CarcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfCar));
            this.GearcomboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfGearbox));
        }
        private void Criterionbutton_Click(object sender, RoutedEventArgs e)
        {
           // Window criterion = new CriterionTest();
           // criterion.Show();
           
        }
      
    }
}
