using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;

namespace EasySaveApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetLanguageDictionary();
        }

        private void SetLanguageDictionary()
        {
            switch (ConfigurationManager.AppSettings["Language"])
            {
                case "FR":
                    EasySaveApp.Resources.Resources.Culture = new System.Globalization.CultureInfo("fr-FR");
                    break;
                case "GB":
                    EasySaveApp.Resources.Resources.Culture = new System.Globalization.CultureInfo("en-GB");
                    break;
                default://default english because there can be so many different system language, we rather fallback on english in this case.
                    EasySaveApp.Resources.Resources.Culture = new System.Globalization.CultureInfo("en-GB");
                    break;
            }

        }

    }
}
