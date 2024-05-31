using FileCabinet;

EmployeeData employeeData = new EmployeeData();
while (true)
{
    Menu.PrintMenu();
    MenuOption choice = Menu.GetChoice();

    switch (choice)
    {
        case MenuOption.AddRecord:
            employeeData.AddRecord();
            break;
        case MenuOption.DeleteRecord:
            employeeData.DeleteRecord();
            break;
        case MenuOption.UpdateRecord:
            employeeData.UpdateRecord();
            break;
        case MenuOption.ShowRecord:
            employeeData.ShowRecord();
            break;
        case MenuOption.PrintAllRecords:
            employeeData.ShowAllRecords();
            break;
        case MenuOption.SortBySalary:
            employeeData.SortBySalary();
            break;
        case MenuOption.Exit:
            Environment.Exit(0);
            break;
        case MenuOption.FillWithTestData:
            employeeData.FillWithTestData();
            break;
    }
}
