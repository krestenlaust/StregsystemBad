namespace Stregsystem.Core.Logging.Loggers
{
    public class FileLogger : ILogger
    {
        readonly FileStream fs;
        readonly StreamWriter sw;

        public FileLogger(string filepath)
        {
            fs = File.OpenWrite(filepath);
            sw = new StreamWriter(fs);
        }

        public void Close()
        {
            sw.Flush();
            sw.Close();
        }

        public void Log(string msg)
        {
            sw.WriteLine(msg);
        }
    }
}
