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
    /// Interaction logic for TesterScheduleWendow.xaml
    /// </summary>
    public partial class TesterScheduleWendow : Window
    {
        IBL bl;
        Tester temp = new Tester();

        public TesterScheduleWendow(Tester temp_copy)
        {
            InitializeComponent();
            temp = temp_copy;

            checkBox1.IsChecked = temp.MatrixTesterworkdays[0, 0].DoesWork;
            checkBox7.IsChecked = temp.MatrixTesterworkdays[0, 1].DoesWork;
            checkBox13.IsChecked = temp.MatrixTesterworkdays[0, 2].DoesWork;
            checkBox19.IsChecked = temp.MatrixTesterworkdays[0, 3].DoesWork;
            checkBox25.IsChecked = temp.MatrixTesterworkdays[0, 4].DoesWork;
            checkBox2.IsChecked = temp.MatrixTesterworkdays[1, 0].DoesWork;
            checkBox8.IsChecked = temp.MatrixTesterworkdays[1, 1].DoesWork;
            checkBox14.IsChecked = temp.MatrixTesterworkdays[1, 2].DoesWork;
            checkBox20.IsChecked = temp.MatrixTesterworkdays[1, 3].DoesWork;
            checkBox26.IsChecked = temp.MatrixTesterworkdays[1, 4].DoesWork;
            checkBox3.IsChecked = temp.MatrixTesterworkdays[2, 0].DoesWork;
            checkBox9.IsChecked = temp.MatrixTesterworkdays[2, 1].DoesWork;
            checkBox15.IsChecked = temp.MatrixTesterworkdays[2, 2].DoesWork;
            checkBox21.IsChecked = temp.MatrixTesterworkdays[2, 3].DoesWork;
            checkBox27.IsChecked = temp.MatrixTesterworkdays[2, 4].DoesWork;
            checkBox4.IsChecked = temp.MatrixTesterworkdays[3, 0].DoesWork;
            checkBox10.IsChecked = temp.MatrixTesterworkdays[3, 1].DoesWork;
            checkBox16.IsChecked = temp.MatrixTesterworkdays[3, 2].DoesWork;
            checkBox22.IsChecked = temp.MatrixTesterworkdays[3, 3].DoesWork;
            checkBox28.IsChecked = temp.MatrixTesterworkdays[3, 4].DoesWork;
            checkBox5.IsChecked  = temp.MatrixTesterworkdays[4, 0].DoesWork;
            checkBox11.IsChecked = temp.MatrixTesterworkdays[4, 1].DoesWork;
            checkBox17.IsChecked = temp.MatrixTesterworkdays[4, 2].DoesWork;
            checkBox23.IsChecked = temp.MatrixTesterworkdays[4, 3].DoesWork;
            checkBox29.IsChecked = temp.MatrixTesterworkdays[4, 4].DoesWork;
            checkBox6.IsChecked = temp.MatrixTesterworkdays[5, 0].DoesWork;
            checkBox12.IsChecked = temp.MatrixTesterworkdays[5, 1].DoesWork;
            checkBox18.IsChecked = temp.MatrixTesterworkdays[5, 2].DoesWork;
            checkBox24.IsChecked = temp.MatrixTesterworkdays[5, 3].DoesWork;
            checkBox30.IsChecked = temp.MatrixTesterworkdays[5, 4].DoesWork;


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            temp.MatrixTesterworkdays[0, 0].DoesWork = checkBox1.IsChecked.Value;
            temp.MatrixTesterworkdays[0, 1].DoesWork = checkBox7.IsChecked.Value;
            temp.MatrixTesterworkdays[0, 2].DoesWork = checkBox13.IsChecked.Value;
            temp.MatrixTesterworkdays[0, 3].DoesWork = checkBox19.IsChecked.Value;
            temp.MatrixTesterworkdays[0, 4].DoesWork = checkBox25.IsChecked.Value;
            temp.MatrixTesterworkdays[1, 0].DoesWork = checkBox2.IsChecked.Value;
            temp.MatrixTesterworkdays[1, 1].DoesWork = checkBox8.IsChecked.Value;
            temp.MatrixTesterworkdays[1, 2].DoesWork = checkBox14.IsChecked.Value;
            temp.MatrixTesterworkdays[1, 3].DoesWork = checkBox20.IsChecked.Value;
            temp.MatrixTesterworkdays[1, 4].DoesWork = checkBox26.IsChecked.Value;
            temp.MatrixTesterworkdays[2, 0].DoesWork = checkBox3.IsChecked.Value;
            temp.MatrixTesterworkdays[2, 1].DoesWork = checkBox9.IsChecked.Value;
            temp.MatrixTesterworkdays[2, 2].DoesWork = checkBox15.IsChecked.Value;
            temp.MatrixTesterworkdays[2, 3].DoesWork = checkBox21.IsChecked.Value;
            temp.MatrixTesterworkdays[2, 4].DoesWork = checkBox27.IsChecked.Value;
            temp.MatrixTesterworkdays[3, 0].DoesWork = checkBox4.IsChecked.Value;
            temp.MatrixTesterworkdays[3, 1].DoesWork = checkBox10.IsChecked.Value;
            temp.MatrixTesterworkdays[3, 2].DoesWork = checkBox16.IsChecked.Value;
            temp.MatrixTesterworkdays[3, 3].DoesWork = checkBox22.IsChecked.Value;
            temp.MatrixTesterworkdays[3, 4].DoesWork = checkBox28.IsChecked.Value;
            temp.MatrixTesterworkdays[4, 0].DoesWork = checkBox5.IsChecked.Value;
            temp.MatrixTesterworkdays[4, 1].DoesWork = checkBox11.IsChecked.Value;
            temp.MatrixTesterworkdays[4, 2].DoesWork = checkBox17.IsChecked.Value;
            temp.MatrixTesterworkdays[4, 3].DoesWork = checkBox23.IsChecked.Value;
            temp.MatrixTesterworkdays[4, 4].DoesWork = checkBox29.IsChecked.Value;
            temp.MatrixTesterworkdays[5, 0].DoesWork = checkBox6.IsChecked.Value;
            temp.MatrixTesterworkdays[5, 1].DoesWork = checkBox12.IsChecked.Value;
            temp.MatrixTesterworkdays[5, 2].DoesWork = checkBox18.IsChecked.Value;
            temp.MatrixTesterworkdays[5, 3].DoesWork = checkBox24.IsChecked.Value;
            temp.MatrixTesterworkdays[5, 4].DoesWork = checkBox30.IsChecked.Value;

            AddTesterPage addMatrix = new AddTesterPage();
            addMatrix.temp_tester.MatrixTesterworkdays = (TesterWrokSchedule[,])temp.Clone();
            this.Close();
        }
    }
}
