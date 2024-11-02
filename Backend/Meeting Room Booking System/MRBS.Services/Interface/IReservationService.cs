using MRBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Services.Interface
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<Reservation> CreateReservation(Reservation newReservation);
        Task DeleteReservation(Reservation reservation);
        Task<Reservation> GetReservationById(int id);
    }
}
