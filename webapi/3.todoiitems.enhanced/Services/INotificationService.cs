namespace TodoItems.Services
{
    using System;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    public interface INotificationService
    {
        void ToDoItemDeleted(long id);
    }

    public class DummyNotificationService : INotificationService
    {
        private readonly ILogger<DummyNotificationService> logger;
        private string value;

        // #4 - use a configuration
        // #5 - use a logger
        public DummyNotificationService(ILogger<DummyNotificationService> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.value = configuration.GetValue<string>("SomeConfig");
        }

        public void ToDoItemDeleted(long id)
        {
            // 6. throw an exception
            if (id % 2 == 0)
            {
                throw new InvalidOperationException("Some exception");
            }

            this.logger.LogInformation($"Item with id {id} deleted.");
        }
    }
}
