using System;
using System.Collections.Generic;
using System.Text;

using MyConnector.Interfaces;

namespace MyConnector.Model
{
    public class Dvd : Media, IDvd
    {
        #region IDvd Members

        public virtual int Region { get; set; }

        #endregion
    }
}
