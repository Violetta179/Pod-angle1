using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        double _x;
        double _y;
        double _v0;
        double _vx;
        double _vy;
        double _angle;
        double _t;
        const double _dt = 0.1;
        const double _g = 9.81;
        const double _k = 0.1;

        public Form1()
        {
            InitializeComponent();
        }

        private void axis1_Load(object sender, EventArgs e)
        {
            axis1.Axis_Type = 3;
            axis1.x_Name = "Ox";
            axis1.y_Name = "Oy";
            axis1.x_Base = 1000;
            axis1.y_Base = 1000;
            axis1.Pix_Size = 0.01f;
            axis1.AxisDraw();
            axis1.StatToPic();
            axis1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _t += _dt;
            _x = (_vx * Math.Cos(_angle)) * _t;
            _y = (_vy * Math.Sin(_angle)) * _t - _g * _t * _t / 2;
            if (_y <= 0)
            {
                timer1.Stop();
                _x = 0;
                _y = 0;
                _t = 0;
            }
            axis1.PixDraw((float)_x, (float)_y, Color.Green, 0);
            axis1.StatToPic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        _angle = Convert.ToDouble(textBox2.Text) * Math.PI / 180;
        _v0 = Convert.ToDouble(textBox1.Text);
        _vx = _v0 * Math.Cos(_angle);
        _vy = _v0 * Math.Sin(_angle);
        timer1.Start();
    }

        private void timer2_Tick(object sender, EventArgs e)
        {
            _t += _dt;
            _vx = _vx - _dt * _dt * _k * _vx * _vx;
            _vy = _vy + _g * _dt * _dt;
            _x = _vx * Math.Cos(_angle) * _dt;
            _y = _vy * Math.Sin(_angle) * _dt - _g * _t * _t / 20;
            if (_y <= 0)
            {
                timer2.Stop();
                _x = 0;
                _y = 0;
                _t = 0;
            }
            axis1.PixDraw((float)_x, (float)_y, Color.Green, 0);
            axis1.StatToPic();
        }

    private void button2_Click(object sender, EventArgs e)
        {
            _angle = Convert.ToDouble(textBox2.Text) * Math.PI / 180;
            _v0 = Convert.ToDouble(textBox1.Text);
            _vx = _v0 * Math.Cos(_angle);
            _vy = _v0 * Math.Sin(_angle);
            timer2.Start();
        }
    }
}
