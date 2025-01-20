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
using System.Windows.Forms;

namespace shalgalt2
{
    /// <summary>
    /// Interaction logic for Dialog2.xaml
    /// </summary>
    public partial class Dialog2 : Window
    {

       private void btn_02_Click(object sender, RoutedEventArgs e)
        {
            zmien_kolor();
            this.DialogResult = true;
        }
        public Dialog2()
        {
            InitializeComponent();
        }
        private void zmien_kolor()
        {
            byte sredniaJasnosc = (byte)((RedSlider.Value + GreenSlider.Value + BlueSlider.Value) / 3);
            if (sredniaJasnosc < 100)
                tb_01.Foreground = new SolidColorBrush(Color.FromRgb((byte)RedSlider.Value,
                                                                 (byte)GreenSlider.Value,
                                                                 (byte)BlueSlider.Value));
            else
                tb_01.Foreground = new SolidColorBrush(Color.FromRgb(sredniaJasnosc, sredniaJasnosc, sredniaJasnosc));
        }
        private void RedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (RedSlider != null && GreenSlider != null && BlueSlider != null)
                zmien_kolor();
        }

        private void GreenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (RedSlider != null && GreenSlider != null && BlueSlider != null)
                zmien_kolor();
        }

        private void BlueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (RedSlider != null && GreenSlider != null && BlueSlider != null)
                zmien_kolor();
        }
    }

    internal class tb_01
    {
        public static SolidColorBrush Foreground { get; internal set; }
    }
}
