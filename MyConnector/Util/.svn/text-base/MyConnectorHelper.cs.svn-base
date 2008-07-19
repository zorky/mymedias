using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;

using MyConnector.Interfaces;

namespace MyConnector
{
    public class MyConnectorHelper
    {
        /// <summary>
        ///     Instanciation du controleur principal pour servir les managers
        /// </summary>
        /// <returns></returns>
        public static IManagerControler GetManagerController()
        {
            NameValueCollection myconf = ConfigurationManager.GetSection("IOCManagerDAL/ManagerControllerConfig") as NameValueCollection;

            Assembly AssemblyB = Assembly.Load(myconf["ManagerControllerDLL"]);
            Type ManagerType = AssemblyB.GetType(myconf["ManagerControllerName"]);
            IManagerControler _mgr = (IManagerControler)Activator.CreateInstance(ManagerType);

            return _mgr;
        }

        /// <summary>
        ///     Instanciation de l'ORM utilisé
        /// </summary>
        /// <returns></returns>
        public static IDALContainerFactory GetWorkingContext()
        {
            IDALContainerFactory _factory;
            NameValueCollection myconf = ConfigurationManager.GetSection("IOCManagerDAL/ContextDALFactoryConfig") as NameValueCollection;

            Assembly AssemblyB = Assembly.Load(myconf["ContextFactoryDLL"]);
            Type ManagerType = AssemblyB.GetType(myconf["ContextFactoryName"]);
            _factory = (IDALContainerFactory)Activator.CreateInstance(ManagerType);

            return _factory;
        }
    }
}
