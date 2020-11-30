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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for LinkTesterPage.xaml
    /// </summary>
    public partial class LinkTesterPage : Page
    {
        IBL bl;
        public LinkTesterPage()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            IEnumerable<Tester> all = bl.GetAllTesters();
            this.comboBoxCity.ItemsSource = (from item in bl.GetAllTesters()
                                             select item.TesterAddress.City).Distinct();     
        }

        private void Allbutton_Click(object sender, RoutedEventArgs e)
        {
            myListFamilyStatus.Visibility = Visibility.Hidden;
            myListSpecialization.Visibility = Visibility.Hidden;
            myListIsActive.Visibility = Visibility.Hidden;
            myListAll.Visibility = Visibility.Visible;
            myListCity.Visibility = Visibility.Hidden;
            Allbutton.Background = new SolidColorBrush(Color.FromArgb(255, 25, 64, 166));
            FamilyStatusbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Specialization.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            IsActive.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            if (myListAll.Items.IsEmpty)
            {
                IEnumerable<Tester> myTesters = bl.GetAllTesters();
                myListAll.ItemsSource = myTesters;
            }
        }
        private void FamilyStatus_Click(object sender, RoutedEventArgs e)
        {
            myListAll.Visibility = Visibility.Hidden;
            myListSpecialization.Visibility = Visibility.Hidden;
            myListIsActive.Visibility = Visibility.Hidden;
            myListCity.Visibility = Visibility.Hidden;
            myListFamilyStatus.Visibility = Visibility.Visible;
            FamilyStatusbutton.Background = new SolidColorBrush(Color.FromArgb(255, 25, 64, 166));
            Allbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Specialization.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            IsActive.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));

            if (myListFamilyStatus.Items.IsEmpty)
            {
                var v = bl.GetTestersFamilyStatus();
                foreach (IGrouping<FamilyStatus, Tester> item in v)
                {
                    foreach (Tester item2 in item)
                    {
                        myListFamilyStatus.Items.Add(item2);
                    }
                    myListFamilyStatus.Items.Add(new object());
                }
            }
        }
        private void IsActive_Click(object sender, RoutedEventArgs e)
        {
            myListAll.Visibility = Visibility.Hidden;
            myListCity.Visibility = Visibility.Hidden;
            myListFamilyStatus.Visibility = Visibility.Hidden;
            myListSpecialization.Visibility = Visibility.Hidden;
            myListIsActive.Visibility = Visibility.Visible;
            IsActive.Background = new SolidColorBrush(Color.FromArgb(255, 25, 64, 166));
            FamilyStatusbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Allbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Specialization.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            if (myListIsActive.Items.IsEmpty)
            {
                var active = bl.GetTestersActive(true);
                foreach (IGrouping<bool, Tester> item in active)
                {
                    foreach (Tester item2 in item)
                    {
                        myListIsActive.Items.Add(item2);
                    }
                    myListIsActive.Items.Add(new object());
                }
            }
        }
        private void Specialization_Click(object sender, RoutedEventArgs e)
        {
            myListAll.Visibility = Visibility.Hidden;
            myListFamilyStatus.Visibility = Visibility.Hidden;
            myListIsActive.Visibility = Visibility.Hidden;
            myListCity.Visibility = Visibility.Hidden;
            myListSpecialization.Visibility = Visibility.Visible;
            Specialization.Background = new SolidColorBrush(Color.FromArgb(255, 25, 64, 166));

            Allbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            FamilyStatusbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            IsActive.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));

            if (myListSpecialization.Items.IsEmpty)
            {
                var Specialization = bl.GetTestersSpecialization();
                
                foreach (IGrouping<TypeOfCar, Tester> item in Specialization)
                {
                    foreach (Tester item2 in item)
                    {
                        myListSpecialization.Items.Add(item2);
                    }
                    myListSpecialization.Items.Add(new object());
                }
            }
        }

        private void comboBoxCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myListAll.Visibility = Visibility.Hidden;
            myListFamilyStatus.Visibility = Visibility.Hidden;
            myListIsActive.Visibility = Visibility.Hidden;
            myListCity.Visibility = Visibility.Visible;
            myListSpecialization.Visibility = Visibility.Hidden;
            Specialization.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            Allbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            FamilyStatusbutton.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            IsActive.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));

            string ezer = (comboBoxCity.SelectedValue as string);
            myListCity.Items.Clear();
            if (myListCity.Items.IsEmpty)
            {
                var city = bl.GetAllTesters(t => t.TesterAddress.City == ezer);

                foreach (Tester item in city)
                {
                    myListCity.Items.Add(item);
                }
            }
           
        }
    }
}
