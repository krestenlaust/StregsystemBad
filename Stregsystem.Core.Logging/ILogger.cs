namespace Stregsystem.Core.Logging
{
    public interface ILogger
    {
        void Log(string msg);
        void Close();
    }
}
