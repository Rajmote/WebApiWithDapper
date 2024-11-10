using Dapper;
using System.Data;
using WebApiWithDapper.Context;
using WebApiWithDapper.Contracts;
using WebApiWithDapper.Entities;

namespace WebApiWithDapper.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var spName = "Sp_GetCompanies";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(spName, commandType: CommandType.StoredProcedure);
                return companies;
            }
        }

        public async Task<Company> GetCompany(int id)
        {
            var spName = "Sp_GetCompanyById";
            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Company>(query, new { id });
                return company;
            }
        }
        
    }
}
