using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace MembershipManager.Models
{
    [CollectionName("Roles")]
    public class Role : MongoIdentityRole<Guid>
    {

    }
}
