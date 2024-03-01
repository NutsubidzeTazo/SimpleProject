using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleProject.Db;
using SimpleProject.Db.Entities;
using SimpleProject.Models.RequestModels;

namespace SimpleProject.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BetsController : ControllerBase
    {
        private readonly SimpleProjectDbContext _dbContext;

        public BetsController(SimpleProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("place")]
        [Authorize]
        public async Task<ActionResult> PlaceBet([FromBody] BetRequestModel betModel)
        {
            if (betModel.UserId != 0)
            {
                var user = await _dbContext.User.SingleAsync(x => x.Id == betModel.UserId);
                user.Balance -= betModel.Amount;
            }
            Bet bet = new Bet()
            {
                UserId = betModel.UserId,
                Amount = betModel.Amount,
                EventId = betModel.EventId,
                Multiplier = betModel.Multiplier,
                Result = null,
                //outcome property has calculation in entity
            };

            await _dbContext.AddAsync(bet);
            await _dbContext.SaveChangesAsync();

            return Ok(bet);
        }
    }
}
