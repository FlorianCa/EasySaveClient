using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;

namespace EasySaveApp.ViewModels
{
    class ParametersViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _language;
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }

        public ICommand SelectFrench { get; private set; }
        public ICommand SelectEnglish { get; private set; }

        public ParametersViewModel()
        {
            Language = ConfigurationManager.AppSettings["Language"];
            SelectFrench = new RelayCommand<object>(param => ExecuteSelectFrench(), param => CanExecuteSelectFrench());
            SelectEnglish = new RelayCommand<object>(param => ExecuteSelectEnglish(), param => CanExecuteSelectEnglish());
        }

        private bool CanExecuteSelectEnglish()
        {
            if (Language == "FR")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ExecuteSelectEnglish()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;
            settings["Language"].Value = "GB";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            Language = ConfigurationManager.AppSettings["Language"];
        }

        private bool CanExecuteSelectFrench()
        {
            if (Language == "GB")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ExecuteSelectFrench()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;
            settings["Language"].Value = "FR";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            Language = ConfigurationManager.AppSettings["Language"];
        }

    }
}
