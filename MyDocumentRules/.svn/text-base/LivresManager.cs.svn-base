using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyConnector;
using MyConnector.Interfaces;
using MyConnector.Model;

using NHibernate;
using NHibernate.Criterion;

namespace MyDocumentRules
{
    public class LivresManager : ILivresManager
    {
        #region private
        /// <summary>
        ///     Session NHibernate
        /// </summary>
        private ISession _laSession = null;

        internal LivresManager(ISession laSession)
        {
            _laSession = laSession;
        }
        #endregion

        #region ILivresManager Members

        List<Livre> ILivresManager.getLivres()
        {
            IList ldocs = _laSession.CreateCriteria(typeof(Livre)).List();
            return UtilHelper.ConvertToList<Livre>(ldocs);
        }

        Livre ILivresManager.getLivre(int id)
        {
            IList ldocs = _laSession.CreateCriteria(typeof(Livre))
                .Add(Expression.Eq("Id", id)).List();

            return ldocs.Count > 0 ? ldocs[0] as Livre : null;
        }

        void ILivresManager.saveLivre(Livre livre)
        {
            try
            {
                _laSession.BeginTransaction();

                _laSession.SaveOrUpdate(livre);

                _laSession.Transaction.Commit();
            }
            catch(Exception e)
            {
                _laSession.Transaction.Rollback();
                throw e;
            }
        }

        void ILivresManager.delLivre(int docid)
        {
            try
            {
                _laSession.BeginTransaction();

                Livre ldel = ((ILivresManager)this).getLivre(docid);
                _laSession.Delete(ldel);
                _laSession.Transaction.Commit();
            }
            catch
            {
                _laSession.Transaction.Rollback();
            }
        }

        List<Livre> ILivresManager.searchLivres(string keywords)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
