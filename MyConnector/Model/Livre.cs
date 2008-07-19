using System;
using System.Collections.Generic;
using System.Text;

using MyConnector.Interfaces;

namespace MyConnector.Model
{
    public class Livre : Media, ILivre
    {
        #region ILivre Members
        
        public string Isbn {get;set;}
        public int NbPages { get; set; }             

        #endregion
    }
}
