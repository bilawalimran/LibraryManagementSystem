using App.Core.Interfaces;
using App.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace App.Core.Services
{
    public class MemberService : IMemberService
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

        public void AddMember(Member member)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = @"INSERT INTO Members
                            (Id, Name, Email, Phone, Address)
                            VALUES
                            (@Id, @Name, @Email, @Phone, @Address)";

            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", member.Id);
            cmd.Parameters.AddWithValue("@Name", member.Name);
            cmd.Parameters.AddWithValue("@Email", member.Email);
            cmd.Parameters.AddWithValue("@Phone", member.Phone);
            cmd.Parameters.AddWithValue("@Address", member.Address);

            cmd.ExecuteNonQuery();
        }

        public void UpdateMember(Member member)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = @"UPDATE Members
                             SET Name=@Name,
                                 Email=@Email,
                                 Phone=@Phone,
                                 Address=@Address
                             WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", member.Id);
            cmd.Parameters.AddWithValue("@Name", member.Name);
            cmd.Parameters.AddWithValue("@Email", member.Email);
            cmd.Parameters.AddWithValue("@Phone", member.Phone);
            cmd.Parameters.AddWithValue("@Address", member.Address);

            cmd.ExecuteNonQuery();
        }

        public void DeleteMember(string id)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = "DELETE FROM Members WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }

        public List<Member> GetAllMembers()
        {
            var members = new List<Member>();

            using var conn = GetConnection();
            conn.Open();

            string query = "SELECT * FROM Members";

            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                members.Add(ReadMember(reader));
            }

            return members;
        }

        public Member? GetMemberById(string id)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = "SELECT * FROM Members WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return ReadMember(reader);
            }

            return null;
        }

        private static Member ReadMember(SqlDataReader reader)
        {
            return new Member
            {
                Id = reader["Id"].ToString() ?? string.Empty,
                Name = reader["Name"].ToString() ?? string.Empty,
                Email = reader["Email"].ToString() ?? string.Empty,
                Phone = reader["Phone"].ToString() ?? string.Empty,
                Address = reader["Address"].ToString() ?? string.Empty
            };
        }
    }
}
