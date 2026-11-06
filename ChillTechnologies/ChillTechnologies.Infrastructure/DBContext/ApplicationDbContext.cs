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

    public virtual DbSet<Almacene> Almacenes { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Aseguradora> Aseguradoras { get; set; }

    public virtual DbSet<AsientosContable> AsientosContables { get; set; }

    public virtual DbSet<AsignacionesVehiculo> AsignacionesVehiculos { get; set; }

    public virtual DbSet<Asistencia> Asistencias { get; set; }

    public virtual DbSet<Auditorium> Auditoria { get; set; }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Camara> Camaras { get; set; }

    public virtual DbSet<Canje> Canjes { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<CategoriasAliado> CategoriasAliados { get; set; }

    public virtual DbSet<CategoriasProducto> CategoriasProductos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cotizacione> Cotizaciones { get; set; }

    public virtual DbSet<CuentasBancaria> CuentasBancarias { get; set; }

    public virtual DbSet<CuentasPorCobrar> CuentasPorCobrars { get; set; }

    public virtual DbSet<CuentasPorPagar> CuentasPorPagars { get; set; }

    public virtual DbSet<DescuentosPoliza> DescuentosPolizas { get; set; }

    public virtual DbSet<DetalleAsiento> DetalleAsientos { get; set; }

    public virtual DbSet<DetalleCotizacion> DetalleCotizacions { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<DetalleOrdenCompra> DetalleOrdenCompras { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<DocumentosVehiculo> DocumentosVehiculos { get; set; }

    public virtual DbSet<EmisionesViaje> EmisionesViajes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Flota> Flotas { get; set; }

    public virtual DbSet<Geocerca> Geocercas { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<MetodosPago> MetodosPagos { get; set; }

    public virtual DbSet<ModelosIum> ModelosIa { get; set; }

    public virtual DbSet<MovimientosBancario> MovimientosBancarios { get; set; }

    public virtual DbSet<MovimientosCaja> MovimientosCajas { get; set; }

    public virtual DbSet<MovimientosInventario> MovimientosInventarios { get; set; }

    public virtual DbSet<MovimientosPunto> MovimientosPuntos { get; set; }

    public virtual DbSet<Nivele> Niveles { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<OrdenesCompra> OrdenesCompras { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Parada> Paradas { get; set; }

    public virtual DbSet<ParametrosSistema> ParametrosSistemas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PlanCuenta> PlanCuentas { get; set; }

    public virtual DbSet<Plane> Planes { get; set; }

    public virtual DbSet<Planilla> Planillas { get; set; }

    public virtual DbSet<Poliza> Polizas { get; set; }

    public virtual DbSet<PosicionesCamara> PosicionesCamaras { get; set; }

    public virtual DbSet<Premio> Premios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<PuntosUsuario> PuntosUsuarios { get; set; }

    public virtual DbSet<Recepcione> Recepciones { get; set; }

    public virtual DbSet<ReglasScoring> ReglasScorings { get; set; }

    public virtual DbSet<RolPermiso> RolPermisos { get; set; }

    public virtual DbSet<RolesSistema> RolesSistemas { get; set; }

    public virtual DbSet<SolicitudesAusencium> SolicitudesAusencia { get; set; }

    public virtual DbSet<Suscripcione> Suscripciones { get; set; }

    public virtual DbSet<TiposAusencium> TiposAusencia { get; set; }

    public virtual DbSet<TiposConductor> TiposConductors { get; set; }

    public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }

    public virtual DbSet<TiposEvento> TiposEventos { get; set; }

    public virtual DbSet<TiposMantenimiento> TiposMantenimientos { get; set; }

    public virtual DbSet<TiposMovimientoInventario> TiposMovimientoInventarios { get; set; }

    public virtual DbSet<TiposNotificacion> TiposNotificacions { get; set; }

    public virtual DbSet<TiposVehiculo> TiposVehiculos { get; set; }

    public virtual DbSet<UmbralesDeteccion> UmbralesDeteccions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    public virtual DbSet<UsuariosSistema> UsuariosSistemas { get; set; }

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

        modelBuilder.Entity<Almacene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("almacenes_pkey");

            entity.ToTable("almacenes");

            entity.HasIndex(e => e.Nombre, "almacenes_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.ResponsableEmpleadoId).HasColumnName("responsable_empleado_id");

            entity.HasOne(d => d.ResponsableEmpleado).WithMany(p => p.Almacenes)
                .HasForeignKey(d => d.ResponsableEmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("almacenes_responsable_empleado_id_fkey");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("areas_pkey");

            entity.ToTable("areas");

            entity.HasIndex(e => e.Nombre, "areas_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AreaPadreId)
                .HasComment("Jerarquia del organigrama; NULL = area raiz")
                .HasColumnName("area_padre_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
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

            entity.HasOne(d => d.AreaPadre).WithMany(p => p.InverseAreaPadre)
                .HasForeignKey(d => d.AreaPadreId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("areas_area_padre_id_fkey");
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

        modelBuilder.Entity<AsientosContable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("asientos_contables_pkey");

            entity.ToTable("asientos_contables");

            entity.HasIndex(e => e.Numero, "asientos_contables_numero_key").IsUnique();

            entity.HasIndex(e => e.Fecha, "idx_asientos_fecha").IsDescending();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Borrador'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Glosa)
                .HasMaxLength(255)
                .HasColumnName("glosa");
            entity.Property(e => e.Numero)
                .HasMaxLength(30)
                .HasColumnName("numero");
            entity.Property(e => e.TipoAsiento)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Diario'::character varying")
                .HasColumnName("tipo_asiento");
            entity.Property(e => e.TotalDebe)
                .HasPrecision(14, 2)
                .HasColumnName("total_debe");
            entity.Property(e => e.TotalHaber)
                .HasPrecision(14, 2)
                .HasColumnName("total_haber");

            entity.HasOne(d => d.Empleado).WithMany(p => p.AsientosContables)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("asientos_contables_empleado_id_fkey");
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

        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("asistencias_pkey");

            entity.ToTable("asistencias");

            entity.HasIndex(e => e.Fecha, "idx_asistencias_fecha").IsDescending();

            entity.HasIndex(e => new { e.EmpleadoId, e.Fecha }, "uq_asistencias_empleado_fecha").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Puntual'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.HoraEntrada).HasColumnName("hora_entrada");
            entity.Property(e => e.HoraSalida).HasColumnName("hora_salida");
            entity.Property(e => e.HorasTrabajadas)
                .HasPrecision(5, 2)
                .HasColumnName("horas_trabajadas");
            entity.Property(e => e.Observacion)
                .HasMaxLength(255)
                .HasColumnName("observacion");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("asistencias_empleado_id_fkey");
        });

        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auditoria_pkey");

            entity.ToTable("auditoria");

            entity.HasIndex(e => e.FechaAccion, "idx_auditoria_fecha").IsDescending();

            entity.HasIndex(e => e.UsuarioSistemaId, "idx_auditoria_usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accion)
                .HasMaxLength(20)
                .HasColumnName("accion");
            entity.Property(e => e.DatosAntes).HasColumnName("datos_antes");
            entity.Property(e => e.DatosDespues).HasColumnName("datos_despues");
            entity.Property(e => e.DireccionIp)
                .HasMaxLength(45)
                .HasColumnName("direccion_ip");
            entity.Property(e => e.FechaAccion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_accion");
            entity.Property(e => e.RegistroId).HasColumnName("registro_id");
            entity.Property(e => e.TablaAfectada)
                .HasMaxLength(60)
                .HasColumnName("tabla_afectada");
            entity.Property(e => e.UsuarioSistemaId).HasColumnName("usuario_sistema_id");

            entity.HasOne(d => d.UsuarioSistema).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.UsuarioSistemaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("auditoria_usuario_sistema_id_fkey");
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cajas_pkey");

            entity.ToTable("cajas");

            entity.HasIndex(e => e.Nombre, "cajas_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Abierta'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasColumnName("nombre");
            entity.Property(e => e.ResponsableEmpleadoId).HasColumnName("responsable_empleado_id");
            entity.Property(e => e.SaldoActual)
                .HasPrecision(12, 2)
                .HasColumnName("saldo_actual");
            entity.Property(e => e.SaldoInicial)
                .HasPrecision(12, 2)
                .HasColumnName("saldo_inicial");

            entity.HasOne(d => d.ResponsableEmpleado).WithMany(p => p.Cajas)
                .HasForeignKey(d => d.ResponsableEmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("cajas_responsable_empleado_id_fkey");
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

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cargos_pkey");

            entity.ToTable("cargos");

            entity.HasIndex(e => e.Nombre, "cargos_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nivel)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Operativo'::character varying")
                .HasColumnName("nivel");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
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

        modelBuilder.Entity<CategoriasProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorias_producto_pkey");

            entity.ToTable("categorias_producto");

            entity.HasIndex(e => e.Nombre, "categorias_producto_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clientes_pkey");

            entity.ToTable("clientes", tb => tb.HasComment("Ficha comercial y de facturacion; puede apuntar a una empresa de flota o a un conductor"));

            entity.HasIndex(e => e.NumeroDocumento, "clientes_numero_documento_key").IsUnique();

            entity.HasIndex(e => e.VendedorId, "idx_clientes_vendedor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CondicionPago)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Contado'::character varying")
                .HasColumnName("condicion_pago");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.LineaCredito)
                .HasPrecision(12, 2)
                .HasColumnName("linea_credito");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(15)
                .HasColumnName("numero_documento");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(150)
                .HasColumnName("razon_social");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(10)
                .HasDefaultValueSql("'RUC'::character varying")
                .HasColumnName("tipo_documento");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.VendedorId).HasColumnName("vendedor_id");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("clientes_empresa_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("clientes_usuario_id_fkey");

            entity.HasOne(d => d.Vendedor).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.VendedorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("clientes_vendedor_id_fkey");
        });

        modelBuilder.Entity<Cotizacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cotizaciones_pkey");

            entity.ToTable("cotizaciones");

            entity.HasIndex(e => e.Numero, "cotizaciones_numero_key").IsUnique();

            entity.HasIndex(e => e.ClienteId, "idx_cotizaciones_cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Borrador'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaEmision).HasColumnName("fecha_emision");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.FechaValidez).HasColumnName("fecha_validez");
            entity.Property(e => e.Igv)
                .HasPrecision(12, 2)
                .HasColumnName("igv");
            entity.Property(e => e.Numero)
                .HasMaxLength(30)
                .HasColumnName("numero");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasPrecision(12, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Cotizaciones)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("cotizaciones_cliente_id_fkey");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Cotizaciones)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("cotizaciones_empleado_id_fkey");
        });

        modelBuilder.Entity<CuentasBancaria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cuentas_bancarias_pkey");

            entity.ToTable("cuentas_bancarias");

            entity.HasIndex(e => e.NumeroCuenta, "cuentas_bancarias_numero_cuenta_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Banco)
                .HasMaxLength(80)
                .HasColumnName("banco");
            entity.Property(e => e.Cci)
                .HasMaxLength(30)
                .HasColumnName("cci");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activa'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Moneda)
                .HasMaxLength(10)
                .HasDefaultValueSql("'PEN'::character varying")
                .HasColumnName("moneda");
            entity.Property(e => e.NumeroCuenta)
                .HasMaxLength(30)
                .HasColumnName("numero_cuenta");
            entity.Property(e => e.Saldo)
                .HasPrecision(14, 2)
                .HasColumnName("saldo");
            entity.Property(e => e.TipoCuenta)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Corriente'::character varying")
                .HasColumnName("tipo_cuenta");
        });

        modelBuilder.Entity<CuentasPorCobrar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cuentas_por_cobrar_pkey");

            entity.ToTable("cuentas_por_cobrar");

            entity.HasIndex(e => e.ClienteId, "idx_cxc_cliente");

            entity.HasIndex(e => e.FechaVencimiento, "idx_cxc_vencimiento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FacturaId).HasColumnName("factura_id");
            entity.Property(e => e.FechaEmision).HasColumnName("fecha_emision");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.Monto)
                .HasPrecision(12, 2)
                .HasColumnName("monto");
            entity.Property(e => e.Saldo)
                .HasPrecision(12, 2)
                .HasColumnName("saldo");

            entity.HasOne(d => d.Cliente).WithMany(p => p.CuentasPorCobrars)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("cuentas_por_cobrar_cliente_id_fkey");

            entity.HasOne(d => d.Factura).WithMany(p => p.CuentasPorCobrars)
                .HasForeignKey(d => d.FacturaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("cuentas_por_cobrar_factura_id_fkey");
        });

        modelBuilder.Entity<CuentasPorPagar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cuentas_por_pagar_pkey");

            entity.ToTable("cuentas_por_pagar");

            entity.HasIndex(e => e.ProveedorId, "idx_cxp_proveedor");

            entity.HasIndex(e => e.FechaVencimiento, "idx_cxp_vencimiento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaEmision).HasColumnName("fecha_emision");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.Monto)
                .HasPrecision(12, 2)
                .HasColumnName("monto");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(40)
                .HasColumnName("numero_documento");
            entity.Property(e => e.OrdenCompraId).HasColumnName("orden_compra_id");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.Saldo)
                .HasPrecision(12, 2)
                .HasColumnName("saldo");

            entity.HasOne(d => d.OrdenCompra).WithMany(p => p.CuentasPorPagars)
                .HasForeignKey(d => d.OrdenCompraId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("cuentas_por_pagar_orden_compra_id_fkey");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.CuentasPorPagars)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("cuentas_por_pagar_proveedor_id_fkey");
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

        modelBuilder.Entity<DetalleAsiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detalle_asiento_pkey");

            entity.ToTable("detalle_asiento");

            entity.HasIndex(e => e.AsientoId, "idx_detalle_asiento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AsientoId).HasColumnName("asiento_id");
            entity.Property(e => e.CuentaId).HasColumnName("cuenta_id");
            entity.Property(e => e.Debe)
                .HasPrecision(14, 2)
                .HasColumnName("debe");
            entity.Property(e => e.Glosa)
                .HasMaxLength(255)
                .HasColumnName("glosa");
            entity.Property(e => e.Haber)
                .HasPrecision(14, 2)
                .HasColumnName("haber");

            entity.HasOne(d => d.Asiento).WithMany(p => p.DetalleAsientos)
                .HasForeignKey(d => d.AsientoId)
                .HasConstraintName("detalle_asiento_asiento_id_fkey");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.DetalleAsientos)
                .HasForeignKey(d => d.CuentaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("detalle_asiento_cuenta_id_fkey");
        });

        modelBuilder.Entity<DetalleCotizacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detalle_cotizacion_pkey");

            entity.ToTable("detalle_cotizacion");

            entity.HasIndex(e => e.CotizacionId, "idx_detalle_cotizacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CotizacionId).HasColumnName("cotizacion_id");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");

            entity.HasOne(d => d.Cotizacion).WithMany(p => p.DetalleCotizacions)
                .HasForeignKey(d => d.CotizacionId)
                .HasConstraintName("detalle_cotizacion_cotizacion_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleCotizacions)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("detalle_cotizacion_producto_id_fkey");
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detalle_factura_pkey");

            entity.ToTable("detalle_factura");

            entity.HasIndex(e => e.FacturaId, "idx_detalle_factura");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.FacturaId).HasColumnName("factura_id");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");

            entity.HasOne(d => d.Factura).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("detalle_factura_factura_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("detalle_factura_producto_id_fkey");
        });

        modelBuilder.Entity<DetalleOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detalle_orden_compra_pkey");

            entity.ToTable("detalle_orden_compra");

            entity.HasIndex(e => e.OrdenCompraId, "idx_detalle_oc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.OrdenCompraId).HasColumnName("orden_compra_id");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");

            entity.HasOne(d => d.OrdenCompra).WithMany(p => p.DetalleOrdenCompras)
                .HasForeignKey(d => d.OrdenCompraId)
                .HasConstraintName("detalle_orden_compra_orden_compra_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleOrdenCompras)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("detalle_orden_compra_producto_id_fkey");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detalle_pedido_pkey");

            entity.ToTable("detalle_pedido");

            entity.HasIndex(e => e.PedidoId, "idx_detalle_pedido");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");

            entity.HasOne(d => d.Pedido).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("detalle_pedido_pedido_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("detalle_pedido_producto_id_fkey");
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

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("empleados_pkey");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.Dni, "empleados_dni_key").IsUnique();

            entity.HasIndex(e => e.Email, "empleados_email_key").IsUnique();

            entity.HasIndex(e => e.AreaId, "idx_empleados_area");

            entity.HasIndex(e => e.Estado, "idx_empleados_estado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.CargoId).HasColumnName("cargo_id");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCese).HasColumnName("fecha_cese");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.JefeId)
                .HasComment("Jefe directo, para el organigrama")
                .HasColumnName("jefe_id");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");
            entity.Property(e => e.SueldoBasico)
                .HasPrecision(10, 2)
                .HasColumnName("sueldo_basico");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.Area).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleados_area_id_fkey");

            entity.HasOne(d => d.Cargo).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleados_cargo_id_fkey");

            entity.HasOne(d => d.Jefe).WithMany(p => p.InverseJefe)
                .HasForeignKey(d => d.JefeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("empleados_jefe_id_fkey");
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

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("facturas_pkey");

            entity.ToTable("facturas");

            entity.HasIndex(e => e.ClienteId, "idx_facturas_cliente");

            entity.HasIndex(e => e.FechaEmision, "idx_facturas_fecha").IsDescending();

            entity.HasIndex(e => new { e.Serie, e.Numero }, "uq_facturas_serie_numero").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Emitida'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaEmision).HasColumnName("fecha_emision");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.Igv)
                .HasPrecision(12, 2)
                .HasColumnName("igv");
            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .HasColumnName("numero");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.Serie)
                .HasMaxLength(4)
                .HasDefaultValueSql("'F001'::character varying")
                .HasColumnName("serie");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.TipoComprobante)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Factura'::character varying")
                .HasColumnName("tipo_comprobante");
            entity.Property(e => e.Total)
                .HasPrecision(12, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("facturas_cliente_id_fkey");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("facturas_pedido_id_fkey");
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

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventario_pkey");

            entity.ToTable("inventario", tb => tb.HasComment("Stock actual por producto y almacen"));

            entity.HasIndex(e => new { e.ProductoId, e.AlmacenId }, "uq_inventario_producto_almacen").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlmacenId).HasColumnName("almacen_id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(60)
                .HasColumnName("ubicacion");
            entity.Property(e => e.UltimaActualizacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ultima_actualizacion");

            entity.HasOne(d => d.Almacen).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.AlmacenId)
                .HasConstraintName("inventario_almacen_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("inventario_producto_id_fkey");
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

        modelBuilder.Entity<MovimientosBancario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movimientos_bancarios_pkey");

            entity.ToTable("movimientos_bancarios");

            entity.HasIndex(e => e.CuentaBancariaId, "idx_movbanco_cuenta");

            entity.HasIndex(e => e.FechaMovimiento, "idx_movbanco_fecha").IsDescending();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Concepto)
                .HasMaxLength(150)
                .HasColumnName("concepto");
            entity.Property(e => e.Conciliado).HasColumnName("conciliado");
            entity.Property(e => e.CuentaBancariaId).HasColumnName("cuenta_bancaria_id");
            entity.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_movimiento");
            entity.Property(e => e.Monto)
                .HasPrecision(14, 2)
                .HasColumnName("monto");
            entity.Property(e => e.Referencia)
                .HasMaxLength(60)
                .HasColumnName("referencia");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");

            entity.HasOne(d => d.CuentaBancaria).WithMany(p => p.MovimientosBancarios)
                .HasForeignKey(d => d.CuentaBancariaId)
                .HasConstraintName("movimientos_bancarios_cuenta_bancaria_id_fkey");
        });

        modelBuilder.Entity<MovimientosCaja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movimientos_caja_pkey");

            entity.ToTable("movimientos_caja");

            entity.HasIndex(e => e.CajaId, "idx_movcaja_caja");

            entity.HasIndex(e => e.FechaMovimiento, "idx_movcaja_fecha").IsDescending();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CajaId).HasColumnName("caja_id");
            entity.Property(e => e.Concepto)
                .HasMaxLength(150)
                .HasColumnName("concepto");
            entity.Property(e => e.DocumentoReferencia)
                .HasMaxLength(60)
                .HasColumnName("documento_referencia");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_movimiento");
            entity.Property(e => e.Monto)
                .HasPrecision(12, 2)
                .HasColumnName("monto");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Caja).WithMany(p => p.MovimientosCajas)
                .HasForeignKey(d => d.CajaId)
                .HasConstraintName("movimientos_caja_caja_id_fkey");

            entity.HasOne(d => d.Empleado).WithMany(p => p.MovimientosCajas)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("movimientos_caja_empleado_id_fkey");
        });

        modelBuilder.Entity<MovimientosInventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movimientos_inventario_pkey");

            entity.ToTable("movimientos_inventario", tb => tb.HasComment("Kardex: entradas, salidas, transferencias y ajustes en un solo libro"));

            entity.HasIndex(e => e.FechaMovimiento, "idx_movinv_fecha").IsDescending();

            entity.HasIndex(e => e.ProductoId, "idx_movinv_producto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlmacenDestinoId).HasColumnName("almacen_destino_id");
            entity.Property(e => e.AlmacenOrigenId).HasColumnName("almacen_origen_id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CostoUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("costo_unitario");
            entity.Property(e => e.DocumentoReferencia)
                .HasMaxLength(60)
                .HasColumnName("documento_referencia");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_movimiento");
            entity.Property(e => e.Observacion)
                .HasMaxLength(255)
                .HasColumnName("observacion");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.TipoMovimientoId).HasColumnName("tipo_movimiento_id");

            entity.HasOne(d => d.AlmacenDestino).WithMany(p => p.MovimientosInventarioAlmacenDestinos)
                .HasForeignKey(d => d.AlmacenDestinoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("movimientos_inventario_almacen_destino_id_fkey");

            entity.HasOne(d => d.AlmacenOrigen).WithMany(p => p.MovimientosInventarioAlmacenOrigens)
                .HasForeignKey(d => d.AlmacenOrigenId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("movimientos_inventario_almacen_origen_id_fkey");

            entity.HasOne(d => d.Empleado).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("movimientos_inventario_empleado_id_fkey");

            entity.HasOne(d => d.Producto).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("movimientos_inventario_producto_id_fkey");

            entity.HasOne(d => d.TipoMovimiento).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.TipoMovimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movimientos_inventario_tipo_movimiento_id_fkey");
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

        modelBuilder.Entity<OrdenesCompra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ordenes_compra_pkey");

            entity.ToTable("ordenes_compra");

            entity.HasIndex(e => e.Estado, "idx_ordenes_compra_estado");

            entity.HasIndex(e => e.ProveedorId, "idx_ordenes_compra_proveedor");

            entity.HasIndex(e => e.Numero, "ordenes_compra_numero_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Borrador'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaEmision).HasColumnName("fecha_emision");
            entity.Property(e => e.FechaEntregaEstimada).HasColumnName("fecha_entrega_estimada");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Igv)
                .HasPrecision(12, 2)
                .HasColumnName("igv");
            entity.Property(e => e.Numero)
                .HasMaxLength(30)
                .HasColumnName("numero");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasPrecision(12, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.Empleado).WithMany(p => p.OrdenesCompras)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ordenes_compra_empleado_id_fkey");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.OrdenesCompras)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ordenes_compra_proveedor_id_fkey");
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

        modelBuilder.Entity<ParametrosSistema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("parametros_sistema_pkey");

            entity.ToTable("parametros_sistema");

            entity.HasIndex(e => e.Clave, "parametros_sistema_clave_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clave)
                .HasMaxLength(60)
                .HasColumnName("clave");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Editable)
                .HasDefaultValue(true)
                .HasColumnName("editable");
            entity.Property(e => e.TipoDato)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Texto'::character varying")
                .HasColumnName("tipo_dato");
            entity.Property(e => e.Valor)
                .HasMaxLength(255)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pedidos_pkey");

            entity.ToTable("pedidos");

            entity.HasIndex(e => e.ClienteId, "idx_pedidos_cliente");

            entity.HasIndex(e => e.Estado, "idx_pedidos_estado");

            entity.HasIndex(e => e.Numero, "pedidos_numero_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.CotizacionId).HasColumnName("cotizacion_id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaEntrega).HasColumnName("fecha_entrega");
            entity.Property(e => e.FechaPedido).HasColumnName("fecha_pedido");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Igv)
                .HasPrecision(12, 2)
                .HasColumnName("igv");
            entity.Property(e => e.Numero)
                .HasMaxLength(30)
                .HasColumnName("numero");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasPrecision(12, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("pedidos_cliente_id_fkey");

            entity.HasOne(d => d.Cotizacion).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.CotizacionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pedidos_cotizacion_id_fkey");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("pedidos_empleado_id_fkey");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permisos_pkey");

            entity.ToTable("permisos");

            entity.HasIndex(e => e.Codigo, "permisos_codigo_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(60)
                .HasComment("Identificador tecnico, por ejemplo vehiculos.crear")
                .HasColumnName("codigo");
            entity.Property(e => e.Modulo)
                .HasMaxLength(60)
                .HasColumnName("modulo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<PlanCuenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("plan_cuentas_pkey");

            entity.ToTable("plan_cuentas");

            entity.HasIndex(e => e.Codigo, "plan_cuentas_codigo_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AceptaMovimiento)
                .HasComment("Solo las cuentas de ultimo nivel reciben asientos")
                .HasColumnName("acepta_movimiento");
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .HasColumnName("codigo");
            entity.Property(e => e.CuentaPadreId).HasColumnName("cuenta_padre_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activa'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Nivel)
                .HasDefaultValue((short)1)
                .HasColumnName("nivel");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoCuenta)
                .HasMaxLength(20)
                .HasColumnName("tipo_cuenta");

            entity.HasOne(d => d.CuentaPadre).WithMany(p => p.InverseCuentaPadre)
                .HasForeignKey(d => d.CuentaPadreId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("plan_cuentas_cuenta_padre_id_fkey");
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

        modelBuilder.Entity<Planilla>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("planillas_pkey");

            entity.ToTable("planillas");

            entity.HasIndex(e => new { e.Anio, e.Mes }, "idx_planillas_periodo");

            entity.HasIndex(e => new { e.EmpleadoId, e.Anio, e.Mes }, "uq_planillas_empleado_periodo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Bonificaciones)
                .HasPrecision(10, 2)
                .HasColumnName("bonificaciones");
            entity.Property(e => e.Descuentos)
                .HasPrecision(10, 2)
                .HasColumnName("descuentos");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Calculada'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaPago).HasColumnName("fecha_pago");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Mes).HasColumnName("mes");
            entity.Property(e => e.NetoPagar)
                .HasPrecision(10, 2)
                .HasColumnName("neto_pagar");
            entity.Property(e => e.SueldoBasico)
                .HasPrecision(10, 2)
                .HasColumnName("sueldo_basico");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Planillas)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("planillas_empleado_id_fkey");
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

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productos_pkey");

            entity.ToTable("productos");

            entity.HasIndex(e => e.CategoriaProductoId, "idx_productos_categoria");

            entity.HasIndex(e => e.Codigo, "productos_codigo_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoriaProductoId).HasColumnName("categoria_producto_id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(40)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioCompra)
                .HasPrecision(10, 2)
                .HasColumnName("precio_compra");
            entity.Property(e => e.PrecioVenta)
                .HasPrecision(10, 2)
                .HasColumnName("precio_venta");
            entity.Property(e => e.StockMinimo).HasColumnName("stock_minimo");
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Unidad'::character varying")
                .HasColumnName("unidad_medida");

            entity.HasOne(d => d.CategoriaProducto).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos_categoria_producto_id_fkey");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proveedores_pkey");

            entity.ToTable("proveedores");

            entity.HasIndex(e => e.Ruc, "proveedores_ruc_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CondicionPago)
                .HasMaxLength(30)
                .HasDefaultValueSql("'Contado'::character varying")
                .HasColumnName("condicion_pago");
            entity.Property(e => e.ContactoNombre)
                .HasMaxLength(120)
                .HasColumnName("contacto_nombre");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
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

        modelBuilder.Entity<Recepcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recepciones_pkey");

            entity.ToTable("recepciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlmacenId).HasColumnName("almacen_id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Parcial'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRecepcion).HasColumnName("fecha_recepcion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.NumeroGuia)
                .HasMaxLength(40)
                .HasColumnName("numero_guia");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.OrdenCompraId).HasColumnName("orden_compra_id");

            entity.HasOne(d => d.Almacen).WithMany(p => p.Recepciones)
                .HasForeignKey(d => d.AlmacenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recepciones_almacen_id_fkey");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Recepciones)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("recepciones_empleado_id_fkey");

            entity.HasOne(d => d.OrdenCompra).WithMany(p => p.Recepciones)
                .HasForeignKey(d => d.OrdenCompraId)
                .HasConstraintName("recepciones_orden_compra_id_fkey");
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

        modelBuilder.Entity<RolPermiso>(entity =>
        {
            entity.HasKey(e => new { e.RolId, e.PermisoId }).HasName("pk_rol_permiso");

            entity.ToTable("rol_permiso");

            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.PermisoId).HasColumnName("permiso_id");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("Momento en que se otorgo el permiso al rol")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_asignacion");

            entity.HasOne(d => d.Permiso).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.PermisoId)
                .HasConstraintName("rol_permiso_permiso_id_fkey");

            entity.HasOne(d => d.Rol).WithMany(p => p.RolPermisos)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("rol_permiso_rol_id_fkey");
        });

        modelBuilder.Entity<RolesSistema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_sistema_pkey");

            entity.ToTable("roles_sistema");

            entity.HasIndex(e => e.Nombre, "roles_sistema_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<SolicitudesAusencium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("solicitudes_ausencia_pkey");

            entity.ToTable("solicitudes_ausencia");

            entity.HasIndex(e => e.EmpleadoId, "idx_ausencias_empleado");

            entity.HasIndex(e => e.Estado, "idx_ausencias_estado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AprobadoPor).HasColumnName("aprobado_por");
            entity.Property(e => e.Dias).HasColumnName("dias");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaRespuesta)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_respuesta");
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_solicitud");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .HasColumnName("motivo");
            entity.Property(e => e.TipoAusenciaId).HasColumnName("tipo_ausencia_id");

            entity.HasOne(d => d.AprobadoPorNavigation).WithMany(p => p.SolicitudesAusenciumAprobadoPorNavigations)
                .HasForeignKey(d => d.AprobadoPor)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("solicitudes_ausencia_aprobado_por_fkey");

            entity.HasOne(d => d.Empleado).WithMany(p => p.SolicitudesAusenciumEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("solicitudes_ausencia_empleado_id_fkey");

            entity.HasOne(d => d.TipoAusencia).WithMany(p => p.SolicitudesAusencia)
                .HasForeignKey(d => d.TipoAusenciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solicitudes_ausencia_tipo_ausencia_id_fkey");
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

        modelBuilder.Entity<TiposAusencium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipos_ausencia_pkey");

            entity.ToTable("tipos_ausencia");

            entity.HasIndex(e => e.Nombre, "tipos_ausencia_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiasMaximos).HasColumnName("dias_maximos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
            entity.Property(e => e.Remunerada)
                .HasDefaultValue(true)
                .HasColumnName("remunerada");
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

        modelBuilder.Entity<TiposMovimientoInventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipos_movimiento_inventario_pkey");

            entity.ToTable("tipos_movimiento_inventario");

            entity.HasIndex(e => e.Nombre, "tipos_movimiento_inventario_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasColumnName("nombre");
            entity.Property(e => e.Signo)
                .HasComment("1 suma stock, -1 resta, 0 traslado entre almacenes")
                .HasColumnName("signo");
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

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioSistemaId, e.RolId }).HasName("pk_usuario_rol");

            entity.ToTable("usuario_rol");

            entity.Property(e => e.UsuarioSistemaId).HasColumnName("usuario_sistema_id");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_asignacion");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("usuario_rol_rol_id_fkey");

            entity.HasOne(d => d.UsuarioSistema).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.UsuarioSistemaId)
                .HasConstraintName("usuario_rol_usuario_sistema_id_fkey");
        });

        modelBuilder.Entity<UsuariosSistema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_sistema_pkey");

            entity.ToTable("usuarios_sistema", tb => tb.HasComment("Personal que accede al ERP; distinto de usuarios (conductores de ChillDrive)"));

            entity.HasIndex(e => e.EmpleadoId, "usuarios_sistema_empleado_id_key").IsUnique();

            entity.HasIndex(e => e.Username, "usuarios_sistema_username_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.UltimoAcceso)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ultimo_acceso");
            entity.Property(e => e.Username)
                .HasMaxLength(60)
                .HasColumnName("username");

            entity.HasOne(d => d.Empleado).WithOne(p => p.UsuariosSistema)
                .HasForeignKey<UsuariosSistema>(d => d.EmpleadoId)
                .HasConstraintName("usuarios_sistema_empleado_id_fkey");
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
