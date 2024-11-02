using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MRBS.Core.Models
{
    public partial class meetingRoomBookingSystemContext : DbContext
    {
        public meetingRoomBookingSystemContext()
        {
        }

        public meetingRoomBookingSystemContext(DbContextOptions<meetingRoomBookingSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=HANI-LENOVO;Initial Catalog=meetingRoomBookingSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.PkCompanyId)
                    .HasName("PK__Companie__67653B79BBB32DC3");

                entity.Property(e => e.PkCompanyId).HasColumnName("pk_CompanyID");

                entity.Property(e => e.CompanyEmail)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.PkReservationId)
                    .HasName("PK__Reservat__BE267D4F0880BAB0");

                entity.Property(e => e.PkReservationId).HasColumnName("pk_ReservationID");

                entity.Property(e => e.DateOfMeeting).HasColumnType("date");

                entity.Property(e => e.FkReservationRelatedRoom).HasColumnName("fk_ReservationRelatedRoom");

                entity.Property(e => e.FkRoomUserId).HasColumnName("fk_RoomUserID");

                entity.HasOne(d => d.FkReservationRelatedRoomNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.FkReservationRelatedRoom)
                    .HasConstraintName("FK__Reservati__fk_Re__3F466844");

                entity.HasOne(d => d.FkRoomUser)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.FkRoomUserId)
                    .HasConstraintName("FK__Reservati__fk_Ro__403A8C7D");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.PkRoomId)
                    .HasName("PK__Rooms__459410CEAD6FD9F6");

                entity.Property(e => e.PkRoomId).HasColumnName("pk_RoomID");

                entity.Property(e => e.FkRoomRelatedCompany).HasColumnName("fk_RoomRelatedCompany");

                entity.Property(e => e.RoomLocation).IsRequired();

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasMaxLength(18);

                entity.HasOne(d => d.FkRoomRelatedCompanyNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.FkRoomRelatedCompany)
                    .HasConstraintName("FK__Rooms__fk_RoomRe__3C69FB99");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.PkUserId)
                    .HasName("PK__Users__9B84DDE93A20B9B6");

                entity.Property(e => e.PkUserId).HasColumnName("pk_UserID");

                entity.Property(e => e.FkUserRelatedCompany).HasColumnName("fk_UserRelatedCompany");

                entity.Property(e => e.UserDoB).HasColumnType("date");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.UserGender)
                    .IsRequired()
                    .HasMaxLength(18);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(18);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.UserRole)
                    .IsRequired()
                    .HasMaxLength(18);

                entity.HasOne(d => d.FkUserRelatedCompanyNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FkUserRelatedCompany)
                    .HasConstraintName("FK__Users__fk_UserRe__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
