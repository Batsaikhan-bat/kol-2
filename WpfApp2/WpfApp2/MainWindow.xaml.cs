using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            tb_01.Clear();
        }

        private void op_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = "txt";
            try
            {
                if (ofd.ShowDialog() == true)
                {
                    FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    tb_01.Text = sr.ReadToEnd();
                }
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.ToString()); }

        }

        private void sv_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.DefaultExt = "txt";
            try
            {
                if (sfd.ShowDialog() == true)
                {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter sr = new StreamWriter(fs);
                    sr.WriteLine(tb_01.Text);
                    sr.Close();
                }
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.ToString()); }

        }

        private void cl_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bg_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                byte A = colorDialog.Color.A;
                byte R = colorDialog.Color.R;
                byte G = colorDialog.Color.G;
                byte B = colorDialog.Color.B;
                tb_01.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(A, R, G, B));
            }
        }

        private void ft_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FontDialog font = new System.Windows.Forms.FontDialog();
            font.ShowColor = true;
            if (font.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tb_01.FontFamily = new System.Windows.Media.FontFamily(font.Font.FontFamily.Name);
                tb_01.FontSize = font.Font.Size;
                System.Drawing.Color selectedColor = font.Color;

                tb_01.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(
                    selectedColor.A, selectedColor.R, selectedColor.G, selectedColor.B));


            }
        }
    }
}
