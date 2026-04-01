//using JobHandlerAPI.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace JobHandlerAPI.Controllers
//{
//    [Route("api/login")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IConfiguration _config;
//        private readonly AppDbContext _context;

//        public AuthController(IConfiguration config, AppDbContext context)
//        {
//            _config = config;
//            _context = context;
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login()
//        {
//            var user = await _context.
//                .FirstOrDefaultAsync(u => u.Email == );

//            if (user == null || user.Password != PasswordHasher.Hash())
//                return Unauthorized("Invalid email or password");

//            var claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//                new Claim(ClaimTypes.Email, user.Email),
//                new Claim(ClaimTypes.Name, user.UserName)
//            };

//            var key = new SymmetricSecurityKey(
//                Encoding.UTF8.GetBytes(_config["JWT:Key"]!));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var token = new JwtSecurityToken(
//                issuer: _config["JWT:Issuer"],
//                audience: _config["JWT:Audience"],
//                claims: claims,
//                expires: DateTime.UtcNow.AddMinutes(
//                    double.Parse(_config["JWT:DurationInMinutes"]!)),
//                signingCredentials: creds
//            );

//            return Ok(new
//            {
//                token = new JwtSecurityTokenHandler().WriteToken(token),
//                expiration = token.ValidTo
//            });
//        }
//    }
