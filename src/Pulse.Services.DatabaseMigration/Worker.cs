namespace Pulse.Services.DatabaseMigration
{
    using Microsoft.EntityFrameworkCore;

    using Pulse.Core.Data;

    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<Worker> _logger;

        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger)
        {
            this._serviceProvider = serviceProvider;
            this._logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this._logger.LogInformation("Starting database migration process.");

            try
            {
                using var scope = this._serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<PulseDbContext>();

                await dbContext.Database.MigrateAsync(stoppingToken);
                this._logger.LogInformation("Database migrations applied successfully.");
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "An error occurred while applying database migrations.");
                throw;
            }
        }
    }
}
