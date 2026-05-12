using App.Core.Data;
using App.Core.Interfaces;
using App.Core.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace LibraryManagementSystem.Infrastructure.Services
{
    public class MemberService : IMemberService
    {
        public void AddMember(Member member)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            string query = "INSERT INTO Members (Name, Email, Phone) VALUES (@Name, @Email, @Phone)";
            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Name", member.Name);
            cmd.Parameters.AddWithValue("@Email", member.Email);
            cmd.Parameters.AddWithValue("@Phone", member.Phone);
            cmd.ExecuteNonQuery();
        }

        public void UpdateMember(Member member)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            string query = "UPDATE Members SET Name=@Name, Email=@Email WHERE Id=@Id";
            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", member.Id);
            cmd.Parameters.AddWithValue("@Name", member.Name);
            cmd.Parameters.AddWithValue("@Email", member.Email);
            cmd.Parameters.AddWithValue("@Phone", member.Phone);

            cmd.ExecuteNonQuery();
        }

        public void DeleteMember(int id)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            string query = "DELETE FROM Members WHERE Id=@Id";
            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        public List<Member> GetAllMembers()
        {
            var members = new List<Member>();

            using var conn = DbHelper.GetConnection();
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
                    Phone = reader["Phone"].ToString()
                });
            }

            return members;
        }
    }
}