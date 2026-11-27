import { MODULOS } from "./modulos";

export const RELACIONES: Record<string, Record<string, string>> = {
  "AcuerdosServicio": {
    "contratoId": "ContratosDesarrollo"
  },
  "AlertasRiesgo": {
    "usuarioId": "Usuarios",
    "vehiculoId": "Vehiculos",
    "viajeId": "Viajes"
  },
  "Aliados": {
    "categoriaId": "CategoriasAliado"
  },
  "Almacenes": {
    "responsableEmpleadoId": "Empleados"
  },
  "Areas": {
    "areaPadreId": "Areas"
  },
  "AsientosContables": {
    "empleadoId": "Empleados"
  },
  "AsignacionesVehiculo": {
    "usuarioId": "Usuarios",
    "vehiculoId": "Vehiculos"
  },
  "Asistencias": {
    "empleadoId": "Empleados"
  },
  "Auditoria": {
    "usuarioSistemaId": "UsuariosSistema"
  },
  "Cajas": {
    "responsableEmpleadoId": "Empleados"
  },
  "Camaras": {
    "posicionId": "PosicionesCamara",
    "vehiculoId": "Vehiculos"
  },
  "Canjes": {
    "premioId": "Premios",
    "usuarioId": "Usuarios"
  },
  "CasosPrueba": {
    "historiaId": "HistoriasUsuario"
  },
  "Clientes": {
    "empresaId": "Empresas",
    "usuarioId": "Usuarios",
    "vendedorId": "Empleados"
  },
  "ContratosDesarrollo": {
    "clienteId": "Clientes"
  },
  "Cotizaciones": {
    "clienteId": "Clientes",
    "empleadoId": "Empleados"
  },
  "CuentasPorCobrar": {
    "clienteId": "Clientes",
    "facturaId": "Facturas"
  },
  "CuentasPorPagar": {
    "ordenCompraId": "OrdenesCompra",
    "proveedorId": "Proveedores"
  },
  "Defectos": {
    "asignadoAId": "Empleados",
    "historiaId": "HistoriasUsuario",
    "proyectoId": "Proyectos",
    "reportadoPorId": "Empleados",
    "versionId": "VersionesProducto"
  },
  "DescuentosPoliza": {
    "polizaId": "Polizas"
  },
  "Despliegues": {
    "ambienteId": "Ambientes",
    "responsableId": "Empleados",
    "versionId": "VersionesProducto"
  },
  "DetalleAsiento": {
    "asientoId": "AsientosContables",
    "cuentaId": "PlanCuentas"
  },
  "DetalleCotizacion": {
    "cotizacionId": "Cotizaciones",
    "productoId": "Productos"
  },
  "DetalleFactura": {
    "facturaId": "Facturas",
    "productoId": "Productos"
  },
  "DetalleOrdenCompra": {
    "ordenCompraId": "OrdenesCompra",
    "productoId": "Productos"
  },
  "DetallePedido": {
    "pedidoId": "Pedidos",
    "productoId": "Productos"
  },
  "DocumentosVehiculo": {
    "tipoDocumentoId": "TiposDocumento",
    "vehiculoId": "Vehiculos"
  },
  "EjecucionesPrueba": {
    "casoPruebaId": "CasosPrueba",
    "empleadoId": "Empleados",
    "versionId": "VersionesProducto"
  },
  "EmisionesViaje": {
    "viajeId": "Viajes"
  },
  "Empleados": {
    "areaId": "Areas",
    "cargoId": "Cargos",
    "jefeId": "Empleados"
  },
  "EquiposProyecto": {
    "empleadoId": "Empleados",
    "proyectoId": "Proyectos"
  },
  "Eventos": {
    "camaraId": "Camaras",
    "tipoEventoId": "TiposEvento",
    "viajeId": "Viajes"
  },
  "Facturas": {
    "clienteId": "Clientes",
    "pedidoId": "Pedidos"
  },
  "Flotas": {
    "empresaId": "Empresas"
  },
  "Geocercas": {
    "empresaId": "Empresas"
  },
  "HistoriasUsuario": {
    "proyectoId": "Proyectos",
    "sprintId": "Sprints"
  },
  "HitosProyecto": {
    "proyectoId": "Proyectos"
  },
  "Mantenimientos": {
    "tipoMantenimientoId": "TiposMantenimiento",
    "vehiculoId": "Vehiculos"
  },
  "MovimientosBancarios": {
    "cuentaBancariaId": "CuentasBancarias"
  },
  "MovimientosCaja": {
    "cajaId": "Cajas",
    "empleadoId": "Empleados"
  },
  "MovimientosInventario": {
    "almacenDestinoId": "Almacenes",
    "almacenOrigenId": "Almacenes",
    "empleadoId": "Empleados",
    "productoId": "Productos",
    "tipoMovimientoId": "TiposMovimientoInventario"
  },
  "MovimientosPuntos": {
    "canjeId": "Canjes",
    "usuarioId": "Usuarios",
    "viajeId": "Viajes"
  },
  "Notificaciones": {
    "tipoNotificacionId": "TiposNotificacion",
    "usuarioId": "Usuarios"
  },
  "OrdenesCompra": {
    "empleadoId": "Empleados",
    "proveedorId": "Proveedores"
  },
  "Pagos": {
    "metodoPagoId": "MetodosPago",
    "suscripcionId": "Suscripciones"
  },
  "Paradas": {
    "geocercaId": "Geocercas",
    "viajeId": "Viajes"
  },
  "Pedidos": {
    "clienteId": "Clientes",
    "cotizacionId": "Cotizaciones",
    "empleadoId": "Empleados"
  },
  "PlanCuentas": {
    "cuentaPadreId": "PlanCuentas"
  },
  "Planillas": {
    "empleadoId": "Empleados"
  },
  "Polizas": {
    "aseguradoraId": "Aseguradoras",
    "vehiculoId": "Vehiculos"
  },
  "Premios": {
    "aliadoId": "Aliados"
  },
  "Productos": {
    "categoriaProductoId": "CategoriasProducto"
  },
  "Proyectos": {
    "contratoId": "ContratosDesarrollo",
    "jefeProyectoId": "Empleados",
    "productoSoftwareId": "ProductosSoftware",
    "tipoProyectoId": "TiposProyecto"
  },
  "Recepciones": {
    "almacenId": "Almacenes",
    "empleadoId": "Empleados",
    "ordenCompraId": "OrdenesCompra"
  },
  "RegistrosHoras": {
    "empleadoId": "Empleados",
    "proyectoId": "Proyectos",
    "tareaId": "Tareas"
  },
  "ReglasScoring": {
    "empresaId": "Empresas",
    "tipoEventoId": "TiposEvento"
  },
  "Repositorios": {
    "productoSoftwareId": "ProductosSoftware"
  },
  "RolPermiso": {
    "permisoId": "Permisos",
    "rolId": "RolesSistema"
  },
  "SeguimientosTicket": {
    "empleadoId": "Empleados",
    "ticketId": "TicketsSoporte"
  },
  "SolicitudesAusencia": {
    "aprobadoPor": "Empleados",
    "empleadoId": "Empleados",
    "tipoAusenciaId": "TiposAusencia"
  },
  "Sprints": {
    "proyectoId": "Proyectos"
  },
  "Suscripciones": {
    "metodoPagoId": "MetodosPago",
    "usuarioId": "Usuarios"
  },
  "Tareas": {
    "empleadoId": "Empleados",
    "historiaId": "HistoriasUsuario"
  },
  "TarifasHora": {
    "cargoId": "Cargos",
    "proyectoId": "Proyectos"
  },
  "TicketsSoporte": {
    "acuerdoServicioId": "AcuerdosServicio",
    "asignadoAId": "Empleados",
    "clienteId": "Clientes",
    "defectoId": "Defectos",
    "productoSoftwareId": "ProductosSoftware",
    "tipoTicketId": "TiposTicket"
  },
  "UmbralesDeteccion": {
    "modeloIaId": "ModelosIa",
    "tipoEventoId": "TiposEvento"
  },
  "UsuarioRol": {
    "rolId": "RolesSistema",
    "usuarioSistemaId": "UsuariosSistema"
  },
  "Usuarios": {
    "planId": "Planes",
    "tipoConductorId": "TiposConductor"
  },
  "UsuariosSistema": {
    "empleadoId": "Empleados"
  },
  "Vehiculos": {
    "tipoVehiculoId": "TiposVehiculo",
    "usuarioId": "Usuarios"
  },
  "VersionesProducto": {
    "productoSoftwareId": "ProductosSoftware"
  },
  "Viajes": {
    "usuarioId": "Usuarios",
    "vehiculoId": "Vehiculos"
  }
};

