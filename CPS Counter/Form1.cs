using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace CPS_Counter
{
    public partial class Form1 : Form
    {
        int clicks = 0;
        int clicks2 = 0;
        int max1sec;
        double maxaverage;
        int time = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                clicks++;
                clicks2++;
                label8.Text = clicks.ToString();
                timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            timercountdown.Text = time.ToString();
            double calc = clicks / time;
            chart1.Series["Clicks"].Points.AddXY(time.ToString(), clicks2.ToString());
            chart1.Series["Averages"].Points.AddXY(time.ToString(), calc.ToString());
            label4.Text = calc.ToString();
            label5.Text = clicks2.ToString();
            max1sec = Math.Max(max1sec, clicks2);
            label9.Text = max1sec.ToString();
            maxaverage = Math.Max(maxaverage, calc);
            label11.Text = maxaverage.ToString();
            clicks2 = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series["Clicks"].Points.Clear();
            chart1.Series["Averages"].Points.Clear();
            timer1.Stop();
            time = 0;
            clicks = 0;
            clicks2 = 0;
            label4.Text = "0";
            timercountdown.Text = "0";
            label8.Text = "0";
            label5.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label9.Text = "0";
            label11.Text = "0";
            max1sec = 0;
            maxaverage = 0;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}