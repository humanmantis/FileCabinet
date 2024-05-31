namespace FileCabinet
{
    public class FixedSalaryEmployee : Employee
    {
        public decimal DailyRate { get; set; }
        public uint Workdays { get; set; }
        public override decimal Salary
        {
            get
            {
                return CalculateMonthlySalary();
            }
        }

        public FixedSalaryEmployee() : base()
        {
        }

        public FixedSalaryEmployee(
            string surname,
            string name,
            string middleName,
            DateTime dob,
            string position,
            string unit,
            ushort room,
            string phone,
            string email,
            decimal dailyRate,
            uint workdays,
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
            DailyRate = dailyRate;
            Workdays = workdays;
            HireDate = hireDate;
            Note = note;
            NextId++;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nSalary: {Salary}" +
                   $"\nDaily Rate: {DailyRate}" +
                   $"\nWorkdays: {Workdays}";
        }
        public override decimal CalculateMonthlySalary()
        {
            return DailyRate * Workdays;
        }

    }
}
