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
    [Route("api/Users")]
    public class UsersController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UsersController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> get()
        {
            var entites = await context.Users.ToListAsync();
            var DTOs = mapper.Map<List<UserDTO>>(entites);
            return DTOs;
        }

        [HttpGet("{IdentificationNumber}", Name = "getUser")]
        public async Task<ActionResult<UserDTO>> ValidateCompanyNIT(string IdentificationNumber)
        {
            var entity = await context.Users
                .Where(user => user.IdentificationNumber == IdentificationNumber)
                .FirstOrDefaultAsync();
            var userDTO = mapper.Map<UserDTO>(entity);

            return userDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDTO UserDTO)
        {
            var existingUser = await context.Users.AnyAsync(user => user.IdentificationNumber == UserDTO.IdentificationNumber);
            if (existingUser)
            {
                return BadRequest("El número de identificación ya fue utilizado");
            }
            var entity = mapper.Map<User>(UserDTO);
            context.Add(entity);
            await context.SaveChangesAsync();
            var userDTO = mapper.Map<UserDTO>(entity);
            return new CreatedAtRouteResult("getUser", new { IdentificationNumber = userDTO.IdentificationNumber }, userDTO);
        }
    }
}
