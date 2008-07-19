using System;
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

using MyConnector.Model;
using MyConnector.Interfaces;

namespace myWebApp
{
    public partial class mydoc : MyWebAppBasePage
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            dmessage.Style.Clear();
            dmessage.Style.Add("display", "none");

            btnValider.Click += new EventHandler(btnValider_Click);
            csVal.ServerValidate += new ServerValidateEventHandler(csVal_ServerValidate);
            rpBooks.ItemCommand += new RepeaterCommandEventHandler(rpBooks_ItemCommand);           

            if (!IsPostBack)
                bind();
        }

        void displayMessage(string type, string message)
        {
            dmessage.Attributes.Add("class", string.Format("section {0}", type));
            dmessage.Style.Add("display", "block");
            dmessage.InnerHtml = message;
        }

        void csVal_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ! string.IsNullOrEmpty(txtTitre.Text);
        }       

        void rpBooks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("deleteBook"))
            {
                int id =Convert.ToInt32(e.CommandArgument);
                documentManager.delLivre(id);
                bind();

            }
        }

        void bind()
        {
            List<Livre> ldocs = documentManager.getLivres();
            
            //var mydocs = from d in ldocs where d.Libelle=="titre" select d;
            var mydocs = from d in ldocs
                         orderby d.Titre descending
                         select d;

            rpBooks.DataSource = mydocs;
            rpBooks.DataBind();
        }

        void btnValider_Click(object sender, EventArgs e)
        {
            csVal.Enabled = true;

            Page.Validate();
            if (Page.IsValid)
            {
                Livre doc = new Livre();
                doc.Titre = txtTitre.Text;
                doc.Resume = txtResume.Text;

                documentManager.saveLivre(doc);

                bind();

                displayMessage("success", "Livre bien enregistré");                
            }
            else            
                displayMessage("error", csVal.ErrorMessage);                            
        }       
    }
}
