using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application.Contracts.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _ilogger;
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _ilogger = loggerFactory.CreateLogger<T>();
            
        }

        public void LogInformation(string message, params object[] args)
        {
            // if you want to format the message before it passed on, you can do it here
           _ilogger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
           _ilogger.LogWarning(message, args);
        }
    }
}
