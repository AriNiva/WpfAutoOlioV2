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

namespace WpfAutoOlioV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Car toyota = new Car();
        Car ferrari = new Car();
        public MainWindow()
        {
            InitializeComponent();
            cbTransMission1.Items.Add("Manual");
            cbTransMission1.Items.Add("Automatic");
            cbTransMission1.Items.Add("Robotic");
            cbTransMission2.ItemsSource = cbTransMission1.Items;
        }

        private void btnAuto1_Click(object sender, RoutedEventArgs e)
        {
            //kun käyttäjä klikkaa tätä buttonia, asetetaan oliolle nämä arvot ominaisuuksiin
            toyota.Color = txtColorAuto1.Text;
            toyota.Model = txtModelAuto1.Text;
            toyota.CurrentSpeed = int.Parse(txtCurrentSpeed1.Text);
            try
            {
                 toyota.MaxSpeed = int.Parse(txtMaxSpeedAuto1.Text);   
            }
            catch (Exception)
            {

                MessageBox.Show("Anna huippunopeus väliltä 1-400 km/h");
                txtMaxSpeedAuto1.Focus();
            }
            toyota.Horsepower = int.Parse(txtHorsepower1.Text);
            toyota.TransMission = cbTransMission1.Text;
            try
            {
                toyota.GearCount = int.Parse(txtGearCount1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Vaihdelukumäärä pitää olla välillä 4-9!");
                txtGearCount1.Text = "";
                txtGearCount1.Focus();
            }
            
            ShowCarInfo(toyota);
        }
        
        public void ShowCarInfo (Car auto) //Tämä rutiini listaa parametrinä saadun olion arvot
        {
            string message = "Model: " + auto.Model + "\n" +
                "Color: " + auto.Color + "\n" +
                "Maxspeed: " + auto.MaxSpeed + "\n" +
                "Horsepower: " + auto.Horsepower + "\n" +
                "Gearcount: " + auto.GearCount + "\n" +
                "Engine running: " + auto.Running + "\n" +
                "Current speed; " + auto.CurrentSpeed;

                MessageBox.Show(message);

        }

        private void btnAuto2_Click(object sender, RoutedEventArgs e)
        {
            ferrari.Color = txtColorAuto2.Text;
            ferrari.Model = txtModelAuto2.Text;
            try
            {
                ferrari.MaxSpeed = int.Parse(txtMaxSpeedAuto2.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Anna huippunopeus väliltä 1-400 km/h");
                txtMaxSpeedAuto2.Focus();
            }
            ferrari.Horsepower = int.Parse(txtHorsepower2.Text);
            ferrari.TransMission = cbTransMission2.Text;
            try
            {
                ferrari.GearCount = int.Parse(txtGearCount2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Vaihdelukumäärä pitää olla välillä 4-9!");
                txtGearCount2.Text = "";
                txtGearCount2.Focus();
            }

            ShowCarInfo(ferrari);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
             toyota.StartEngine();
            if (toyota.Running == true)
            {
                btnIndicator.Background = Brushes.PaleGreen;
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            toyota.StopEngine();
            if (toyota.Running == false)
            {
                btnIndicator.Background = Brushes.Yellow;
            }
        }

        private void btnStart2_Click(object sender, RoutedEventArgs e)
        {
            ferrari.StartEngine();
            if (ferrari.Running == true)
            {
                btnIndicator2.Background = Brushes.PaleGreen;
            }
        }

        private void btnStop2_Click(object sender, RoutedEventArgs e)
        {
            ferrari.StopEngine();
            if (ferrari.Running == false)
            {
                btnIndicator2.Background = Brushes.Yellow;
            }
        }

        private void BtnAccelerate1_Click(object sender, RoutedEventArgs e)
        {
            if(toyota.CurrentSpeed < toyota.MaxSpeed) 
            {
                toyota.Accelerate();
            }
            txtCurrentSpeed1.Text = toyota.CurrentSpeed.ToString();
        }

        private void btnBrake1_Click(object sender, RoutedEventArgs e)
        {
            if (toyota.CurrentSpeed > 0)
            {
                toyota.Brake();
            }
            txtCurrentSpeed1.Text = toyota.CurrentSpeed.ToString();
        }

        private void btnAccelerate2_Click(object sender, RoutedEventArgs e)
        {
            if (ferrari.CurrentSpeed < ferrari.MaxSpeed)
            {
                ferrari.Accelerate();
            }
            txtCurrentSpeed2.Text = ferrari.CurrentSpeed.ToString();
        }

        private void btnBrake2_Click(object sender, RoutedEventArgs e)
        {
            if (ferrari.CurrentSpeed > 0)
            {
                ferrari.Brake();
            }
            txtCurrentSpeed2.Text = ferrari.CurrentSpeed.ToString();
        }
    }
}
