using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows;

namespace AudioPlayer
{
    [Serializable]
    public class PlayListList : List<TrackItem>
    {
        private const string PATH = "../../playlist.db";
        public PlayListList()
        {
            readFromDatabase();
        }

        public void Add(TrackItem item)
        {
            base.Add(item);
            addToDatabase(item);
        }


        
        
        


        #region Database
        private void readFromDatabase()
        {
            SQLiteConnection connection = getConnection();
            // SQLiteCommand command = _connection.CreateCommand();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT \"index\", title, author, length, PATH FROM Tracks", connection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                int index = int.Parse(row.ItemArray[0].ToString());
                string title = row.ItemArray[1].ToString();
                string author = row.ItemArray[2].ToString();
                int lenght = int.Parse(row.ItemArray[3].ToString());
                string path =row.ItemArray[4].ToString();

                TrackItem trackItem = new TrackItem(index, title, author, lenght, path);
                
                base.Add(trackItem);
            }
        }

        private void addToDatabase(TrackItem item)
        {
            SQLiteConnection connection = getConnection();
            

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO Tracks (\"index\", title, author, length, PATH) VALUES ({item.index}, '{item.title}', '{item.author}', {item.length}, '{item.path}');";
            command.ExecuteNonQuery();
            
            connection.Close();
        }

        private void writeAllToDatabase()
        {
            foreach (var trackItem in this)
            {
                addToDatabase(trackItem);
            }
        }

        private static SQLiteConnection getConnection()
        {
            SQLiteConnection sqLiteConnection = new SQLiteConnection($"Data Source={PATH};New=False;Compress=True");
            sqLiteConnection.Open();
            return sqLiteConnection;
        }
        #endregion
    }
}
