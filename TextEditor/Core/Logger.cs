using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Core
{
    public static class Logger
    {
        private static string _logDirectory { get; set; }
        private static string _logFile => Path.Combine( _logDirectory, $"{DateTime.UtcNow.ToString( "yyyy-MM-dd" )}.txt" );
        private static log4net.ILog log = log4net.LogManager.GetLogger( "Text Editor" );
        //TODO: Implement a much better logger. for now it works but it crashes each first time you start it up
        
        public static void Log ( string content )
        {
            log.Info( content );
        }

    }
}
