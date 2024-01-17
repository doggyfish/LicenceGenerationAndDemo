using LicenceCommon;

namespace LicenceDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string info = string.Empty;
                string msg = string.Empty;

                if (LicenceHelper.CheckLicenceKeyIsExists())
                {
                    string keyFile = LicenceHelper.GetDefaultRegisterFileName();
                    info = LicenceHelper.ReadLicenceKey(keyFile);
                }
                else
                {
                    var dialogResult = MessageBox.Show("Licence file not found, do you upload a licence file manually?", "Confirm", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Title = "Please choose licence file";
                        openFileDialog.FileName = LicenceHelper.GetDefaultRegisterFileName();

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            var keyFile = openFileDialog.FileName;

                            info = LicenceHelper.ReadLicenceKey(keyFile);

                            File.Copy(keyFile, LicenceHelper.GetDefaultRegisterFileName());
                        }
                        else
                        {
                            string computerFile = LicenceHelper.GetComputerInfoAndGenerateFile();

                            if (!string.IsNullOrEmpty(computerFile))
                            {
                                msg = $"You are not authorized, please send your computer file {computerFile} to administrator to receive a licence file";
                            }
                        }
                    }
                    else
                    {
                        string computerFile = LicenceHelper.GetComputerInfoAndGenerateFile();
                        if (!string.IsNullOrEmpty(computerFile))
                        {
                            msg = $"You are not authorized, please send your computer file {computerFile} to administrator to receive a licence file";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(info) && string.IsNullOrEmpty(msg))
                {
                    string[] infos = info.Split("\r\n");
                    if (infos.Length > 0) {
                        var dicInfo = new Dictionary<string, string>();

                        foreach (string item in infos)
                        {
                            if (string.IsNullOrEmpty(item))
                                continue;
                            var itemArray = item.Split("=");
                            dicInfo.Add(itemArray[0], itemArray[1]);
                        }

                        if (dicInfo.Count > 0)
                        {
                            string localMacAddress = string.Empty;

                            var computerInfo = LicenceHelper.GetComputerInfo();

                            if (computerInfo != null)
                            {
                                localMacAddress = computerInfo["mac"];
                            }

                            if (localMacAddress == dicInfo["mac"])
                            {
                                var endTime = DateTime.Parse(dicInfo["endTime"]);
                                if (DateTime.Now < endTime)
                                {
                                    // not expired, can use
                                }
                                else
                                {
                                    msg = $"Software expired at [{endTime}]";
                                }
                            }
                            else
                            {
                                msg = "Software licence doesn't match hardware information";
                            }
                        }
                        else
                        {
                            msg = $"Invalid licence";
                        }
                    }
                    else
                    {
                        msg = $"Invalid licence";
                    }
                }

                if (!string.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg);

                    foreach (var control in this.Controls)
                    {
                        (control as Control).Enabled = false;
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                string error = $"Internal Error: {ex.Message}\r\n{ex.StackTrace}";
                MessageBox.Show(error);

                foreach (var control in this.Controls)
                {
                    (control as Control).Enabled = false;
                }
            }
        }
    }
}
