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
                db = new Database( args[ 0 ], uint.Parse(args[ 1 ]), args[ 4 ], args[ 2 ], args[ 3 ] );
                DNSBL = initialiseBlacklists( );
                runBot( );
            }
        }

        Database db;
        Blacklist[ ] DNSBL;

        void showHelp( )
        {
            Console.WriteLine( "Usage: [mono] bopr.exe <server> <port> <username> <password> <schema>" );
        }

        Blacklist[ ] initialiseBlacklists( )
        {
            Blacklist[ ] bl = new Blacklist[ 5 ];
            bl[ 0 ] = new Blacklist( Utility.Net.IPAddress.newFromString( "127.0.0.9" ), "dnsbl.njabl.org" );
            bl[ 1 ] = new Blacklist( Utility.Net.IPAddress.newFromString( "127.0.0.2" ), "dnsbl.proxybl.org" );
            bl[ 2 ] = new Blacklist( Utility.Net.IPAddress.newFromString( "127.0.0.2" ), "http.dnsbl.sorbs.net" );
            bl[ 3 ] = new Blacklist( Utility.Net.IPAddress.newFromString( "127.0.0.3" ), "socks.dnsbl.sorbs.net" );
            bl[ 4 ] = new Blacklist( Utility.Net.IPAddress.newFromString( "127.0.0.4" ), "misc.dnsbl.sorbs.net" );
            return bl;
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
