using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace BlockedOpenProxyReviewerBot
{
    class Blacklist
    {
        public Blacklist( IPAddress openProxyResult, string zoneSuffix )
        {
            OPresult = openProxyResult;
            suffix = zoneSuffix;
        }

        IPAddress OPresult;
        string suffix;


        string GetDnsHost( IPAddress ip)
        {
           return Utility.Net.IPAddress.getReversedIpString( ip ) + "." + suffix;
        }

        public bool openProxy( IPAddress ip )
        {
            string dnsLookup = GetDnsHost( ip );
            try
            {
                IPAddress[ ] result = Dns.GetHostAddresses( dnsLookup );
                if( result.Length > 0 )
                    if( result.Contains<IPAddress>( OPresult ) )
                    {
                        Logger.Instance( ).Hit( dnsLookup );
                        return true;
                    }
            }
            catch( SocketException ex )
            {

            }
            Logger.Instance( ).Miss( dnsLookup );
            return false;
        }
    }
}
