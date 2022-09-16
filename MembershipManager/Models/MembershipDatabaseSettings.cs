namespace MembershipManager.Models
{
    public class MembershipDatabaseSettings: Common
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string UsersCollectionName { get; set; } = null!;
        public string MembersCollectionName { get; set; } = null!;

        public string CommunesCollectionName { get; set; } = null!;

        public string PrefecturesCollectionName { get; set; } = null!;

        public string RegionsCollectionName { get; set; } = null!;
    }
}
