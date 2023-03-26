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
        public async Task<List<Account>> GetAccount()
        {
            return await _mongoDBService.GetAccountListAsync();
        }
        
        
       
        [HttpPost]
        public async Task<IActionResult> PostAccount([FromBody] Account Account)
        {
            await _mongoDBService.CreateAccountAsync(Account);
            return CreatedAtAction(nameof(GetAccount), new { id = Account.Id }, Account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToAccount(string id, [FromBody] Account account)
        {
            await _mongoDBService.AddToAccountAsync(id, account);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            await _mongoDBService.DeleteAccountAsync(id);
            return NoContent();
        }
    }
}

