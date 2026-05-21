using App.Core.Interfaces;
using App.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace App.Core.Services
{
    public class IssueService : IIssueService
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

        public void IssueBook(IssueRecord issue)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = @"INSERT INTO Issues(BookId, MemberId, IssueDate, ReturnDate)
                             VALUES(@BookId, @MemberId, @IssueDate, @ReturnDate)";

            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@BookId", issue.BookId);
            cmd.Parameters.AddWithValue("@MemberId", issue.MemberId);
            cmd.Parameters.AddWithValue("@IssueDate", issue.IssueDate == default ? DateTime.Now : issue.IssueDate);
            cmd.Parameters.AddWithValue("@ReturnDate", issue.ReturnDate.HasValue
                ? issue.ReturnDate.Value
                : DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        public void ReturnBook(int issueId)
        {
            ReturnBook(issueId, DateTime.Now);
        }

        public void ReturnBook(int issueId, DateTime returnDate)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = "UPDATE Issues SET ReturnDate=@ReturnDate WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", issueId);
            cmd.Parameters.AddWithValue("@ReturnDate", returnDate);

            cmd.ExecuteNonQuery();
        }

        public void DeleteIssue(int issueId)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = "DELETE FROM Issues WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", issueId);

            cmd.ExecuteNonQuery();
        }

        public List<IssueRecord> GetAllIssues()
        {
            var issues = new List<IssueRecord>();

            using var conn = GetConnection();
            conn.Open();

            string query = "SELECT * FROM Issues";

            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                issues.Add(new IssueRecord
                {
                    Id = (int)reader["Id"],
                    BookId = (int)reader["BookId"],
                    MemberId = (int)reader["MemberId"],
                    IssueDate = (DateTime)reader["IssueDate"],
                    ReturnDate = reader["ReturnDate"] == DBNull.Value
                        ? null
                        : (DateTime)reader["ReturnDate"]
                });
            }

            return issues;
        }
    }
}
