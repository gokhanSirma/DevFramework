using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramwork.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerService
    {
        private ILog _log;
        public LoggerService(ILog log)
        {
            _log = log;
        }
        
        public bool IsDebugEnabled
        {
            get { return _log.IsDebugEnabled; }
        }
        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        
        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _log.Info(logMessage);
            }
        }
        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
            {
                _log.Error(logMessage);
            }
        }
        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(logMessage);
            }
        }
        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(logMessage);
            }
        }
        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
            {
                _log.Debug(logMessage);
            }
        }
    }
}
