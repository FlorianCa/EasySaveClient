using EasySaveApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace EasySaveApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        private Socket client;
        public void SetClient(Socket socket)
        {
            client = socket;
        }

        private List<Save> _runningSaves;
        public List<Save> RunningSaves
        {
            get { return _runningSaves; }
            set { if (_runningSaves != value) _runningSaves = value; OnPropertyChanged(); }
        }

        public int NumberOfSave
        {
            get
            {
                return ListWorkSave.Count();
            }
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
                OnPropertyChanged("ListWorkSave");
            }
        }

        public HomeViewModel(Socket socket)
        {
            client = socket;
            ListWorkSave = new List<Save>();
            _runningSaves = new List<Save>();
            Init();
        }

        public void Init()
        {
            ListWorkSave = new List<Save>();
            _runningSaves = new List<Save>();
        }

        /*private void UpdateSave()
        {
            string jsonStringSerialize = "";

            foreach(Save s in RunningSaves)
            {
                try
                {
                    jsonStringSerialize += JsonConvert.SerializeObject(s, Formatting.Indented);
                    client.Send(Encoding.ASCII.GetBytes(jsonStringSerialize));

                }
                catch (InvalidCastException e)
                {
                    throw e;
                }
            }
        }*/
    }
}
