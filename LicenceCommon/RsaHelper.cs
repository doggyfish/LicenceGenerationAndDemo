
using System.Security.Cryptography;
using System.Text;

namespace LicenceCommon
{
    //encrypt client pc hardware info/expiry date etc
    public class RsaHelper
    {
        private static string keyContainerName = "star";
        private static string m_PriKey = string.Empty;
        private static string m_PubKey = string.Empty;

        public static string PriKey
        {
            get { return m_PriKey; }
            set { m_PriKey = value; }
        }

        public static string PubKey
        {
            get { return m_PubKey; }
            set { m_PubKey = value; }
        }

        public static string Encrypto(string source)
        {
            if (string.IsNullOrEmpty(m_PubKey) && string.IsNullOrEmpty(m_PriKey))
            {
                GenerateKey();
            }

            return GetEncryptoInfoByRsa(source);
        }



        public static string Decrypto(string dest)
        {
            if (string.IsNullOrEmpty(m_PubKey) && string.IsNullOrEmpty(m_PriKey))
            {
                GenerateKey();
            }

            return GetDecryptoInfoByRsa(dest);
        }


        public static void GenerateKey()
        {
            CspParameters m_CspParameters = new CspParameters();
            m_CspParameters.KeyContainerName = keyContainerName;

            // Create a new instance of RSACryptoServiceProvider
            using (RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(2048, m_CspParameters)) // Set key size to 2048
            {
                // Extract and store the private and public key
                m_PriKey = rsaCsp.ToXmlString(true);
                m_PubKey = rsaCsp.ToXmlString(false);

                // Setting PersistKeyInCsp to false so that the key does not remain in the key container
                rsaCsp.PersistKeyInCsp = false;
            } // The 'using' statement ensures that resources are freed and the key is cleared from the container when the RSA object is disposed
        }

        private static string GetEncryptoInfoByRsa(string source)
        {
            byte[] plainByte = Encoding.ASCII.GetBytes(source);

            //initialize
            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(m_PubKey);

            int keySize = rsaCsp.KeySize / 8;
            int bufferSize = keySize - 11;

            if(plainByte.Length > bufferSize)
            {
                throw new Exception("non-symmetric encryption support max of " + bufferSize + " bytes, actual value is " + plainByte.Length + " bytes");
            }

            byte[] cryptoByte = rsaCsp.Encrypt(plainByte, false);

            return Convert.ToBase64String(cryptoByte);
        }

        private static string GetDecryptoInfoByRsa(string dest)
        {
            byte[] btDest = Convert.FromBase64String(dest);

            //initialize
            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(m_PriKey);

            int keySize = rsaCsp.KeySize / 8;
            
            if(btDest.Length > keySize)
            {
                throw new Exception("non-symmetric decryption support max of " + keySize + " bytes, actual value is " + btDest.Length + " bytes");
            }

            byte[] cryptoByte = rsaCsp.Decrypt(btDest, false);

            return Encoding.ASCII.GetString(cryptoByte);
        }
    }
}
