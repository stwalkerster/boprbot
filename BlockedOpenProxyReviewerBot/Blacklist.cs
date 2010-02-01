using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
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
            
            IPAddress[] result = Dns.GetHostAddresses( dnsLookup );
            if( result.Length > 0 )
                if( result.Contains<IPAddress>( OPresult ) )
                    return true;

            return false;
        }
    }
}
