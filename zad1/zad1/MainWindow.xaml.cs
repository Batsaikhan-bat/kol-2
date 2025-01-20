using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                //Filter = "Text files (.txt)|.txt"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var filePath = openFileDialog.FileName;
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    var numbers = new List<int>();

                    foreach (var line in lines)
                    {
                        if (int.TryParse(line.Trim(), out int number))
                        {
                            numbers.Add(number);
                        }
                    }

                    if (numbers.Count > 0)
                    {
                        DisplayResults(numbers);
                        SaveResults(numbers);
                    }
                    else
                    {
                        MessageBox.Show("Plik nie zawiera żadnych prawidłowych liczb.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Wybrany plik nie istnieje.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DisplayResults(List<int> numbers)
        {
            NumberListBox.Items.Clear();
            foreach (var number in numbers)
            {
                NumberListBox.Items.Add(number);
            }

            int count = numbers.Count;
            int sum = numbers.Sum();
            double average = numbers.Average();

            CountLabel.Content = $"Ilość elementów: {count}";
            SumLabel.Content = $"Suma elementów: {sum}";
            AverageLabel.Content = $"Średnia elementów: {average:F2}";
        }

        private void SaveResults(List<int> numbers)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (.txt)|.txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine("Liczby:");
                    foreach (var number in numbers)
                    {
                        writer.WriteLine(number);
                    }
                    writer.WriteLine();
                    writer.WriteLine($"Ilość elementów: {numbers.Count}");
                    writer.WriteLine($"Suma elementów: {numbers.Sum()}");
                    writer.WriteLine($"Średnia elementów: {numbers.Average():F2}");
                }

                MessageBox.Show("Wyniki zostały zapisane pomyślnie.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}