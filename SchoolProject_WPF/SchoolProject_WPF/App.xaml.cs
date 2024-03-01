using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace SchoolProject_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public static class DbString
    { 
        //public static string conString { get; } = "Data Source=.;Initial Catalog=StudentDb;Integrated Security=True;Encrypt=False";
        public static string conString { get; } = "Data Source=ad1server.database.windows.net;Initial Catalog=StudentDb;User ID=****;Password=****;Encrypt=True";

    }
}
