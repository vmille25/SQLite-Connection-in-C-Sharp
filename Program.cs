using System;
using System.Data.SQLite;

namespace SQLite_Sample_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection sqliteConnection;
            sqliteConnection = CreateConnection();
            CreateTable(sqliteConnection);
            InsertData(sqliteConnection);
            ReadData(sqliteConnection);
        }
        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqliteConn;
            sqliteConn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True;");
            try
            {
                sqliteConn.Open();
            }
            catch
            {

            }
            return sqliteConn;
        }

        static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCommand;
            string createSQL = "CREATE TABLE SampleTable(Col1 VARCHAR(20), Col2 INT)";
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = createSQL;
            sqliteCommand.ExecuteNonQuery();
        }

        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES ('Sample Text', 1);";
            sqliteCommand.ExecuteNonQuery();
        }

        static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqliteReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "SELECT * FROM SampleTable";
            sqliteReader = sqliteCommand.ExecuteReader();
            while (sqliteReader.Read())
            {
                string readerString = sqliteReader.GetString(0);
                Console.WriteLine(readerString);
            }
            conn.Close();
        }
    }
}
