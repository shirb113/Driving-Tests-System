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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for LinxTraineePage.xaml
    /// </summary>
    public partial class LinkTraineePage : Page
    {
        IBL bl;

        public LinkTraineePage()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
        }
        private void Allbutton_Click(object sender, RoutedEventArgs e)
        {
            myListDrivingSchool.Visibility = Visibility.Hidden;
            myListTeacher.Visibility = Visibility.Hidden;
            myListNumOfTest.Visibility = Visibility.Hidden;
            myListAll.Visibility = Visibility.Visible;
            drivingSchool.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            NumOfTest.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Teacher.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Allbutton.Background = new SolidColorBrush(Color.FromArgb(255, 25, 64, 166));
            if (myListAll.Items.IsEmpty)
            {
                IEnumerable<Trainee> myTesters = bl.GetAllTrainee();
                myListAll.ItemsSource = myTesters;
            }
        }
      
        private void drivingSchool_Click(object sender, RoutedEventArgs e)
        {
            myListAll.Visibility = Visibility.Hidden;
            myListTeacher.Visibility = Visibility.Hidden;
            myListNumOfTest.Visibility = Visibility.Hidden;
            myListDrivingSchool.Visibility = Visibility.Visible;
            drivingSchool.Background = new SolidColorBrush(Color.FromArgb(255, 25, 64, 166));
            NumOfTest.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Teacher.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Allbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            if (myListDrivingSchool.Items.IsEmpty)
            {
                var v = bl.GetTraineeDrivingSchool();
                foreach (IGrouping<string, Trainee> item in v)
                {
                    foreach (Trainee item2 in item)
                    {
                        myListDrivingSchool.Items.Add(item2);
                    }
                    myListDrivingSchool.Items.Add(new object());
                }
            }
        }

        private void Teacher_Click(object sender, RoutedEventArgs e)
        {
            myListDrivingSchool.Visibility = Visibility.Hidden;
            myListTeacher.Visibility = Visibility.Visible;
            myListNumOfTest.Visibility = Visibility.Hidden;
            myListAll.Visibility = Visibility.Hidden;
            drivingSchool.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            NumOfTest.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Teacher.Background = new SolidColorBrush(Color.FromArgb(255, 25, 64, 166));
            Allbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            if (myListTeacher.Items.IsEmpty)
            {
                var v = bl.GetTraineeTeacher(true);
                foreach (IGrouping<string, Trainee> item in v)
                {
                    foreach (Trainee item2 in item)
                    {
                        myListTeacher.Items.Add(item2);
                    }
                    myListTeacher.Items.Add(new object());
                }
            }
        }
        private void NumOfTest_Click(object sender, RoutedEventArgs e)
        {
            myListAll.Visibility = Visibility.Hidden;
            myListDrivingSchool.Visibility = Visibility.Hidden;
            myListTeacher.Visibility = Visibility.Hidden;
            myListNumOfTest.Visibility = Visibility.Visible;
            drivingSchool.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            NumOfTest.Background = new SolidColorBrush(Color.FromArgb(255, 25, 64, 166));
            Teacher.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Allbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            if (myListNumOfTest.Items.IsEmpty)
            {
                var v = bl.GetTraineeNumOfTest();
                foreach (IGrouping<int, Trainee> item in v)
                {
                    foreach (Trainee item2 in item)
                    {
                        myListNumOfTest.Items.Add(item2);
                    }
                   myListNumOfTest.Items.Add(new object());
                }
            }
        }
    }
}
