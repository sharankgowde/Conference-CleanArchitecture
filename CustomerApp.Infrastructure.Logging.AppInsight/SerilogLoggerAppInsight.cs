using Serilog;
using CustomerApp.Core.Interfaces;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using CustomerApp.Core.Models;

namespace CustomerApp.Infrastructure.Logging
{
    public class SerilogLoggerAppInsight : ICustomLogger
    {

        private ILogger _logger;
        private TelemetryClient _telemetryClient;
   
        public async Task LogInformation(IEnumerable<ConfigDetails> configDetails, string message)
        {

            string observabilityConn = GetObservabilityConnection(configDetails);
            InitializeLogger(observabilityConn);
   _logger.Information(message);

        }

        public async Task LogError(IEnumerable<ConfigDetails> configDetail,   string message, Exception ex)
        {

            string observabilityConn = GetObservabilityConnection(configDetail);
            InitializeLogger(observabilityConn);
            _logger.Information(message);

            _logger.Error(ex, message);
        }




        private string GetObservabilityConnection(IEnumerable<ConfigDetails> configDetails)
        {
            foreach (ConfigDetails config in configDetails)
            {
                if (config.Type == "Azure")
                {
                    return config.ObservabilityConn;
                }
            }
            return null; 
        }

        private void InitializeLogger(string observabilityConn)
        {
            var telemetryConfiguration = new TelemetryConfiguration(observabilityConn);
            _telemetryClient = new TelemetryClient(telemetryConfiguration);

            _logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.ApplicationInsights(_telemetryClient, TelemetryConverter.Traces)
                .CreateLogger();
        }
    }
}