using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SchülerHelfenSchüler.Models
{
    public partial class SchülerHelfenSchülerContext : DbContext
    {
        public SchülerHelfenSchülerContext()
        {
        }

        public SchülerHelfenSchülerContext(DbContextOptions<SchülerHelfenSchülerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectTeacher> SubjectTeachers { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserOffer> UserOffers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:schuelerhelfenschueler.database.windows.net,1433;Initial Catalog=SchülerHelfenSchüler;Persist Security Info=False;User ID=dhofma;Password=salzweg44?;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Class1);

                entity.ToTable("Class");

                entity.Property(e => e.Class1)
                    .HasMaxLength(2)
                    .HasColumnName("class");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("subject");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("user_id");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.Subject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offer_Subject");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offer_Teacher");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offer_User");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Subject1);

                entity.ToTable("Subject");

                entity.Property(e => e.Subject1)
                    .HasMaxLength(20)
                    .HasColumnName("subject");
            });

            modelBuilder.Entity<SubjectTeacher>(entity =>
            {
                entity.HasKey(e => new { e.TeacherId, e.Subject });

                entity.ToTable("SubjectTeacher");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.Subject)
                    .HasMaxLength(20)
                    .HasColumnName("subject");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.SubjectTeachers)
                    .HasForeignKey(d => d.Subject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectTeacher_Subject");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.SubjectTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectTeacher_Teacher");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastname");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("class");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Class)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Class");
            });

            modelBuilder.Entity<UserOffer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UserOffer");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("class");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("subject");

                entity.Property(e => e.TeacherFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("teacherFirstName");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.TeacherLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("teacherLastName");

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("userFirstName");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("user_id");

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("userLastName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
