using DataAccessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.Interfaces
{
    public interface IErrorLogRepository
    {
        void LogError(ErrorLog errorInfo);
    }
}
