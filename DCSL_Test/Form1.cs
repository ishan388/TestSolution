using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCSL_BusinessLayer;
using System.Timers;

namespace DCSL_Test
{
    public partial class Form1 : Form
    {
        IDCSL_BL objBL;
        private System.Timers.Timer aTimer;
        public Form1(IDCSL_BL dCSL_BL)
        {
            InitializeComponent();
            //RichTextBox.CheckForIllegalCrossThreadCalls = false;
            objBL = dCSL_BL;
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            var source = fbdSource.ShowDialog();
            if (source == DialogResult.OK && !string.IsNullOrWhiteSpace(fbdSource.SelectedPath))
                txtSource.Text = fbdSource.SelectedPath;
        }
        private void btnDestination_Click(object sender, EventArgs e)
        {
            var destination = fbdDestination.ShowDialog();
            if (destination == DialogResult.OK && !string.IsNullOrWhiteSpace(fbdDestination.SelectedPath))
                txtDestination.Text = fbdDestination.SelectedPath;
        }
        private async void WriteCopyStatus(Object source, ElapsedEventArgs e)
        {
            await Task.Run(() =>
            {
                txtCopyStatus.Text += objBL.TrackCopyStatus();
            });
        }
        private async Task CopyDirectory(string sourceDirName, string destDirName)
        {
            string result = string.Empty;
            if (txtSource.Text.Length > 0 && txtDestination.Text.Length > 0)
            {
                await Task.Factory.StartNew(() =>
                {
                    result = objBL.DirectoryCopy(sourceDirName, destDirName, true);
                });
            }
            else
                result = "Please select Source and Destination both paths";
            txtDestination.Text = txtSource.Text = string.Empty;
            rtxtAnything.Text = result;
            aTimer.Stop();
            aTimer.Dispose();
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtCopyStatus.Text = String.Empty;
            rtxtAnything.Text = "Copy operations started...";
            SetTimer();
            this.CopyDirectory(txtSource.Text, txtDestination.Text).ConfigureAwait(false);
        }
        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(100);
            aTimer.Elapsed += WriteCopyStatus;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

    }
}
