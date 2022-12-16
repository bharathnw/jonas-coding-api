using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ErrorLogService : IErrorLogService
    {
        private readonly IErrorLogRepository _errorLogRepository;
        private readonly IMapper _mapper;
        public ErrorLogService(IErrorLogRepository errorLogRepository, IMapper mapper)
        {
            _errorLogRepository = errorLogRepository;
            _mapper = mapper;
        }
        public void LogError(ErrorLogInfo errorInfo)
        {
            _errorLogRepository.LogError(_mapper.Map<ErrorLog>(errorInfo));
        }
    }
}
