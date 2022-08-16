using MembershipManager.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace MembershipManager.Services
{
    public class RolesService
    {
        private readonly IMongoCollection<Role> _rolesCollection;

        public RolesService(
            IOptions<MembershipDatabaseSettings> memberStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                memberStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                memberStoreDatabaseSettings.Value.DatabaseName);

            _rolesCollection = mongoDatabase.GetCollection<Role>(
                memberStoreDatabaseSettings.Value.RolesCollectionName);
        }

        public async Task<List<Role>> GetAsync() =>
            await _rolesCollection.Find(_ => true).ToListAsync();

        public async Task<Role?> GetAsync(string id) =>
            await _rolesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Role newRole) =>
            await _rolesCollection.InsertOneAsync(newRole);

        public async Task UpdateAsync(string id, Role updatedRole) =>
            await _rolesCollection.ReplaceOneAsync(x => x.Id == id, updatedRole);

        public async Task RemoveAsync(string id) =>
            await _rolesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
