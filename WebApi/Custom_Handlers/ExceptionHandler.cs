using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using BusinessLayer.Services;
using DataAccessLayer.Repositories;
using System;
using System.IO;
using System.Web.Http.Filters;

namespace WebApi.Custom_Handlers
{
    public class ExceptionHandler : ExceptionFilterAttribute
    {
        private readonly IErrorLogService _errorLogService;
        public ExceptionHandler(IErrorLogService errorLogService)
        {
            _errorLogService = errorLogService;
        }

        public ExceptionHandler()
        {
        }


        public override void OnException(HttpActionExecutedContext context)
        {
            //Path to store the log file
            string path = @"C:\ProgramData\JonasCodingErrorLogs.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            //Appending all the exceptions to the text file (It could be improvised by adding NLog or other package)
            File.AppendAllLines(path, new[] { System.DateTime.UtcNow + " | " + context.Exception.Message + " | " + context.Exception.StackTrace });
        }

    }
}
