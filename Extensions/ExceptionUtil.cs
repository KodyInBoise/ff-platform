using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ff_platform.Extensions
{
    public class ExceptionWrapper
    {
        public DateTime Timestamp { get; private set; }
        public string Type { get; set; }
        public string Message { get; set; }

        public ExceptionWrapper(Exception ex)
        {
            Timestamp = DateTime.Now;
            Type = ex.GetType().ToString();
            Message = ex.Message;
        }
    }


    public class ExceptionUtil
    {
        public static ExceptionUtil Instance { get; private set; }

        static string _exceptionLogPath { get; set; }

        object _lock { get; set; }


        public ExceptionUtil()
        {
            _exceptionLogPath = GetExceptionLogPath();
        }

        private string GetExceptionLogPath()
        {
            var directory = Directory.GetCurrentDirectory();

            return Path.Combine(directory, "exceptions.log");
        }

        public static void Initialize()
        {
            Instance = new ExceptionUtil();
        }

        public static void Handle(Exception ex)
        {
            var wrapper = new ExceptionWrapper(ex);

            Task.Run(() => Instance.WriteException(wrapper));
        }

        private void WriteException(ExceptionWrapper ex)
        {
            lock (_lock)
            {
                try
                {
                    var exceptions = GetExceptions();

                    exceptions.Add(ex);

                    File.WriteAllText(_exceptionLogPath, JsonConvert.SerializeObject(exceptions));
                }
                catch { }
            }
        }

        public static List<ExceptionWrapper> GetExceptions()
        {
            var content = File.ReadAllText(_exceptionLogPath);

            return Deserializer.FromJson<List<ExceptionWrapper>>(content);
        }
    }
}
