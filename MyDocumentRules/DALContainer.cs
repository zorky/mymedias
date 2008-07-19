using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyConnector.Interfaces;

using NHibernate;

namespace MyDocumentRules
{
    public class DALContainer : IDALContainer
    {
        #region private
        private ISession _laSession;
        internal ISession laSession
        {
            set { _laSession = value; }
        }
        #endregion

        #region IDALContainer Members

        object IDALContainer.GetWorkingContext()
        {
            return _laSession;
        }

        void IDALContainer.ClearWorkingContext()
        {
            if (_laSession != null && _laSession.IsOpen)
                _laSession.Close();
        }

        #endregion
    }    
}
