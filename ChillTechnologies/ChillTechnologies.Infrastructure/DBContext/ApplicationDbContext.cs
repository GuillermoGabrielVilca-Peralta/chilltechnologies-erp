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

    public virtual DbSet<AlertasRiesgo> AlertasRiesgos { get; set; }

    public virtual DbSet<Aliado> Aliados { get; set; }

    public virtual DbSet<Aseguradora> Aseguradoras { get; set; }

    public virtual DbSet<AsignacionesVehiculo> AsignacionesVehiculos { get; set; }

    public virtual DbSet<Camara> Camaras { get; set; }

    public virtual DbSet<Canje> Canjes { get; set; }

    public virtual DbSet<CategoriasAliado> CategoriasAliados { get; set; }

    public virtual DbSet<DescuentosPoliza> DescuentosPolizas { get; set; }

    public virtual DbSet<DocumentosVehiculo> DocumentosVehiculos { get; set; }

    public virtual DbSet<EmisionesViaje> EmisionesViajes { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Flota> Flotas { get; set; }

    public virtual DbSet<Geocerca> Geocercas { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<MetodosPago> MetodosPagos { get; set; }

    public virtual DbSet<ModelosIum> ModelosIa { get; set; }

    public virtual DbSet<MovimientosPunto> MovimientosPuntos { get; set; }

    public virtual DbSet<Nivele> Niveles { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Parada> Paradas { get; set; }

    public virtual DbSet<Plane> Planes { get; set; }

    public virtual DbSet<Poliza> Polizas { get; set; }

    public virtual DbSet<PosicionesCamara> PosicionesCamaras { get; set; }

    public virtual DbSet<Premio> Premios { get; set; }

    public virtual DbSet<PuntosUsuario> PuntosUsuarios { get; set; }

    public virtual DbSet<ReglasScoring> ReglasScorings { get; set; }

    public virtual DbSet<Suscripcione> Suscripciones { get; set; }

    public virtual DbSet<TiposConductor> TiposConductors { get; set; }

    public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }

    public virtual DbSet<TiposEvento> TiposEventos { get; set; }

    public virtual DbSet<TiposMantenimiento> TiposMantenimientos { get; set; }

    public virtual DbSet<TiposNotificacion> TiposNotificacions { get; set; }

    public virtual DbSet<TiposVehiculo> TiposVehiculos { get; set; }

    public virtual DbSet<UmbralesDeteccion> UmbralesDeteccions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VRankingConductore> VRankingConductores { get; set; }

    public virtual DbSet<VSuscripcionesActiva> VSuscripcionesActivas { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    public virtual DbSet<ZonasRiesgo> ZonasRiesgos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<AlertasRiesgo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("alertas_riesgo_pkey");

            entity.ToTable("alertas_riesgo");

            entity.HasIndex(e => e.Estado, "idx_alertas_estado");

            entity.HasIndex(e => e.FechaAlerta, "idx_alertas_fecha").IsDescending();

            entity.HasIndex(e => e.UsuarioId, "idx_alertas_usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaAlerta)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_alerta");
            entity.Property(e => e.Motivo)
                .HasMaxLength(150)
                .HasColumnName("motivo");
            entity.Property(e => e.Severidad)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Media'::character varying")
                .HasColumnName("severidad");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.VehiculoId).HasColumnName("vehiculo_id");
            entity.Property(e => e.ViajeId).HasColumnName("viaje_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.AlertasRiesgos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("alertas_riesgo_usuario_id_fkey");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.AlertasRiesgos)
                .HasForeignKey(d => d.VehiculoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("alertas_riesgo_vehiculo_id_fkey");

            entity.HasOne(d => d.Viaje).WithMany(p => p.AlertasRiesgos)
                .HasForeignKey(d => d.ViajeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("alertas_riesgo_viaje_id_fkey");
        });

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

        modelBuilder.Entity<Aseguradora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("aseguradoras_pkey");

            entity.ToTable("aseguradoras");

            entity.HasIndex(e => e.Ruc, "aseguradoras_ruc_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactoNombre)
                .HasMaxLength(120)
                .HasColumnName("contacto_nombre");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activa'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<AsignacionesVehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("asignaciones_vehiculo_pkey");

            entity.ToTable("asignaciones_vehiculo", tb => tb.HasComment("Historial de que conductor maneja que vehiculo de flota"));

            entity.HasIndex(e => e.UsuarioId, "idx_asignaciones_usuario");

            entity.HasIndex(e => e.VehiculoId, "idx_asignaciones_vehiculo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activa'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaFin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.VehiculoId).HasColumnName("vehiculo_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.AsignacionesVehiculos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("asignaciones_vehiculo_usuario_id_fkey");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.AsignacionesVehiculos)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("asignaciones_vehiculo_vehiculo_id_fkey");
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

        modelBuilder.Entity<DescuentosPoliza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("descuentos_poliza_pkey");

            entity.ToTable("descuentos_poliza");

            entity.HasIndex(e => e.PolizaId, "idx_descuentos_poliza");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Calculado'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCalculo)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_calculo");
            entity.Property(e => e.MontoDescontado)
                .HasPrecision(10, 2)
                .HasColumnName("monto_descontado");
            entity.Property(e => e.PeriodoFin).HasColumnName("periodo_fin");
            entity.Property(e => e.PeriodoInicio).HasColumnName("periodo_inicio");
            entity.Property(e => e.PolizaId).HasColumnName("poliza_id");
            entity.Property(e => e.PorcentajeDescuento)
                .HasPrecision(5, 2)
                .HasColumnName("porcentaje_descuento");
            entity.Property(e => e.PuntajePromedio)
                .HasPrecision(5, 2)
                .HasColumnName("puntaje_promedio");

            entity.HasOne(d => d.Poliza).WithMany(p => p.DescuentosPolizas)
                .HasForeignKey(d => d.PolizaId)
                .HasConstraintName("descuentos_poliza_poliza_id_fkey");
        });

        modelBuilder.Entity<DocumentosVehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("documentos_vehiculo_pkey");

            entity.ToTable("documentos_vehiculo");

            entity.HasIndex(e => e.VehiculoId, "idx_documentos_vehiculo");

            entity.HasIndex(e => e.FechaVencimiento, "idx_documentos_vencimiento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Archivo)
                .HasMaxLength(255)
                .HasColumnName("archivo");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Vigente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaEmision).HasColumnName("fecha_emision");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.Numero)
                .HasMaxLength(60)
                .HasColumnName("numero");
            entity.Property(e => e.TipoDocumentoId).HasColumnName("tipo_documento_id");
            entity.Property(e => e.VehiculoId).HasColumnName("vehiculo_id");

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.DocumentosVehiculos)
                .HasForeignKey(d => d.TipoDocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documentos_vehiculo_tipo_documento_id_fkey");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.DocumentosVehiculos)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("documentos_vehiculo_vehiculo_id_fkey");
        });

        modelBuilder.Entity<EmisionesViaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("emisiones_viaje_pkey");

            entity.ToTable("emisiones_viaje");

            entity.HasIndex(e => e.ViajeId, "emisiones_viaje_viaje_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AhorroEstimadoKg)
                .HasPrecision(10, 3)
                .HasComment("CO2 no emitido gracias a la buena conduccion frente al promedio")
                .HasColumnName("ahorro_estimado_kg");
            entity.Property(e => e.Co2Kg)
                .HasPrecision(10, 3)
                .HasColumnName("co2_kg");
            entity.Property(e => e.CombustibleLitros)
                .HasPrecision(10, 3)
                .HasColumnName("combustible_litros");
            entity.Property(e => e.FechaCalculo)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_calculo");
            entity.Property(e => e.ViajeId).HasColumnName("viaje_id");

            entity.HasOne(d => d.Viaje).WithOne(p => p.EmisionesViaje)
                .HasForeignKey<EmisionesViaje>(d => d.ViajeId)
                .HasConstraintName("emisiones_viaje_viaje_id_fkey");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("empresas_pkey");

            entity.ToTable("empresas", tb => tb.HasComment("Clientes corporativos: empresas de taxi, delivery o transporte"));

            entity.HasIndex(e => e.Ruc, "empresas_ruc_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactoNombre)
                .HasMaxLength(120)
                .HasColumnName("contacto_nombre");
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
                .HasDefaultValueSql("'Activa'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(150)
                .HasColumnName("razon_social");
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
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
            entity.Property(e => e.Confianza)
                .HasPrecision(5, 2)
                .HasColumnName("confianza");
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
            entity.Property(e => e.ModeloIaId).HasColumnName("modelo_ia_id");
            entity.Property(e => e.TipoEventoId).HasColumnName("tipo_evento_id");
            entity.Property(e => e.Validado)
                .HasComment("Confirmacion humana de que la deteccion de IA fue correcta")
                .HasColumnName("validado");
            entity.Property(e => e.ValidadoPor).HasColumnName("validado_por");
            entity.Property(e => e.ViajeId)
                .HasComment("NULL si la deteccion ocurre fuera de un viaje activo")
                .HasColumnName("viaje_id");

            entity.HasOne(d => d.Camara).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.CamaraId)
                .HasConstraintName("eventos_camara_id_fkey");

            entity.HasOne(d => d.ModeloIa).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.ModeloIaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("eventos_modelo_ia_id_fkey");

            entity.HasOne(d => d.TipoEvento).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.TipoEventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("eventos_tipo_evento_id_fkey");

            entity.HasOne(d => d.ValidadoPorNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.ValidadoPor)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("eventos_validado_por_fkey");

            entity.HasOne(d => d.Viaje).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.ViajeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("eventos_viaje_id_fkey");
        });

        modelBuilder.Entity<Flota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("flotas_pkey");

            entity.ToTable("flotas", tb => tb.HasComment("Agrupacion de vehiculos dentro de una empresa cliente"));

            entity.HasIndex(e => e.EmpresaId, "idx_flotas_empresa");

            entity.HasIndex(e => new { e.EmpresaId, e.Nombre }, "uq_flotas_empresa_nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activa'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Flota)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("flotas_empresa_id_fkey");
        });

        modelBuilder.Entity<Geocerca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("geocercas_pkey");

            entity.ToTable("geocercas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.EmpresaId)
                .HasComment("NULL = geocerca global del sistema")
                .HasColumnName("empresa_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activa'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Latitud)
                .HasPrecision(10, 7)
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasPrecision(10, 7)
                .HasColumnName("longitud");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.RadioMetros).HasColumnName("radio_metros");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Permitida'::character varying")
                .HasColumnName("tipo");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Geocercas)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("geocercas_empresa_id_fkey");
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mantenimientos_pkey");

            entity.ToTable("mantenimientos");

            entity.HasIndex(e => e.Estado, "idx_mantenimientos_estado");

            entity.HasIndex(e => e.VehiculoId, "idx_mantenimientos_vehiculo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CostoSoles)
                .HasPrecision(10, 2)
                .HasColumnName("costo_soles");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Programado'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaProgramada).HasColumnName("fecha_programada");
            entity.Property(e => e.FechaRealizado).HasColumnName("fecha_realizado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Kilometraje).HasColumnName("kilometraje");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.Taller)
                .HasMaxLength(120)
                .HasColumnName("taller");
            entity.Property(e => e.TipoMantenimientoId).HasColumnName("tipo_mantenimiento_id");
            entity.Property(e => e.VehiculoId).HasColumnName("vehiculo_id");

            entity.HasOne(d => d.TipoMantenimiento).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.TipoMantenimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("mantenimientos_tipo_mantenimiento_id_fkey");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("mantenimientos_vehiculo_id_fkey");
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

        modelBuilder.Entity<ModelosIum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("modelos_ia_pkey");

            entity.ToTable("modelos_ia");

            entity.HasIndex(e => new { e.Nombre, e.Version }, "uq_modelos_nombre_version").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Arquitectura)
                .HasMaxLength(40)
                .HasDefaultValueSql("'YOLOv8'::character varying")
                .HasColumnName("arquitectura");
            entity.Property(e => e.FechaEntrenamiento).HasColumnName("fecha_entrenamiento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecisionPromedio)
                .HasPrecision(5, 2)
                .HasColumnName("precision_promedio");
            entity.Property(e => e.Version)
                .HasMaxLength(20)
                .HasColumnName("version");
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

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notificaciones_pkey");

            entity.ToTable("notificaciones");

            entity.HasIndex(e => e.FechaEnvio, "idx_notificaciones_fecha").IsDescending();

            entity.HasIndex(e => e.Leida, "idx_notificaciones_leida");

            entity.HasIndex(e => e.UsuarioId, "idx_notificaciones_usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_envio");
            entity.Property(e => e.FechaLectura)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_lectura");
            entity.Property(e => e.Leida).HasColumnName("leida");
            entity.Property(e => e.Mensaje).HasColumnName("mensaje");
            entity.Property(e => e.TipoNotificacionId).HasColumnName("tipo_notificacion_id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(120)
                .HasColumnName("titulo");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.TipoNotificacion).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.TipoNotificacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("notificaciones_tipo_notificacion_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("notificaciones_usuario_id_fkey");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pagos_pkey");

            entity.ToTable("pagos");

            entity.HasIndex(e => e.Estado, "idx_pagos_estado");

            entity.HasIndex(e => e.SuscripcionId, "idx_pagos_suscripcion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.MetodoPagoId).HasColumnName("metodo_pago_id");
            entity.Property(e => e.MontoSoles)
                .HasPrecision(10, 2)
                .HasColumnName("monto_soles");
            entity.Property(e => e.Referencia)
                .HasMaxLength(100)
                .HasColumnName("referencia");
            entity.Property(e => e.SuscripcionId).HasColumnName("suscripcion_id");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.MetodoPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pagos_metodo_pago_id_fkey");

            entity.HasOne(d => d.Suscripcion).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.SuscripcionId)
                .HasConstraintName("pagos_suscripcion_id_fkey");
        });

        modelBuilder.Entity<Parada>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("paradas_pkey");

            entity.ToTable("paradas");

            entity.HasIndex(e => e.ViajeId, "idx_paradas_viaje");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DuracionMinutos).HasColumnName("duracion_minutos");
            entity.Property(e => e.GeocercaId).HasColumnName("geocerca_id");
            entity.Property(e => e.HoraFin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("hora_inicio");
            entity.Property(e => e.Latitud)
                .HasPrecision(10, 7)
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasPrecision(10, 7)
                .HasColumnName("longitud");
            entity.Property(e => e.ViajeId).HasColumnName("viaje_id");

            entity.HasOne(d => d.Geocerca).WithMany(p => p.Parada)
                .HasForeignKey(d => d.GeocercaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("paradas_geocerca_id_fkey");

            entity.HasOne(d => d.Viaje).WithMany(p => p.Parada)
                .HasForeignKey(d => d.ViajeId)
                .HasConstraintName("paradas_viaje_id_fkey");
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

        modelBuilder.Entity<Poliza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("polizas_pkey");

            entity.ToTable("polizas");

            entity.HasIndex(e => e.Estado, "idx_polizas_estado");

            entity.HasIndex(e => e.VehiculoId, "idx_polizas_vehiculo");

            entity.HasIndex(e => e.Numero, "polizas_numero_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AseguradoraId).HasColumnName("aseguradora_id");
            entity.Property(e => e.Cobertura)
                .HasMaxLength(150)
                .HasColumnName("cobertura");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Vigente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Numero)
                .HasMaxLength(60)
                .HasColumnName("numero");
            entity.Property(e => e.PrimaSoles)
                .HasPrecision(10, 2)
                .HasColumnName("prima_soles");
            entity.Property(e => e.VehiculoId).HasColumnName("vehiculo_id");

            entity.HasOne(d => d.Aseguradora).WithMany(p => p.Polizas)
                .HasForeignKey(d => d.AseguradoraId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("polizas_aseguradora_id_fkey");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Polizas)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("polizas_vehiculo_id_fkey");
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

        modelBuilder.Entity<ReglasScoring>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reglas_scoring_pkey");

            entity.ToTable("reglas_scoring");

            entity.HasIndex(e => new { e.EmpresaId, e.TipoEventoId }, "uq_reglas_empresa_tipo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activa)
                .HasDefaultValue(true)
                .HasColumnName("activa");
            entity.Property(e => e.EmpresaId)
                .HasComment("NULL = regla por defecto del sistema; con valor = regla propia de esa empresa")
                .HasColumnName("empresa_id");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.ImpactoPuntaje).HasColumnName("impacto_puntaje");
            entity.Property(e => e.Peso)
                .HasPrecision(5, 2)
                .HasDefaultValue(1.00m)
                .HasColumnName("peso");
            entity.Property(e => e.TipoEventoId).HasColumnName("tipo_evento_id");

            entity.HasOne(d => d.Empresa).WithMany(p => p.ReglasScorings)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("reglas_scoring_empresa_id_fkey");

            entity.HasOne(d => d.TipoEvento).WithMany(p => p.ReglasScorings)
                .HasForeignKey(d => d.TipoEventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reglas_scoring_tipo_evento_id_fkey");
        });

        modelBuilder.Entity<Suscripcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("suscripciones_pkey");

            entity.ToTable("suscripciones", tb => tb.HasComment("Ciclos de pago del plan Profesional"));

            entity.HasIndex(e => e.Estado, "idx_suscripciones_estado");

            entity.HasIndex(e => e.FechaFin, "idx_suscripciones_fin");

            entity.HasIndex(e => e.UsuarioId, "idx_suscripciones_usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CantidadLicencias)
                .HasDefaultValue(1)
                .HasColumnName("cantidad_licencias");
            entity.Property(e => e.EmpresaId)
                .HasComment("Suscripcion corporativa (B2B); excluyente con usuario_id (B2C)")
                .HasColumnName("empresa_id");
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
            entity.Property(e => e.RenovacionAutomatica).HasColumnName("renovacion_automatica");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Suscripciones)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("suscripciones_empresa_id_fkey");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Suscripciones)
                .HasForeignKey(d => d.MetodoPagoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("suscripciones_metodo_pago_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Suscripciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade)
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

        modelBuilder.Entity<TiposDocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipos_documento_pkey");

            entity.ToTable("tipos_documento");

            entity.HasIndex(e => e.Nombre, "tipos_documento_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiasAlertaPrevia)
                .HasDefaultValue(30)
                .HasColumnName("dias_alerta_previa");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
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

        modelBuilder.Entity<TiposMantenimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipos_mantenimiento_pkey");

            entity.ToTable("tipos_mantenimiento");

            entity.HasIndex(e => e.Nombre, "tipos_mantenimiento_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KmSugerido).HasColumnName("km_sugerido");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TiposNotificacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipos_notificacion_pkey");

            entity.ToTable("tipos_notificacion");

            entity.HasIndex(e => e.Nombre, "tipos_notificacion_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Canal)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Push'::character varying")
                .HasColumnName("canal");
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
            entity.Property(e => e.FactorEmisionGKm)
                .HasPrecision(8, 2)
                .HasComment("Gramos de CO2 por kilometro segun tipo de vehiculo")
                .HasColumnName("factor_emision_g_km");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<UmbralesDeteccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("umbrales_deteccion_pkey");

            entity.ToTable("umbrales_deteccion");

            entity.HasIndex(e => new { e.ModeloIaId, e.TipoEventoId }, "uq_umbrales_modelo_tipo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConfianzaMinima)
                .HasPrecision(5, 2)
                .HasColumnName("confianza_minima");
            entity.Property(e => e.ModeloIaId).HasColumnName("modelo_ia_id");
            entity.Property(e => e.TipoEventoId).HasColumnName("tipo_evento_id");

            entity.HasOne(d => d.ModeloIa).WithMany(p => p.UmbralesDeteccions)
                .HasForeignKey(d => d.ModeloIaId)
                .HasConstraintName("umbrales_deteccion_modelo_ia_id_fkey");

            entity.HasOne(d => d.TipoEvento).WithMany(p => p.UmbralesDeteccions)
                .HasForeignKey(d => d.TipoEventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("umbrales_deteccion_tipo_evento_id_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios", tb => tb.HasComment("Conductores registrados en ChillDrive"));

            entity.HasIndex(e => e.EmpresaId, "idx_usuarios_empresa");

            entity.HasIndex(e => e.Estado, "idx_usuarios_estado");

            entity.HasIndex(e => e.Correo, "usuarios_correo_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .HasColumnName("correo");
            entity.Property(e => e.EmpresaId)
                .HasComment("NULL = conductor independiente (B2C)")
                .HasColumnName("empresa_id");
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

            entity.HasOne(d => d.Empresa).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("usuarios_empresa_id_fkey");

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

            entity.HasIndex(e => e.FlotaId, "idx_vehiculos_flota");

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
            entity.Property(e => e.FlotaId).HasColumnName("flota_id");
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

            entity.HasOne(d => d.Flota).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.FlotaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("vehiculos_flota_id_fkey");

            entity.HasOne(d => d.TipoVehiculo).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.TipoVehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vehiculos_tipo_vehiculo_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade)
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

        modelBuilder.Entity<ZonasRiesgo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("zonas_riesgo_pkey");

            entity.ToTable("zonas_riesgo");

            entity.HasIndex(e => e.NivelRiesgo, "idx_zonas_riesgo_nivel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IncidentesRegistrados).HasColumnName("incidentes_registrados");
            entity.Property(e => e.Latitud)
                .HasPrecision(10, 7)
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasPrecision(10, 7)
                .HasColumnName("longitud");
            entity.Property(e => e.NivelRiesgo)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Medio'::character varying")
                .HasColumnName("nivel_riesgo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.RadioMetros).HasColumnName("radio_metros");
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Otro'::character varying")
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
