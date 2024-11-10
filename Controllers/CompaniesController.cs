using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWithDapper.Contracts;

namespace WebApiWithDapper.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _companyRepository.GetCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(int id)
        {
            try
            {
                var company = await _companyRepository.GetCompany(id);
                if (company == null)
                    return NotFound();

                return Ok(company);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
