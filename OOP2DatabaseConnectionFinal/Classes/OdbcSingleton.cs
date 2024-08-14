using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2DatabaseConnectionFinal
{
    internal class OdbcSingleton
    {
        private static OdbcConnection instance = null;
        private static readonly object padlock = new object();

        OdbcSingleton()
        {
        }

        public static OdbcConnection Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new System.Data.Odbc.OdbcConnection(OOP2DatabaseConnectionFinal.Properties.Settings.Default.ConnectionString);
                        instance.Open();
                    }
                    return instance;
                }
            }
        }
    }
}
