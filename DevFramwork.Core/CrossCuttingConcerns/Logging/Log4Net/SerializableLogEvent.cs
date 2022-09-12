﻿using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramwork.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]//önemli unutma
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;
        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        public string Username => _loggingEvent.UserName;
        public object MessageObject => _loggingEvent.MessageObject;
    }
}
