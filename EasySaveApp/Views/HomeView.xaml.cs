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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EasySaveApp.Model;
using EasySaveApp.ViewModels;

namespace EasySaveApp.Views
{
    /// <summary>
    /// Logique d'interaction pour HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void PauseSave(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Save save = button.DataContext as Save;
            save.Status = "Paused";
            //save.WaitHandle.Reset();
        }

        private void PlaySave(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Save save = button.DataContext as Save;
            save.Status = "Is Running";
            //save.WaitHandle.Set();
        }

        private void StopSave(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Save save = button.DataContext as Save;
            save.Status = "Stopped";
            save.Stop = true;
        }
    }
}
