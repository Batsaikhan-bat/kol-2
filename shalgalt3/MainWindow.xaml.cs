using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace shalgalt3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Car> Cars { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Cars = new ObservableCollection<Car>();
            DataContext = this;
            this.Closing += MainWindow_Closing;
            if (File.Exists("vehicles.txt"))
            {
                var lines = File.ReadAllLines("vehicles.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3) // Ensure the line has three parts
                    {
                        Cars.Add(new Car
                        {
                            Marka = parts[0],
                            Model = parts[1],
                            Year = parts[2]
                        });
                    }
                }
            }
        }
        private void bt_01_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialog_01();
            if (dialog.ShowDialog() == true)
            {
                Cars.Add(new Car
                {
                    Marka = dialog.Marka,
                    Model = dialog.Model,
                    Year = dialog.Year
                });
            }
        }
        private void bt_02_Click(object sender, RoutedEventArgs e)
        {
            if (CarList.SelectedItem is Car selectedCar)
            {
                var dialog = new Dialog_02
                {
                    Marka = selectedCar.Marka,
                    Model = selectedCar.Model,
                    Year = selectedCar.Year
                };

                if (dialog.ShowDialog() == true)
                {
                    selectedCar.Marka = dialog.Marka;
                    selectedCar.Model = dialog.Model;
                    selectedCar.Year = dialog.Year;
                }
            }
        }
        private void bt_03_Click(object sender, RoutedEventArgs e)
        {
            if (CarList.SelectedItem is Car selectedCar)
            {
                Cars.Remove(selectedCar);
            }
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var lines = Cars.Select(car => $"{car.Marka},{car.Model},{car.Year}");
            File.WriteAllLines("vehicles.txt", lines);
        }
        public class Car
        {
            public string Marka { get; set; }
            public string Model { get; set; }
            public string Year { get; set; }
        }
    }

}

