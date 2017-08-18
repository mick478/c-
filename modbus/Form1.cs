using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Modbus.Device;

namespace WindowsFormsApplication11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModbusSerialRtuMasterWriteRegisters(2);
        }
        public static void ModbusSerialRtuMasterWriteRegisters(ushort a1)
        {
            using (SerialPort port = new SerialPort("COM4"))
            {
                // configure serial port
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.Open();

                // create modbus master
                IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);

                byte slaveId = 1;
                ushort startAddress = 00008;
                ushort[] registers = new ushort[] { a1 };

                // write three registers
                master.WriteMultipleRegisters(slaveId, startAddress, registers);
                //var values = master.ReadHoldingRegisters(slaveId, startAddress, 14);
                //Console.WriteLine(values);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ModbusSerialRtuMasterWriteRegisters(0);
        }

    }
}
