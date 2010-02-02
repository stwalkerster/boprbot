using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BlockedOpenProxyReviewerBot
{
    class Program
    {
        public const int BLCOUNT = 5;

        static void Main( string[ ] args )
        {
            new Program( args );
        }

        public Program( string[] args )
        {
            Logger.Instance( ).Log( "Welcome to BOPRbot!" );
            if( args.Length == 1 )
            {
                Logger.Instance( ).Log( "Using .hmbot configuration file." );
                Utility.DotHmbotConfigurationFile cnf = new Utility.DotHmbotConfigurationFile( args[ 0 ] );
                Logger.Instance( ).Log( "Connecting to mysql://" + cnf.mySqlUsername + ":" + cnf.mySqlPassword + "@" + cnf.mySqlServerHostname + ":" + cnf.mySqlServerPort.ToString() + "/" + cnf.mySqlSchema );
                // server, port, schema, username, password
                db = new Database( cnf.mySqlServerHostname, cnf.mySqlServerPort, cnf.mySqlSchema, cnf.mySqlUsername, cnf.mySqlPassword );
                runBot( );
            }
            else if(args.Length == 5)
            {
                Logger.Instance( ).Log( "Connecting to mysql://" + args[ 2 ] + ":" + args[ 3 ] + "@" + args[ 0 ] + ":" + args[ 1 ] + "/" + args[ 4 ] );
                    // server, port, schema, username, password
                db = new Database( args[ 0 ], uint.Parse(args[ 1 ]), args[ 4 ], args[ 2 ], args[ 3 ] );
                runBot( );
            }
            else
            {
                showHelp( );
            }
        }

        Database db;
        Blacklist[ ] DNSBL;

        void showHelp( )
        {
            Logger.Instance().Log( "Usage: [mono] bopr.exe <server> <port> <username> <password> <schema>" );
        }

        Blacklist[ ] initialiseBlacklists( )
        {
            Blacklist[ ] bl = new Blacklist[ BLCOUNT ];
            bl[ 0 ] = new Blacklist( Utility.Net.IPAddress.newFromString( "127.0.0.9" ), "dnsbl.njabl.org" );
            bl[ 1 ] = new Blacklist( Utility.Net.IPAddress.newFromString( "127.0.0.2" ), "dnsbl.proxybl.org" );
            bl[ 2 ] = new Blacklist( Utility.Net.IPAddress.newFromString( "127.0.0.2" ), "http.dnsbl.sorbs.net" );
            bl[ 3 ] = new Blacklist( Utility.Net.IPAddress.newFromString( "127.0.0.3" ), "socks.dnsbl.sorbs.net" );
            bl[ 4 ] = new Blacklist( Utility.Net.IPAddress.newFromString( "127.0.0.4" ), "misc.dnsbl.sorbs.net" );
            return bl;
        }

        void runBot( )
        {
            Logger.Instance( ).Log( "Initialising blacklists" );
            DNSBL = initialiseBlacklists( );
            Logger.Instance( ).Log( "Running BOPRbot." );
            Block[ ] proxyBlocks = db.getProxyBlocks( 0 );
            Logger.Instance( ).Log( "Fetched " + proxyBlocks.Length.ToString( ) + " blocks to check." );
            Logger.Instance( ).Log( "Will need to perform " + proxyBlocks.Length * BLCOUNT + " DNS lookups." );
            Logger.Instance( ).Log( "Starting execution" );
            foreach( Block b in proxyBlocks )
            {
                if( b.IP != null )
                {
                    int count = 0;
                    foreach( Blacklist d in DNSBL )
                    {
                        if( d.openProxy( b.IP ) )
                            count++;


                    }
                    Reporter.Instance( ).Add( b, count );
                }
            }

            Reporter.Instance( ).WriteReport( DNSBL );

        }
    }
}
