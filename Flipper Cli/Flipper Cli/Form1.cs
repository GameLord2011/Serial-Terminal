using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flipper_Cli
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            getAvaliblePortNames();

        }

        void getAvaliblePortNames()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
        }


        private void Cli_Click(object sender, EventArgs e)
        {
            
        }

        private void cliSend_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openButon_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || comboBox2.Text == "")
                {
                    Recive.Text = "Please select a serial port and/or baud rate.";
                }
                else
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.WriteTimeout = 3000;
                    serialPort1.ReadTimeout = 3000;
                    serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                    serialPort1.Open();
                    progressBar1.Value = 100;
                    button1.Enabled = true;
                    textBox2.Enabled = true;
                    textBox1.Enabled = true;
                    openButon.Enabled = false;
                    closeButton.Enabled = true;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                }
            }
            catch (UnauthorizedAccessException)
            {
                textBox1.Text = "Acess to this port is denied. :-(";
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            Console.Beep();
            button1.Enabled = false;
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            openButon.Enabled = true;
            closeButton.Enabled = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(textBox2.Text);
            textBox2.Text = "";
            try
            {
                string v = serialPort1.ReadLine();
                textBox1.Text = v;
            }
            catch (TimeoutException)
            {
                textBox1.Text = "device timed out.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
