using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyConnector.Model;
using MyConnector.Interfaces;

using NHibernate;
//using NHibernate.Expression;
using NHibernate.Criterion;

namespace MyDocumentRules
{
    public class SearchManager : ISearchManager
    {
        #region private
        /// <summary>
        ///     Session NHibernate
        /// </summary>
        private ISession _laSession = null;

        internal SearchManager(ISession laSession)
        {
            _laSession = laSession;
        }
        #endregion

        #region ISearchManager Members

        public List<Result> Search(string keywords)
        {            
            throw new NotImplementedException();
        }

        #endregion
    }
}
