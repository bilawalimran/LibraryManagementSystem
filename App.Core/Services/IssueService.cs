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

            string query = @"INSERT INTO Issues(Id, BookId, MemberId, IssueDate, ReturnDate)
                             VALUES(@Id, @BookId, @MemberId, @IssueDate, @ReturnDate)";

            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", issue.Id);
            cmd.Parameters.AddWithValue("@BookId", issue.BookId);
            cmd.Parameters.AddWithValue("@MemberId", issue.MemberId);
            cmd.Parameters.AddWithValue("@IssueDate", issue.IssueDate == default ? DateTime.Now : issue.IssueDate);
            cmd.Parameters.AddWithValue("@ReturnDate", issue.ReturnDate.HasValue
                ? issue.ReturnDate.Value
                : DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        public void ReturnBook(string issueId)
        {
            ReturnBook(issueId, DateTime.Now);
        }

        public void ReturnBook(string issueId, DateTime returnDate)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = "UPDATE Issues SET ReturnDate=@ReturnDate WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", issueId);
            cmd.Parameters.AddWithValue("@ReturnDate", returnDate);

            cmd.ExecuteNonQuery();
        }

        public void DeleteIssue(string issueId)
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

            string query = @"SELECT i.*,
                                    b.Title AS BookName,
                                    m.Name AS MemberName
                             FROM Issues i
                             LEFT JOIN Books b ON i.BookId = b.Id
                             LEFT JOIN Members m ON i.MemberId = m.Id";

            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                issues.Add(new IssueRecord
                {
                    Id = reader["Id"].ToString() ?? string.Empty,
                    BookId = reader["BookId"].ToString() ?? string.Empty,
                    MemberId = reader["MemberId"].ToString() ?? string.Empty,
                    BookName = reader["BookName"].ToString() ?? string.Empty,
                    MemberName = reader["MemberName"].ToString() ?? string.Empty,
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
