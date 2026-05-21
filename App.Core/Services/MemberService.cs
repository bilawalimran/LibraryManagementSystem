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
                            (Name, Email, Phone, Address)
                            VALUES
                            (@Name, @Email, @Phone, @Address)";

            using var cmd = new SqlCommand(query, conn);

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

        public void DeleteMember(int id)
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
                members.Add(new Member
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Address = reader["Address"].ToString()
                });
            }

            return members;
        }

        public Member GetMemberById(int id)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = "SELECT * FROM Members WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Member
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Address = reader["Address"].ToString()
                };
            }

            return null;
        }
    }
}
