using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        private readonly IDbWrapper<ErrorLog> _errorLogDbWrapper;

        public ErrorLogRepository(IDbWrapper<ErrorLog> errorLogDbWrapper)
        {
            _errorLogDbWrapper = errorLogDbWrapper;
        }


        public void LogError(ErrorLog errorInfo)
        {
            _errorLogDbWrapper.Insert(errorInfo);
        }
}
}
