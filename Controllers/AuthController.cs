//using JobHandlerAPI.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace JobHandlerAPI.Controllers
//{
//using JobHandlerAPI.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//[Route("api/[controller]")]
//[ApiController]
//public class AuthController : ControllerBase
//{
//    private readonly UserManager<ApplicationUser> _userMgr;
//    private readonly RoleManager<IdentityRole> _roleMgr;
//    private readonly IConfiguration _config;

//    public AuthController(
//        UserManager<ApplicationUser> userManager,
//        RoleManager<IdentityRole> roleManager,
//        IConfiguration configuration)
//    {
//        _userMgr = userManager;
//        _roleMgr = roleManager;
//        _config = configuration;
//    }

//    [HttpPost("register")]
//    public async Task<IActionResult> Register(
//        RegisterDto dto)
//    {
//        var user = new ApplicationUser
//        {
//            UserName = dto.Email,
//            Email = dto.Email,
//            FullName = dto.FullName,
//            Department = dto.Department
//        };

//        // Identity handles password hashing!
//        var result = await _userMgr.CreateAsync(
//            user, dto.Password);

//        if (!result.Succeeded)
//            return BadRequest(result.Errors);

//        // Assign role
//        await _userMgr.AddToRoleAsync(user, "Student");

//        return Ok("User registered successfully!");
//    }

//    [HttpPost("login")]
//    public async Task<IActionResult> Login(LoginDto dto)
//    {
//        var user = await _userMgr
//            .FindByEmailAsync(dto.Email);

//        if (user == null)
//            return Unauthorized("Invalid credentials");

//        // Identity checks hashed password!
//        var validPassword = await _userMgr
//            .CheckPasswordAsync(user, dto.Password);

//        if (!validPassword)
//            return Unauthorized("Invalid credentials");

//        // Get user roles
//        var roles = await _userMgr
//            .GetRolesAsync(user);

//        // Build claims
//        var claims = new List<Claim>
//        {
//            new(ClaimTypes.NameIdentifier, user.Id),
//            new(ClaimTypes.Email, user.Email!),
//            new(ClaimTypes.Name, user.FullName),
//        };

//        // Add role claims
//        foreach (var role in roles)
//            claims.Add(new(ClaimTypes.Role, role));

//        // Generate JWT (same as before)
//        var key = new SymmetricSecurityKey(
//            Encoding.UTF8.GetBytes(
//                _config["JWT:Key"]!));
//        var creds = new SigningCredentials(
//            key, SecurityAlgorithms.HmacSha256);

//        var token = new JwtSecurityToken(
//            issuer: _config["JWT:Issuer"],
//            audience: _config["JWT:Audience"],
//            claims: claims,
//            expires: DateTime.Now.AddMinutes(60),
//            signingCredentials: creds);

//        return Ok(new
//        {
//            token = new JwtSecurityTokenHandler()
//                       .WriteToken(token),
//            expiration = token.ValidTo,
//            user = new
//            {
//                user.FullName,
//                user.Email,
//                roles
//            }
//        });
//    }
//}
