using LicenceCommon;
using System.Text;

namespace LicenceGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtPublicKey.Text = LicenceHelper.GetPublicKey();
            this.txtPrivateKey.Text = LicenceHelper.GetPrivateKey();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ComputerInfo|*.key";
            ofd.Multiselect = false;
            ofd.Title = "Choose Computer Info File";
            ofd.FileName = LicenceHelper.GetDefaultComputerFileName();

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtSourceFile.Text = ofd.FileName;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtSourceFile.Text))
                {
                    MessageBox.Show("Choose Computer Info File First.");
                    return;
                }

                if(File.Exists(this.txtSourceFile.Text))
                {
                    var info = LicenceHelper.GetComputerInfo(this.txtSourceFile.Text);
                    int days = GetLicenceDays();
                    var keyInfos = new StringBuilder(info);
                    var beginTime = DateTime.Now;
                    var endTime = DateTime.Now.AddDays(days);

                    keyInfos.AppendLine($"endTime={endTime.ToString("yyyy-MM-dd HH:mm:ss")}");

                    info = keyInfos.ToString();
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "Save generated licence key";
                    saveFileDialog.FileName = LicenceHelper.GetDefaultRegisterFileName();

                    if(saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        LicenceHelper.GenerateLicenceKey(info, saveFileDialog.FileName);
                        MessageBox.Show("Generated licence file successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Computer info file does not exist");
                }
            }
            catch (Exception ex)
            {
                string error = $"Generation Error: {ex.Message}\r\n{ex.StackTrace}";
                MessageBox.Show(error);
            }
        }

        private int GetLicenceDays()
        {
            int days = 1;
            RadioButton[] rbtns = new RadioButton[]
            {
                this.rbtnSeven, this.rbtnTen, this.rbtnFifteen, this.rbtnThirty, this.rbtnSixty,
                this.rbtnNinety, this.rbtnSixMonth, this.rbtnForever
            };

            foreach(RadioButton rb in rbtns )
            {
                if(rb.Checked) { 
                    if(!int.TryParse(rb.Tag.ToString() , out days))
                    {
                        days = 0;
                    }
                    break;
                }
            }

            days = days == -1 ? 9999 : days;

            return days;
        }
    }
}
