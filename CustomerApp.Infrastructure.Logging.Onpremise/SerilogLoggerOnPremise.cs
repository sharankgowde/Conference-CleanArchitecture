using CustomerApp.Core.Interfaces;
using CustomerApp.Core.Models;
using Serilog;
using Serilog.Core; 
using System.Net.Http.Headers;

namespace CustomerApp.Infrastructure.Logging.Onpremise
{
    public class SerilogLoggerOnPremise : ICustomLogger
    {
        private readonly ILogger _logger;
        public SerilogLoggerOnPremise()
        {
            _logger = new LoggerConfiguration().WriteTo.File(@"C:\Users\Sharanbasavaraj.G\OneDrive - EY\Documents\EY_Office\EY_Office\Professional\Conferance\azConference\Logfile.log").CreateLogger();

            Log.Information("this is a information");

        }
        public async Task LogInformation(IEnumerable<ConfigDetails> configDetails, string message)
        {
            _logger.Information(message);
        }
        public async Task LogError(IEnumerable<ConfigDetails> configDetails, string message, Exception ex)
        {
        
            _logger.Error(ex, message);
        }

       
    }
}