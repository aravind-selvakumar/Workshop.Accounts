using Microsoft.AspNetCore.Mvc;
using Workshop.Accounts.Models;
using Workshop.Accounts.Services;

namespace Workshop.Accounts.Controllers
{

    [Controller]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public AccountController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }


        [HttpGet]
        public async Task<List<Account>> Get()
        {
            return await _mongoDBService.GetAsync();
        }
        
        
       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Account Account)
        {
            await _mongoDBService.CreateAsync(Account);
            return CreatedAtAction(nameof(Get), new { id = Account.Id }, Account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToAccount(string id, [FromBody] string movieId)
        {
            await _mongoDBService.AddToAccountAsync(id, movieId);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }
    }
}

