using System;
using System.Collections.Generic;
using System.Text;

using MyConnector.Model;

namespace MyConnector.Interfaces
{
    public interface IAuteursManager
    {
        List<Auteur> getAuteurs();
        Auteur getAuteur(int id);
        void saveAuteur(Auteur auteur);
        void delAuteur(int id);
    }
}
