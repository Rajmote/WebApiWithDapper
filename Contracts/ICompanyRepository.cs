using WebApiWithDapper.Entities;

namespace WebApiWithDapper.Contracts
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
    }
}
