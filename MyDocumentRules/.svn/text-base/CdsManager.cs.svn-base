using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyConnector;
using MyConnector.Interfaces;
using MyConnector.Model;

using NHibernate;

namespace MyDocumentRules
{
    public class CdsManager : ICdsManager
    {
        #region private
        /// <summary>
        ///     Session NHibernate
        /// </summary>
        private ISession _laSession = null;

        internal CdsManager(ISession laSession)
        {
            _laSession = laSession;
        }
        #endregion
        #region ICdManager Members
        
        List<Media> ICdsManager.getMedias()
        {
            return UtilHelper.ConvertToList<Media>(_laSession.CreateCriteria(typeof(Media)).List());
        }

        List<Cd> ICdsManager.getCds()
        {
            return UtilHelper.ConvertToList<Cd>(_laSession.CreateCriteria(typeof(Cd)).List());
        }

        public Cd getCd(int id)
        {
            throw new NotImplementedException();
        }

        void ICdsManager.saveCd(Cd cd)
        {
            try
            {
                _laSession.BeginTransaction();

                _laSession.SaveOrUpdate(cd);

                _laSession.Transaction.Commit();
            }
            catch (Exception e)
            {
                _laSession.Transaction.Rollback();
                throw e;
            }
        }

        public void delCd(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cd> searchCds(string keywords)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
