using System;

namespace Logger
{

    public static class BaseLoggerMixins
    {

        public static void Error(this BaseLogger logNum, string message, params object[] paramArray)
        {
            string formattedMessage = string.Format(message, paramArray);

            if(logNum is null)
            {
                throw new ArgumentNullException(nameof(logNum));
            }

            logNum.Log(LogLevel.Error, formattedMessage);
        }

        public static void Warning(this BaseLogger logNum, string message, params object[] paramArray)
        {
            string formattedMessage = string.Format(message, paramArray);

            if (logNum is null)
            {
                throw new ArgumentNullException(nameof(logNum));
            }

            logNum.Log(LogLevel.Warning, formattedMessage);
        }

        public static void Information(this BaseLogger logNum, string message, params object[] paramArray)
        {
            string formattedMessage = string.Format(message, paramArray);

            if (logNum is null)
            {
                throw new ArgumentNullException(nameof(logNum));
            }

            logNum.Log(LogLevel.Information, formattedMessage);
        }

        public static void Debug(this BaseLogger logNum, string message, params object[] paramArray)
        {
            string formattedMessage = string.Format(message, paramArray);

            if (logNum is null)
            {
                throw new ArgumentNullException(nameof(logNum));
            }

            logNum.Log(LogLevel.Debug, formattedMessage);
        }
    }
}
