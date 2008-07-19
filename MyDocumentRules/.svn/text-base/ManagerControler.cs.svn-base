using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyConnector.Interfaces;

namespace MyDocumentRules
{
    public class ManagerControler : IManagerControler
    {
        #region IManagerControler Members

        ISearchManager IManagerControler.getSearchManager(IDALContainer container)
        {
            return new SearchManager(container.GetWorkingContext() as NHibernate.ISession);
        }

        //ILivresManager IManagerControler.getMediaManager(IDALContainer container)
        //{           
        //    return new LivresManager(container.GetWorkingContext() as NHibernate.ISession);
        //}

        IMediasManager IManagerControler.getMediaManager(IDALContainer container)
        {
            return new MediasManager(container.GetWorkingContext() as NHibernate.ISession);
        }

        //ICdsManager IManagerControler.getCdManager(IDALContainer container)
        //{
        //    return new CdsManager(container.GetWorkingContext() as NHibernate.ISession);
        //}

        IAuteursManager IManagerControler.getAuteurManager(IDALContainer container)
        {
            return new AuteurManager(container.GetWorkingContext() as NHibernate.ISession);
        }
        #endregion
    }
}
