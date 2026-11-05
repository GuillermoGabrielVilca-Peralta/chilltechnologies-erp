using System;
using System.Collections.Generic;
using ChillTechnologies.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChillTechnologies.Infrastructure.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aliado> Aliados { get; set; }

    public virtual DbSet<Camara> Camaras { get; set; }

    public virtual DbSet<Canje> Canjes { get; set; }

    public virtual DbSet<CategoriasAliado> CategoriasAliados { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<MetodosPago> MetodosPagos { get; set; }

    public virtual DbSet<MovimientosPunto> MovimientosPuntos { get; set; }

    public virtual DbSet<Nivele> Niveles { get; set; }

    public virtual DbSet<Plane> Planes { get; set; }

    public virtual DbSet<PosicionesCamara> PosicionesCamaras { get; set; }

    public virtual DbSet<Premio> Premios { get; set; }

    public virtual DbSet<PuntosUsuario> PuntosUsuarios { get; set; }

    public virtual DbSet<Suscripcione> Suscripciones { get; set; }

    public virtual DbSet<TiposConductor> TiposConductors { get; set; }

    public virtual DbSet<TiposEvento> TiposEventos { get; set; }

    public virtual DbSet<TiposVehiculo> TiposVehiculos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VRankingConductore> VRankingConductores { get; set; }

    public virtual DbSet<VSuscripcionesActiva> VSuscripcionesActivas { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Aliado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("aliados_pkey");

            entity.ToTable("aliados");

            entity.HasIndex(e => e.Ruc, "aliados_ruc_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.ComisionPorcentaje)
                .HasPrecision(5, 2)
                .HasDefaultValue(10.00m)
                .HasColumnName("comision_porcentaje");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.Distrito)
                .HasMaxLength(60)
                .HasColumnName("distrito");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Logo)
                .HasMaxLength(255)
                .HasColumnName("logo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Aliados)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aliados_categoria_id_fkey");
        });

        modelBuilder.Entity<Camara>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("camaras_pkey");

            entity.ToTable("camaras", tb => tb.HasComment("Dispositivos de captura de video por vehiculo"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DireccionIp)
                .HasMaxLength(50)
                .HasColumnName("direccion_ip");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Desconectada'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.PosicionId).HasColumnName("posicion_id");
            entity.Property(e => e.VehiculoId).HasColumnName("vehiculo_id");

            entity.HasOne(d => d.Posicion).WithMany(p => p.Camaras)
                .HasForeignKey(d => d.PosicionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("camaras_posicion_id_fkey");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Camaras)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("camaras_vehiculo_id_fkey");
        });

        modelBuilder.Entity<Canje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("canjes_pkey");

            entity.ToTable("canjes");

            entity.HasIndex(e => e.CodigoQr, "canjes_codigo_qr_key").IsUnique();

            entity.HasIndex(e => e.Estado, "idx_canjes_estado");

            entity.HasIndex(e => e.PremioId, "idx_canjes_premio");

            entity.HasIndex(e => e.UsuarioId, "idx_canjes_usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoQr)
                .HasMaxLength(64)
                .HasDefaultValueSql("encode(gen_random_bytes(16), 'hex'::text)")
                .HasColumnName("codigo_qr");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCanje)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_canje");
            entity.Property(e => e.FechaUso)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_uso");
            entity.Property(e => e.PremioId).HasColumnName("premio_id");
            entity.Property(e => e.PuntosUtilizados).HasColumnName("puntos_utilizados");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Premio).WithMany(p => p.Canjes)
                .HasForeignKey(d => d.PremioId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("canjes_premio_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Canjes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("canjes_usuario_id_fkey");
        });

        modelBuilder.Entity<CategoriasAliado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorias_aliado_pkey");

            entity.ToTable("categorias_aliado");

            entity.HasIndex(e => e.Nombre, "categorias_aliado_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("eventos_pkey");

            entity.ToTable("eventos");

            entity.HasIndex(e => e.CamaraId, "idx_eventos_camara");

            entity.HasIndex(e => e.FechaEvento, "idx_eventos_fecha").IsDescending();

            entity.HasIndex(e => e.ViajeId, "idx_eventos_viaje");

            entity.HasIndex(e => e.ClienteEventoId, "uq_eventos_cliente_evento_id")
                .IsUnique()
                .HasFilter("(cliente_evento_id IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CamaraId).HasColumnName("camara_id");
            entity.Property(e => e.ClienteEventoId)
                .HasMaxLength(64)
                .HasColumnName("cliente_evento_id");
            entity.Property(e => e.FechaEvento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_evento");
            entity.Property(e => e.FotoEvidencia)
                .HasMaxLength(255)
                .HasColumnName("foto_evidencia");
            entity.Property(e => e.ImpactoPuntaje).HasColumnName("impacto_puntaje");
            entity.Property(e => e.Latitud)
                .HasPrecision(10, 7)
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasPrecision(10, 7)
                .HasColumnName("longitud");
            entity.Property(e => e.TipoEventoId).HasColumnName("tipo_evento_id");
            entity.Property(e => e.ViajeId)
                .HasComment("NULL si la deteccion ocurre fuera de un viaje activo")
                .HasColumnName("viaje_id");

            entity.HasOne(d => d.Camara).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.CamaraId)
                .HasConstraintName("eventos_camara_id_fkey");

            entity.HasOne(d => d.TipoEvento).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.TipoEventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("eventos_tipo_evento_id_fkey");

            entity.HasOne(d => d.Viaje).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.ViajeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("eventos_viaje_id_fkey");
        });

        modelBuilder.Entity<MetodosPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("metodos_pago_pkey");

            entity.ToTable("metodos_pago");

            entity.HasIndex(e => e.Nombre, "metodos_pago_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<MovimientosPunto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movimientos_puntos_pkey");

            entity.ToTable("movimientos_puntos", tb => tb.HasComment("Libro mayor inmutable: cada fila es una transaccion de puntos"));

            entity.HasIndex(e => e.CanjeId, "idx_movpuntos_canje");

            entity.HasIndex(e => e.FechaMovimiento, "idx_movpuntos_fecha").IsDescending();

            entity.HasIndex(e => e.UsuarioId, "idx_movpuntos_usuario");

            entity.HasIndex(e => e.ViajeId, "idx_movpuntos_viaje");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CanjeId).HasColumnName("canje_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_movimiento");
            entity.Property(e => e.Puntos).HasColumnName("puntos");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.ViajeId).HasColumnName("viaje_id");

            entity.HasOne(d => d.Canje).WithMany(p => p.MovimientosPuntos)
                .HasForeignKey(d => d.CanjeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("movimientos_puntos_canje_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.MovimientosPuntos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("movimientos_puntos_usuario_id_fkey");

            entity.HasOne(d => d.Viaje).WithMany(p => p.MovimientosPuntos)
                .HasForeignKey(d => d.ViajeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("movimientos_puntos_viaje_id_fkey");
        });

        modelBuilder.Entity<Nivele>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("niveles_pkey");

            entity.ToTable("niveles");

            entity.HasIndex(e => e.Nombre, "niveles_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .HasColumnName("nombre");
            entity.Property(e => e.PuntosMinimos).HasColumnName("puntos_minimos");
        });

        modelBuilder.Entity<Plane>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("planes_pkey");

            entity.ToTable("planes");

            entity.HasIndex(e => e.Nombre, "planes_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioSoles)
                .HasPrecision(8, 2)
                .HasColumnName("precio_soles");
        });

        modelBuilder.Entity<PosicionesCamara>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("posiciones_camara_pkey");

            entity.ToTable("posiciones_camara");

            entity.HasIndex(e => e.Nombre, "posiciones_camara_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Premio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("premios_pkey");

            entity.ToTable("premios");

            entity.HasIndex(e => e.AliadoId, "idx_premios_aliado");

            entity.HasIndex(e => e.Estado, "idx_premios_estado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AliadoId).HasColumnName("aliado_id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Disponible'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.PuntosRequeridos).HasColumnName("puntos_requeridos");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Aliado).WithMany(p => p.Premios)
                .HasForeignKey(d => d.AliadoId)
                .HasConstraintName("premios_aliado_id_fkey");
        });

        modelBuilder.Entity<PuntosUsuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("puntos_usuario_pkey");

            entity.ToTable("puntos_usuario");

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("usuario_id");
            entity.Property(e => e.NivelId).HasColumnName("nivel_id");
            entity.Property(e => e.PuntosActuales).HasColumnName("puntos_actuales");
            entity.Property(e => e.PuntosHistoricos)
                .HasComment("Acumulado total; no baja con canjes. Determina nivel y ranking.")
                .HasColumnName("puntos_historicos");
            entity.Property(e => e.UltimaActualizacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ultima_actualizacion");

            entity.HasOne(d => d.Nivel).WithMany(p => p.PuntosUsuarios)
                .HasForeignKey(d => d.NivelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("puntos_usuario_nivel_id_fkey");

            entity.HasOne(d => d.Usuario).WithOne(p => p.PuntosUsuario)
                .HasForeignKey<PuntosUsuario>(d => d.UsuarioId)
                .HasConstraintName("puntos_usuario_usuario_id_fkey");
        });

        modelBuilder.Entity<Suscripcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("suscripciones_pkey");

            entity.ToTable("suscripciones", tb => tb.HasComment("Ciclos de pago del plan Profesional"));

            entity.HasIndex(e => e.Estado, "idx_suscripciones_estado");

            entity.HasIndex(e => e.FechaFin, "idx_suscripciones_fin");

            entity.HasIndex(e => e.UsuarioId, "idx_suscripciones_usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activa'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.MetodoPagoId).HasColumnName("metodo_pago_id");
            entity.Property(e => e.MontoSoles)
                .HasPrecision(8, 2)
                .HasDefaultValue(15.00m)
                .HasColumnName("monto_soles");
            entity.Property(e => e.ReferenciaPago)
                .HasMaxLength(100)
                .HasColumnName("referencia_pago");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Suscripciones)
                .HasForeignKey(d => d.MetodoPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("suscripciones_metodo_pago_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Suscripciones)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("suscripciones_usuario_id_fkey");
        });

        modelBuilder.Entity<TiposConductor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipos_conductor_pkey");

            entity.ToTable("tipos_conductor");

            entity.HasIndex(e => e.Nombre, "tipos_conductor_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TiposEvento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipos_evento_pkey");

            entity.ToTable("tipos_evento");

            entity.HasIndex(e => e.Nombre, "tipos_evento_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImpactoPuntajeDefault).HasColumnName("impacto_puntaje_default");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TiposVehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipos_vehiculo_pkey");

            entity.ToTable("tipos_vehiculo");

            entity.HasIndex(e => e.Nombre, "tipos_vehiculo_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios", tb => tb.HasComment("Conductores registrados en ChillDrive"));

            entity.HasIndex(e => e.Estado, "idx_usuarios_estado");

            entity.HasIndex(e => e.Correo, "usuarios_correo_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .HasColumnName("correo");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.FotoPerfil)
                .HasMaxLength(255)
                .HasColumnName("foto_perfil");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.PlanId).HasColumnName("plan_id");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoConductorId).HasColumnName("tipo_conductor_id");
            entity.Property(e => e.UltimoAcceso)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ultimo_acceso");

            entity.HasOne(d => d.Plan).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_plan_id_fkey");

            entity.HasOne(d => d.TipoConductor).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TipoConductorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_tipo_conductor_id_fkey");
        });

        modelBuilder.Entity<VRankingConductore>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_ranking_conductores");

            entity.Property(e => e.Conductor).HasColumnName("conductor");
            entity.Property(e => e.Nivel)
                .HasMaxLength(20)
                .HasColumnName("nivel");
            entity.Property(e => e.PuntajePromedio).HasColumnName("puntaje_promedio");
            entity.Property(e => e.PuntosActuales).HasColumnName("puntos_actuales");
            entity.Property(e => e.PuntosHistoricos).HasColumnName("puntos_historicos");
            entity.Property(e => e.TipoConductor)
                .HasMaxLength(30)
                .HasColumnName("tipo_conductor");
            entity.Property(e => e.TotalViajes).HasColumnName("total_viajes");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
        });

        modelBuilder.Entity<VSuscripcionesActiva>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_suscripciones_activas");

            entity.Property(e => e.Conductor).HasColumnName("conductor");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .HasColumnName("correo");
            entity.Property(e => e.DiasRestantes).HasColumnName("dias_restantes");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(30)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.MontoSoles)
                .HasPrecision(8, 2)
                .HasColumnName("monto_soles");
            entity.Property(e => e.SuscripcionId).HasColumnName("suscripcion_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("vehiculos_pkey");

            entity.ToTable("vehiculos", tb => tb.HasComment("Vehiculos registrados por cada conductor"));

            entity.HasIndex(e => e.UsuarioId, "idx_vehiculos_usuario");

            entity.HasIndex(e => e.Placa, "vehiculos_placa_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .HasColumnName("color");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .HasColumnName("modelo");
            entity.Property(e => e.Placa)
                .HasMaxLength(15)
                .HasColumnName("placa");
            entity.Property(e => e.TipoVehiculoId).HasColumnName("tipo_vehiculo_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.TipoVehiculo).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.TipoVehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vehiculos_tipo_vehiculo_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("vehiculos_usuario_id_fkey");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("viajes_pkey");

            entity.ToTable("viajes");

            entity.HasIndex(e => e.Estado, "idx_viajes_estado");

            entity.HasIndex(e => e.FechaInicio, "idx_viajes_fecha_inicio").IsDescending();

            entity.HasIndex(e => e.UsuarioId, "idx_viajes_usuario");

            entity.HasIndex(e => e.VehiculoId, "idx_viajes_vehiculo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DistanciaKm)
                .HasPrecision(10, 2)
                .HasColumnName("distancia_km");
            entity.Property(e => e.DuracionMinutos).HasColumnName("duracion_minutos");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'En Curso'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaFin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.PuntajeConduccion)
                .HasPrecision(5, 2)
                .HasComment("Score 0-100 generado por modelo de IA en tiempo real")
                .HasColumnName("puntaje_conduccion");
            entity.Property(e => e.PuntosGanados).HasColumnName("puntos_ganados");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.VehiculoId).HasColumnName("vehiculo_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("viajes_usuario_id_fkey");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.VehiculoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("viajes_vehiculo_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
