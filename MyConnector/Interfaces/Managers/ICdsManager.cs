using System;
using System.Collections.Generic;
using System.Text;

using MyConnector.Model;

namespace MyConnector.Interfaces
{
    public interface ICdsManager
    {
        List<Media> getMedias();
        List<Cd> getCds();
        Cd getCd(int id);
        void saveCd(Cd cd);
        void delCd(int id);
        List<Cd> searchCds(string keywords);
    }
}
