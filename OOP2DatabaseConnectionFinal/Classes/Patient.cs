using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2DatabaseConnectionFinal.Classes
{
    internal class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PatientNumber { get; set; }
        public string DisplayValue { get => (PatientNumber != -1) ? $"{FirstName} {LastName} ({Convert.ToString(PatientNumber)})" : "No Patient"; }
        public Patient() {
            PatientNumber = -1;
        }

    }
}
