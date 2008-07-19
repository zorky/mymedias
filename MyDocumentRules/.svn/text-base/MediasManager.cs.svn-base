using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyConnector;
using MyConnector.Model;
using MyConnector.Interfaces;

using NHibernate;
using NHibernate.Criterion;

namespace MyDocumentRules
{
    public class MediasManager : IMediasManager
    {
        #region private
        /// <summary>
        ///     Session NHibernate
        /// </summary>
        private ISession _laSession = null;

        internal MediasManager(ISession laSession)
        {
            _laSession = laSession;
        }
        #endregion

        #region IMediasManager Members

        public List<Media> getMedias()
        {
            IList lmedias = _laSession.CreateCriteria(typeof(Media)).List();
            return UtilHelper.ConvertToList<Media>(lmedias);
        }

        public Media getMedia(int id)
        {
            return _laSession.Get<Media>(id);            
        }

        public void saveMedia(Media media)
        {
            try
            {
                _laSession.BeginTransaction();

                media.OnSaving(media);

                media.MediaType = (MediaType) Enum.Parse(typeof(MediaType), media.GetType().Name);                

                _laSession.SaveOrUpdate(media);

                media.OnSaved(media);

                _laSession.Transaction.Commit();
            }
            catch (Exception e)
            {
                _laSession.Transaction.Rollback();
                throw e;
            }
        }

        public void delMedia(int id)
        {
            try
            {
                Media mdel = ((IMediasManager)this).getMedia(id);

                if (mdel != null)
                {
                    _laSession.BeginTransaction();
                    _laSession.Delete(mdel);
                    _laSession.Transaction.Commit();
                }
            }
            catch(Exception e)
            {
                _laSession.Transaction.Rollback();
                throw e;
            }
        }

        #endregion
    }
}
