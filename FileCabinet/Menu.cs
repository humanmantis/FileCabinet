namespace FileCabinet
{
    public static class Menu
    {
        private static readonly string[] options = new string[]
        {
            "Add a record",
            "Delete a record",
            "Update a record",
            "Show a record",
            "Print all records",
            "Sort by salary",
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
            int choice = ConsoleInputHandler.GetInput<int>("Enter your choice: ");

            if (choice < 1 || choice > options.Length)
            {
                Console.WriteLine("Invalid choice");
                return GetChoice();
            }
            
            return (MenuOption)choice;
        }
    }
}
