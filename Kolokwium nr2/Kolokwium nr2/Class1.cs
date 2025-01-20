using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium_nr2
{
   public class Class1
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ID {  get; set; }
        public string Author { get; set; }
        public override string ToString()
            
        {
            return "ID:" + ID + " Name:" + Name  + " Author:" + Author + " Description:" + Description;
        }
        
    }
}
