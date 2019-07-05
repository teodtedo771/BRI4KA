using System;
using System.IO;
using System.IO.Ports;
using System.Threading;
namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "0";
            SendSampleData(command);
            Console.WriteLine("Sent!");
        }
        static void SendSampleData(string command)
        {
            // Instantiate the communications
            // port with some basic settings
            SerialPort port = new SerialPort(
              "COM9", 9600, Parity.None, 8, StopBits.One);

            // Open the port for communications
            port.Open();

            // Write a string
            port.Write(command);

            // Write a set of bytes
            port.Write(new byte[] { 0x0A, 0xE2, 0xFF }, 0, 3);

            // Close the port
            port.Close();
        }

    }
}
