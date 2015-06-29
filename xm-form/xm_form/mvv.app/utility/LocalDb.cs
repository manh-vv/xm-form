using System;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;

namespace xm_form.mvv.app.utility
{
    public class LocalDb
    {
        private static SQLiteAsyncConnection _dbConn;

        public static void SetDb(string dbPath, ISQLitePlatform sqlitePlatform)
        {
            //initialize a new SQLiteConnection 
            if (_dbConn == null)
            {
                var connectionFunc = new Func<SQLiteConnectionWithLock>(() =>
                    new SQLiteConnectionWithLock
                    (
                        sqlitePlatform,
                        new SQLiteConnectionString(dbPath, false)
                    ));

                _dbConn = new SQLiteAsyncConnection(connectionFunc);


                // call create table
                CreateTableAsyncTask();
            }
        }

        private static void CreateTableAsyncTask()
        {
            //
            //                _dbConn.CreateTableAsync<Person>();
        }
    }
}