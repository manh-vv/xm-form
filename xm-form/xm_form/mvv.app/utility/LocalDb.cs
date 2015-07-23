using System;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using xm_form.mvv.app.model;

namespace xm_form.mvv.app.utility
{
    public static class LocalDb
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

	    public static async void SelectOne<T>(string query, object[] queryParams, Action<T> whenDone) where T : DbModel
	    {
		    var list = await _dbConn.QueryAsync<T>(query, queryParams);
		    
			T t = null;
		    
			if (list != null && list.Count > 0)
			    t = list[0];

			whenDone.Invoke(t);
	    }

	    public static async Task<int> Insert<T>(T t) where T : DbModel
	    {
		    var i = await _dbConn.InsertAsync(t);
			
			return i;
	    }

	    public static async Task<int> InsertOrReplaceAsync<T>(T t) where T : DbModel
	    {
		    var i = await _dbConn.InsertOrReplaceAsync(t);
		    return i;
	    }
    }

	
}