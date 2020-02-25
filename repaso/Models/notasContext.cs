using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace repaso.Models
{
    public partial class notasContext : DbContext
    {
        public notasContext()
        {
        }

        public notasContext(DbContextOptions<notasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=USER\\MSSQLSERVER01; Initial Catalog=notas; User Id=xavier; Password=inmejia1998");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materia>(entity =>
            {
                entity.ToTable("materia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("note");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alumno).HasColumnName("alumno");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.AlumnoNavigation)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.Alumno)
                    .HasConstraintName("FK__note__alumno__5165187F");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Materia).HasColumnName("materia");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.MateriaNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.Materia)
                    .HasConstraintName("FK__student__materia__4E88ABD4");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Materia).HasColumnName("materia");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.MateriaNavigation)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.Materia)
                    .HasConstraintName("FK__teacher__materia__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
