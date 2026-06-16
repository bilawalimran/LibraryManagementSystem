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
        private readonly string _connectionString;

        public BookService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
        }

        public void AddBook(Book book)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Books(Id, Title, Author, Category, PublishedDate, Quantity) VALUES (@Id, @Title, @Author, @Category, @PublishedDate, @Quantity)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", book.Id);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Category", book.Category.ToString());
                cmd.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
                cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateBook(Book book)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Books SET Title=@Title, Author=@Author, Category=@Category, PublishedDate=@PublishedDate, Quantity=@Quantity WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", book.Id);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Category", book.Category.ToString());
                cmd.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
                cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBook(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) books.Add(ReadBook(reader));
                }
            }
            return books;
        }

        public Book? GetBookById(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return ReadBook(reader);
                }
            }
            return null;
        }

        public List<Book> SearchBooks(string keyword)
        {
            List<Book> books = new List<Book>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Books WHERE Title LIKE @Keyword OR Author LIKE @Keyword OR Category LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) books.Add(ReadBook(reader));
                }
            }
            return books;
        }

        private Book ReadBook(SqlDataReader reader)
        {
            Book b = new Book();
            b.Id = reader["Id"].ToString() ?? string.Empty;
            b.Title = reader["Title"].ToString() ?? string.Empty;
            b.Author = reader["Author"].ToString() ?? string.Empty;
            b.Category = Enum.TryParse<BookCategory>(reader["Category"].ToString(), true, out var category) ? category : BookCategory.Science;
            b.PublishedDate = Convert.ToDateTime(reader["PublishedDate"]);
            b.Quantity = Convert.ToInt32(reader["Quantity"]);
            return b;
        }
    }
}