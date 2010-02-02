using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;

namespace BlockedOpenProxyReviewerBot
{
    class Reporter
    {
        protected Reporter( )
        {
            blocks = new ArrayList( );

        }
        private static Reporter _instance;
        public static Reporter Instance( )
        {
            if( _instance == null )
                _instance = new Reporter( );
            return _instance;
        }

        string xmlTemplate;
        ArrayList blocks;

        public void Add(Block b, int BlacklistCount)
        {
            if( BlacklistCount > Program.BLCOUNT )
                throw new ArgumentOutOfRangeException( );

            blocks.Add( new BlackListCheckResult( BlacklistCount, b ) );
        }

        public void WriteReport( Blacklist[] blacklists )
        {
          XmlWriter x =   XmlWriter.Create( "bopr-" + DateTime.Now.ToString( "yyyyMMddHHmmss" ) + ".xml" );

          x.WriteRaw( "<?xml-stylesheet type=\"text/xsl\" href=\"bopr-xslt.xslt\"?>" );

          x.WriteStartElement( "boprbot" );
          
            x.WriteStartElement( "boprblacklist" );
          foreach( Blacklist bl in blacklists )
          {
              x.WriteStartElement( "blacklist" );
              x.WriteStartElement( "suffix" );
              x.WriteString( bl.getSuffix() );
              x.WriteEndElement( );
              x.WriteStartElement( "hitip" );
              x.WriteString( bl.getHitIpAddress().ToString() );
              x.WriteEndElement( );
              x.WriteEndElement( );
          }
          x.WriteEndElement( );

          x.WriteStartElement( "bopri" );
          foreach( BlackListCheckResult item in blocks )
          {
              x.WriteStartElement( "ipblock" );

              x.WriteStartElement( "ip" );
              x.WriteString( item.blockInfo.IP.ToString() );
              x.WriteEndElement( );

              x.WriteStartElement( "timestamp" );
              x.WriteString( item.blockInfo.Date.ToString("yyyy-MM-dd HH:mm:ss" ) );
              x.WriteEndElement( );

              x.WriteStartElement( "id" );
              x.WriteString( item.blockInfo.ID.ToString() );
              x.WriteEndElement( );

              x.WriteStartElement( "expiry" );
              x.WriteString( item.blockInfo.Expiry );
              x.WriteEndElement( );

              x.WriteStartElement( "blocker" );
              x.WriteString( item.blockInfo.By );
              x.WriteEndElement( );

              x.WriteStartElement( "hits" );
              x.WriteString( item.blackListCount.ToString() );
              x.WriteEndElement( );

              x.WriteEndElement( );
          }
          x.WriteEndElement( );

          x.WriteEndElement( );

          x.Flush( );
        }
    }
}
