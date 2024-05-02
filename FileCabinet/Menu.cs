namespace FileCabinet
{
    internal class Menu
    {
        private static readonly string[] options = new string[]
        {
            "Add a record",
            "Delete a record",
            "Update a record",
            "Show a record",
            "Print all records",
            "Exit",
            "Fill with test data"
        };

        public static void PrintMenu()
        {
            Console.WriteLine("\nMenu: ");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.WriteLine("------------------------");
        }

        public static MenuOption GetChoice()
        {
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice < 1 && choice > options.Length)
            {
                Console.WriteLine("Invalid choice");
                return GetChoice();
            }
            return (MenuOption)choice;
        }


    }
}
