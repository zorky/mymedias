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
    public partial class DvdWUC : AbstractMediaDetailWrite
    {        
        public override void LoadFormMedia(IMedia media)
        {
            txtRegion.Text = ((IDvd)media).Region.ToString();
        }

        public override void SaveValuesToMedia(IMedia media)
        {
            ((IDvd)media).Region = string.IsNullOrEmpty(txtRegion.Text) ? 0 : int.Parse(txtRegion.Text);
        }
    }
}