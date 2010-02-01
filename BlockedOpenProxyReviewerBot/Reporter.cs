using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

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

        public void WriteReport( )
        {
            //System.Xml.XmlWriter.Create(
        }
    }
}
