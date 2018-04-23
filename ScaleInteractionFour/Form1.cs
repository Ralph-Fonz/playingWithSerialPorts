﻿using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
using System.Linq;

namespace ScaleInteractionFour
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rdoOne.Visible = false;
            rdoTwo.Visible = false;
            rdoThree.Visible = false;
            rdoFour.Visible = false;
            try
            {
                getAvaliablePorts();
            }
            catch
            {

            }

        }
        #region port Open/Close
        // Open Port
        void openPort()
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();
            }
            else
            {
                serialPort1.Close();
                serialPort1.Open();
            }
        }

        // Close Port
        void closePort()
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                serialPort1.Dispose(); // clears
            }
        }
        #endregion

        #region Port Settings
        void grpBox_Validated(object sender, EventArgs e)
        {
            GroupBox g = sender as GroupBox;
            var a = from RadioButton r in g.Controls
                    where r.Checked == true
                    select r.Name;
            var strChecked = a.First();
            txtRand.Text = strChecked;
        }

        void portSettings()
        {
            var checkedButton = groupBox1.Controls.OfType<RadioButton>()
                                  .FirstOrDefault(r => r.Checked);
            txtRand.Text = checkedButton.Text;

            //serialPort1.PortName = Convert.ToString(cboPorts.Text); // find selected radio button

            serialPort1.BaudRate = 9600; // Important* set BaudRate from scale
            serialPort1.Parity = Parity.None; // Important* set Parity from scale

        }
        #endregion

        #region Available Ports
        void getAvaliablePorts()
        {
            String[] ports = SerialPort.GetPortNames();

            int numbPorts = ports.Length;

            switch (numbPorts)
            {
                case 1:
                    rdoOne.Visible = true;
                    rdoOne.Text = ports[0];
                    lblOne.Text = "Rand Port Name";
                    break;
                case 2:
                    rdoOne.Visible = true;
                    rdoTwo.Visible = true;
                    rdoOne.Text =  ports[0];
                    lblOne.Text = "Rand Port Name";
                    rdoTwo.Text =  ports[1];
                    lblOne.Text = "Rand Port Name";
                    break;
                case 3:
                    rdoOne.Visible = true;
                    rdoTwo.Visible = true;
                    rdoThree.Visible = true;
                    rdoOne.Text = ports[0];
                    lblOne.Text = "Rand Port Name";
                    rdoTwo.Text = ports[1];
                    lblOne.Text = "Rand Port Name";
                    rdoThree.Text =  ports[2];
                    lblOne.Text = "Rand Port Name";
                    break;
                case 4:
                    rdoOne.Visible = true;
                    rdoTwo.Visible = true;
                    rdoThree.Visible = true;
                    rdoFour.Visible = true;
                    rdoOne.Text = ports[0];
                    lblOne.Text = "Rand Port Name";
                    rdoTwo.Text =  ports[1];
                    lblOne.Text = "Rand Port Name";
                    rdoThree.Text =  ports[2];
                    lblOne.Text = "Rand Port Name";
                    rdoFour.Text = ports[3];
                    lblOne.Text = "Rand Port Name";
                    break;
            }


            void getPortDetails()
            {
                // TODO: find a way to list port details
            }


            #endregion
        }


        private void button1_Click(object sender, EventArgs e)
        {
            portSettings();
        }
    }
}
