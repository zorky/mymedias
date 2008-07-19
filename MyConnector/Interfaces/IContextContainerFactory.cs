using System;
using System.Collections.Generic;
using System.Text;

namespace MyConnector
{
    public interface IContextContainerFactory
    {
        IContextContainer GetContainer();        
    }
}
