using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameLibrary.Handlers.Logging
{
    public class JsonTraceListener : TraceListener
    {
        private string _logPath;

        public JsonTraceListener(string logPath = "Gamelog.json")
        {
            _logPath = logPath;
        }

        public override void Write(string? message)
        {
            StreamWriter stream = new StreamWriter("_logPath", true);
            using (stream)
            {
                var msg = JsonSerializer.Serialize(new { Date = DateTime.Now, Message = message });
                stream.Write(msg);
                stream.Flush();
            }
        }

        public override void WriteLine(string? message)
        {
            StreamWriter stream = new StreamWriter(_logPath, true);
            using (stream)
            {
                var msg = JsonSerializer.Serialize(new { Date = DateTime.Now, Message = message });
                stream.WriteLine(msg);
                stream.Flush();
            }
        }
    }
}