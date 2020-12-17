using EasySaveApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace EasySaveApp.ViewModels
{
    class ExecuteViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Socket client;
        public void SetClient(Socket s)
        {
            client = s;
        }

        private List<Save> _listWorkSave;
        public List<Save> ListWorkSave
        {
            get
            {
                return _listWorkSave;
            }
            set
            {
                _listWorkSave = value;
                OnPropertyChanged();
            }
        }
        public Save SelectedItem
        {
            get
            {
                return ListWorkSave.Where(item => item.IsSelected).FirstOrDefault();
            }
        }
        public ICommand OneSave { get; private set; }
        public ICommand AllSave { get; private set; }

        /*
         * Thread vars
         */
        public bool saveRunning = false;
        
        public ExecuteViewModel(Socket socket)
        {
            client = socket;
            Init();
            OneSave = new RelayCommand<object>(param => ExecuteOneSave(), param => CanExecuteSave());
            AllSave = new RelayCommand<object>(param => ExecuteAllSave(), param => true);
        }

        private bool CanExecuteSave()
        {
            if (ListWorkSave.Count > 0 && SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ExecuteAllSave()
        {
            
            ListWorkSave.ForEach(i => Save(i));
        }

        private void ExecuteOneSave()
        {
            
            Save(SelectedItem);
        }

        private void Save(object save)
        {
            Save s = (Save)save;
            string jsonStringSerialize = "";

            jsonStringSerialize += JsonConvert.SerializeObject(s, Formatting.Indented);
            client.Send(Encoding.ASCII.GetBytes(jsonStringSerialize));

        }

        private void Init()
        {
            ListWorkSave = new List<Save>();
        }
    }
}
