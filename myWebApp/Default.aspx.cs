using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using myWebApp.Controls.Display;

using MyConnector.Model;
using MyConnector.Interfaces;


namespace myWebApp
{
    public partial class default_ : MyWebAppBasePage
    {          
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ListeMediaWUC)media).Deleted += new EventHandler(MediaWUC_Deleted);
        }

        void MediaWUC_Deleted(object sender, EventArgs e)
        {
            displayMessage("success", "Media bien supprimé");            
        }        

        /// <summary>
        ///     bloc message succés ou erreur
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        void displayMessage(string type, string message)
        {
            dmessage.Attributes.Add("class", string.Format("section {0}", type));
            dmessage.Style.Add("display", "block");
            dmessage.InnerHtml = message;
        }                     
    }
}
