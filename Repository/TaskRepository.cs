namespace RepositoryApp.Repositories;

using System.Data.SqlClient;
using ToDoList.Entities;

public class TaskRepository {
    private SqlConnection sqlConnection;

   // public static List<Task> tasks ;
    public TaskRepository(string connectionString)
    {
       this.sqlConnection = new SqlConnection(connectionString);

        this.sqlConnection.Open();
        
    }

    public List<Task> GetAll() {
        
       var tasks = new List<Task>();
      var  command = new SqlCommand(cmdText:@"select t.id as task_id,t.name as task_name, s.name as status_name, p.name as priority_name from task t
join status s on t.statusId = s.id
join priority p on t.priorityId = p.id",this.sqlConnection);
         

        var reader = command.ExecuteReader();

        while(reader.Read()) {
            var newTask = new Task() {
                Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Status = reader.GetString(2),
            Priority = reader.GetString(3)
            };

            tasks.Add(newTask);
            // reader.GetInt32(0);
            // reader.GetString(1);
            // reader.GetInt32(2);
        }
        reader.Close();

        return tasks;
    }

    public bool CreateTask(string newTaskName, int newTaskStatusId, int newTaskPriorityId) {
        // string query = newUser.Age is null
        //     ? $"insert into Users(Name) values('{newUser.Name}')"
        //     :$"insert into Users(Name, Age) values('{newUser.Name}', {newUser.Age})";

         var  command = new SqlCommand(cmdText:$@"insert into Task (Name, StatusId, PriorityId)
                                                values ('{newTaskName}', '{newTaskStatusId}', '{newTaskPriorityId}')",this.sqlConnection);

        return command.ExecuteNonQuery() > 0;
    }

    public bool DeleteTask(int taskId)
    {
        var  command = new SqlCommand(cmdText:$@"delete from Task where Id = {taskId}",this.sqlConnection);

        return command.ExecuteNonQuery() > 0;


    }
}