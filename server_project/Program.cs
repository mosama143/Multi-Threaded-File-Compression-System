using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace server_project
{
    internal class Program
    {
        static TcpListener server;

        static void Main(string[] args)
        {
            int port = 5000;

            server = new TcpListener(IPAddress.Any, port);

            server.Start();

            Console.WriteLine("Compression Server Started...");
            Console.WriteLine("Waiting For Clients...\n");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                Console.WriteLine("Client Connected");

                Thread thread = new Thread(() =>
                {
                    HandleClient(client);
                });

                thread.Start();
            }
        }

        static void HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();

                // استقبال حجم الملف
                byte[] sizeBytes = new byte[8];
                stream.Read(sizeBytes, 0, sizeBytes.Length);

                long fileSize = BitConverter.ToInt64(sizeBytes, 0);

                Console.WriteLine($"Receiving File Size: {fileSize}");

                // استقبال الملف
                byte[] fileBytes = new byte[fileSize];

                int totalRead = 0;

                while (totalRead < fileSize)
                {
                    int read = stream.Read(
                        fileBytes,
                        totalRead,
                        (int)(fileSize - totalRead));

                    totalRead += read;
                }

                Console.WriteLine("File Received");

                // ضغط الملف
                byte[] compressedData = CompressFile(fileBytes);

                Console.WriteLine("File Compressed");

                // إرسال حجم الملف المضغوط
                byte[] compressedSize =
                    BitConverter.GetBytes((long)compressedData.Length);

                stream.Write(compressedSize, 0, compressedSize.Length);

                // إرسال الملف المضغوط
                stream.Write(compressedData, 0, compressedData.Length);

                Console.WriteLine("Compressed File Sent\n");

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static byte[] CompressFile(byte[] data)
        {
            using (MemoryStream output = new MemoryStream())
            {
                using (GZipStream gzip =
                    new GZipStream(output, CompressionMode.Compress))
                {
                    gzip.Write(data, 0, data.Length);
                }

                return output.ToArray();
            }
        }
    }
}