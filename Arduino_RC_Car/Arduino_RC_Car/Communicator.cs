using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace Arduino_RC_Car
{
    class Communicator
    {
        public SerialPort serialPort { get; private set; }
        
        public Communicator(string portName, int baudRate)
        {
            serialPort = new SerialPort();
            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
        }

        public Communicator(string portName, int baudRate,Parity parity, int n, StopBits stopbits)
        {
            serialPort = new SerialPort();
            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            parity = Parity.None;
            n = 8;
            stopbits = StopBits.None;
        }

        public void Start()
        {
            if(serialPort != null)
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                else
                {
                    serialPort.Open();
                    
                }
            }
        }

        public void SendCommand(string command)
        {
            serialPort.Write(command);
        }

        public void SendSetOfBytes(byte[] bytes,int offset, int count)
        {
            serialPort.Write(bytes, offset, count);
        }

        public void SendSetOfChars(char[] chars, int offset, int count)
        {
            serialPort.Write(chars, offset, count);
        }

        public void ClosePort()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        public void RecieveData(byte[] buffer, int offset, int count)
        {
            serialPort.Read(buffer, offset, count);
        }

        public int RecieveDataChar()
        {
            return serialPort.ReadChar();
        }
    }
}
