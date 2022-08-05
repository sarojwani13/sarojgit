using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NotesService.Models;

#nullable disable

namespace NotesService.Data
{
    public partial class CTAuthenticationServerDbContext : DbContext
    {
        public CTAuthenticationServerDbContext()
        {
        }

        public CTAuthenticationServerDbContext(DbContextOptions<CTAuthenticationServerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ethinicity> Ethinicities { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("data source=(LocalDB)\\MSSQLLocalDB;initial catalog=CTAuthenticationServerDb;integrated security=true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ethinicity>(entity =>
            {
                entity.HasKey(e => e.EthnicityId);

                entity.ToTable("Ethinicity");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.NotesId)
                    .HasName("PK__Notes__35AB5BAA829D4675");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.NotesClosedByNavigation)
                    .WithMany(p => p.NoteNotesClosedByNavigations)
                    .HasForeignKey(d => d.NotesClosedBy)
                    .HasConstraintName("FK__Notes__NotesClos__5165187F");

                entity.HasOne(d => d.NotesRepliedByNavigation)
                    .WithMany(p => p.NoteNotesRepliedByNavigations)
                    .HasForeignKey(d => d.NotesRepliedBy)
                    .HasConstraintName("FK__Notes__NotesRepl__534D60F1");

                entity.HasOne(d => d.NotesReplyNavigation)
                    .WithMany(p => p.InverseNotesReplyNavigation)
                    .HasForeignKey(d => d.NotesReplyId)
                    .HasConstraintName("FK_ReplyId_to_UserId");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.NoteReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notes__ReceiverI__52593CB8");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.NoteSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notes__SenderId__5070F446");
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.ToTable("Race");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EthnicityId, "IX_Users_EthnicityId");

                entity.HasIndex(e => e.RaceId, "IX_Users_RaceId");

                entity.HasIndex(e => e.RoleId, "IX_Users_RoleId");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddress)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageKnown)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ethnicity)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.EthnicityId);

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RaceId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
