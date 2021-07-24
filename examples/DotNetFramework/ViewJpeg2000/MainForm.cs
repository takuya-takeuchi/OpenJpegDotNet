using System;
using System.Net;
using System.Windows.Forms;

namespace ViewJpeg2000
{

    public partial class MainForm : Form
    {

        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            this.textBox.Text = "https://github.com/takuya-takeuchi/OpenJpegDotNet/blob/main/test/OpenJpegDotNet.Tests/TestImages/Bretagne1_0.j2k?raw=true";
        }

        #endregion

        #region Methods

        #region Event Handlers

        private async void ButtonClick(object sender, EventArgs e)
        {
            try
            {
                var webClient = new WebClient();
                var content = await webClient.DownloadDataTaskAsync(new Uri(this.textBox.Text));

                using (var reader = new OpenJpegDotNet.IO.Reader(content))
                {
                    var result = reader.ReadHeader();
                    this.pictureBox.Image?.Dispose();
                    this.pictureBox.Image = reader.ReadData();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        #endregion

        #endregion

    }

}
