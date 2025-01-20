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

namespace Kolokwium_nr2
{
    /// <summary>
    /// Interaction logic for tsonh.xaml
    /// </summary>
    public partial class tsonh : Window
    {  
        public Class1 Class1 { get; set; }
        public tsonh()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Class1.ID = id.Text;
            Class1.Author=Author.Text;
            Class1.Description=Description.Text;
            Class1.Name=Name.Text;
            this.Close();
           
        }
        public void Update()
        {
            if (Class1 != null) 
            {
                id.Text = Class1.ID;
                Name.Text = Class1.Name;
                Author.Text = Class1.Author;
                Description.Text = Class1.Description;
                
            }
        }
      
            
    }
}
