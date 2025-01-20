using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

namespace Kolokwium_nr2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window

    {
        List<Class1> list = new List<Class1>();
        //List<string> list1 = new List<string>();


        public MainWindow()
        {
            InitializeComponent();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            tsonh tsonh = new tsonh();
           tsonh.Class1 = new Class1();
            if (tsonh.ShowDialog() == true)
            {

                list.Add(tsonh.Class1);
                main_list.ItemsSource = null;
                main_list.ItemsSource = list;
            }


        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            tsonh tsonh = new tsonh();
            tsonh.Class1 = main_list.SelectedItem as Class1;
            tsonh.Update();
            if (main_list.SelectedItems != null)
            {
                if (tsonh.ShowDialog() == true)
                {

                    main_list.ItemsSource = null;
                    main_list.ItemsSource = list;
                }
            }
        }


        private void delete_Click(object sender, RoutedEventArgs e)
        {
            tsonh tsonh = new tsonh();
            tsonh.Class1 = new Class1();
            MessageBoxResult result = MessageBox.Show("Are u sure ", "confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            {
                if (main_list.SelectedItems != null)
                {
                    if (result == MessageBoxResult.Yes)
                    {
                        Class1 seletctedClass1 = main_list.SelectedItem as Class1;
                        {
                            if (seletctedClass1 != null)
                            {
                                list.Remove(seletctedClass1);
                                main_list.ItemsSource = null;
                                main_list.ItemsSource = list;
                            }
                            else MessageBox.Show("Pleace select item", "Warnig", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                }

            }

        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            tsonh tsonh = new tsonh();
            //tsonh.Class1 = new Class1();
            ofd.Filter = "(text files (*.text) |*.text|all files (*.*)|*.*)";
            ofd.Title = "Open file";
            if (ofd.ShowDialog() == true)
            {

                String s = File.ReadAllText(ofd.FileName);
                main_list.ItemsSource = new List<string> { s };
                Stack_File.Visibility = Visibility.Collapsed;
                // string[] parts= s.Split(';');
                //Class1 class1 = new Class1()
                //{
                //    ID = parts[0],
                //    Name = parts[1],
                //    Author = parts[2],
                //    Description = parts[3],


                //};
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save to file";
            sfd.Filter = "text files (*.text) |*.text|all files (*.*)|*.*)";
            if (sfd.ShowDialog() == true)
            {
                string filepath = sfd.FileName;
               
                    // var listSave = main_list.ItemsSource.Cast<string>().ToList();
                    string content = string.Join(Environment.NewLine, list);
                    File.WriteAllText(filepath, content);
                    MessageBox.Show("Succefully saved");
                    Stack_File.Visibility = Visibility.Collapsed;
                
            }


        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog cd = new System.Windows.Forms.ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                byte R = cd.Color.R;
                byte G = cd.Color.G;
                byte B = cd.Color.B;
                main_list.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(R, G, B));
                Stack_view.Visibility = Visibility.Collapsed;

            }
        }

        private void Fond_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FontDialog fd = new System.Windows.Forms.FontDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                main_list.FontSize = fd.Font.Size;
                main_list.FontFamily = new System.Windows.Media.FontFamily(fd.Font.Name);
                main_list.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                main_list.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;

                Stack_view.Visibility = Visibility.Collapsed;
            }
        }

        private void Fore_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog cd = new System.Windows.Forms.ColorDialog();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                byte R = cd.Color.R;
                byte G = cd.Color.G;
                byte B = cd.Color.B;
                main_list.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(R, G, B));
                Stack_view.Visibility = Visibility.Collapsed;

            }

        }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            if (Stack_File.Visibility == Visibility.Collapsed)
            {
                Stack_File.Visibility = Visibility.Visible;
            }
            else Stack_File.Visibility = Visibility.Collapsed;

        }

        private void View_Click(object sender, RoutedEventArgs e)
        {

            if (Stack_view.Visibility == Visibility.Collapsed)
            {
                Stack_view.Visibility = Visibility.Visible;
            }
            else Stack_view.Visibility = Visibility.Collapsed;

        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string src = Search.Text.ToLower();
            Class1 class1 = new Class1();
            if (class1.ID.ToLower().Contains(src) || class1.Name.ToLower().Contains(src))
            {
    

            }
        }
    }
}
    

