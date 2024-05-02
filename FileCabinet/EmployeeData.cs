namespace FileCabinet
{
    internal class EmployeeData
    {
        private List<Employee> employees = new List<Employee>();

        public void FillWithTestData()
        {
            employees.Add(new Employee("Ivanchenko", "Ivan", "Ivanovych", new DateTime(1980, 1, 1), "Engineer", "IT", 101, "123-45-67", "ivan@mail.com", 12345, new DateTime(2020, 1, 1), ""));
            employees.Add(new Employee("Petrenko", "Petro", "Petrovych", new DateTime(1985, 2, 2), "Manager", "HR", 102, "123-45-68", "petro@mail.com", 23456, new DateTime(2020, 2, 2), ""));
            employees.Add(new Employee("Mykulenko", "Mykola", "Mykolaiovych", new DateTime(1990, 3, 3), "Director", "Top", 103, "123-45-69", "mykola@mail.com", 34567, new DateTime(2020, 3, 3), ""));
        }

        public void AddRecord()
        {
            Console.WriteLine("Add a record: ");

            Employee employee = new Employee();
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
                string answer = Console.ReadLine();
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
            else
            {
                Console.WriteLine("Record not found");
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

        private Employee FindEmployee()
        {
            Console.Write("Enter ID: ");
            uint id = Convert.ToUInt32(Console.ReadLine());
            Employee employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                Console.WriteLine("Record not found");
            }
            return employee;
        }

        private Employee FillEmployee(Employee employee)
        {
            Console.Write("Enter Surname: ");
            employee.Surname = Console.ReadLine() ?? "";
            Console.Write("Enter Name: ");
            employee.Name = Console.ReadLine() ?? "";
            Console.Write("Enter Middle Name: ");
            employee.MiddleName = Console.ReadLine() ?? "";
            Console.Write("Enter Date of Birth: ");
            employee.Dob = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Position: ");
            employee.Position = Console.ReadLine() ?? "";
            Console.Write("Enter Unit: ");
            employee.Unit = Console.ReadLine() ?? "";
            Console.Write("Enter Room: ");
            employee.Room = Convert.ToUInt16(Console.ReadLine());
            Console.Write("Enter Phone: ");
            employee.Phone = Console.ReadLine() ?? "";
            Console.Write("Enter Email: ");
            employee.Email = Console.ReadLine() ?? "";
            Console.Write("Enter Salary: ");
            employee.Salary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Hire Date: ");
            employee.HireDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Note: ");
            employee.Note = Console.ReadLine() ?? "";

            return employee;
        }
    }
}
