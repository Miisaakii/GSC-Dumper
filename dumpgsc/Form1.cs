using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XDevkit;
using JRPC_Client;
using System.Diagnostics;

namespace dumpgsc
{
    public partial class Form1 : Form
    {
        IXboxConsole RGH;
        uint start_range = 0x40300000;
        uint end_range = 9999999;
        string GSC_PATH = AppDomain.CurrentDomain.BaseDirectory + @"output/menu.gsc";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] GSC = RGH.GetMemory(start_range, end_range);
            File.WriteAllBytes(GSC_PATH, GSC);
            MessageBox.Show("GSC has been decompiled\n\nRun (Console Decompiler.exe) and select the decompiled GSC for get the source.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"output/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RGH.Connect(out RGH))
            {
                RGH.XNotify("GSC Dumper\nCreated By AimMisaki");
                MessageBox.Show("GSC Dumper connected!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Couldn't connect!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to GSC Dumper\nversion 1.0\nmade by AimMisaki", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
