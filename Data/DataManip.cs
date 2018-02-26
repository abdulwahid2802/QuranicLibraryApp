using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Mono.Data.Sqlite;
using System.Threading.Tasks;

namespace DesignLibrary_Tutorial.Data
{
    public class DataManip
    {
        private Context mContext;
        public DataManip(Context context)
        {
            this.mContext = context;
           

            // using File.Exists
        

        }

        public string createDBconnection()
        {
            try
            {
                var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var pathToDatabase = Path.Combine(docsFolder, "db_adonet.db");
                SqliteConnection.CreateFile(pathToDatabase);
                return pathToDatabase.ToString();
            }
            catch (IOException ex)
            {
                var reason = string.Format("The database failed to create - reason {0}", ex.Message);
                Toast.MakeText(mContext, reason, ToastLength.Long).Show();
                return null;
            }
        }

        public string createDatabase(string path)
        {
            try
            {
                var connection = new SQLiteAsyncConnection(path);
                connection.CreateTableAsync<LocalDB>();
                return "Database created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> insertUpdateData(LocalDB data, string path)
        {
            try
            {
                var db = new SQLiteAsyncConnection(path);
                int insRes = await db.InsertAsync(data);

                if ( insRes != 0)
                    await db.UpdateAsync(data);

                return "Single data file inserted or updated";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        public Task<LocalDB> Query(string path, int id)
        {



            LocalDB ldb = new LocalDB();
            var db = new SQLiteAsyncConnection(path);
            return db.Table<LocalDB>().Where(i => i.FirstName == "AbdulVohid").FirstOrDefaultAsync();

        }


    }
}