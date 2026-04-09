using JobHandlerAPI.DTOs;
using JobHandlerAPI.Helpers;
using JobHandlerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace JobHandlerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userMgr;
        private readonly RoleManager<IdentityRole> _roleMgr;
        private readonly IConfiguration _config;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userMgr = userManager;
            _roleMgr = roleManager;
            _config = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var userResult = await CreateUser(dto, allowExisting: false);
            if (!userResult.IsSuccess)
                return BadRequest(userResult.Errors);

            // Assign default role
            await _userMgr.AddToRoleAsync(userResult.Data, "User");

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("create-admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAdmin(RegisterDto dto)
        {
            var userResult = await CreateUser(dto, allowExisting: true);
            if (!userResult.IsSuccess)
                return BadRequest(userResult.Errors);

            var user = userResult.Data;

  
            if (!await _userMgr.IsInRoleAsync(user, "Admin"))
                await _userMgr.AddToRoleAsync(user, "Admin");

            return Ok(new { message = "User is now an admin" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userMgr.FindByEmailAsync(dto.Email);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var validPassword = await _userMgr.CheckPasswordAsync(user, dto.Password);

            if (!validPassword)
                return Unauthorized("Invalid credentials");

            var roles = await _userMgr.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.Name)
            };

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JWT:Key"]!));

            var creds = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                user = new
                {
                    user.Name,
                    user.Email,
                    roles
                }
            });
        }

        private async Task<Result<ApplicationUser>> CreateUser(RegisterDto dto, bool allowExisting)
        {
      
            var user = await _userMgr.FindByEmailAsync(dto.Email);

            if (user != null)
            {
                if (!allowExisting)
                    return Result<ApplicationUser>.Failure("Email already exists");

                return Result<ApplicationUser>.Success(user);
            }

       
            var existingUsername = await _userMgr.FindByNameAsync(dto.Username);
            if (existingUsername != null)
                return Result<ApplicationUser>.Failure("Username already exists");

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                return Result<ApplicationUser>.Failure("Name can not be empty");
            }
    
            user = new ApplicationUser
            {
                UserName = dto.Username,
                Email = dto.Email,
                Name = dto.Name
            };

            var result = await _userMgr.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return Result<ApplicationUser>.Failure(errors);
            }

            return Result<ApplicationUser>.Success(user);
        
    }
}
}