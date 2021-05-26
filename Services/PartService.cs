using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SandfieldTest.Models;

namespace SandfieldTest.Services
{
    public class PartService
    {
        private readonly string _connectionString;
        public PartService(string connectionString)
        {
            _connectionString = connectionString;
        } 

        public List<Part> GetPartList()
        {
            List<Part> lst;
            using (var conn = Helpers.DBConnection.GetDBConnection(_connectionString))
            {
                lst = conn.Query<Part>("usp_GetAllPart", commandType: CommandType.StoredProcedure).ToList();
            }
            return lst;
        }
         
    }
}