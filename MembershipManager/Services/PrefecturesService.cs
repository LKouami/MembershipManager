using MembershipManager.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace MembershipManager.Services
{
    public class PrefecturesService
    {
        private readonly IMongoCollection<Prefecture> _prefecturesCollection;

        public PrefecturesService(
            IOptions<MembershipDatabaseSettings> memberStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                memberStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                memberStoreDatabaseSettings.Value.DatabaseName);

            _prefecturesCollection = mongoDatabase.GetCollection<Prefecture>(
                memberStoreDatabaseSettings.Value.PrefecturesCollectionName);
        }

        public async Task<List<Prefecture>> GetAsync() =>
            await _prefecturesCollection.Find(_ => true).ToListAsync();

        public async Task<Prefecture?> GetAsync(string id) =>
            await _prefecturesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Prefecture newPrefecture){
            newPrefecture.CreatedDate = DateTime.Now;
            newPrefecture.ModifiedDate = DateTime.Now;
            await _prefecturesCollection.InsertOneAsync(newPrefecture);
        }

        public async Task UpdateAsync(string id, Prefecture updatedPrefecture) {
            updatedPrefecture.ModifiedDate = DateTime.Now;
            updatedPrefecture.CreatedDate = updatedPrefecture.CreatedDate;
            await _prefecturesCollection.ReplaceOneAsync(x => x.Id == id, updatedPrefecture);
        }

        public async Task RemoveAsync(string id) =>
            await _prefecturesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
