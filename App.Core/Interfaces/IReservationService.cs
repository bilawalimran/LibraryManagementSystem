using App.Core.Models;
using System.Collections.Generic;

namespace App.Core.Interfaces
{
    public interface IReservationService
    {
        void AddReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(string id);
        List<Reservation> GetAllReservations();
        Reservation? GetReservationById(string id);
    }
}
