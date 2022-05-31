using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace CustomURL01.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        IConfiguration _configuration;
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        //[BindProperty]
        //public List<string> Names { get; set; }

        public IActionResult OnGetAsync()
        {
            //Names = new List<string>();

            //String TableName = _configuration.GetSection("Settings:TableName").Value;

            //// var connectionStringBuilder = new SqliteConnectionStringBuilder();

            //string dbname = _configuration.GetSection("Settings:DBName").Value;

            //DataOperation dtOp = new DataOperation();

            //if (dtOp.InitializeDB(dbname))
            //{
            //    //dtOp.DeleteOldTable(dbname, TableName);

            //    dtOp.CreateNewTableIfNotExist(dbname, TableName);

            //    dtOp.InsertValue(dbname, TableName, new DataModels.URLMap("AmazingThing1", "<p>Amazing Thing 1</p>"));

            //    List<DataModels.URLMap> mydta = dtOp.ReadAllValues(dbname, TableName);

            //}
            


            //Use DB in project directory.  If it does not exist, create it:
            //connectionStringBuilder.DataSource = "./SqliteDB.db";

            //using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            //{
            //    SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            //    connection.Open();

            //    //Create a table (drop if already exists first):

            //    var delTableCmd = connection.CreateCommand();
            //    delTableCmd.CommandText = $"DROP TABLE IF EXISTS {TableName}";
            //    delTableCmd.ExecuteNonQuery();

            //    var createTableCmd = connection.CreateCommand();
            //    createTableCmd.CommandText = $@"CREATE TABLE IF NOT EXISTS {TableName}
            //                                (ID INTEGER PRIMARY KEY AUTOINCREMENT,
            //                                URLName VARCHAR(500),
            //                                URLValue VARCHAR(5000)
            //                                 )";
            //    int exeresult= createTableCmd.ExecuteNonQuery();

            //    //Seed some data:
            //    using (var transaction = connection.BeginTransaction())
            //    {
            //        var insertCmd = connection.CreateCommand();

            //        insertCmd.CommandText = $"INSERT INTO {TableName} (urlname,urlvalue) VALUES('testurl1','hello1')";
            //        insertCmd.ExecuteNonQuery();

            //        insertCmd.CommandText = $"INSERT INTO {TableName} (urlname,urlvalue) VALUES('testurl2','hello2')";
            //        insertCmd.ExecuteNonQuery();

            //        insertCmd.CommandText = $"INSERT INTO {TableName} (urlname,urlvalue) VALUES('testurl2','hello3')";
            //        insertCmd.ExecuteNonQuery();

            //        transaction.Commit();
            //    }

            //    //Read the newly inserted data:
            //    var selectCmd = connection.CreateCommand();
            //    selectCmd.CommandText = $"SELECT ID,urlname,urlvalue FROM {TableName}";

               
            //    using (var reader = selectCmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var message = reader.GetInt32(0);
            //            var res = reader.GetString(1);
            //            var res2 = reader.GetString(2);
            //            Names.Add($"{message.ToString()}-{res}-{res2}");
            //        }
            //    }


            //}


            return Page();
        }

    }
}