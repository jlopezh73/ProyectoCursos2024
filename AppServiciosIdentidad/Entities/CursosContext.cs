using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppServiciosIdentidad.Entities;

public partial class CursosContext : DbContext
{
    public CursosContext()
    {
    }

    public CursosContext(DbContextOptions<CursosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    public virtual DbSet<ParticipantePago> ParticipantePagos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=cursos;user=cursos;password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Curso");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Clave).HasMaxLength(10);
            entity.Property(e => e.Costo).HasPrecision(6);
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.FechaTermino).HasColumnType("datetime");
            entity.Property(e => e.Instructor).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(200);
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Participante");

            entity.HasIndex(e => e.Idcurso, "IDCurso");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idcurso).HasColumnName("IDCurso");
            entity.Property(e => e.Materno).HasMaxLength(30);
            entity.Property(e => e.Matricula).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(30);
            entity.Property(e => e.Pagado).HasPrecision(12);
            entity.Property(e => e.Paterno).HasMaxLength(30);
            entity.Property(e => e.Precio).HasPrecision(12);

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Participantes)
                .HasForeignKey(d => d.Idcurso)
                .HasConstraintName("participante_ibfk_1");
        });

        modelBuilder.Entity<ParticipantePago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Participante_Pago");

            entity.HasIndex(e => e.Idcurso, "IDCurso");

            entity.HasIndex(e => e.Idparticipante, "IDParticipante");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Idcurso).HasColumnName("IDCurso");
            entity.Property(e => e.Idparticipante).HasColumnName("IDParticipante");
            entity.Property(e => e.Monto).HasPrecision(12);

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.ParticipantePagos)
                .HasForeignKey(d => d.Idcurso)
                .HasConstraintName("participante_pago_ibfk_2");

            entity.HasOne(d => d.IdparticipanteNavigation).WithMany(p => p.ParticipantePagos)
                .HasForeignKey(d => d.Idparticipante)
                .HasConstraintName("participante_pago_ibfk_1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Materno).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Paterno).HasMaxLength(50);
            entity.Property(e => e.Puesto).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
