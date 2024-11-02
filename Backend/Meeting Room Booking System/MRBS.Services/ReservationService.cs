using MRBS.Core.Interfaces;
using MRBS.Core.Models;
using MRBS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Reservation> CreateReservation(Reservation newReservation)
        {
            await _unitOfWork.Reservations.AddAsync(newReservation);
            await _unitOfWork.CommitAsync();
            return newReservation;
        }

        public async Task DeleteReservation(Reservation reservation)
        {
            _unitOfWork.Reservations.Remove(reservation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _unitOfWork.Reservations
                .GetAllReservationsAsync();
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _unitOfWork.Reservations
                .GetWithReservationByIdAsync(id);
        }
    }
}
