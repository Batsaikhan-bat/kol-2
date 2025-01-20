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

namespace shalgalt3
{
    /// <summary>
    /// Interaction logic for Dialog_01.xaml
    /// </summary>
    public partial class Dialog_01 : Window
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Year { get; internal set; }
        public Dialog_01()
        {
            InitializeComponent();
        }
        private void bt_01_Click(object sender, RoutedEventArgs e)
        {
            Marka = tbox_01.Text;
            Model = tbox_02.Text;
            Year = tbox_03.Text;
            DialogResult = true;

        }

        private void bt_02_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
