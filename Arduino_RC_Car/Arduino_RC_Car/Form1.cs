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
        public const char stop = '0';
        public const char forward = '1';
        public const char backward = '2';
        public const char left = '3';
        public const char right = '4';
        public const char requestData = '5';

        public static string Message { get; set; }

        Radar radar = new Radar();

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
            communicator.Start();
            if (communicator.serialPort.IsOpen)
            {
                MessageBox.Show("connected");
                lbl_status.Location = new Point((638 / 2) - 55, 59); //so it can be in the middle
                lbl_status.ForeColor = Color.FromArgb(0,122,204);
                lbl_status.Text = "Connected successfully";

            }
            
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            lbl_status.Text = Message;
            if (communicator.serialPort.IsOpen)
            {
                //communicator.SendCommand("5");
                communicator.serialPort.DataReceived += SerialPort_DataReceived;
            }
        }

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

    }
}
