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
    public partial class CdWUC : AbstractMediaDetailWrite
    {
        public override void LoadFormMedia(IMedia media)
        {
            txtDureeMn.Text = ((ICd)media).DureeMn.ToString();
        }

        public override void SaveValuesToMedia(IMedia media)
        {
            ((ICd)media).DureeMn = string.IsNullOrEmpty(txtDureeMn.Text) ? 0 : int.Parse(txtDureeMn.Text);
        }
    }
}