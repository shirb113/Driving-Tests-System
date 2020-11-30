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
    /// Interaction logic for CriterionTest.xaml
    /// </summary>
    public partial class CriterionTest : Window
    {
        Criterion temp = new Criterion();
        public CriterionTest(Criterion temp_test2)
        {
            InitializeComponent();
            temp = temp_test2;
            checkBox.IsChecked = temp.Signals;
            checkBox1.IsChecked = temp.LookingAtMirrors;
            checkBox2.IsChecked = temp.Parking;
            checkBox3.IsChecked = temp.ParkingInReverse;
            checkBox4.IsChecked = temp.KeepDistance;
            checkBox5.IsChecked = temp.Speed;
            checkBox6.IsChecked = temp.Bypassing;
            checkBox7.IsChecked = temp.DriveInTheRightLane;
            checkBox8.IsChecked = temp.PreemptiveRight;
            checkBox9.IsChecked = temp.Stopping;
            checkBox10.IsChecked = temp.ObedienceToTrafficSigns;
            checkBox11.IsChecked = temp.AddressingPedestrians;
            checkBox12.IsChecked = temp.ALeapInTheRise;
            checkBox13.IsChecked = temp.ChangeGears;
            checkBox14.IsChecked = temp.EngineShutdown;
            checkBox15.IsChecked = temp.IntegrationIntoMovement;
            checkBox16.IsChecked = temp.SkillForVehicleOperation;
            checkBox17.IsChecked = temp.AeactionTime;
        }

        private void OKbutton_Click(object sender, RoutedEventArgs e)
        {
            temp.Signals = checkBox.IsChecked.Value;
            temp.LookingAtMirrors = checkBox1.IsChecked.Value;
            temp.Parking = checkBox2.IsChecked.Value;
            temp.ParkingInReverse = checkBox3.IsChecked.Value;
            temp.KeepDistance = checkBox4.IsChecked.Value;
            temp.Speed = checkBox5.IsChecked.Value;
            temp.Bypassing = checkBox6.IsChecked.Value;
            temp.DriveInTheRightLane = checkBox7.IsChecked.Value;
            temp.PreemptiveRight = checkBox8.IsChecked.Value;
            temp.Stopping = checkBox9.IsChecked.Value;
            temp.ObedienceToTrafficSigns = checkBox10.IsChecked.Value;
            temp.AddressingPedestrians = checkBox11.IsChecked.Value;
            temp.ALeapInTheRise = checkBox12.IsChecked.Value;
            temp.ChangeGears = checkBox13.IsChecked.Value;
            temp.EngineShutdown = checkBox14.IsChecked.Value;
            temp.IntegrationIntoMovement = checkBox15.IsChecked.Value;
            temp.SkillForVehicleOperation = checkBox16.IsChecked.Value;
            temp.AeactionTime = checkBox17.IsChecked.Value;

            UpdateTestPage criterions = new UpdateTestPage(" ");
            this.Close();

        }
    }
}
