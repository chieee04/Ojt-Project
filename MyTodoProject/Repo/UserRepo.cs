using Dapper;
using MyTodoProject.Data;
using MyTodoProject.Models;
namespace MyTodoProject.Repo
{
    public class UserRepo
    {
        private readonly DapperContex _context;

        public UserRepo(DapperContex contex)
        {
            _context = contex;
        }
        public Users? Login(string username, string password)
        {
            var query = @"SELECT * FROM Accounts 
                          WHERE username = @username 
                          AND password = @password";

            using var connection = _context.CreateConnection();
            return connection.Query<Users>(query, new { username, password }).FirstOrDefault();
        }

       

    }
}
