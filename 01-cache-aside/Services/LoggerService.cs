namespace SingletonDP.Services
{
    public class LoggerService : ILoggerServices
    {
        private readonly Guid _instanceId;
        public LoggerService()
        {
            _instanceId = Guid.NewGuid();
        }
        public void LogError(string message)
        {
            Console.WriteLine($"Error id :{_instanceId} message {message}");
         
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"Info  id :{_instanceId} message {message}");
    
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"Warning  id :{_instanceId} message {message}");
          
        }
    }
}
