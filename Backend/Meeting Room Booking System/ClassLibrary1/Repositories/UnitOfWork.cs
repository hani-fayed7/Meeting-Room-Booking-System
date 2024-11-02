using MRBS.Core.Interfaces;
using MRBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly meetingRoomBookingSystemContext _context;
        private CompanyRepository _companyRepository;
        private ReservationRepository _reservationRepository;
        private RoomRepository _roomRepository;
        private UserRepository _userRepository;

        public UnitOfWork(meetingRoomBookingSystemContext context)
        {
            this._context = context;
        }

        public CompanyRepository Companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);

        public ReservationRepository Reservations => _reservationRepository = _reservationRepository ?? new ReservationRepository(_context);
        public RoomRepository Rooms => _roomRepository = _roomRepository ?? new RoomRepository(_context);
        public UserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
