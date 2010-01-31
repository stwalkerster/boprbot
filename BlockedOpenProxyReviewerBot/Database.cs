using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace BlockedOpenProxyReviewerBot
{
    class Database
    {

        MySqlConnection db_connection;

        public Database( string server, uint port, string schema, string username, string password )
        {
            MySqlConnectionStringBuilder myCSB = new MySqlConnectionStringBuilder( );
            myCSB.Database = schema;
            myCSB.Server = server;
            myCSB.Port = port;
            myCSB.UserID = username;
            myCSB.Password = password;
            string connStr = myCSB.ToString( );

           // myCSB.ToString( );

            db_connection = new MySqlConnection( connStr );
            db_connection.Open( );
        }

        public Block[] getProxyBlocks( )
        {
            MySqlCommand cmd = new MySqlCommand( "SELECT * FROM ipblocks i WHERE ipb_reason LIKE \"%proxy%\";" );
            cmd.Connection = db_connection;
            MySqlDataReader dr = cmd.ExecuteReader( );

            ArrayList blocks = new ArrayList( );
            
            while( dr.Read() )
            {
                object[ ] vals = new object[ dr.FieldCount ];
                dr.GetValues( vals );

                blocks.Add(Block.newFromDataRow( vals ));
            }

            dr.Close( );

            Block[ ] bA = new Block[ blocks.Count ];
            blocks.CopyTo( bA );
            return bA;
        }

    }
}
