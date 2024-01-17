
namespace LicenceCommon
{
    //Save encrypted data, and decrypt key into file
    public sealed class RegistFileHelper
    {
        #region private fields
        #endregion

        #region constructors
        #endregion

        #region public properties
        public static string ComputerInfoFile = "ComputerInfo.key";
        public static string RegistInfoFile = "Licence.key";
        #endregion

        #region public methods
        public static void WriteRegistFile(string info, string keyFile)
        {
            string tmp = string.IsNullOrEmpty(keyFile) ? RegistInfoFile : keyFile;
            WriteFile(info, tmp);
        }

        public static void WriteComputerFile(string info)
        {
            WriteFile(info, ComputerInfoFile);
        }

        public static string ReadRegistFile(string keyFile)
        {
            string tmp = string.IsNullOrEmpty(keyFile) ? RegistInfoFile : keyFile;
            return ReadFile(tmp);
        }

        public static string ReadComputerInfoFile(string file)
        {
            string tmp = string.IsNullOrEmpty(file) ? ComputerInfoFile : file;
            return ReadFile(tmp);
        }
        #endregion

        #region private methods
        private static void WriteFile(string info, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(info);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                //handle ex
            }
        }
        private static string ReadFile(string fileName)
        {
            string info = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    info = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                //handle ex
            }
            return info;
        }
        #endregion
    }
}
