using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleperformanceApi.DTOs;
using TeleperformanceApi.Entities;

namespace TeleperformanceApi.Controllers
{
    [ApiController]
    [Route("api/Companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CompaniesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyDTO>>> get()
        {
            var entites = await context.Companies.ToListAsync();
            var DTOs = mapper.Map<List<CompanyDTO>>(entites);
            return DTOs;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDTO>> Post([FromBody] CompanyDTO CompanyDTO)
        {
            var entity = mapper.Map<Company>(CompanyDTO);
            context.Add(entity);
            await context.SaveChangesAsync();
            var companyDTO = mapper.Map<CompanyDTO>(entity);
            return companyDTO;
        }

        [HttpGet("{nit}")]
        public async Task<ActionResult<CompanyDTO>> ValidateCompanyNIT(string nit)
        {
            var entity = await context.Companies
                .Where(company => company.NIT.Equals(nit))
                .FirstOrDefaultAsync();
            var companyDTO = mapper.Map<CompanyDTO>(entity);

            return companyDTO;
        }
    }
}
