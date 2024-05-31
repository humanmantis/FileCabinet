namespace FileCabinet
{
    public class PieceworkEmployee : Employee
    {
        public Dictionary<TaskPrices.TaskType, int> CompletedTasks { get; set; }
        public override decimal Salary
        {
            get
            {
                return CalculateMonthlySalary();
            }
        }

        public PieceworkEmployee() : base()
        {
        }

        public PieceworkEmployee(
            string surname,
            string name,
            string middleName,
            DateTime dob,
            string position,
            string unit,
            ushort room,
            string phone,
            string email,
            Dictionary<TaskPrices.TaskType, int> completedTasks,
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
            CompletedTasks = completedTasks;
            HireDate = hireDate;
            Note = note;
            NextId++;
        }

        public override string ToString()
        {
            string str = base.ToString();
            str += $"\nSalary: {Salary}";
            str += "\nCompleted Tasks:";
            foreach (var item in CompletedTasks)
            {
                string task = item.Key.ToString();
                str += $"\n{task}: {item.Value} (Price: {TaskPrices.Prices[item.Key]})";
            }
            return str;
        }

        public override decimal CalculateMonthlySalary()
        {
            decimal totalSalary = 0;
            foreach (var task in CompletedTasks)
            {
                totalSalary += TaskPrices.Prices[task.Key] * task.Value;
            }
            return totalSalary;
        }
    }
}
