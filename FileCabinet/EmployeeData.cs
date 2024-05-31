using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;

namespace FileCabinet
{
    public class EmployeeData
    {
        private List<Employee> employees = new List<Employee>();

        public void FillWithTestData()
        {
            employees.Add(new FixedSalaryEmployee("Ivanchenko", "Ivan", "Ivanovych", new DateTime(1980, 1, 1), "Engineer", "IT", 101, "123-45-67", "ivan@mail.com", 900, 20, new DateTime(2020, 1, 1), ""));
            employees.Add(new HourlyWageEmployee("Petrenko", "Petro", "Petrovych", new DateTime(1985, 2, 2), "Manager", "HR", 102, "123-45-68", "petro@mail.com", 100, 185, new DateTime(2020, 2, 2), ""));
            employees.Add(new PieceworkEmployee("Mykulenko", "Mykola", "Mykolaiovych", new DateTime(1990, 3, 3), "Director", "Top", 103, "123-45-69", "mykola@mail.com", new Dictionary<TaskPrices.TaskType, int>() { { TaskPrices.TaskType.Backend, 5 }, { TaskPrices.TaskType.Documentation, 4 } }, new DateTime(2020, 3, 3), ""));
            employees.Add(new HourlyWageEmployee("Bohdan", "Ivan", "Petrovych", new DateTime(1985, 2, 2), "Manager", "HR", 102, "123-45-68", "petro@mail.com", 100, 185, new DateTime(2020, 2, 2), ""));
        }

        public void AddRecord()
        {
            Console.WriteLine("Add a record: ");
            EmployeeType type = InputEmployeeType();

            Employee employee = GetEmployeeByType(type);
            FillEmployee(employee);
            employees.Add(employee);

            Console.WriteLine("Record added successfully");
        }

        public void DeleteRecord()
        {
            Console.WriteLine("Delete a record: ");

            Employee employee = FindEmployee();
            if (employee != null)
            {
                Console.WriteLine("Are you sure you want to delete this record? (yes/no)");
                string answer = ConsoleInputHandler.GetInput<string>("Are you sure you want to delete this record? (yes/no)");
                if (answer == "yes")
                {
                    employees.Remove(employee);
                    Console.WriteLine("Record deleted successfully");
                }
                else if (answer == "no")
                {
                    Console.WriteLine("Record not deleted");
                }
                else
                {
                    Console.WriteLine("Invalid answer");
                }
            }
        }
        public void UpdateRecord()
        {
            Console.WriteLine("Update a record: ");
            
            Employee employee = FindEmployee();
            if (employee != null)
            {
                FillEmployee(employee);
                Console.WriteLine("Record updated successfully");
            }
        }

        public void ShowRecord()
        {
            Console.WriteLine("Show a record: ");
            
            Employee employee = FindEmployee();
            if (employee != null)
            {
                Console.WriteLine(employee);
            }
        }

        public void ShowAllRecords()
        {
            Console.WriteLine("Show all records: ");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
                Console.WriteLine("------------------------");
            }
        }

        public void SortBySalary()
        {
            Console.WriteLine("Sort by salary: ");
            employees.Sort();
            ShowAllRecords();
        }

        private Employee FindEmployee()
        {
            uint id = ConsoleInputHandler.GetInput<uint>("Enter ID: ");
            Employee employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                Console.WriteLine("Record not found");
            }
            return employee;
        }

        private Employee FillEmployee(Employee employee)
        {
            employee.Surname = ConsoleInputHandler.GetInput<string>("Enter Surname: ") ?? "";
            employee.Name = ConsoleInputHandler.GetInput<string>("Enter Name: ") ?? "";
            employee.MiddleName = ConsoleInputHandler.GetInput<string>("Enter Middle Name: ") ?? "";
            employee.Dob = ConsoleInputHandler.GetInput<DateTime>("Enter Date of Birth: ");
            employee.Position = ConsoleInputHandler.GetInput<string>("Enter Position: ") ?? "";
            employee.Unit = ConsoleInputHandler.GetInput<string>("Enter Unit: ") ?? "";
            employee.Room = ConsoleInputHandler.GetInput<ushort>("Enter Room: ");
            employee.Phone = ConsoleInputHandler.GetInput<string>("Enter Phone: ") ?? "";
            employee.Email = ConsoleInputHandler.GetInput<string>("Enter Email: ") ?? "";
            employee.HireDate = ConsoleInputHandler.GetInput<DateTime>("Enter Hire Date: ");
            employee.Note = ConsoleInputHandler.GetInput<string>("Enter Note: ") ?? "";

            switch (employee.GetType())
            {
                case Type t when t == typeof(FixedSalaryEmployee):
                    FixedSalaryEmployee fixedSalaryEmployee = (FixedSalaryEmployee)employee;
                    fixedSalaryEmployee.DailyRate = ConsoleInputHandler.GetInput<decimal>("Enter Daily Rate: ");
                    fixedSalaryEmployee.Workdays = ConsoleInputHandler.GetInput<uint>("Enter Workdays: ");
                    break;

                case Type t when t == typeof(HourlyWageEmployee):
                    HourlyWageEmployee hourlyWageEmployee = (HourlyWageEmployee)employee;
                    hourlyWageEmployee.HourlyRate = ConsoleInputHandler.GetInput<decimal>("Enter Hourly Rate: ");
                    hourlyWageEmployee.HoursWorkedPerMonth = ConsoleInputHandler.GetInput<uint>("Enter Hours Worked Per Month: ");
                    break;

                case Type t when t == typeof(PieceworkEmployee):
                    PieceworkEmployee pieceworkEmployee = (PieceworkEmployee)employee;
                    pieceworkEmployee.CompletedTasks = new Dictionary<TaskPrices.TaskType, int>();
                    foreach (TaskPrices.TaskType taskType in Enum.GetValues(typeof(TaskPrices.TaskType)))
                    {
                        pieceworkEmployee.CompletedTasks.Add(taskType, ConsoleInputHandler.GetInput<int>($"Enter number of {taskType}: "));
                    }
                    break;
            }

            return employee;
        }

        private EmployeeType InputEmployeeType()
        {
            string[] employeeTypeName = ["Fixed Salary", "Hourly Wage", "Piecework"];

            Console.WriteLine("Please choose employee type:");
            for (int i = 0; i < employeeTypeName.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {employeeTypeName[i]}");
            }   
 
            int choice = ConsoleInputHandler.GetInput<int>("Enter your choice: ");

            if (choice < 1 || choice > employeeTypeName.Length)
            {
                Console.WriteLine("Invalid choice");
                return InputEmployeeType();
            }
            
       

            return (EmployeeType)choice;
        }

        private Employee GetEmployeeByType(EmployeeType type)
        {
            switch (type)
            {
                case EmployeeType.FixedSalary:
                    return new FixedSalaryEmployee();
                case EmployeeType.HourlyWage:
                    return new HourlyWageEmployee();
                case EmployeeType.Piecework:
                    return new PieceworkEmployee();
                default:
                    return new Employee();
            }
        }
    }

}
