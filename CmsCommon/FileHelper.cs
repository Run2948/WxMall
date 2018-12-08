using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cms.Common
{
    public class FileHelper
    {
        /// <summary>
        /// 文件写入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="context"></param>
        public static void Write(string path, string context)
        {
            StreamWriter f1 = new System.IO.StreamWriter(path, true, System.Text.Encoding.UTF8);
            f1.WriteLine(context);
            f1.Flush();
            f1.Close();
            f1.Dispose();
        }
    }
}
