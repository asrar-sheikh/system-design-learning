namespace SingletonDP.Services
{
    public interface ILoggerServices
    {
            void LogInfo(string message);
            void LogWarning(string message);
            void LogError(string message);
    }

    public interface ISingletonTracker
    {
        Guid Id { get; }
    }

    public interface IScopedTracker
    {
        Guid Id { get; }
    }

    public interface ITransientTracker
    {
        Guid Id { get; }
    }
}
