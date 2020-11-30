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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Trainee.xaml
    /// </summary>
    public partial class TraineePage : Page
    {
        public TraineePage()
        {
            InitializeComponent();
        }
        private void updateTraineeButton_Click(object sender, RoutedEventArgs e)
        {
            //Window updateTrainee = new UpdateTrainee();
            //updateTrainee.Show();
            UpdateTraineePage t = new UpdateTraineePage();
            this.NavigationService.Navigate(t);
        }

        private void deleteTraineeButton_Click(object sender, RoutedEventArgs e)
        {
            //Window deleteTrainee = new DeleteTrainee();
            //deleteTrainee.Show();
            DeleteTraineePage t = new DeleteTraineePage();
            this.NavigationService.Navigate(t);
        }

        private void addTraineeButton_Click(object sender, RoutedEventArgs e)
        {
            //Window addTrainee = new AddTrainee();
            //addTrainee.Show();
            AddTraineePage t = new AddTraineePage();
            this.NavigationService.Navigate(t);
        }


    }
}
