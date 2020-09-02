using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PropertyChanged;

namespace Gandalan.IBOS3.Controls
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
