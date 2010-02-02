using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockedOpenProxyReviewerBot
{
    class IrcController
    {
        Utility.Net.Chat.IRC i;
        int pos, total;

        public IrcController( )
        {
            i = new Utility.Net.Chat.IRC( 
                "chat.eu.freenode.net", 
                8001, 
                "BOPRbot", 
                "", 
                "BOPRbot", 
                "Stwalkerster's BOPRbot" 
                );
            i.ConnectionRegistrationSucceededEvent += new Utility.Net.Chat.IRC.ConnectionRegistrationEventHandler( i_ConnectionRegistrationSucceededEvent );
            i.PrivmsgEvent += new Utility.Net.Chat.IRC.PrivmsgEventHandler( i_PrivmsgEvent );
            i.Log += new Utility.Net.Chat.IRC.LogEventHandler( i_Log );
            i.Connect( );
        }

        void i_Log( string message )
        {
            // noop
        }

        void i_PrivmsgEvent( Utility.Net.Chat.IRC.User source, string destination, string message )
        {
            if( message.ToLower( ).StartsWith( ".bopr" ) )
            {
                i.IrcPrivmsg( destination, source.Nickname + ": I have checked " + pos + " / " + total + " blocked IP addresses so far." );
            }
        }

        void i_ConnectionRegistrationSucceededEvent( )
        {
            i.IrcJoin( "##helpmebot" );
        }

      public  void setTotal( int total )
        {
            this.total = total;
        }

    public    void setPosition( int position )
        {
            pos = position;
        }

    public    void stop( )
        {
            i.IrcQuit( );
        }
    }
}
