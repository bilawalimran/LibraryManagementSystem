using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace App.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly string _connectionString;

        public ReservationService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
        }

        public void AddReservation(Reservation reservation)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Reservations(Id, BookId, MemberId, ReservationDate, ExpiryDate, Status) VALUES (@Id, @BookId, @MemberId, @ReservationDate, @ExpiryDate, @Status)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", reservation.Id);
                cmd.Parameters.AddWithValue("@BookId", reservation.BookId);
                cmd.Parameters.AddWithValue("@MemberId", reservation.MemberId);
                cmd.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
                cmd.Parameters.AddWithValue("@ExpiryDate", (object)reservation.ExpiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", reservation.Status.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateReservation(Reservation reservation)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Reservations SET BookId=@BookId, MemberId=@MemberId, ReservationDate=@ReservationDate, ExpiryDate=@ExpiryDate, Status=@Status WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", reservation.Id);
                cmd.Parameters.AddWithValue("@BookId", reservation.BookId);
                cmd.Parameters.AddWithValue("@MemberId", reservation.MemberId);
                cmd.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
                cmd.Parameters.AddWithValue("@ExpiryDate", (object)reservation.ExpiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", reservation.Status.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteReservation(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Reservations WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = new List<Reservation>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"SELECT r.*, b.Title AS BookName, m.Name AS MemberName
                               FROM Reservations r
                               LEFT JOIN Books b ON r.BookId = b.Id
                               LEFT JOIN Members m ON r.MemberId = m.Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) reservations.Add(ReadReservation(reader));
                }
            }
            return reservations;
        }

        public Reservation? GetReservationById(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"SELECT r.*, b.Title AS BookName, m.Name AS MemberName
                               FROM Reservations r
                               LEFT JOIN Books b ON r.BookId = b.Id
                               LEFT JOIN Members m ON r.MemberId = m.Id
                               WHERE r.Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return ReadReservation(reader);
                }
            }
            return null;
        }

        private Reservation ReadReservation(SqlDataReader reader)
        {
            Reservation r = new Reservation();
            r.Id = reader["Id"].ToString() ?? string.Empty;
            r.BookId = reader["BookId"].ToString() ?? string.Empty;
            r.MemberId = reader["MemberId"].ToString() ?? string.Empty;
            r.BookName = reader["BookName"].ToString() ?? string.Empty;
            r.MemberName = reader["MemberName"].ToString() ?? string.Empty;
            r.ReservationDate = Convert.ToDateTime(reader["ReservationDate"]);
            r.ExpiryDate = reader["ExpiryDate"] == DBNull.Value ? null : Convert.ToDateTime(reader["ExpiryDate"]);
            r.Status = Enum.TryParse<ReservationStatus>(reader["Status"].ToString(), true, out var status) ? status : ReservationStatus.Pending;
            return r;
        }
    }
}