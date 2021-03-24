using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using Api.Models.Interfaces;

namespace Api.Models
{
    public class ReadBookData : IGetAllBooks, IGetBook
    {
        //creating a db with test rows
        public List<Book> GetAllBooks()
        {
            // string currentDir = Directory.GetCurrentDirectory();
            // System.Console.WriteLine(currentDir);
            string cs = @"URI=file:C:\Users\arynk\documents\code\source1\bookdatabase\book.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM books";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            List<Book> allBooks = new List<Book>();
            while (rdr.Read())
            {
                allBooks.Add(new Book(){Id = rdr.GetInt32(0), Title = rdr.GetString(1), Author = rdr.GetString(2)});
            }
            return allBooks;
        }

        public Book GetBook(int id)
        {
            string cs = @"URI=file:C:\Users\arynk\documents\code\source1\bookdatabase\book.db";
            
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM books WHERE id = @id";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            return new Book(){Id = rdr.GetInt32(0), Title = rdr.GetString(1), Author = rdr.GetString(2)};

            
        }
    }
}
