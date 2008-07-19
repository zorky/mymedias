using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyConnector
{
    public class UtilHelper
    {
        /// <summary>
        ///     Transforme une IList<T> en List<T>
        /// </summary>
        /// <typeparam name="T">le type</typeparam>
        /// <param name="l">la liste</param>
        /// <returns></returns>
        public static List<T> ConvertToList<T>(IList l)
        {
            List<T> lres = new List<T>(l.Count);
            foreach (T elem in l)
                lres.Add(elem);
            return lres;
        }
    }
}
