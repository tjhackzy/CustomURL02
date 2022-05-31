using Microsoft.Data.Sqlite;

using static CustomURL01.DataModels;

namespace CustomURL01
{
    public class DataModels
    {


        public class URLMap
        {
            public int ID { get; set; }
            public string? URLName { get; set; }
            public string? URLValue { get; set; }

            public URLMap(int id, string name, string value)
            {
                this.ID = id;
                this.URLName = name;
                this.URLValue = value;
            }
            public URLMap( string name, string value)
            {
                
                this.URLName = name;
                this.URLValue = value;
            }
        }
    }
    public class DataOperation
    {
        public bool InitializeDB(string dbname)
        {
            try
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder();
                connectionStringBuilder.DataSource = $"./{dbname}";

                using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
                connection.Open();
            }
            catch
            {

                return false;
            }
            return true;

        }


        public bool DeleteOldTable(string dbname, string TableName)
        {
            try
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder();
                connectionStringBuilder.DataSource = $"./{dbname}";

                using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
                connection.Open();

                var delTableCmd = connection.CreateCommand();
                delTableCmd.CommandText = $"DROP TABLE IF EXISTS {TableName}";
                delTableCmd.ExecuteNonQuery();

            }
            catch
            {
                return false;
            }
            return true;

        }

        public bool CreateNewTableIfNotExist(string dbname, string TableName)
        {
            try
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder();
                connectionStringBuilder.DataSource = $"./{dbname}";

                using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
                connection.Open();

                var createTableCmd = connection.CreateCommand();
                createTableCmd.CommandText = $@"CREATE TABLE IF NOT EXISTS {TableName}
                                            (ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                            URLName VARCHAR(500),
                                            URLValue VARCHAR(5000)
                                             )";
                int exeresult = createTableCmd.ExecuteNonQuery();

            }
            catch
            {
                return false;
            }
            return true;

        }

        public bool InsertValue(string dbname, string TableName, URLMap dta)
        {
            try
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder();
                connectionStringBuilder.DataSource = $"./{dbname}";

                using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();

                    insertCmd.CommandText = $"INSERT INTO {TableName} (urlname,urlvalue) VALUES('{dta.URLName}','{dta.URLValue}')";
                    insertCmd.ExecuteNonQuery();
                  
                    transaction.Commit();
                }


            }
            catch
            {
                return false;
            }
            return true;

        }

        public List<URLMap> ReadAllValues(string dbname, string TableName)
        {
            List<URLMap> mydata = new List<URLMap>();
            try
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder();
                connectionStringBuilder.DataSource = $"./{dbname}";

                using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = $"SELECT ID,urlname,urlvalue FROM {TableName}";


                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string value = reader.GetString(2);
                        mydata.Add(new URLMap(id, name, value));
                    }
                }


            }
            catch
            {
                return mydata;
            }
            return mydata;

        }


    }
}