const CAMPOS_ETIQUETA = ["nombreCompleto", "razonSocial", "nombre", "titulo", "asunto", "username", "codigo", "numero", "descripcion", "placa", "correo", "clave", "glosa"];

export function moduloRelacionado(claveModulo: string, campo: string): string | undefined {
  return RELACIONES[claveModulo]?.[campo];
}

export function etiquetaDeRegistro(registro: Record<string, unknown>): string {
  for (const campo of CAMPOS_ETIQUETA) {
    const valor = registro[campo];
    if (typeof valor === "string" && valor.trim() !== "") return valor;
  }
  const nombres = registro["nombres"];
  const apellidos = registro["apellidos"];
  if (typeof nombres === "string") {
    return typeof apellidos === "string" ? `${nombres} ${apellidos}` : nombres;
  }
  return `#${registro["id"] ?? "?"}`;
}

const cache = new Map<string, Promise<Map<number, string>>>();

export function cargarCatalogo(
  claveModulo: string,
  traer: (ruta: string) => Promise<Record<string, unknown>[]>
): Promise<Map<number, string>> {
  const guardado = cache.get(claveModulo);
  if (guardado) return guardado;

  const modulo = MODULOS.find((m) => m.clave === claveModulo);
  if (!modulo) return Promise.resolve(new Map());

  const promesa = traer(modulo.endpoint)
    .then((filas) => {
      const mapa = new Map<number, string>();
      for (const fila of filas) {
        const id = fila["id"];
        if (typeof id === "number") mapa.set(id, etiquetaDeRegistro(fila));
      }
      return mapa;
    })
    .catch(() => new Map<number, string>());

  cache.set(claveModulo, promesa);
  return promesa;
}

export function limpiarCacheCatalogos() {
  cache.clear();
}
