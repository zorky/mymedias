using System;
using System.Collections.Generic;
using System.Text;

namespace MyConnector.Interfaces
{
    public interface IDALContainer
    {
        /// <summary>
        ///     Création du contexte DAL
        /// </summary>
        /// <returns></returns>
        Object GetWorkingContext();
        /// <summary>
        ///     Suppression du contexte DAL
        /// </summary>
        void ClearWorkingContext();
    }
}
