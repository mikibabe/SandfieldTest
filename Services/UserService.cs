using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SandfieldTest.Models;

namespace SandfieldTest.Services
{
    public class UserService
    {
        private readonly string _connectionString;
        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public User GetUserById(int id)
        { 
            User user;
            using (var conn = Helpers.DBConnection.GetDBConnection(_connectionString))
            {
                user = conn.Query<User>("usp_GetUserById", new { @Id = id },  
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return user;
        }

        public List<UserView> GetUserList()
        {
            List<UserView> lst;
            using (var conn = Helpers.DBConnection.GetDBConnection(_connectionString))
            {
                lst = conn.Query<UserView>("usp_GetAllUser", commandType: CommandType.StoredProcedure).ToList();
            }
            return lst;
        }

        public string GetUserAccessLevelById(int id)
        {
            string userAccessLevel;
            using (var conn = Helpers.DBConnection.GetDBConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Id", id);
                p.Add("@UserAccessLevel", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);

                var user = conn.Query<int>("usp_GetUserAccessLevel", p,
                    commandType: CommandType.StoredProcedure);


                userAccessLevel = p.Get<string>("@UserAccessLevel"); 
            }
            return userAccessLevel;
        }

        public bool EditUser(Models.User dto)
        { 
            using (var conn = Helpers.DBConnection.GetDBConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dto.Id);
                p.Add("@UserId", dto.UserId);
                p.Add("@Password", dto.Password);
                p.Add("@Group", dto.Group);
                p.Add("@PartId", dto.PartId);
                p.Add("@Role", dto.Role);

                int result = conn.Execute("usp_EditUser", p, commandType: CommandType.StoredProcedure); 
                return (result > 0);
            }
        }
        public bool DeleteUser(int id)
        {
            using (var conn = Helpers.DBConnection.GetDBConnection(_connectionString))
            {
                int result = conn.Execute("usp_DeleteUser", new { id }, commandType: CommandType.StoredProcedure);
                return (result > 0);
            }
        }


        public int AddUser(Models.User dto)
        {
            using (var conn = Helpers.DBConnection.GetDBConnection(_connectionString))
            {
                var p = new DynamicParameters(); 
                p.Add("@UserId", dto.UserId);
                p.Add("@Password", dto.Password);
                p.Add("@Group", dto.Group);
                p.Add("@Role", dto.Role);
                p.Add("@PartId", dto.PartId);
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var user = conn.Query<int>("usp_AddUser", p,
                    commandType: CommandType.StoredProcedure); 

                var userId = p.Get<int>("@Id");
                return userId;
            }
        }

    }
}