using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyConnector.Model;
using MyConnector.Interfaces;
using MyConnector;

using NHibernate;
using NHibernate.Criterion;

namespace MyDocumentRules
{
    public class AuteurManager : IAuteursManager
    {
        #region private
        /// <summary>
        ///     Session NHibernate
        /// </summary>
        private ISession _laSession = null;

        internal AuteurManager(ISession laSession)
        {
            _laSession = laSession;
        }
        #endregion

        #region IAuteursManager Members

        public List<Auteur> getAuteurs()
        {
            IList lauteurs = _laSession.CreateCriteria(typeof(Auteur)).List();
            return UtilHelper.ConvertToList<Auteur>(lauteurs);
        }

        public Auteur getAuteur(int id)
        {
            return _laSession.Get<Auteur>(id);            
        }

        public void saveAuteur(Auteur auteur)
        {
            try
            {
                _laSession.BeginTransaction();

                _laSession.SaveOrUpdate(auteur);

                _laSession.Transaction.Commit();
            }
            catch (Exception e)
            {
                _laSession.Transaction.Rollback();
                throw e;
            }
        }

        public void delAuteur(int id)
        {
            try
            {
                Auteur adel = ((IAuteursManager)this).getAuteur(id);

                if (adel != null)
                {
                    _laSession.BeginTransaction();
                    _laSession.Delete(adel);
                    _laSession.Transaction.Commit();
                }
            }
            catch (Exception e)
            {
                _laSession.Transaction.Rollback();
                throw e;
            }
        }

        #endregion
    }
}
