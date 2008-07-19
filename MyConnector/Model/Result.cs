using System;
using System.Collections.Generic;
using System.Text;

using MyConnector.Interfaces;

namespace MyConnector.Model
{
    public class Result : IResult
    {
        string _url = string.Empty;
        public virtual string Url 
        {
            get { return _url; }
            set { _url = value; }
        }

        string _resume;
        public virtual string Resume
        {
            get { return _resume; }
            set { _resume = value; }
        }
    }
}
