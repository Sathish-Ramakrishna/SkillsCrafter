using SkillsCrafter.Core.Implementation.AppData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsCrafter.Core.Implementation.ADO
{
    public class ADOConnection
    {
        #region Properties

        public DbConnection connection = null;

        #endregion

        #region Methods.Public 

        #region Connection.Open 

        public DbConnection OpenConnection()
        {

            DbProviderFactory provider = DbProviderFactories.GetFactory(AppSettings.DatabaseProvider);
            //DbConnection con = provider.CreateConnection();
            //con.ConnectionString = @"Data Source=.\SQLExpress;Integrated Security=True;AttachDBFilename=D:\Application\Data\Database.mdf";
            //DbCommand com = provider.CreateCommand();
            //
            var connectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            //
            connection = provider.CreateConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            //
            return connection;
        }

        #endregion

        #region Connection.Close 

        public void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        #endregion
        
        #endregion
    }
}
