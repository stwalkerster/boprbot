using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockedOpenProxyReviewerBot
{
    class Program
    {
        static void Main( string[ ] args )
        {
            new Program( args );
        }

        public Program( string[] args )
        {
            if( args.Length != 5 )
            {
                showHelp( );
            }
            else
            {
                db = new Database( args[ 0 ], (uint)args[ 1 ], args[ 4 ], args[ 2 ], args[ 3 ] );
                runBot( );
            }
        }

        Database db;

        void showHelp( )
        {
            Console.WriteLine( "Usage: mono bopr.exe <server> <port> <username> <password> <schema>" );
        }

        void runBot( )
        {
            Block[ ] proxyBlocks = db.getProxyBlocks( );

            foreach( Block b in proxyBlocks )
            {
                
            }
        }
    }
}
