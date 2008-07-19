using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using myWebApp;

namespace myWebApp
{
    public partial class _genqs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            NameValueCollection myparas = new NameValueCollection();
            myparas.Add("idUser", "18759");
            myparas.Add("context", "reinit");
            myparas.Add("token", Securite.getUniqueKey(null));

            string qs = Securite.createQSSecure(myparas);
            lbKey.Text = qs;

            hpHref.NavigateUrl = string.Format("{0}/pwdReinit.aspx?{1}", 
                ConfigurationManager.AppSettings["server"], qs);
            hpHref.Text = "Test moi";            
        }
    }
}
