using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2DatabaseConnectionFinal.Classes
{
    internal class Ward
    {
        public char WardLetter { get ; set; }
        public string WardName { get; set; }

        public Ward (char wardLetter, string wardName)
        {
            this.WardLetter = wardLetter;
            this.WardName = wardName;
        }
    }
}
