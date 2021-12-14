namespace CCL.Security
{
    abstract public class User
    {
        public User(int userId, string name, int catalogId, string userType)
        {
            UserId = userId;
            Name = name;
            CatalogID = catalogId;
            UserType = userType;
        }
        public int UserId { get; }
        public string Name { get; }
        public int CatalogID { get; }
        protected string UserType { get; }
    }
}