using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Gandalan.IDAS.WebApi.Client.Wpf.Controls
{
    public partial class CircularProgressBar : ProgressBar
    {
        public CircularProgressBar()
        {
            ValueChanged += CircularProgressBar_ValueChanged;
        }

        private void CircularProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var bar = sender as CircularProgressBar;
            var currentAngle = bar.Angle;
            var targetAngle = e.NewValue / bar.Maximum * 359.999;

            var anim = new DoubleAnimation(currentAngle, targetAngle, TimeSpan.FromMilliseconds(500));
            bar.BeginAnimation(AngleProperty, anim, HandoffBehavior.SnapshotAndReplace);
        }

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Angle. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(0.0));

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for StrokeThickness. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(10.0));
    }
}
