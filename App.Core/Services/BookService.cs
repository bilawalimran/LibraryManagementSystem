using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace App.Core.Services
{
    public class BookService : IBookService
    {
        private static SqlConnection GetConnection()
        {
            string? connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string 'LibraryDB' was not found in App.config.");
            }

            return new SqlConnection(connectionString);
        }

        public void AddBook(Book book)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = @"INSERT INTO Books
                            (Id, Title, Author, Category, PublishedDate, Quantity)
                            VALUES
                            (@Id, @Title, @Author, @Category, @PublishedDate, @Quantity)";

            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", book.Id);
            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Category", book.Category.ToString());
            cmd.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
            cmd.Parameters.AddWithValue("@Quantity", book.Quantity);

            cmd.ExecuteNonQuery();
        }

        public void UpdateBook(Book book)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = @"UPDATE Books
                             SET Title=@Title,
                                 Author=@Author,
                                 Category=@Category,
                                 PublishedDate=@PublishedDate,
                                 Quantity=@Quantity
                             WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", book.Id);
            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Category", book.Category.ToString());
            cmd.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
            cmd.Parameters.AddWithValue("@Quantity", book.Quantity);

            cmd.ExecuteNonQuery();
        }

        public void DeleteBook(string id)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = "DELETE FROM Books WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            using var conn = GetConnection();
            conn.Open();

            string query = "SELECT * FROM Books";

            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                books.Add(ReadBook(reader));
            }

            return books;
        }

        public Book? GetBookById(string id)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = "SELECT * FROM Books WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return ReadBook(reader);
            }

            return null;
        }

        public List<Book> SearchBooks(string filterType, string keyword)
        {
            var books = new List<Book>();

            using var conn = GetConnection();
            conn.Open();

            string query = $"SELECT * FROM Books WHERE {filterType} LIKE @Keyword";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                books.Add(ReadBook(reader));
            }

            return books;
        }

        private static Book ReadBook(SqlDataReader reader)
        {
            return new Book
            {
                Id = reader["Id"].ToString() ?? string.Empty,
                Title = reader["Title"].ToString() ?? string.Empty,
                Author = reader["Author"].ToString() ?? string.Empty,
                Category = Enum.Parse<BookCategory>(
                    reader["Category"].ToString() ?? nameof(BookCategory.Science)),
                PublishedDate = (DateTime)reader["PublishedDate"],
                Quantity = (int)reader["Quantity"]
            };
        }
    }
}
