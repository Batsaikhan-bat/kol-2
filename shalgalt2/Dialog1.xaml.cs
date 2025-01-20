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
    /// Interaction logic for Dialog1.xaml
    /// </summary>
    public partial class Dialog1 : Window
    {
        public string InputText { get; set; }
        public Dialog1()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            InputText = tbox_01.Text;
            this.DialogResult = true;
        }
    }
}
