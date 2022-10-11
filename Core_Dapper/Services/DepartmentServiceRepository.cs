using Core_Dapper.DataAccess;
using Core_Dapper.Models;
using Dapper;
using Microsoft.AspNetCore.Identity;
using static Dapper.SqlMapper;

namespace Core_Dapper.Services
{
    public class DepartmentServiceRepository : IServiceRepository<Department, int>
    {
        private readonly CompanyDapperContext _context;
        private readonly IConfiguration _configuration;

        public DepartmentServiceRepository(CompanyDapperContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        async Task<Department> IServiceRepository<Department, int>.CreateAsync(Department entity)
        {
            try
            {
                var query = _configuration["Queries:CreateDept"].ToString();
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DeptNo", entity.DeptNo, System.Data.DbType.Int32);
                queryParameters.Add("@DeptName", entity.DeptName, System.Data.DbType.String);
                queryParameters.Add("@Location", entity.Location, System.Data.DbType.String);
                queryParameters.Add("@Capacity", entity.Capacity, System.Data.DbType.Int32);

                using (var conn = _context.CreateConnection())
                {
                    await conn.ExecuteAsync(query,queryParameters);    
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<bool> IServiceRepository<Department, int>.DeleteAsync(int id)
        {
            bool isDeleted = false;
            try
            {
                var query = _configuration["Queries:DeleteDept"].ToString();
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DeptNo", id, System.Data.DbType.Int32);
                

                using (var conn = _context.CreateConnection())
                {
                    int result = await conn.ExecuteAsync(query, queryParameters);
                    if (result != 0)
                        isDeleted= true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isDeleted;
        }

        async Task<IEnumerable<Department>> IServiceRepository<Department, int>.GetAsync()
        {
            try
            {
                var query = _configuration["Queries:AllDept"].ToString();
                using (var conn = _context.CreateConnection())
                {
                    var departments = await conn.QueryAsync<Department>(query);
                    return departments;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<Department> IServiceRepository<Department, int>.GetAsync(int id)
        {
            try
            {
                var query = _configuration["Queries:DeptByNo"].ToString();
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DeptNo", id, System.Data.DbType.Int32);
                using (var conn = _context.CreateConnection())
                {
                    var department = await conn.QuerySingleOrDefaultAsync<Department>(query, queryParameters);
                    return department;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<Department> IServiceRepository<Department, int>.UpdateAsync(int id, Department entity)
        {
            try
            {
                var query = _configuration["Queries:UpdateDept"].ToString();
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@DeptNo", entity.DeptNo, System.Data.DbType.Int32);
                queryParameters.Add("@DeptName", entity.DeptName, System.Data.DbType.String);
                queryParameters.Add("@Location", entity.Location, System.Data.DbType.String);
                queryParameters.Add("@Capacity", entity.Capacity, System.Data.DbType.Int32);

                using (var conn = _context.CreateConnection())
                {
                   int result =  await conn.ExecuteAsync(query, queryParameters);
                    if (result != 0)
                        return entity;
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
