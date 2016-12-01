namespace Audit.Interfaces
{
    public interface ILoggerStorage
    {
        void Store();
        bool IsInitialized { get; set; }
        void Initialize();
    }
}