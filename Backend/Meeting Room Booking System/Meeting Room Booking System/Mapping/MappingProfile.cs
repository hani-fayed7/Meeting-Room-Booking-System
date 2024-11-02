using Meeting_Room_Booking_System.Resources;
using MRBS.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeting_Room_Booking_System.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Company, CompanyResource>();
            CreateMap<Reservation, ReservationResource>();
            CreateMap<Room, RoomResource>();
            CreateMap<User, UserResource>();

            // Resource to Domain
            CreateMap<CompanyResource, Company>();
            CreateMap<SaveCompanyResource, Company>();

            CreateMap<ReservationResource, Reservation>();
            CreateMap<SaveReservationResource, Reservation>();

            CreateMap<RoomResource, Room>();
            CreateMap<SaveRoomResource, Room>();

            CreateMap<UserResource, User>();
            CreateMap<SaveUserResource, User>();
        }
    }
}