using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockedOpenProxyReviewerBot
{
    class Logger
    {
        private static Logger _instance;
        protected Logger( )
        {

        }
        public static Logger Instance( )
        {
            if( _instance == null )
                _instance = new Logger( );
            return _instance;
        }

        public void Log( string message )
        {
            printDate( );
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine( message );
        }

        public void Hit( string hostname )
        {
            printDate( );
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write( "HIT on " );
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine( hostname );
        }

        public void Miss( string hostname )
        {
            printDate( );
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write( "MISS on " );
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine( hostname );
        }

        private void printDate( )
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write( "[" + DateTime.Now.ToString( "yyyy/MM/dd HH:mm:ss" ) + "] " );
        }
    }
}
