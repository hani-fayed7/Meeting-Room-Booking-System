using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Meeting_Room_Booking_System.Resources;
using Meeting_Room_Booking_System.Validators;
using Microsoft.AspNetCore.Mvc;
using MRBS.Core.Models;
using MRBS.Services.Interface;

namespace Meeting_Room_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            this._mapper = mapper;
            this._companyService = companyService;
            /*_companyService = companyService;*/
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CompanyResource>>> GetAllArtists()
        {
            var companies = await _companyService.GetAllCompanies();
            var companyResources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);

            return Ok(companyResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyResource>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            var companyResource = _mapper.Map<Company, CompanyResource>(company);

            return Ok(companyResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<CompanyResource>> CreateComapny([FromBody] SaveCompanyResource saveCompanyResource)
        {
            var validator = new SaveCompanyResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCompanyResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var companyToCreate = _mapper.Map<SaveCompanyResource, Company>(saveCompanyResource);

            var newCompany = await _companyService.CreateCompany(companyToCreate);

            var company = await _companyService.GetCompanyById(newCompany.PkCompanyId);

            var companyResource = _mapper.Map<Company, CompanyResource>(company);

            return Ok(companyResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _companyService.GetCompanyById(id);

            await _companyService.DeleteCompany(company);

            return NoContent();
        }
    }
}