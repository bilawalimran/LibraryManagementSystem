using App.Core.Interfaces;
using App.Core.Models;
using App.Core.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace App.Core.Services
{
    public class IssueService : IIssueService
    {
        private readonly string _connectionString;

        public IssueService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
        }

        public void IssueBook(IssueRecord issue)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Issues(Id, BookId, MemberId, IssueDate, ReturnDate, Status) VALUES (@Id, @BookId, @MemberId, @IssueDate, @ReturnDate, @Status)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", issue.Id);
                cmd.Parameters.AddWithValue("@BookId", issue.BookId);
                cmd.Parameters.AddWithValue("@MemberId", issue.MemberId);
                cmd.Parameters.AddWithValue("@IssueDate", issue.IssueDate == default ? DateTime.Now : issue.IssueDate);
                cmd.Parameters.AddWithValue("@ReturnDate", (object)issue.ReturnDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", issue.Status.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        public void ReturnBook(string issueId, DateTime? returnDate = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Issues SET ReturnDate=@ReturnDate WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", issueId);
                cmd.Parameters.AddWithValue("@ReturnDate", returnDate ?? DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStatus(string issueId, IssueStatus status)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Issues SET Status=@Status WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", issueId);
                cmd.Parameters.AddWithValue("@Status", status.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteIssue(string issueId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Issues WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", issueId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<IssueRecord> GetAllIssues()
        {
            List<IssueRecord> issues = new List<IssueRecord>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"SELECT i.*, b.Title AS BookName, m.Name AS MemberName
                               FROM Issues i
                               LEFT JOIN Books b ON i.BookId = b.Id
                               LEFT JOIN Members m ON i.MemberId = m.Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) issues.Add(ReadIssue(reader));
                }
            }
            return issues;
        }

        public List<IssueRecord> SearchIssues(string keyword)
        {
            List<IssueRecord> issues = new List<IssueRecord>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"SELECT i.*, b.Title AS BookName, m.Name AS MemberName
                               FROM Issues i
                               LEFT JOIN Books b ON i.BookId = b.Id
                               LEFT JOIN Members m ON i.MemberId = m.Id
                               WHERE b.Title LIKE @Keyword OR m.Name LIKE @Keyword OR i.Status LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) issues.Add(ReadIssue(reader));
                }
            }
            return issues;
        }

        private IssueRecord ReadIssue(SqlDataReader reader)
        {
            IssueRecord i = new IssueRecord();
            i.Id = reader["Id"].ToString() ?? string.Empty;
            i.BookId = reader["BookId"].ToString() ?? string.Empty;
            i.MemberId = reader["MemberId"].ToString() ?? string.Empty;
            i.BookName = reader["BookName"].ToString() ?? string.Empty;
            i.MemberName = reader["MemberName"].ToString() ?? string.Empty;
            i.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
            i.ReturnDate = reader["ReturnDate"] == DBNull.Value ? null : Convert.ToDateTime(reader["ReturnDate"]);
            i.Status = Enum.TryParse(reader["Status"]?.ToString(), out IssueStatus parsedStatus)
                ? parsedStatus
                : IssueStatus.Issued;
            return i;
        }
    }
}