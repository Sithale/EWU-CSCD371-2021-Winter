using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {

        public string FilePath { get; set; } = "";

        public override void Log(LogLevel logLevel, string message)
        {
            using StreamWriter sw = File.CreateText(FilePath);

            sw.WriteLine($"{DateTime.Now} {this.ClassName} {logLevel} {message}");
        }
    }
}
