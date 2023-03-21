using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Gandalan.IDAS.WebApi.Client.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for SmallHeaderControl.xaml
    /// </summary>
    
    public partial class LargeHeaderControl : UserControl, INotifyPropertyChanged
    {
        public LargeHeaderControl()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        [Description("Text für den Header"), Category("LargeHeaderControl")]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(LargeHeaderControl), new UIPropertyMetadata(""));

        [Description("Bild für den Button"), Category("LargeHeaderControl")]
        public Uri ImageSource
        {
            get { return (Uri)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("ImageSource", typeof(Uri), typeof(LargeHeaderControl), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnImageSourceChanged)));
        
        public event RoutedEventHandler Click;
        public event PropertyChangedEventHandler PropertyChanged;

        public Visibility ButtonVisible { get { return Click != null ? Visibility.Visible : Visibility.Hidden; } }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(sender, e);
        }

        private static void OnImageSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            LargeHeaderControl userControl = (LargeHeaderControl)sender;
            userControl.ButtonImage.Source = new BitmapImage((Uri)e.NewValue);
        }
    }
}
