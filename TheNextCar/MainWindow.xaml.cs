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
using System.Diagnostics;

using TheNextCar.Controller;

namespace TheNextCar
{
    public partial class MainWindow : Window, OnDoorChanged, OnPowerChanged, OnCarEngineStatusChanged
    {
        private Car nextCar;
        public MainWindow()
        {
            InitializeComponent();
            AccubatteryController accubatteryController = new AccubatteryController(this);
            DoorController doorController = new DoorController(this);
            nextCar = new Car(accubatteryController, doorController, this);
            Console.WriteLine("asdasdasd");
        }
        
        public void carEngineStatusChanged(string value, string message)
        {
            status.Content = message;
            StartButton.Content = value;
        }

        public void doorSecurityChanged(string vale, string message)
        {
            this.LockDoorState.Content = message;
            this.LockDoorButton.Content = vale;
        }
        public void doorStatusChanged(string vale, string message)
        {
            this.DoorOpenState.Content = message;
            this.DoorOpenButton.Content = vale;
        }

        public void onPowerChangedStatus(string value, string message)
        {
            this.AccuState.Content = message;
            this.AccuButton.Content = value;
        }

        private void OnAccuButtonClicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Accu Button");
            this.nextCar.toggleThePowerButton();
        }
        private void OnLockDoorButtonClicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Lock Button");
            this.nextCar.toggleTheLoockDoorButton();
        }
        private void OnDoorOpenButtonClicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Door Button");
            this.nextCar.toggleTheDoorButton();
        }
        private void OnStartButtonClicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Start Button");
            this.nextCar.toggleStartEngineButton();
        }


    }
}
