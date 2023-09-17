using System;
using System.Data.SqlClient;
using System.Text;
using RepositoryApp.Repositories;
using ToDoList.Entities;
// See https://aka.ms/new-console-template for more information
const string connectionString = "Server=WINDOWS-CR2UC3A;Database=TestDB;Trusted_Connection=True;";
var tasksList = new List<ToDoList.Entities.Task>();

//SqlConnection connection = new SqlConnection(connectionString);

TaskRepository taskRepository = new TaskRepository(connectionString);

string choosenStatus;
string choosenPriority;
string choosenTask;
List<string> menu = new List<string>()
        {"Add Task",
        "Remove Task",
        "View All Tasks"
        };
IDictionary<int, string> AllTasks = new Dictionary<int, string>();

IDictionary<int, string> taskStatus = new Dictionary<int, string>();
taskStatus.Add(1, "Done");
taskStatus.Add(2, "Undone");


IDictionary<int, string> taskPriority = new Dictionary<int, string>();
taskPriority.Add(1, "Low");
taskPriority.Add(2, "Medium");
taskPriority.Add(3, "High");

dynamic res = Menu.MainDraw(menu);
switch (res)
{
    case "Add Task":
        Console.WriteLine("Enter Task Name:");
        StringBuilder name = new StringBuilder();
        name.Append(Console.ReadLine());
        Console.Clear();
        choosenStatus = Menu.MainDraw(taskStatus.Values.ToList<string>());
        Console.Clear();
        choosenPriority = Menu.MainDraw(taskPriority.Values.ToList<string>());
        taskRepository.CreateTask(name.ToString(), taskStatus.FirstOrDefault(x => x.Value == choosenStatus).Key, taskPriority.FirstOrDefault(x => x.Value == choosenPriority).Key);
        break;
    case "Remove Task":
       
       // tasksList = taskRepository.GetAll();
         for (int i = 0; i < taskRepository.GetAll().Count; i++)
         {
             AllTasks.Add( taskRepository.GetAll()[i].Id,taskRepository.GetAll()[i].Name);
             //System.Console.WriteLine(AllTasks.Values.);
         }

        choosenTask = Menu.MainDraw(AllTasks.Values.ToList());

        taskRepository.DeleteTask(AllTasks.FirstOrDefault(x => x.Value == choosenTask).Key);
       // System.Console.WriteLine(taskRepository.GetAll().Count);

        break;
   case "View All Tasks":
    
         for (int i = 0; i < taskRepository.GetAll().Count; i++)
         {
             AllTasks.Add( taskRepository.GetAll()[i].Id,taskRepository.GetAll()[i].Name);
             //System.Console.WriteLine(AllTasks.Values.);
         }

        System.Console.WriteLine(" Press Esc to go back\n\n");
        choosenTask = Menu.MainDraw(AllTasks.Values.ToList());


   break;

    default:
        break;
}
