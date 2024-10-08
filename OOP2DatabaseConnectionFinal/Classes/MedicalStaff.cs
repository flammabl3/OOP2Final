﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2DatabaseConnectionFinal.Classes
{
    abstract class MedicalStaff
    {
        public int StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }

        public string DisplayValue { get { return $"{FirstName} {LastName} ({StaffID})"; } }
        public string DisplayTitle { 
            get {
                return this.GetType() == typeof(Doctor) ? "Doctor" : this.GetType() == typeof(Nurse) ? "Nurse" : "Nurse";
            }
        }

        public MedicalStaff(int staffID, string firstName, string lastName, string contactPhone, string email)
        {
            StaffID = staffID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ContactPhone = contactPhone;
        }

        public MedicalStaff(int staffID, string firstName, string lastName, string contactPhone, string email, string Title)
        {
            StaffID = staffID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ContactPhone = contactPhone;
            Title = Title;
        }
    }

    internal class Nurse : MedicalStaff
    {
        public Nurse(int staffID, string firstName, string lastName, string contactPhone, string email) : base(staffID, firstName, lastName, contactPhone, email) { 
        
        }
    }

    internal class Doctor : MedicalStaff
    {
        public Doctor(int staffID, string firstName, string lastName, string contactPhone, string email) : base(staffID, firstName, lastName, contactPhone, email)
        {

        }
    }
}
