using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.Extensions
{
    public class UploadUtil
    {
        readonly string rootPath;

        public UploadUtil()
        {
            rootPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
        }
    }
}
