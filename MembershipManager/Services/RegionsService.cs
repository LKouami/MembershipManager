using MembershipManager.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace MembershipManager.Services
{
    public class RegionsService
    {
        private readonly IMongoCollection<Region> _regionsCollection;

        public RegionsService(
            IOptions<MembershipDatabaseSettings> memberStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                memberStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                memberStoreDatabaseSettings.Value.DatabaseName);

            _regionsCollection = mongoDatabase.GetCollection<Region>(
                memberStoreDatabaseSettings.Value.RegionsCollectionName);
        }

        public async Task<List<Region>> GetAsync() =>
            await _regionsCollection.Find(_ => true).ToListAsync();

        public async Task<Region?> GetAsync(string id) =>
            await _regionsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Region newRegion) =>
            await _regionsCollection.InsertOneAsync(newRegion);

        public async Task UpdateAsync(string id, Region updatedRegion) =>
            await _regionsCollection.ReplaceOneAsync(x => x.Id == id, updatedRegion);

        public async Task RemoveAsync(string id) =>
            await _regionsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
