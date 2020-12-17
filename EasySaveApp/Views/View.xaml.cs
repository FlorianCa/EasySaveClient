using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EasySaveApp.ViewModels;

namespace EasySaveApp.Views
{
    /// <summary>
    /// Logique d'interaction pour View.xaml
    /// </summary>
    public partial class View : Window
    {
        private ViewModel _vm = new ViewModel();

        public View()
        {
            InitializeComponent();
            DataContext = _vm;
            FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata
            {
                DefaultValue = FindResource(typeof(Window))
            });
        }

        private void OnCloseButton(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
            this.Close();
        }
        
        private void OnMaximizeButton(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }
        
        private void OnReduceButton(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
