namespace Logger
{
    public class LogFactory
    {
        private string FilePath { get; set; } = "";
        public BaseLogger? CreateLogger(string className)
        {
            if(FilePath == "")
            {
                return null;
            }

            BaseLogger fileLog = new FileLogger()
            {
                ClassName = className,
                FilePath = this.FilePath
            };

            return fileLog;
        }

        public void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;

        }
    }
}
