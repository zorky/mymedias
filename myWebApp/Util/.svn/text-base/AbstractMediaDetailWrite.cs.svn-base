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

namespace myWebApp
{
    /// <summary>
    ///     Interface pour les contrôles de gestion des détails 
    ///     selon le type de média à gérer (Livre, Cd, ...)
    /// </summary>
    public abstract class AbstractMediaDetailWrite : System.Web.UI.UserControl
    {
        protected IMedia Media { get; set; }
        /// <summary>
        ///     Charge les informations du média dans le formulaire
        /// </summary>
        /// <param name="media"></param>
        public abstract void LoadFormMedia(IMedia media);
        /// <summary>
        ///     Sauve les champs du formulaire saisis dans le média
        /// </summary>
        /// <param name="media"></param>
        public abstract void SaveValuesToMedia(IMedia media);
    }
}
