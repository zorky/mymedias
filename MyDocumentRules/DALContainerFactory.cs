using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyConnector.Interfaces;
using MyCommon;

using NHibernate;

namespace MyDocumentRules
{
    public class ContainerFactory : IDALContainerFactory
    {
        public ContainerFactory() { }

        #region private

        private static NHibernate.ISessionFactory _laFactory = null;

        internal static NHibernate.ISessionFactory LaFactory
        {
            get
            {
                if (_laFactory == null)
                    _laFactory = NHibernateSessionFactory.GetSessionFactory("SQLite",
                        new List<String>(new String[] { "MyDocumentRules" }));
                return _laFactory;
            }
            set { _laFactory = value; }
        }
        #endregion

        #region IDALContainerFactory Members

        IDALContainer IDALContainerFactory.getContainer()
        {
            DALContainer mycontainer = new DALContainer();
            mycontainer.laSession = LaFactory.OpenSession();

            return mycontainer;
        }

        #endregion
    }
}
