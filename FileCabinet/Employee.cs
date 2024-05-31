
namespace FileCabinet
{
    public class Employee: IComparable<Employee>
    {
        private protected static uint NextId = 1;
        public uint Id { get; private protected set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime Dob { get; set; }
        public string Position { get; set; }
        public string Unit { get; set; }
        public ushort Room { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string Note { get; set; }

        public Employee()
        {
            Id = NextId;
            NextId++;
        }
        public Employee(
            string surname,
            string name,
            string middleName,
            DateTime dob,
            string position,
            string unit,
            ushort room,
            string phone,
            string email,
            decimal salary,
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
            Salary = salary;
            HireDate = hireDate;
            Note = note;
            NextId++;
        }

        public override string ToString()
        {
            return $"ID: {Id}\n" +
                $"Surname: {Surname}\n" +
                $"Name: {Name}\n" +
                $"Middle Name: {MiddleName}\n" +
                $"Date of Birth: {Dob.ToShortDateString()}\n" +
                $"Position: {Position}\n" +
                $"Unit: {Unit}\n" +
                $"Room: {Room}\n" +
                $"Phone: {Phone}\n" +
                $"Email: {Email}\n" +
                $"Hire Date: {HireDate.ToShortDateString()}\n" +
                $"Note: {Note}";
        }

        public int CompareTo(Employee? other)
        {
            if (other == null)
            {
                return 1;
            }

            int salaryComparison = Salary.CompareTo(other.Salary);
            if (salaryComparison != 0)
            {
                return salaryComparison;
            }

            return Id.CompareTo(other.Id);
        }
        public virtual decimal CalculateMonthlySalary()
        {
            return Salary;
        }
    }
}
