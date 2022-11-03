using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class ConsoleApplication
    {
        private readonly ILogger<ConsoleApplication> logger;

        public ConsoleApplication(ILogger<ConsoleApplication> logger)
        {
            this.logger = logger;
        }
        public Task RunAsync()
        {
            logger.LogInformation("Hello World!");
            return Task.CompletedTask;
        }
    }
}
