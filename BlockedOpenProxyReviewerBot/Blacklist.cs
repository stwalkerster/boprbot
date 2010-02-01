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


        string GetDnsHost( )
        {
           return Utility.Net.IPAddress.getReversedIpString( OPresult ) + "." + suffix;
        }

        public bool openProxy( IPAddress ip )
        {
            IPAddress[] result = Dns.GetHostAddresses( GetDnsHost( ) );
            if( result.Length > 0 )
                if( result.Contains<IPAddress>( OPresult ) )
                    return true;

            return false;
        }
    }
}
