using MRBS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CompanyRepository Companies { get; }
        ReservationRepository Reservations { get; }
        RoomRepository Rooms { get; }
        UserRepository Users { get; }
        Task<int> CommitAsync();
    }
}
