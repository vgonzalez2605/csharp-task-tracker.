using System.ComponentModel;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        List<TaskItem> tasks = new List<TaskItem>();
        TaskItem task = new TaskItem();
        TaskItem task2 = new TaskItem();
        

        task.Title = "Learn C#";
        task.IsCompleted = true;

        task2.Title = "Practice Git";
        task2.IsCompleted = false;
        

        tasks.Add(task);
        tasks.Add(task2);
        

        while (true)
        {
            Console.Write("\n===== TASK TRACKER =====\n1. View Tasks\n2. Add Task\n3. Complete Task\n4. Exit\n5. About\n\nEnter your choice: \n");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PrintTasks(tasks);
                    break;

                case "2":
                    AddTask(tasks);
                    break;

                case "3":
                    CompleteTask(tasks);
                    break;

                case "4":
                    return;

                case "5":
                    Console.WriteLine("Task Tracker v1.0\r\nCreated as part of my C# developer training.");
                    break;

                default:
                    Console.WriteLine("\nInvalid input, please enter 1, 2, or 3.");
                    break;

            }
        }

    }

    public static void PrintTasks(List<TaskItem> tasks)
    {
        
        for(int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].IsCompleted)
            {
                Console.WriteLine((i + 1) +". [x] " + tasks[i].Title);
            }
            else
            {
                Console.WriteLine((i + 1) + ". [ ] " + tasks[i].Title);
            }
        }
        
    }
    public static void AddTask(List<TaskItem> tasks)
    {
        
        Console.Write("Please Enter A Task: ");
        string? title = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Invalid task name.");
            Console.Write("Please Enter A Task: ");
            title = Console.ReadLine();
        }
        TaskItem task = new TaskItem();
        task.Title = title;
        tasks.Add(task);
    }

    public static void CompleteTask(List<TaskItem> tasks)
    {
        PrintTasks(tasks);
        Console.Write("Enter the task number to complete: ");
        string? input = Console.ReadLine();
        bool success = int.TryParse(input, out int taskNumber);

        if(!success || taskNumber < 1 || taskNumber > tasks.Count)
        {
            Console.WriteLine("Invalid task number");
            return;
        }

        tasks[taskNumber - 1].IsCompleted = true;
        Console.WriteLine("Task is completed successfully!");

    }
}

    

class TaskItem
{

    public string Title { get; set; }

    public bool IsCompleted { get; set; }

}
