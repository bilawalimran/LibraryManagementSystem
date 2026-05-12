using App.Core.Data;
using App.Core.Interfaces;
using App.Core.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace LibraryManagementSystem.Infrastructure.Services
{
    public class BookService : IBookService
    {
        public void AddBook(Book book)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            string query = "INSERT INTO Books (Title, Author, Quantity) VALUES (@Title, @Author, @Quantity)";
            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Quantity", book.Quantity);

            cmd.ExecuteNonQuery();
        }

        public void UpdateBook(Book book)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            string query = "UPDATE Books SET Title=@Title, Author=@Author, Quantity=@Quantity WHERE Id=@Id";
            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", book.Id);
            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Quantity", book.Quantity);

            cmd.ExecuteNonQuery();
        }

        public void DeleteBook(int id)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            string query = "DELETE FROM Books WHERE Id=@Id";
            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            using var conn = DbHelper.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Books";
            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                books.Add(new Book
                {
                    Id = (int)reader["Id"],
                    Title = reader["Title"].ToString(),
                    Author = reader["Author"].ToString(),
                    Quantity = (int)reader["Quantity"]
                });
            }

            return books;
        }

        public Book GetBookById(int id)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Books WHERE Id=@Id";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Book
                {
                    Id = (int)reader["Id"],
                    Title = reader["Title"].ToString(),
                    Author = reader["Author"].ToString(),
                    Quantity = (int)reader["Quantity"]
                };
            }

            return null;
        }
    }
}