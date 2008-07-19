namespace myWebApp
{
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Text;
    using System.Web;
    using System.Configuration;
    using System.Security.Cryptography;

    public class Securite
    {
        /// <summary>
        ///     Création d'une querystring : ?para1=val1&para2=val2&...&paraN=valN
        /// </summary>
        /// <param name="qs">la querystring créée</param>
        /// <returns></returns>
        private static string _getQS(NameValueCollection qs)
        {
            StringBuilder sb = new StringBuilder();            
            foreach (string k in qs)
                sb.AppendFormat("{0}={1}&", k, qs[k]);
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        /// <summary>
        ///     Création d'une URL avec un HASH des paramètres
        ///     pour vérification future des paras.
        /// </summary>
        /// <param name="qs">QueryString</param>
        /// <returns></returns>
        public static string createQSSecure(NameValueCollection qs)        
        {
            string cle = ConfigurationManager.AppSettings["cryptKey"];            
            string hash = string.Empty;
            string qsStr = string.Empty;
            NameValueCollection qs2 = new NameValueCollection(qs);

            qs2.Remove("Hash");
            qsStr = _getQS(qs2);

            hash = getHashSHA256(string.Format("{0}{1}", cle, qsStr));
            // protection des caractères réservés pour l'URL
            hash = hash.Replace("/", "_").Replace("+", "-");

            return String.Format("{0}&Hash={1}", qsStr, hash);
        }

        /// <summary>
        ///     Vérifie à partir d'une collection de paramètres (dont un Hash)
        ///     s'il ont été modifié (comparaison de Hash créé précédemment et du
        ///     Hash créé avec qs)
        /// </summary>
        /// <param name="qs">QueryString</param>
        /// <returns></returns>

        public static bool isUrlSecureValid(NameValueCollection qs)
        {           
            string cle = ConfigurationManager.AppSettings["cryptKey"];
            string hash = qs["Hash"];
            // on remet au format original les caractères protégés
            hash = hash.Replace("_", "/").Replace("-", "+");

            NameValueCollection qs2 = new NameValueCollection(qs);
            qs2.Remove("Hash");

            return hash.Equals(getHashSHA256(string.Format("{0}{1}", cle, _getQS(qs2))));
        }

        /// <summary>
        ///     calcul le hash SHA256 d'une clé
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string getHashSHA256(string phrase)
        {
            byte[] data = Encoding.UTF8.GetBytes(phrase);
            using (HashAlgorithm sha = new SHA256Managed())
            {
                byte[] encryptedBytes = sha.TransformFinalBlock(data, 0, data.Length);
                return Convert.ToBase64String(sha.Hash);
            }
        }

        /// <summary>
        ///     Génération clé unique
        /// </summary>
        /// <param name="maxsize"></param>
        /// <returns></returns>
        public static string getUniqueKey(int? maxsize)
        {
            int PasswordLength = maxsize ?? 8;
            String _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ23456789";
            Byte[] randomBytes = new Byte[PasswordLength];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < PasswordLength; i++)            
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];            

            return new string(chars);
        }
    }
}
