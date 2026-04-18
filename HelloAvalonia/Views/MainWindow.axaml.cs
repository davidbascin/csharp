using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;

namespace HelloAvalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void Button_OnClick(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine("Button clicked!");
    }
}