using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace Arduino_RC_Car
{
    public partial class Frm_Main : Form
    {
        List<string> ports = new List<string>();
        public static string port = "COM7";
        public const string stop = "0";
        public const string forward = "1";
        public const string backward = "2";
        public const string left = "3";
        public const string right = "4";
        public const string requestData = "5";

        public static string Message { get; set; }

        List<string> sensondata = new List<string>();

        Radar radar = new Radar();
        public string distance = "";
        public static int Distance{get;set;}


        public Frm_Main()
        {
            InitializeComponent();
            ports.AddRange(SerialPort.GetPortNames());
            cmb_ComPorts.DataSource = ports;
            if(ports.Count != 0) 
            {
                port = cmb_ComPorts.SelectedText; //needs to be checked if working
                lbl_status.Location = new Point((638 / 2) - 75, 59); //so it can be in the middle
                lbl_status.ForeColor = Color.Red;
                lbl_status.Text = "Connect to bluetooth";
            }
            else
            {
                lbl_status.Location = new Point((638 / 2)-55, 59); //so it can be in the middle
                lbl_status.ForeColor = Color.Red;
                lbl_status.Text = "Bluetooth is off";
            }

            pnl_radar.Controls.Add(radar);
        }

        Communicator communicator = new Communicator(port, 9600, Parity.None, 8, StopBits.One);

        // Draggable topPanel
        bool moving;
        Point offset;
        Point original;


        void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            pnl_top.Capture = true;
            offset = MousePosition;
            original = this.Location;
        }

        void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moving)
                return;

            int x = original.X + MousePosition.X - offset.X;
            int y = original.Y + MousePosition.Y - offset.Y;

            this.Location = new Point(x, y);
        }

        void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            pnl_top.Capture = false;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            communicator.SendCommand("0");
            communicator.SendCommand("1");
        }

        //bluetooth button
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(communicator.serialPort.PortName);
            communicator.Start();
            if (communicator.serialPort.IsOpen)
            {
                MessageBox.Show("connected");
                lbl_status.Location = new Point((638 / 2) - 75, 59); //so it can be in the middle
                lbl_status.ForeColor = Color.FromArgb(0,122,204);
                lbl_status.Text = "Connected successfully";
                tmr_radar.Start();
            }
            
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            lbl_status.Text = Message;
            if (communicator.serialPort.IsOpen)
            {
                int i = 0;
                while (i <= 5) //1-distance, 2nd - humidity, 3rd - temp
                {
                    sensondata.Add(communicator.serialPort.ReadLine());
                    i++;
                }
                //MessageBox.Show(sensondata[sensondata.Count - 3]);
                //MessageBox.Show(sensondata[sensondata.Count - 2]);
                //MessageBox.Show(sensondata[sensondata.Count - 1]);
                //communicator.SendCommand("5");
                //communicator.serialPort.DataReceived += SerialPort_DataReceived;

                //string distance = "";
                string temp = "";
                string humidity = "";
                for (int j = sensondata.Count-5; j < sensondata.Count-1; j++)
                {
                    if (sensondata[j].Contains("C"))
                    {
                        temp = sensondata[j]; //in case indexof returns -1
                        int lastChar = sensondata[j].IndexOf(".");
                        int lenght = sensondata[j].Count() - (lastChar)-2;
                        if (lastChar != -1)
                        {
                            temp = sensondata[j].Substring(0, lenght);
                        }
                        
                        lbl_tempValue.Text = temp+"C";
                    }
                    if (sensondata[j].Contains("%"))
                    {
                        humidity = sensondata[j];
                        int lastChar = sensondata[j].IndexOf(".");
                        int lenght = sensondata[j].Count() - (lastChar)-2;
                        if (lastChar != -1)
                        {
                            humidity = sensondata[j].Substring(0, lenght);
                        }
                        lbl_humidityValue.Text = humidity+"%";
                    }
                    if (sensondata[j] == "yes")
                    {
                        lbl_gasesValue.Text = "Yes";
                        lbl_gasesValue.ForeColor = Color.Red;
                    }
                    if (sensondata[j] == "no")
                    {
                        lbl_gasesValue.Text = "No";
                        lbl_gasesValue.ForeColor = Color.FromArgb(6,204,6);
                    }
                }
                
            }
        }

        //not needed
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            this.Invoke((MethodInvoker)delegate
                {
                    lbl_temp.Text = sp.ReadExisting() + " C";
                });
            
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            communicator.SendCommand("0");
            communicator.SendCommand("2");
        }

        //btn_stop
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            communicator.SendCommand("0");
            if (Message == "Port is closed")
            {
                MessageBox.Show(Message);
            }
            communicator.ClosePort();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            communicator.Start();
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            communicator.SendCommand("0");
            communicator.SendCommand("4");
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            communicator.SendCommand("0");
            communicator.SendCommand("3");
        }

        private void cmb_ComPorts_TextChanged(object sender, EventArgs e)
        {
            port = cmb_ComPorts.SelectedValue.ToString();
        }

        private void tmr_radar_Tick(object sender, EventArgs e) //gets the distance
        {
            if (communicator.serialPort.IsOpen)
            {
                //if(sensondata.Count < 5)
                //{
                    int i = 0;
                    while (i <= 5) //1-distance, 2nd - humidity, 3rd - temp
                    {
                        sensondata.Add(communicator.serialPort.ReadLine());
                        i++;
                    }
                //}
                

                int lastindex;
                for (int j = sensondata.Count - 5; j < sensondata.Count - 1; j++)
                {
                    string unparsedDistance = "";

                    if (sensondata[j].Contains("d"))
                    {

                        unparsedDistance = sensondata[j];
                        lastindex = unparsedDistance.IndexOf('d');
                        Distance = int.Parse(unparsedDistance.Substring(0, lastindex));
                    }

                }
            }
            
        }

        private void btn_up_MouseUp(object sender, MouseEventArgs e)
        {
            communicator.SendCommand(stop);
        }

        private void btn_up_MouseDown(object sender, MouseEventArgs e)
        {
            communicator.SendCommand(forward);
        }

        private void btn_left_MouseDown(object sender, MouseEventArgs e)
        {
            communicator.SendCommand(left);
        }

        private void btn_left_MouseUp(object sender, MouseEventArgs e)
        {
            communicator.SendCommand(stop);
        }

        private void btn_right_MouseDown(object sender, MouseEventArgs e)
        {
            communicator.SendCommand(right);
        }

        private void btn_right_MouseUp(object sender, MouseEventArgs e)
        {
            communicator.SendCommand(stop);
        }

        private void btn_down_MouseDown(object sender, MouseEventArgs e)
        {
            communicator.SendCommand(backward);
        }

        private void btn_down_MouseUp(object sender, MouseEventArgs e)
        {
            communicator.SendCommand(stop);
        }
    }
}
