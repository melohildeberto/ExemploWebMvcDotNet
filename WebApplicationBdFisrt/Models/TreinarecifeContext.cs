using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationBdFisrt.Models;

public partial class TreinarecifeContext : DbContext
{
    public TreinarecifeContext()
    {
    }

    public TreinarecifeContext(DbContextOptions<TreinarecifeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-ANVV0SF\\SQLEXPRESS;Initial Catalog=treinarecife;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Aluno__3214EC076FD3D7BB");

            entity.ToTable("Aluno");

            entity.HasIndex(e => e.Cpf, "UQ__Aluno__C1FF9309DF9AB866").IsUnique();

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curso__3214EC077B5C04E2");

            entity.ToTable("Curso");

            entity.Property(e => e.Ementa)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.IdProfessor).HasColumnName("Id_Professor");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.IdProfessorNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdProfessor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Curso__Id_Profes__3A81B327");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professo__3214EC0772328C11");

            entity.ToTable("Professor");

            entity.HasIndex(e => e.Cpf, "UQ__Professo__C1FF93093CEEAEE3").IsUnique();

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
