using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;

namespace Youtube_downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnDownload_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select Path"})
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    var youtubes = YouTube.Default;
                    var video = await youtubes.GetVideoAsync(textBox.Text);
                    label2.Text = "Downloading...";
                    File.WriteAllBytes(fbd.SelectedPath + video.FullName, await video.GetBytesAsync());
                    label2.Text = "Complete";
                }
            }
        }
    }
}
