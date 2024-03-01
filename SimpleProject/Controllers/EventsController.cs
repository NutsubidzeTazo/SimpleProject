using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleProject.Db;
using SimpleProject.Db.Entities;
using SimpleProject.Models.RequestModels;

namespace SimpleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private readonly SimpleProjectDbContext _dbContext;

        public EventsController(SimpleProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("event")]
        public async Task<ActionResult> CreateEvent([FromBody] EventRequestModel eventRequestModel)
        {
            Event eventEntity = new Event()
            {
                EventName = eventRequestModel.EventName,
                FirstWinnerMultiplier = eventRequestModel.FirstWinnerMultiplier,
                SecondWinnerMultiplier = eventRequestModel.SecondWinnerMultiplier,
            };

            await _dbContext.AddAsync(eventEntity);
            await _dbContext.SaveChangesAsync();

            return Ok(eventEntity);
        }
    }
}
