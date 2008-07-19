using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using MyConnector.Interfaces;
using MyConnector.Model;

namespace myWebApp
{
    /// <summary>
    ///     Interface pour les contrôles d'affichage selon le type de média
    /// </summary>
    public abstract class AbstractMediaDetailDisplay : System.Web.UI.UserControl
    {        
        protected IMedia Media { get; set; }
        /// <summary>
        ///     Affiche le média dans le formulaire
        /// </summary>
        /// <param name="media"></param>
        public abstract void afficheMedia(IMedia media);
    }
}
