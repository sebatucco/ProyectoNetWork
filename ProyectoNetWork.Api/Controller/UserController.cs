
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProyectoNetWork.Application.Interface;
using ProyectoNetWork.Data.DTOs;
using ProyectoNetWork.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoNetWork.Api.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityRepository _securityRepository;
        public UserController(IUserRepository userRepository, ISecurityRepository securityRepository)
        {
            _userRepository = userRepository;
            _securityRepository = securityRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _userRepository.GetAllUsers();
            return Ok(user);
        }

        [HttpPost]
        public async Task Post(User user)
        {
            await _userRepository.AddUsers(user);
            
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task Put([FromBody]User user, [FromRoute] int id)
        {
            await _userRepository.UppdateUsers(user, id);

        }

        [Authorize]
        [HttpGet("/api/getUserId/{id}")]
        public async Task<IActionResult> GetUserId([FromRoute]int id)
        {
            var user = await _userRepository.GetUsersId(id);
            return Ok(user);

        }

        [HttpPost("/api/Token")]
        public async Task<IActionResult> Token([FromBody] SecurityDTO user)
        {
            var validationUser = await IsValidUser(user);
            if (validationUser.Item1)
            {
                var token = "Bearer "+ GenerateToken(validationUser.Item2);
                return Ok(new { token });
            }
            return Unauthorized();

        }

        private async Task<(bool, User)> IsValidUser(SecurityDTO securityDTO)
        {
            var user = await _securityRepository.LoginUser(securityDTO);
            return (user != null, user);
        }

        private string GenerateToken(User user)
        {

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKeyApplication2022"));
            var signinCredential = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signinCredential);

            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                 new Claim(JwtRegisteredClaimNames.Email, user.Mail)
            };

            /*var tokenString = new JwtSecurityToken(
                                 issuer: "UserApi",
                                 audience: "UserApi",
                                 expires: DateTime.Now.AddMinutes(3),
                                 claims: claims,
                                 signingCredentials: signinCredential
                                 );*/

            var payload = new JwtPayload
                (
                  issuer: "UserApi",
                  audience: "UserApi",
                  claims: claims,
                  notBefore: DateTime.Now,
                  expires: DateTime.Now.AddHours(5)
                );
            ;
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
