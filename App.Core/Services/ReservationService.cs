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
        private static SqlConnection GetConnection()
        {
            string? connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string 'LibraryDB' was not found in App.config.");
            }

            return new SqlConnection(connectionString);
        }

        public void AddReservation(Reservation reservation)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = @"INSERT INTO Reservations
                            (Id, BookId, MemberId, ReservationDate, ExpiryDate, Status)
                            VALUES
                            (@Id, @BookId, @MemberId, @ReservationDate, @ExpiryDate, @Status)";

            using var cmd = new SqlCommand(query, conn);

            AddReservationParameters(cmd, reservation);
            cmd.ExecuteNonQuery();
        }

        public void UpdateReservation(Reservation reservation)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = @"UPDATE Reservations
                             SET BookId=@BookId,
                                 MemberId=@MemberId,
                                 ReservationDate=@ReservationDate,
                                 ExpiryDate=@ExpiryDate,
                                 Status=@Status
                             WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);

            AddReservationParameters(cmd, reservation);
            cmd.ExecuteNonQuery();
        }

        public void DeleteReservation(string id)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = "DELETE FROM Reservations WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }

        public List<Reservation> GetAllReservations()
        {
            var reservations = new List<Reservation>();

            using var conn = GetConnection();
            conn.Open();

            string query = "SELECT * FROM Reservations";

            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                reservations.Add(ReadReservation(reader));
            }

            return reservations;
        }

        public Reservation? GetReservationById(string id)
        {
            using var conn = GetConnection();
            conn.Open();

            string query = "SELECT * FROM Reservations WHERE Id=@Id";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return ReadReservation(reader);
            }

            return null;
        }

        private static void AddReservationParameters(SqlCommand cmd, Reservation reservation)
        {
            cmd.Parameters.AddWithValue("@Id", reservation.Id);
            cmd.Parameters.AddWithValue("@BookId", reservation.BookId);
            cmd.Parameters.AddWithValue("@MemberId", reservation.MemberId);
            cmd.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
            cmd.Parameters.AddWithValue("@ExpiryDate", reservation.ExpiryDate.HasValue
                ? reservation.ExpiryDate.Value
                : DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", reservation.Status.ToString());
        }

        private static Reservation ReadReservation(SqlDataReader reader)
        {
            return new Reservation
            {
                Id = reader["Id"].ToString() ?? string.Empty,
                BookId = reader["BookId"].ToString() ?? string.Empty,
                MemberId = reader["MemberId"].ToString() ?? string.Empty,
                ReservationDate = (DateTime)reader["ReservationDate"],
                ExpiryDate = reader["ExpiryDate"] == DBNull.Value
                    ? null
                    : (DateTime)reader["ExpiryDate"],
                Status = Enum.Parse<ReservationStatus>(
                    reader["Status"].ToString() ?? nameof(ReservationStatus.Pending))
            };
        }
    }
}
