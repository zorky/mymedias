using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

using MyConnector.Interfaces;

namespace MyConnector.Model
{
    [Serializable]
    public enum Langue { Fr = 0, En };

    [Serializable]
    public enum MediaType { Livre = 0, Cd, Dvd, Divx, Jeu };

    public class Media : IMedia
    {
        #region IMedia Members

        public int Id
        {
            get;
            set;
        }

        public string Titre
        {
            get;
            set;
        }

        public string SousTitre
        {
            get;
            set;
        }

        public Langue Langue
        {
            get;
            set;
        }

        public DateTime? DateParution
        {
            get;
            set;
        }

        public string Resume
        {
            get;
            set;
        }

        public bool IsSupprime
        {
            get;
            set;
        }

        public DateTime DateCreation
        {
            get;
            set;
        }

        public MediaType MediaType
        {
            get;
            set;
        }

        public virtual Auteur Auteur
        {
            get;
            set;
        }   
        #endregion

        #region évènements
        /// <summary>
        ///     Evénement avant la sauvegarde
        /// </summary>
        public static EventHandler Saving;        
        public virtual void OnSaving(Media media)
        {
            if (Saving != null)
                Saving(media, EventArgs.Empty);
        }
        /// <summary>
        ///     Evénement après la sauvegarde
        /// </summary>
        public static EventHandler Saved;        
        public virtual void OnSaved(Media media)
        {
            if (Saved != null)
                Saved(media, EventArgs.Empty);
        }
        #endregion
    }
}
