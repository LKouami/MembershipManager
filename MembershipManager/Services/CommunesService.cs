using MembershipManager.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace MembershipManager.Services
{
    public class CommunesService
    {
        private readonly IMongoCollection<Commune> _communesCollection;

        public CommunesService(
            IOptions<MembershipDatabaseSettings> memberStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                memberStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                memberStoreDatabaseSettings.Value.DatabaseName);

            _communesCollection = mongoDatabase.GetCollection<Commune>(
                memberStoreDatabaseSettings.Value.CommunesCollectionName);
        }

        public async Task<List<Commune>> GetAsync() =>
            await _communesCollection.Find(_ => true).ToListAsync();

        public async Task<Commune?> GetAsync(string id) =>
            await _communesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Commune newCommune) =>
            await _communesCollection.InsertOneAsync(newCommune);

        public async Task UpdateAsync(string id, Commune updatedCommune) =>
            await _communesCollection.ReplaceOneAsync(x => x.Id == id, updatedCommune);

        public async Task RemoveAsync(string id) =>
            await _communesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
