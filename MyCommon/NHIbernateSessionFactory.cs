using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCommon
{    
    public class NHibernateSessionFactory
    {
        public static NHibernate.ISessionFactory GetSessionFactory(
            string connectionString, List<String> DllNames)
        {
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
            // set provider & driver properties
            cfg.Properties.Add(
            "connection.provider",
                "NHibernate.Connection.DriverConnectionProvider");

            cfg.Properties.Add(
            "connection.driver_class",
                "NHibernate.Driver.SQLite20Driver");
            
            cfg.Properties.Add(
            "dialect",
                "NHibernate.Dialect.SQLiteDialect");

            cfg.Properties.Add(
            "max_fetch_depth","-1"); // allows for unlimited outer joins (recommeded value is maximum 4

            cfg.Properties.Add(
            "connection.connection_string",
                 ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);            

            cfg.Properties.Add("connection.isolation", "ReadCommitted");            
            cfg.Properties.Add("query.substitutions", "true 1, false 0");

            // here we add all the needed assemblies that contain mappings or objects
            foreach (String assemblyName in DllNames)
                cfg.AddAssembly(System.Reflection.Assembly.Load(assemblyName));

            return cfg.BuildSessionFactory();
        }
    }
}
