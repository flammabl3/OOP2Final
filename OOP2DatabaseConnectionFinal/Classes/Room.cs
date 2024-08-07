using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2DatabaseConnectionFinal.Classes
{
    internal class Room
    {
        public int RoomNumber { get; set; }
        public char WardLetter { get; set; }

        public string RoomName { get; set; }
        public string DisplayValue
        {
            get
            {
                return $"{WardLetter}{RoomNumber}";
            }
        }

        public Room(int roomNumber, char wardLetter, string roomName)
        {
            this.RoomNumber = roomNumber;
            this.WardLetter = wardLetter;
            this.RoomName = roomName;
        }
    }

    internal class MedicalRoom : Room
    {
        public MedicalRoom(int roomNumber, char wardLetter, string roomName) : base(roomNumber, wardLetter, roomName)
        {

        }
    }

    internal class PatientRoom : Room
    {
        public PatientRoom(int roomNumber, char wardLetter, string roomName) : base(roomNumber, wardLetter, roomName)
        {

        }
    }
}
