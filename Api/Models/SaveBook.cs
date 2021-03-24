using System.Data.SQLite;
using Api.Models.Interfaces;

namespace Api.Models
{
    public class SaveBook : IInsertBook
    {
        public void IInsertBook(Book value)
        {
            string cs = @"URI=file:C:\Users\arynk\documents\code\source1\bookdatabase\book.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO books(title, author) VALUES(@title, @author)";
            cmd.Parameters.AddWithValue("@title", value.Title);
            cmd.Parameters.AddWithValue("@author", value.Author);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}