using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using System.Windows;

namespace EasySaveApp.Model
{
    public class Model : INotifyPropertyChanged
    {

        private List<Save> _workSaveList = new List<Save>();
        public List<Save> WorkSaveList
        {
            get
            {
                return _workSaveList;
            }
            set
            {
                if(_workSaveList != value)
                {
                    _workSaveList = value;
                    OnPropertyChanged();
                }
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Save> _runningSaves = new List<Save>();
        public List<Save> RunningSaves
        {
            get { return _runningSaves; }
            set { if (_runningSaves != value) { _runningSaves = value; OnPropertyChanged(); } }
        }

        public Model()
        {

        }

        public void SetSaves(string str)
        {

            List<Save> saveList = new List<Save>();

            JsonTextReader reader = new JsonTextReader(new StringReader(str));
            reader.SupportMultipleContent = true;

            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }

                JsonSerializer serializer = new JsonSerializer();
                Save save = serializer.Deserialize<Save>(reader);
                saveList.Add(save);
            }


            RunningSaves = saveList;

            /*foreach(Save s in RunningSaves)
            {
                MessageBox.Show(s.ToString());
            }*/
        }

    }
}

