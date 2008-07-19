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

using MyConnector;
using MyConnector.Interfaces;
using MyConnector.Model;

namespace myWebApp
{
    public class MyWebAppBasePage : Page
    {
        #region private
        IDALContainer _dalcontainer = null;
        #endregion

        #region Managers
        public IMediasManager mediaManager
        {
            get
            {
                return (HttpContext.Current.Items["mediamgr"] ?? 
                    (HttpContext.Current.Items["mediamgr"] = MyConnectorHelper.GetManagerController().getMediaManager(Container))) as IMediasManager;
            }
        }        

        public ISearchManager searchManager
        {
            get
            {
                if (HttpContext.Current.Items["srchmgr"] == null)
                    HttpContext.Current.Items["srchmgr"] = MyConnectorHelper.GetManagerController().getSearchManager(Container);
                return HttpContext.Current.Items["srchmgr"] as ISearchManager;
            }
        }

        public IAuteursManager auteurManager
        {
            get 
            {                
                if (HttpContext.Current.Items["autmgr"] == null)
                    HttpContext.Current.Items["autmgr"] = MyConnectorHelper.GetManagerController().getAuteurManager(Container);
                return HttpContext.Current.Items["autmgr"] as IAuteursManager;
            }
        }

        IDALContainer Container
        {
            get
            {
                if (_dalcontainer == null)
                    _dalcontainer = MyConnectorHelper.GetWorkingContext().getContainer();
                return _dalcontainer;
            }
        }        
        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            LoadComplete += new EventHandler(MyWebAppBasePage_LoadComplete);
        }

        void MyWebAppBasePage_LoadComplete(object sender, EventArgs e)
        {
            if (_dalcontainer != null)
                _dalcontainer.ClearWorkingContext();            
        }
    }
}
