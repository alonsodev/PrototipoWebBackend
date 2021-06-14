using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Logging
{
    public interface ILogging
    {
        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="message">The debug message</param>        
        void Debug(string message);

        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="exception">Exception to write in debug message</param>
        void Debug(string message, Exception exception);

        /// <summary>
        /// Log debug message 
        /// </summary>
        /// <param name="item">The item with information to write in debug</param>
        void Debug(object item);

        /// <summary>
        /// Log FATAL error
        /// </summary>
        /// <param name="message">The message of fatal error</param>        
        void Fatal(string message);

        /// <summary>
        /// log FATAL error
        /// </summary>
        /// <param name="message">The message of fatal error</param>
        /// <param name="exception">The exception to write in this fatal message</param>
        void Fatal(string message, Exception exception);

        /// <summary>
        /// Log message information 
        /// </summary>
        /// <param name="message">The information message to write</param>        
        void LogInfo(string message);

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message">The warning message to write</param>        
        void LogWarning(string message);

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>        
        void LogError(string message);

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>
        /// <param name="exception">The exception associated with this error</param>        
        void LogError(string message, Exception exception);
    }
}
