using Dapper;
using MyTodoProject.Data;
using MyTodoProject.Models;

namespace MyTodoProject.Repo
{
    public class TaskRepo
    {
        private readonly DapperContex _context;

        public TaskRepo(DapperContex context)
        {
            _context = context;
        }

        public IEnumerable<Tasks> GetPersonalTasks(int userID)
        {
            using var conn = _context.CreateConnection();
            return conn.Query<Tasks>("SELECT * FROM Tasks WHERE userID=@userID", new { userID });
        }

        public IEnumerable<dynamic> GetAllUserTasks()
        {
            var query = @"SELECT T.taskID,
                         T.title,
                         T.description,
                         A.username
                  FROM Tasks T
                  JOIN Accounts A
                  ON T.userID = A.userID";

            using var conn = _context.CreateConnection();

            return conn.Query(query);
        }

        public void AddTask(Tasks task)
        {
            using var conn = _context.CreateConnection();

            conn.Execute(@"INSERT INTO Tasks(userID,title,description)
                           VALUES(@userID,@title,@description)", task);
        }

        public void UpdateTask(Tasks task)
        {
            using var conn = _context.CreateConnection();

            conn.Execute(@"UPDATE Tasks
                           SET title=@title,
                               description=@description
                           WHERE taskID=@taskID", task);
        }

        public void DeleteTask(int id)
        {
            using var conn = _context.CreateConnection();

            conn.Execute("DELETE FROM Tasks WHERE taskID=@id", new { id });
        }
    }
}