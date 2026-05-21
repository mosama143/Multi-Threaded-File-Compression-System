using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client_App
{
    public partial class Form1 : Form
    {
        string selectedFile = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                selectedFile = open.FileName;

                FileInfo info = new FileInfo(selectedFile);

                lblFile.Text =
                    "Selected File: " + info.Name;

                lblSize.Text =
                    "Original Size: " +
                    (info.Length / 1024.0).ToString("0.00") +
                    " KB";

                lblStatus.Text = "Status: File Ready";
            }
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            if (selectedFile == "")
            {
                MessageBox.Show("Please Select File");
                return;
            }

            try
            {
                progressBar1.Value = 10;

                lblStatus.Text = "Status: Connecting...";

                TcpClient client =
                    new TcpClient("127.0.0.1", 5000);

                NetworkStream stream = client.GetStream();

                byte[] fileBytes =
                    File.ReadAllBytes(selectedFile);

                // Send Size
                byte[] size =
                    BitConverter.GetBytes((long)fileBytes.Length);

                stream.Write(size, 0, size.Length);

                progressBar1.Value = 30;

                lblStatus.Text = "Status: Sending File...";

                // Send File
                stream.Write(fileBytes, 0, fileBytes.Length);

                progressBar1.Value = 55;

                lblStatus.Text = "Status: Compressing...";

                // Receive Compressed Size
                byte[] compressedSizeBytes = new byte[8];

                stream.Read(
                    compressedSizeBytes,
                    0,
                    compressedSizeBytes.Length);

                long compressedSize =
                    BitConverter.ToInt64(compressedSizeBytes, 0);

                // Receive Compressed File
                byte[] compressedData =
                    new byte[compressedSize];

                int totalRead = 0;

                while (totalRead < compressedSize)
                {
                    int read = stream.Read(
                        compressedData,
                        totalRead,
                        (int)(compressedSize - totalRead));

                    totalRead += read;
                }

                progressBar1.Value = 85;

                lblStatus.Text = "Status: Saving File...";

                string newFile =
                    selectedFile + ".gz";

                File.WriteAllBytes(newFile, compressedData);

                progressBar1.Value = 100;

                lblStatus.Text =
                    "Status: Completed ✔";

                MessageBox.Show(
                    "Compressed File Saved Successfully",
                    "Done",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Status: Failed ❌";

                MessageBox.Show(ex.Message);
            }
        }
    }
}