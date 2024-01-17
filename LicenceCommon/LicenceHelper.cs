using System.Text;

namespace LicenceCommon
{
    /// <summary>
    /// Accessing all other helpers to provide licence generation solution
    /// </summary>
    public sealed class LicenceHelper
    {
        #region private fields
        #endregion

        #region constructors
        #endregion

        #region public properties
        #endregion

        #region public methods
        public static string GetComputerInfoAndGenerateFile()
        {
            string computerKeyFile = string.Empty;
            try
            {
                var info = ComputerHelper.GetComputerInfo();
                if (info != null && info.Count > 0)
                {
                    var strInfo = new StringBuilder();

                    foreach (var computer in info)
                    {
                        strInfo.AppendLine($"{computer.Key}={computer.Value}");
                    }

                    RegistFileHelper.WriteComputerFile(strInfo.ToString());

                    computerKeyFile = RegistFileHelper.ComputerInfoFile;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return computerKeyFile;
        }

        public static Dictionary<string, string> GetComputerInfo()
        {
            return ComputerHelper.GetComputerInfo();
        }

        public static bool CheckLicenceKeyIsExists()
        {
            var keyFile = RegistFileHelper.RegistInfoFile;
            if (File.Exists(keyFile))
            {
                return true;
            }
            else
            { return false; }
        }

        public static string GetComputerInfo(string computerInfoFile)
        {
            return RegistFileHelper.ReadComputerInfoFile(computerInfoFile);
        }

        public static void GenerateLicenceKey(string info, string keyFile)
        {
            string encrypto = RsaHelper.Encrypto(info);

            string priKey = RsaHelper.PriKey;
            byte[] priKeyBytes = Encoding.ASCII.GetBytes(priKey);
            string priKeyBase64 = Convert.ToBase64String(priKeyBytes);

            StringBuilder keyInfo = new StringBuilder();
            keyInfo.AppendLine($"priKey={priKeyBase64}");
            keyInfo.AppendLine($"encrypto={encrypto}");
            RegistFileHelper.WriteRegistFile(keyInfo.ToString(), keyFile);
        }

        public static string ReadLicenceKey(string keyFile)
        {
            var keyInfo = RegistFileHelper.ReadRegistFile(keyFile);

            if (keyInfo == null)
            {
                return string.Empty;
            }

            string[] keyInfoArray = keyInfo.Split("\r\n");
            var priKeyBase64 = keyInfoArray[0].Substring(keyInfoArray[0].IndexOf("=") + 1);
            var encrypto = keyInfoArray[1].Substring(keyInfoArray[1].IndexOf("=") + 1);
            var priKeyByte = Convert.FromBase64String(priKeyBase64);
            var priKey = Encoding.ASCII.GetString(priKeyByte);
            RsaHelper.PriKey = priKey;

            var info = RsaHelper.Decrypto(encrypto);
            return info;
        }

        public static string GetDefaultRegisterFileName()
        {
            return RegistFileHelper.RegistInfoFile;
        }

        public static string GetDefaultComputerFileName()
        {
            return RegistFileHelper.ComputerInfoFile;
        }

        public static string GetPublicKey()
        {
            if (string.IsNullOrEmpty(RsaHelper.PubKey))
            {
                RsaHelper.GenerateKey();
            }

            return RsaHelper.PubKey;
        }

        public static string GetPrivateKey()
        {
            if (string.IsNullOrEmpty(RsaHelper.PriKey))
            {
                RsaHelper.GenerateKey();
            }

            return RsaHelper.PriKey;
        }
        #endregion

        #region private methods
        #endregion
    }
}