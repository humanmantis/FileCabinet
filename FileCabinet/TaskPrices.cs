namespace FileCabinet
{
    public static class TaskPrices
    { 
        public enum TaskType
        {
            Frontend = 1,
            Backend,
            Testing,
            Documentation
        }

        public static Dictionary<TaskType, decimal> Prices = new Dictionary<TaskType, decimal>
       {
            { TaskType.Frontend, 400m },
            { TaskType.Backend, 450m },
            { TaskType.Testing, 300m },
            { TaskType.Documentation, 250m }
        };  
    }
}
