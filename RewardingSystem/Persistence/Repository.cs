namespace RewardingSystem.Persistence
{
    public class Repository
    {
        protected DatabaseContext Context { get; set; }

        public Repository(DatabaseContext context)
        {
            this.Context = context;
        }
    }
}