namespace Stregsystem.Core.Logging
{
    /// <summary>
    /// Provides logging capabilities.
    /// </summary>
    public interface ILogger
    {
        void Log(string msg);
        void Close();
    }
}
