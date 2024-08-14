using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2DatabaseConnectionFinal.Classes
{
    abstract class Procedure
    {
        public int ProcedureID { get; set; }
        public string procedureName { get; set; }
        public char Type { get; set; }

        public MedicalStaff OperatingStaff { get; set; }
        public Patient Patient { get; set; }
        public DateTime DatePerformed { get; set; }
        public DateTime DateScheduled { get; set; }

        public Procedure() { }
    }

    internal class Care : Procedure
    {
    }

    internal class Surgery : Procedure
    {
        Room SurgeryRoom { get; set; }
    }

    internal class ProcedureTypes
    {
        public string Name { get ; set; }
        public char Type { get; set; }
        public ProcedureTypes(string name, char type) { 
            this.Name = name;
            this.Type = type;
        }
    }
}
