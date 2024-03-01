using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleProject.Db;
using SimpleProject.Db.Entities;
using SimpleProject.Helpers;
using SimpleProject.Helpers.JwtHelper;
using SimpleProject.Models.RequestModels;
using SimpleProject.Models.ResponseModels;

namespace SimpleProject.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : Controller
{
    private readonly SimpleProjectDbContext _dbContext;
    private const decimal BALANCE = 1000.00m;
    private readonly JwtConfiguration _jwtConfiguration;
    private readonly RequestContextData _requestContextData;
    public UsersController(SimpleProjectDbContext dbContext, JwtConfiguration jwtConfiguration, RequestContextData requestContextData)
    {
        _dbContext = dbContext;
        _jwtConfiguration = jwtConfiguration;
        _requestContextData = requestContextData;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] UserRequestModel userModel)
    {
        try
        {
            var hashedPassword = PasswordHasher.HashPassword(userModel.Password);

            User user = new()
            {
                Username = userModel.Username,
                Email = userModel.Email,
                Password = hashedPassword,
                Balance = BALANCE
            };
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }


    [HttpPost("authenticate")]
    public async Task<ActionResult<UserResponseModel>> Login([FromBody] UserRequestModel userModel)
    {
        var user = await _dbContext.User.FirstOrDefaultAsync(x => x.Username == userModel.Username || x.Email == userModel.Email);

        if (user != null)
        {

            var passwordIsValid = PasswordHasher.VerifyPassword(userModel.Password, user.Password);

            if (passwordIsValid)
            {
                var token = _jwtConfiguration.GenerateToken(user.Username, user.Balance, user.Email);

                return Ok(new UserResponseModel() { Balance = user.Balance, Username = user.Username, Email = user.Email, Token = token });
            }
            else
            {
                return Unauthorized();
            }
        }

        return Ok();
    }

    [HttpGet("profile")]
    [Authorize]
    public async Task<ActionResult> GetUserProfile()
    {
        ProfileResponseModel model = new ProfileResponseModel()
        {
            Balance = _requestContextData.Balance,
            Email = _requestContextData.Email,
            Username = _requestContextData.Username
        };

        await Task.CompletedTask;

        return Ok(model);
    }
}
