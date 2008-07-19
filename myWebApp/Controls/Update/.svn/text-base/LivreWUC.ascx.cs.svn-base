using System;
using System.Collections;
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

using MyConnector.Interfaces;

namespace myWebApp.Controls.Update
{
    public partial class LivreWUC : AbstractMediaDetailWrite
    {
       public override void LoadFormMedia(IMedia media)
        {
            txtIsbn.Text = ((ILivre)media).Isbn;
            txtNbPages.Text = ((ILivre)media).NbPages.ToString();
        }

        public override void SaveValuesToMedia(IMedia media)
        {
            ((ILivre)media).Isbn = txtIsbn.Text;
            ((ILivre)media).NbPages = string.IsNullOrEmpty(txtNbPages.Text) ? 0 : int.Parse(txtNbPages.Text);
        }
    }
}