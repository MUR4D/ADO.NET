using System;
using System.Data.SqlClient;
using System.Text;
using RepositoryApp.Repositories;
using ToDoList.Entities;
// See https://aka.ms/new-console-template for more information
const string connectionString = "Server=WINDOWS-CR2UC3A;Database=TestDB;Trusted_Connection=True;";
var tasksList = new List<ToDoList.Entities.Task>();
ToDoList.Entities.Task newTask;
//SqlConnection connection = new SqlConnection(connectionString);

TaskRepository taskRepository = new TaskRepository(connectionString);

string choosenStatus;
string choosenPriority;
string choosenTask="NULL";
bool flag = true;
List<string> menu = new List<string>()
        {"Add Task",
        "Remove Task",
        "View All Tasks"
        };
IDictionary<int, string> AllTasks = new Dictionary<int, string>();
for (int i = 0; i < taskRepository.GetAll().Count; i++)
{
    AllTasks.Add(taskRepository.GetAll()[i].Id,taskRepository.GetAll()[i].Name);
}

IDictionary<int, string> taskStatus = new Dictionary<int, string>();
taskStatus.Add(1, "Done");
taskStatus.Add(2, "Undone");


IDictionary<int, string> taskPriority = new Dictionary<int, string>();
taskPriority.Add(1, "Low");
taskPriority.Add(2, "Medium");
taskPriority.Add(3, "High");

dynamic res ;
int id = 1;
do
{
    res = Menu.MainDraw(menu);

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
     //   newTask = new ToDoList.Entities.Task(name.ToString(),taskStatus.FirstOrDefault(x => x.Value == choosenStatus).Value,taskPriority.FirstOrDefault(x=>x.Value == choosenPriority).Value);
    //   AllTasks.Add(id,name.ToString());
      // id+=1;
        flag = false;
        res=0;
        //continue;
        break;
    case "Remove Task":
       
       // tasksList = taskRepository.GetAll();
       

            if (AllTasks.Values.ToList().Count == 0)
        //choosenTask = Menu.MainDraw(AllTasks.Values.ToList());
            {
                System.Console.WriteLine("No Tasks!");
                Console.ReadKey();
                
            }
            else

            {
                choosenTask = Menu.MainDraw(AllTasks.Values.ToList());

                taskRepository.DeleteTask(AllTasks.FirstOrDefault(x => x.Value == choosenTask).Key);
                AllTasks.Remove(AllTasks.FirstOrDefault(x=>x.Value == choosenTask).Key);
            }
            flag = false;
            res = 0;
            // System.Console.WriteLine(taskRepository.GetAll().Count);

            break;
   case "View All Tasks":
    
        
        System.Console.WriteLine(" Press Esc to go back\n\n");
        
         //   Console.ReadLine();
         if (AllTasks.Values.ToList().Count == 0)
         {
            System.Console.WriteLine("No Tasks!");
            flag = false;
            res = 0;
                Console.ReadKey(true);
         }
            else
            {
            choosenTask = Menu.MainDraw(AllTasks.Values.ToList());
        flag = false;
        res = 0;
                
            }
           // choosenTask = null;
     //   Console.ReadLine();
        Console.Clear();
       // if (choosenTask.Substring(1,1)=="+")
        //{
         //   flag = false;
          //  res=0;
        //}
       System.Console.WriteLine(choosenTask);
        //Console.Clear();


   break;

    default:
        break;
}
Console.Clear();
}while (flag!=true);