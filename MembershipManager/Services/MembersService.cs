using MembershipManager.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace MembershipManager.Services
{
    public class MembersService
    {
        private readonly IMongoCollection<Member> _membersCollection;

        public MembersService(
            IOptions<MembershipDatabaseSettings> memberStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                memberStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                memberStoreDatabaseSettings.Value.DatabaseName);

            _membersCollection = mongoDatabase.GetCollection<Member>(
                memberStoreDatabaseSettings.Value.MembersCollectionName);
        }

        public async Task<List<Member>> GetAsync() =>
            await _membersCollection.Find(_ => true).ToListAsync();

        public async Task<Member?> GetAsync(string id) =>
            await _membersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Member newMember) {
            newMember.CreatedDate = DateTime.Now;
            newMember.ModifiedDate = DateTime.Now;
            await _membersCollection.InsertOneAsync(newMember);
        }
         

        public async Task UpdateAsync(string id, Member updatedMember){
            updatedMember.ModifiedDate = DateTime.Now;
            updatedMember.CreatedDate = updatedMember.CreatedDate;
            await _membersCollection.ReplaceOneAsync(x => x.Id == id, updatedMember);
        } 

        public async Task RemoveAsync(string id) =>
            await _membersCollection.DeleteOneAsync(x => x.Id == id);
    }
}
