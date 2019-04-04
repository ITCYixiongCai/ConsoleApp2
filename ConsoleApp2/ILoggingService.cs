using SharedTypes;

namespace ConsoleApp2
{
    public interface ILoggingService
    {
        void Log(string toLog);
        void LogDeleteZeile(int rowIndex);
        void Log(LogLineModel toLog);
    }
}