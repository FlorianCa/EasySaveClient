using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;

namespace EasySaveApp.Model
{
    public class Save : INotifyPropertyChanged
    {
        private string _name;
        private string _sourcePath;
        private string _destiPath;
        private string _type;
        private bool _isselected;
        private int _percent;
        public double elapsedTime;
        private int _filesSaved = 0;
        private int _filesTotal;
        private string _status = "Done";
        public bool Stop = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SourcePath
        {
            get
            {
                return _sourcePath;
            }
            set
            {
                if (_sourcePath != value)
                {
                    _sourcePath = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DestiPath
        {
            get
            {
                return _destiPath;
            }
            set
            {
                if (_destiPath != value)
                {
                    _destiPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsSelected
        {
            get
            {
                return _isselected;
            }
            set
            {
                _isselected = value;
                OnPropertyChanged();
            }
        }

        public int Percent
        {
            get
            {
                return _percent;
            }
            set
            {
                if (_percent != value)
                {
                    _percent = value;
                    OnPropertyChanged();
                }
            }
        }

        public int FilesSaved
        {
            get
            {
                return _filesSaved;
            }
            set
            {
                if (_filesSaved != value)
                {
                    _filesSaved = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public int FilesTotal
        {
            get
            {
                return _filesTotal;
            }
            set
            {
                if (_filesTotal != value)
                {
                    _filesTotal = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
