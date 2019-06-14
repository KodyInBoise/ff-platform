using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.Extensions
{
    public class LoggingUtil
    {
        readonly string _rootPath;
        readonly string _infoPath;
        readonly string _errorPath;

        object _infoLock { get; set; }
        object _errorLock { get; set; }

        static LoggingUtil _instance { get; set; }

        public LoggingUtil()
        {
            _instance = this;

            _rootPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

            if (!Directory.Exists(_rootPath))
            {
                Directory.CreateDirectory(_rootPath);
            }

            _infoPath = Path.Combine(_rootPath, "Info.txt");
            _errorPath = Path.Combine(_rootPath, "Errors.txt");

            _infoLock = new object();
            _errorLock = new object();
        }

        public void Info(string content)
        {
            var entry = $"{DateTime.Now.ToString()} | {content}";
            lock (_instance._infoLock)
            {
                File.AppendAllLines(_instance._infoPath, new string[] { entry });
            }
        }

        public void Error(Exception ex)
        {
            var entry = $"{DateTime.Now.ToString()} | {ex.Message}";
            lock (_instance._errorLock)
            {
                File.AppendAllLines(_instance._errorPath, new string[] { entry });
            }
        }
    }
}
