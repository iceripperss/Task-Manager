namespace CCL.Security
{
    public class Progger
        : User
    {
        public Progger(int userId, string name, int catalogId) 
            : base(userId, name, catalogId, nameof(Progger))
        {
        }
    }
}