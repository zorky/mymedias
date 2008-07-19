using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using myWebApp;

using MyConnector.Model;
using MyConnector.Interfaces;

namespace myWebApp.Controls.Display
{
    public partial class ListeMediaWUC : System.Web.UI.UserControl
    {
        /// <summary>
        ///     Evenement sur la suppression d'un media
        /// </summary>
        public event EventHandler Deleted;
        private void OnDeleted(int id)
        {
            if (Deleted != null)
                Deleted(id, EventArgs.Empty);
        }
        private IMediasManager mediaManager = null;

        protected void Page_Load(object sender, EventArgs e)
        {           
            mediaManager = ((myWebApp.MyWebAppBasePage)this.Page).mediaManager;
            rpBooks.ItemCommand += new RepeaterCommandEventHandler(rpBooks_ItemCommand);

            if (!IsPostBack)
                bind();
        }  

        /// <summary>
        ///     Evenement sur la suppression
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        void rpBooks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("deleteMedia"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                mediaManager.delMedia(id);
                bind();

                OnDeleted(id);
            }
        }

        /// <summary>
        ///     Chargement et binding
        /// </summary>
        void bind()
        {
            List<Media> lmedias = mediaManager.getMedias();
            rpBooks.DataSource = lmedias;
            rpBooks.DataBind();
        }    

        /// <summary>
        ///     Affichage du détail d'un média
        /// </summary>
        /// <param name="media"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        protected string afficheDetails(IMedia media, IFormatProvider format)
        {
            AbstractMediaDetailDisplay mycontrol = null;
            TextWriter txt = new StringWriter();
            HtmlTextWriter html = new HtmlTextWriter(txt);

            mycontrol = LoadControl(string.Format("~/Controls/Display/{0}WUC.ascx", media.GetType().Name)) as AbstractMediaDetailDisplay;
            mycontrol.afficheMedia(media);

            mycontrol.RenderControl(html);
            return txt.ToString();
        }

        /// <summary>
        ///     Affichage de l'icone selon le type de média
        /// </summary>
        /// <param name="media"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        protected string afficheIcon(IMedia media, IFormatProvider format)
        {
            return string.Format(@"<img alt=""{0}"" src=""Themes/images/{0}.png""/>", media.GetType().Name);
        }

        
    }
}