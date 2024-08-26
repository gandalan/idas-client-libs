using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using PropertyChanged;

namespace Gandalan.IDAS.WebApi.Client.Wpf.Controls;

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
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(LargeHeaderControl), new UIPropertyMetadata(""));

    [Description("Bild für den Button"), Category("LargeHeaderControl")]
    //[OnChangedMethod(nameof(OnImageSourceChanged))]
    public Uri ImageSource
    {
        get => (Uri)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("ImageSource", typeof(Uri), typeof(LargeHeaderControl), new FrameworkPropertyMetadata(OnImageSourceChanged));

    public event RoutedEventHandler Click;
    public event PropertyChangedEventHandler PropertyChanged;

    public Visibility ButtonVisible => Click != null ? Visibility.Visible : Visibility.Hidden;

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Click?.Invoke(sender, e);
    }

    [SuppressPropertyChangedWarnings]
    private static void OnImageSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var userControl = (LargeHeaderControl)sender;
        userControl.ButtonImage.Source = new BitmapImage((Uri)e.NewValue);
    }
}
