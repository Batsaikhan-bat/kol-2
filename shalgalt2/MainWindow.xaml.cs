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
using System.Windows.Forms;

namespace shalgalt2
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

        private void btn_01_Click(object sender, RoutedEventArgs e)
        {
            Dialog1 dialog = new Dialog1();
            if (dialog.ShowDialog() == true) ;
            {
                tb_01.Text = dialog.InputText;
            }
        }

        private void btn_02_Click(object sender, RoutedEventArgs e)
        {
            Dialog2 dialog = new Dialog2();
            dialog.ShowDialog();
            byte sredniaJasnosc = (byte)((dialog.RedSlider.Value + dialog.GreenSlider.Value + dialog.BlueSlider.Value) / 3);
            if (sredniaJasnosc < 255)
                tb_01.Foreground = new SolidColorBrush(Color.FromRgb((byte)dialog.RedSlider.Value,
                                                                (byte)dialog.GreenSlider.Value,
                                                                (byte)dialog.BlueSlider.Value));
            else
                tb_01.Foreground = new SolidColorBrush(Color.FromRgb(sredniaJasnosc, sredniaJasnosc, sredniaJasnosc));


        }

        private void btn_03_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FontDialog fd = new System.Windows.Forms.FontDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tb_01.FontFamily = new FontFamily(fd.Font.FontFamily.Name);
                tb_01.FontSize = fd.Font.Size;
            }
        }
    }
}
