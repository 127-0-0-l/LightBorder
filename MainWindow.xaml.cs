using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace LightBorder
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Interval = new TimeSpan(0, 0, 0, 0, 200);

            byte maxValue = 255;
            byte minValue = 75;
            byte speed = 10;
            byte r = maxValue;
            byte g = minValue;
            byte b = minValue;


            t.Tick += (s, a) =>
            {
                if (r == maxValue && g < maxValue && b == minValue)
                {
                    g += speed;
                }
                else if (r > minValue && g == maxValue && b == minValue)
                {
                    r -= speed;
                }
                else if (r == minValue && g == maxValue && b < maxValue)
                {
                    b += speed;
                }
                else if (r == minValue && g > minValue && b == maxValue)
                {
                    g -= speed;
                }
                else if (r < maxValue && g == minValue && b == maxValue)
                {
                    r += speed;
                }
                else if (r == maxValue && g == minValue && b > minValue)
                {
                    b -= speed;
                }

                BorderBrush = new SolidColorBrush(Color.FromRgb(r, g, b));
            };

            t.Start();
        }
    }
}
