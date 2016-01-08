using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Xamarin.Forms;
using Codenutz.XFLabs.Basics.Droid;
using Codenutz.XFLabs.Basics.Interface;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Codenutz.XFLabs.Basics.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        { }

        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var filename = "ReserveTable.db3";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            return connection;
        }

    }
}