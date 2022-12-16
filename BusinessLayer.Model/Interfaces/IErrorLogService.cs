using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface IErrorLogService
    {
        void LogError(ErrorLogInfo errorInfo);
    }
}
