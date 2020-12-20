using System;
using System.Globalization;
using System.Windows.Forms;

namespace CPS_Counter
{
    public partial class Form1 : Form
    {
        private int _clicks;
        private int _clicks2;
        private int _max1Sec;
        private double _maxAverage;
        private int _time;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                _clicks++;
                _clicks2++;
                label8.Text = _clicks.ToString();
                timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _time++;
            timercountdown.Text = _time.ToString();
            var calc = _clicks / _time;
            chart1.Series["Clicks"].Points.AddXY(_time.ToString(), _clicks2.ToString());
            chart1.Series["Averages"].Points.AddXY(_time.ToString(), calc.ToString(CultureInfo.CurrentCulture));
            label4.Text = calc.ToString(CultureInfo.CurrentCulture);
            label5.Text = _clicks2.ToString();
            _max1Sec = Math.Max(_max1Sec, _clicks2);
            label9.Text = _max1Sec.ToString();
            _maxAverage = Math.Max(_maxAverage, calc);
            label11.Text = _maxAverage.ToString(CultureInfo.CurrentCulture);
            _clicks2 = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series["Clicks"].Points.Clear();
            chart1.Series["Averages"].Points.Clear();
            timer1.Stop();
            _time = 0;
            _clicks = 0;
            _clicks2 = 0;
            label4.Text = @"0";
            timercountdown.Text = @"0";
            label8.Text = @"0";
            label5.Text = @"0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label9.Text = @"0";
            label11.Text = @"0";
            _max1Sec = 0;
            _maxAverage = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}