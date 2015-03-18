using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project3
{
    public partial class Form1 : Form
    {
        private WeatherDisplayForm weatherDisplay;

        public void onWeatherDisplayFormClosing(Object sender, FormClosingEventArgs e)
        {
            Close();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Convert the duration minutes to seconds;
            int duration = 60 * (int) durationMinutes.Value;

            weatherDisplay = new WeatherDisplayForm(duration);
            weatherDisplay.Size = new Size(550, 550);
            weatherDisplay.FormClosing += onWeatherDisplayFormClosing;
            weatherDisplay.Show();
            this.Hide();
        }
    }
    public class WeatherDisplayForm : Form
    {
        GPU gpu;
        WeatherSystem systemTrackWeather;
        int simulationDuration;
        int timerCount;
        Timer simulationCountDown;
        bool simulationComplete;

        private void timerTickMethod(Object sender, EventArgs args)
        {
            if (simulationDuration == 0 || timerCount++ < (simulationDuration - 2))
                Invalidate();
            else
            {
                simulationCountDown.Stop();

                simulationComplete = true;
            }
        }

        public WeatherDisplayForm(int duration)
        {
            Load += onLoad;

            simulationDuration = duration;

            timerCount = 0;

            simulationCountDown = new Timer();

            simulationCountDown.Interval = 1000; // 1000 milliseconds = 1 second

            simulationCountDown.Tick += timerTickMethod;

            simulationComplete = false;
        }

        private void onLoad(object sender, EventArgs e)
        {
            this.ClientSize = new Size(700, 450);

            gpu = new GPU(this.ClientSize.Height);

            systemTrackWeather = new WeatherSystem(gpu.displaySize());

            simulationCountDown.Start();
        }

        protected override void OnPaint(PaintEventArgs paint)
        {
            if (!simulationComplete)
            {
                gpu.BeginPaint(paint);

                systemTrackWeather.updateWeatherDisplay(gpu);

                gpu.EndPaint();
            }
        }

    }
}
