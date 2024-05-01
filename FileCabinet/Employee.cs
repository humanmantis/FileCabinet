using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinet
{
    internal class Employee
    {
        public uint Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime Dob { get; set; }
        public string Position { get; set; }
        public string Unit { get; set; }
        public ushort Room { get; set; }
        public PhoneAttribute Phone { get; set; }
        public EmailAddressAttribute Email { get; set; }
        public decimal Salary { get; set; }
        public DateOnly Date { get; set; }
        public string Note { get; set; }
        public Employee(
            uint id,
            string surname,
            string name,
            string middleName,
            DateTime dob,
            string position,
            string unit,
            ushort room,
            PhoneAttribute phone,
            EmailAddressAttribute email,
            decimal salary,
            DateOnly date,
            string note
        )
        {
            Id = id;
            Surname = surname;
            Name = name;
            MiddleName = middleName;
            Dob = dob;
            Position = position;
            Unit = unit;
            Room = room;
            Phone = phone;
            Email = email;
            Salary = salary;
            Date = date;
            Note = note;
        }
    }
}
