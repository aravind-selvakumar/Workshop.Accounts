using Workshop.Accounts.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Workshop.Accounts.Services
{
     public class MongoDBService
    {

        private readonly IMongoCollection<Account> _AccountCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _AccountCollection = database.GetCollection<Account>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<List<Account>> GetAccountListAsync()
        {
            return await _AccountCollection.Find(new BsonDocument()).ToListAsync();
        }
        public async Task CreateAccountAsync(Account Account) 
        {
            await _AccountCollection.InsertOneAsync(Account);
            return;
        }
        public async Task AddToAccountAsync(string accountNumber, Account account)
        {
            FilterDefinition<Account> filter = Builders<Account>.Filter.Eq("AccountNumber", accountNumber);
           // UpdateDefinition<Account> update = Builders<Account>.Update.
                //AddToSet<string>("movieIds", movieId);
            //await _AccountCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteAccountAsync(string accountNumber)
        {
            FilterDefinition<Account> filter = Builders<Account>.Filter.Eq("AccountNumber", accountNumber);
            await _AccountCollection.DeleteOneAsync(filter);
            return;
        }

    }
}

