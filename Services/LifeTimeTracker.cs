namespace SingletonDP.Services
{
    public class LifeTimeTracker:ISingletonTracker, IScopedTracker, ITransientTracker
    {
        public Guid Id { get; }
        public LifeTimeTracker()
        {
            Id = Guid.NewGuid();
        }   
    
    }
}
