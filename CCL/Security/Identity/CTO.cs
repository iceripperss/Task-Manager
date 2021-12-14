namespace CCL.Security
{
    public class CTO
        : User
    {
        public CTO(int userId, string name, int catalogId) 
            : base(userId, name, catalogId, nameof(CTO))
        {
        }
    }
}