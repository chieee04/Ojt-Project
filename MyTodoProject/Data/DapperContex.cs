using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace MyTodoProject.Data;
    public class DapperContex
    {
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContex(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("conn")
        ?? throw new InvalidOperationException("conn not Found!!");
    }
    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);
    

}

