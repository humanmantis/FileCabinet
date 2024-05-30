namespace FileCabinet
{
    public class HourlyWageEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public uint HoursWorkedPerMonth { get; set; }
        public new decimal Salary
        {
            get
            {
                return CalculateMonthlySalary();
            }
        }

        public HourlyWageEmployee() : base()
        {
        }

        public HourlyWageEmployee(
            string surname,
            string name,
            string middleName,
            DateTime dob,
            string position,
            string unit,
            ushort room,
            string phone,
            string email,
            decimal hourlyRate,
            uint hoursWorkedPerMonth,
            DateTime hireDate,
            string note
        )
        {
            Id = NextId;
            Surname = surname;
            Name = name;
            MiddleName = middleName;
            Dob = dob;
            Position = position;
            Unit = unit;
            Room = room;
            Phone = phone;
            Email = email;
            HourlyRate = hourlyRate;
            HoursWorkedPerMonth = hoursWorkedPerMonth;
            HireDate = hireDate;
            Note = note;
            NextId++;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nSalary: {Salary}" +
                   $"\nHourly Rate: {HourlyRate}" +
                   $"\nHours Worked Per Month: {HoursWorkedPerMonth}";
        }

        public override decimal CalculateMonthlySalary()
        {
            decimal baseSalary = HourlyRate * HoursWorkedPerMonth;
            if (HoursWorkedPerMonth > 160)
            {
                baseSalary *= 1.15m;
            }
            return baseSalary;
        }

    }
}
