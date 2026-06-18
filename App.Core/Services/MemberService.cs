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
        private readonly string _connectionString;

        public MemberService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
        }

        public void AddMember(Member member)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Members(Id, Name, Email, Phone, Address) VALUES (@Id, @Name, @Email, @Phone, @Address)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", member.Id);
                cmd.Parameters.AddWithValue("@Name", member.Name);
                cmd.Parameters.AddWithValue("@Email", member.Email);
                cmd.Parameters.AddWithValue("@Phone", member.Phone);
                cmd.Parameters.AddWithValue("@Address", member.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateMember(Member member)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Members SET Name=@Name, Email=@Email, Phone=@Phone, Address=@Address WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", member.Id);
                cmd.Parameters.AddWithValue("@Name", member.Name);
                cmd.Parameters.AddWithValue("@Email", member.Email);
                cmd.Parameters.AddWithValue("@Phone", member.Phone);
                cmd.Parameters.AddWithValue("@Address", member.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMember(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Members WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Member> GetAllMembers()
        {
            List<Member> members = new List<Member>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Members", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) members.Add(ReadMember(reader));
                }
            }
            return members;
        }

        public Member? GetMemberById(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Members WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return ReadMember(reader);
                }
            }
            return null;
        }

        public List<Member> SearchMembers(string keyword)
        {
            List<Member> members = new List<Member>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Members WHERE Name LIKE @Keyword OR Email LIKE @Keyword OR Phone LIKE @Keyword OR Address LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) members.Add(ReadMember(reader));
                }
            }
            return members;
        }

        private Member ReadMember(SqlDataReader reader)
        {
            Member m = new Member();
            m.Id = reader["Id"].ToString() ?? string.Empty;
            m.Name = reader["Name"].ToString() ?? string.Empty;
            m.Email = reader["Email"].ToString() ?? string.Empty;
            m.Phone = reader["Phone"].ToString() ?? string.Empty;
            m.Address = reader["Address"].ToString() ?? string.Empty;
            return m;
        }
    }
}