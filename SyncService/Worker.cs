namespace SyncService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var source = _configuration["SyncOptions:Source"];
                var target = _configuration["SyncOptions:Target"];

                if (source == null)
                    _logger.LogCritical("SyncOptions:Source configuration doesn't exists");
                else
                    _logger.LogInformation("Source: {source}", source);

                if (target == null)
                    _logger.LogCritical("SyncOptions:Target configuration doesn't exists");
                else
                    _logger.LogInformation("Target: {target}", target);


                await Task.Delay(5_000, stoppingToken);
            }
        }
    }
}
