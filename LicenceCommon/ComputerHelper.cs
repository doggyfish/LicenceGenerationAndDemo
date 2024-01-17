using System.Management;

namespace LicenceCommon
{
    /// <summary>
    /// Obtain client pc hardware info
    /// </summary>
    public sealed class ComputerHelper
    {
        #region private fields
        #endregion

        #region constructors
        #endregion

        #region public properties
        #endregion

        #region public methods
        public static Dictionary<string, string> GetComputerInfo()
        {
            var info = new Dictionary<string, string>();
            string cpu = GetCpuInfo();
            string baseBoard = GetBaseBoardInfo();
            string bios = GetBiosInfo();
            string mac = GetMacInfo();
            info.Add("cpu", cpu);
            info.Add("baseBoard", baseBoard);
            info.Add("bios", bios);
            info.Add("mac", mac);

            return info;
        }


        #endregion

        #region private methods
        private static string GetHardWareInfo(string typePath, string key)
        {
            try
            {
                ManagementClass managementClass = new ManagementClass(typePath);

                ManagementObjectCollection mn = managementClass.GetInstances();

                PropertyDataCollection properties = managementClass.Properties;

                foreach(PropertyData property in properties)
                {
                    if (property.Name == key)
                    {
                        foreach(ManagementObject m in mn)
                        {
                            return m.Properties[property.Name].Value.ToString();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                //Handle Exception
            }

            return string.Empty;
        }

        private static string GetMacInfo()
        {
            return GetMacAddress(); //gethardwareinfo("win32_NetworkAdapterConfiguration", "MACAddress");
        }

        private static string GetMacAddress()
        {
            var mac = string.Empty;
            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var moc = mc.GetInstances();

            foreach (var o in moc)
            {
                var mo = (ManagementObject)o;

                if (!(bool)mo["IPEnabled"])
                    continue;

                mac = mo["MACAddress"].ToString();
                break;
            }

            return mac;
        }

        private static string GetBaseBoardInfo()
        {
            return GetHardWareInfo("Win32_BaseBoard", "SerialNumber");
        }

        private static string GetBiosInfo()
        {
            return GetHardWareInfo("Win32_BIOS", "SerialNumber");
        }

        private static string GetCpuInfo()
        {
            return GetHardWareInfo("Win32_Processor", "ProcessorId");
        }
        #endregion
    }
}
