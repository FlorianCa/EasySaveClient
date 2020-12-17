using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using EasySaveApp.Model;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace EasySaveApp.ViewModels
{
    class ViewModel
    {
        //private Model.Model _model = new Model.Model();

        private Socket client;
        public HomeViewModel HomeViewModel { get; set; }
        public ExecuteViewModel ExecuteViewModel { get; set; }

        public ParametersViewModel ParametersViewModel { get; set; }

        public ViewModel ()
        {
            Thread thread = new Thread(new ThreadStart(ConnectionRemoteConsole));
            thread.Start();

            HomeViewModel = new HomeViewModel(client);
            ExecuteViewModel = new ExecuteViewModel(client);
            ParametersViewModel= new ParametersViewModel();

        }

        private void ConnectionRemoteConsole()
        {
            client = ConnectSocket();
            ExecuteViewModel.SetClient(client);
            HomeViewModel.SetClient(client);

            ListenNetwork(client);
            //Disconnect(client);
        }

        private static Socket ConnectSocket()
        {
            Socket socketC = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 49153);
            socketC.Connect(iep);
            return socketC;
        }

        private void ListenNetwork(Socket s)
        {
            string data = null;
            byte[] bytes = new byte[1024];
            try
            {

                while (true)
                {
                    int bytesRec = s.Receive(bytes);
                    data += Encoding.Default.GetString(bytes, 0, bytesRec);

                    if (!String.IsNullOrEmpty(data))
                    {

                        List<Save> saveList = new List<Save>();
                        List<Save> currentSaveList = new List<Save>();

                        JsonTextReader reader = new JsonTextReader(new StringReader(data))
                        {
                            SupportMultipleContent = true
                        };

                        while (true)
                        {
                            if (!reader.Read())
                            {
                                break;
                            }

                            JsonSerializer serializer = new JsonSerializer();
                            Save save = serializer.Deserialize<Save>(reader);

                            if (save.Status != "Done")
                            {
                                
                                currentSaveList.Add(save);
                            }
                            else
                            {
                                saveList.Add(save);
                            }

                            ExecuteViewModel.ListWorkSave = saveList;
                            HomeViewModel.RunningSaves = currentSaveList;
                        }

                    }

                    data = null;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Disconnect(Socket socket)
        {
            socket.Close();
        }
    }
}
