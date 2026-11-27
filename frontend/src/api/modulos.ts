export type TipoCampo = "texto" | "numero" | "booleano" | "fecha" | "fechahora";

export interface Campo {
  nombre: string;
  tipo: TipoCampo;
  opcional: boolean;
}

export interface Modulo {
  clave: string;
  titulo: string;
  area: string;
  endpoint: string;
  soloLectura: boolean;
  llaveCompuesta: boolean;
  camposCrear: Campo[];
  camposEditar: Campo[];
}

export const MODULOS: Modulo[] = [
  {
    "clave": "Usuarios",
    "titulo": "Usuarios",
    "area": "ChillDrive",
    "endpoint": "/api/Usuarios",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombres",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "apellidos",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "correo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "password",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "planId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipoConductorId",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombres",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "apellidos",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "fotoPerfil",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "planId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipoConductorId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Vehiculos",
    "titulo": "Vehiculos",
    "area": "ChillDrive",
    "endpoint": "/api/Vehiculos",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "usuarioId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "flotaId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "placa",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "marca",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "modelo",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "anio",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "color",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "tipoVehiculoId",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "usuarioId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "flotaId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "placa",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "marca",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "modelo",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "anio",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "color",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "tipoVehiculoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Viajes",
    "titulo": "Viajes",
    "area": "ChillDrive",
    "endpoint": "/api/Viajes",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "usuarioId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "vehiculoId",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "distanciaKm",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "duracionMinutos",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "puntajeConduccion",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "puntosGanados",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Eventos",
    "titulo": "Eventos",
    "area": "ChillDrive",
    "endpoint": "/api/Eventos",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "viajeId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "camaraId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipoEventoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "impactoPuntaje",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "latitud",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "longitud",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "fotoEvidencia",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "clienteEventoId",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "viajeId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "tipoEventoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "impactoPuntaje",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "latitud",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "longitud",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "fotoEvidencia",
        "tipo": "texto",
        "opcional": true
      }
    ]
  },
  {
    "clave": "Camaras",
    "titulo": "Camaras",
    "area": "ChillDrive",
    "endpoint": "/api/Camaras",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "vehiculoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "direccionIp",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "posicionId",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "direccionIp",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "posicionId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Suscripciones",
    "titulo": "Suscripciones",
    "area": "ChillDrive",
    "endpoint": "/api/Suscripciones",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "usuarioId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "empresaId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "fechaInicio",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaFin",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "montoSoles",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "metodoPagoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "referenciaPago",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "renovacionAutomatica",
        "tipo": "booleano",
        "opcional": false
      },
      {
        "nombre": "cantidadLicencias",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "fechaInicio",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaFin",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "montoSoles",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "metodoPagoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "referenciaPago",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "renovacionAutomatica",
        "tipo": "booleano",
        "opcional": false
      },
      {
        "nombre": "cantidadLicencias",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Planes",
    "titulo": "Planes",
    "area": "ChillDrive",
    "endpoint": "/api/Planes",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "precioSoles",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "precioSoles",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      }
    ]
  },
  {
    "clave": "TiposConductor",
    "titulo": "Tipos de conductor",
    "area": "ChillDrive",
    "endpoint": "/api/TiposConductor",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "TiposVehiculo",
    "titulo": "Tipos de vehiculo",
    "area": "ChillDrive",
    "endpoint": "/api/TiposVehiculo",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "factorEmisionGKm",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "factorEmisionGKm",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "PosicionesCamara",
    "titulo": "Posiciones de camara",
    "area": "ChillDrive",
    "endpoint": "/api/PosicionesCamara",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "TiposEvento",
    "titulo": "Tipos de evento",
    "area": "ChillDrive",
    "endpoint": "/api/TiposEvento",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "impactoPuntajeDefault",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "impactoPuntajeDefault",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Niveles",
    "titulo": "Niveles",
    "area": "ChillDrive",
    "endpoint": "/api/Niveles",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "puntosMinimos",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "puntosMinimos",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "PuntosUsuarios",
    "titulo": "Puntos por usuario",
    "area": "ChillDrive",
    "endpoint": "/api/PuntosUsuarios",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "usuarioId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "nivelId",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "usuarioId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "puntosActuales",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "puntosHistoricos",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "nivelId",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "MovimientosPuntos",
    "titulo": "Movimientos de puntos",
    "area": "ChillDrive",
    "endpoint": "/api/MovimientosPuntos",
    "soloLectura": true,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "usuarioId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "puntos",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "viajeId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "canjeId",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": []
  },
  {
    "clave": "Premios",
    "titulo": "Premios",
    "area": "ChillDrive",
    "endpoint": "/api/Premios",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "aliadoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "puntosRequeridos",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "stock",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "fechaInicio",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "fechaFin",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "imagen",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "puntosRequeridos",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "stock",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "fechaInicio",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "fechaFin",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "imagen",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Canjes",
    "titulo": "Canjes",
    "area": "ChillDrive",
    "endpoint": "/api/Canjes",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "usuarioId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "premioId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "puntosUtilizados",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Aliados",
    "titulo": "Aliados",
    "area": "ChillDrive",
    "endpoint": "/api/Aliados",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "ruc",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "categoriaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "direccion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "distrito",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "email",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "logo",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "comisionPorcentaje",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "ruc",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "categoriaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "direccion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "distrito",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "email",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "logo",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "comisionPorcentaje",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "CategoriasAliado",
    "titulo": "Categorias de aliado",
    "area": "ChillDrive",
    "endpoint": "/api/CategoriasAliado",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Notificaciones",
    "titulo": "Notificaciones",
    "area": "ChillDrive",
    "endpoint": "/api/Notificaciones",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "usuarioId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipoNotificacionId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "titulo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "mensaje",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "leida",
        "tipo": "booleano",
        "opcional": false
      }
    ]
  },
  {
    "clave": "TiposNotificacion",
    "titulo": "Tipos de notificacion",
    "area": "ChillDrive",
    "endpoint": "/api/TiposNotificacion",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "canal",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "canal",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Geocercas",
    "titulo": "Geocercas",
    "area": "ChillDrive",
    "endpoint": "/api/Geocercas",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "empresaId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "latitud",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "longitud",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "radioMetros",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipo",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "latitud",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "longitud",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "radioMetros",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Paradas",
    "titulo": "Paradas",
    "area": "ChillDrive",
    "endpoint": "/api/Paradas",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "viajeId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "geocercaId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "latitud",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "longitud",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "geocercaId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "latitud",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "longitud",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "horaFin",
        "tipo": "fechahora",
        "opcional": true
      },
      {
        "nombre": "duracionMinutos",
        "tipo": "numero",
        "opcional": true
      }
    ]
  },
  {
    "clave": "ZonasRiesgo",
    "titulo": "Zonas de riesgo",
    "area": "ChillDrive",
    "endpoint": "/api/ZonasRiesgo",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "latitud",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "longitud",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "radioMetros",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "nivelRiesgo",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "latitud",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "longitud",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "radioMetros",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "nivelRiesgo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "incidentesRegistrados",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "EmisionesViaje",
    "titulo": "Emisiones por viaje",
    "area": "ChillDrive",
    "endpoint": "/api/EmisionesViaje",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "viajeId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "co2Kg",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "combustibleLitros",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "ahorroEstimadoKg",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "co2Kg",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "combustibleLitros",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "ahorroEstimadoKg",
        "tipo": "numero",
        "opcional": true
      }
    ]
  },
  {
    "clave": "ReglasScoring",
    "titulo": "Reglas de scoring",
    "area": "ChillDrive",
    "endpoint": "/api/ReglasScoring",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "empresaId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "tipoEventoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "impactoPuntaje",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "peso",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "activa",
        "tipo": "booleano",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "tipoEventoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "impactoPuntaje",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "peso",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "activa",
        "tipo": "booleano",
        "opcional": false
      }
    ]
  },
  {
    "clave": "AlertasRiesgo",
    "titulo": "Alertas de riesgo",
    "area": "ChillDrive",
    "endpoint": "/api/AlertasRiesgo",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "usuarioId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "vehiculoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "viajeId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "motivo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "severidad",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "motivo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "severidad",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "ModelosIa",
    "titulo": "Modelos de IA",
    "area": "ChillDrive",
    "endpoint": "/api/ModelosIa",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "version",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "arquitectura",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "precisionPromedio",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "fechaEntrenamiento",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "activo",
        "tipo": "booleano",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "version",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "arquitectura",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "precisionPromedio",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "fechaEntrenamiento",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "activo",
        "tipo": "booleano",
        "opcional": false
      }
    ]
  },
  {
    "clave": "UmbralesDeteccion",
    "titulo": "Umbrales de deteccion",
    "area": "ChillDrive",
    "endpoint": "/api/UmbralesDeteccion",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "modeloIaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipoEventoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "confianzaMinima",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "tipoEventoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "confianzaMinima",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "MetodosPago",
    "titulo": "Metodos pago",
    "area": "ChillDrive",
    "endpoint": "/api/MetodosPago",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Pagos",
    "titulo": "Pagos",
    "area": "ChillDrive",
    "endpoint": "/api/Pagos",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "suscripcionId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "metodoPagoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "montoSoles",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "referencia",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "metodoPagoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "montoSoles",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "referencia",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Empresas",
    "titulo": "Empresas",
    "area": "Flotas y seguros",
    "endpoint": "/api/Empresas",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "razonSocial",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "ruc",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "direccion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "distrito",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "email",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "contactoNombre",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "razonSocial",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "ruc",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "direccion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "distrito",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "email",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "contactoNombre",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Flotas",
    "titulo": "Flotas",
    "area": "Flotas y seguros",
    "endpoint": "/api/Flotas",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "empresaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "AsignacionesVehiculo",
    "titulo": "Asignaciones de vehiculo",
    "area": "Flotas y seguros",
    "endpoint": "/api/AsignacionesVehiculo",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "vehiculoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "usuarioId",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Mantenimientos",
    "titulo": "Mantenimientos",
    "area": "Flotas y seguros",
    "endpoint": "/api/Mantenimientos",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "vehiculoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipoMantenimientoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "fechaProgramada",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "kilometraje",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "taller",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "observaciones",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "tipoMantenimientoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "fechaProgramada",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "kilometraje",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "costoSoles",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "taller",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "observaciones",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "TiposMantenimiento",
    "titulo": "Tipos de mantenimiento",
    "area": "Flotas y seguros",
    "endpoint": "/api/TiposMantenimiento",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "kmSugerido",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "kmSugerido",
        "tipo": "numero",
        "opcional": true
      }
    ]
  },
  {
    "clave": "DocumentosVehiculo",
    "titulo": "Documentos de vehiculo",
    "area": "Flotas y seguros",
    "endpoint": "/api/DocumentosVehiculo",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "vehiculoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipoDocumentoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "numero",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "fechaEmision",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "fechaVencimiento",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "archivo",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "tipoDocumentoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "numero",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "fechaEmision",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "fechaVencimiento",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "archivo",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "TiposDocumento",
    "titulo": "Tipos de documento",
    "area": "Flotas y seguros",
    "endpoint": "/api/TiposDocumento",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "diasAlertaPrevia",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "diasAlertaPrevia",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Aseguradoras",
    "titulo": "Aseguradoras",
    "area": "Flotas y seguros",
    "endpoint": "/api/Aseguradoras",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "ruc",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "contactoNombre",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "email",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "ruc",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "contactoNombre",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "email",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Polizas",
    "titulo": "Polizas",
    "area": "Flotas y seguros",
    "endpoint": "/api/Polizas",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "aseguradoraId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "vehiculoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "numero",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "fechaInicio",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaFin",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "primaSoles",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "cobertura",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "numero",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "fechaInicio",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaFin",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "primaSoles",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "cobertura",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "DescuentosPoliza",
    "titulo": "Descuentos de poliza",
    "area": "Flotas y seguros",
    "endpoint": "/api/DescuentosPoliza",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "polizaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "periodoInicio",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "periodoFin",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "puntajePromedio",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "porcentajeDescuento",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "montoDescontado",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "puntajePromedio",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "porcentajeDescuento",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "montoDescontado",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Areas",
    "titulo": "Areas",
    "area": "Recursos Humanos",
    "endpoint": "/api/Areas",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "areaPadreId",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "areaPadreId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Cargos",
    "titulo": "Cargos",
    "area": "Recursos Humanos",
    "endpoint": "/api/Cargos",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "nivel",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "nivel",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Empleados",
    "titulo": "Empleados",
    "area": "Recursos Humanos",
    "endpoint": "/api/Empleados",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombres",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "apellidos",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "dni",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "email",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "areaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "cargoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "jefeId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "fechaIngreso",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "sueldoBasico",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombres",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "apellidos",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "email",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "areaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "cargoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "jefeId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "sueldoBasico",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Asistencias",
    "titulo": "Asistencias",
    "area": "Recursos Humanos",
    "endpoint": "/api/Asistencias",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "fecha",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "horaEntrada",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "horaSalida",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "observacion",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "horaEntrada",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "horaSalida",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "observacion",
        "tipo": "texto",
        "opcional": true
      }
    ]
  },
  {
    "clave": "TiposAusencia",
    "titulo": "Tipos de ausencia",
    "area": "Recursos Humanos",
    "endpoint": "/api/TiposAusencia",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "remunerada",
        "tipo": "booleano",
        "opcional": false
      },
      {
        "nombre": "diasMaximos",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "remunerada",
        "tipo": "booleano",
        "opcional": false
      },
      {
        "nombre": "diasMaximos",
        "tipo": "numero",
        "opcional": true
      }
    ]
  },
  {
    "clave": "SolicitudesAusencia",
    "titulo": "Solicitudes de ausencia",
    "area": "Recursos Humanos",
    "endpoint": "/api/SolicitudesAusencia",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipoAusenciaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "fechaInicio",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaFin",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "dias",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "motivo",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "aprobadoPor",
        "tipo": "numero",
        "opcional": true
      }
    ]
  },
  {
    "clave": "Planillas",
    "titulo": "Planillas",
    "area": "Recursos Humanos",
    "endpoint": "/api/Planillas",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "anio",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "mes",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "sueldoBasico",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "bonificaciones",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "descuentos",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "sueldoBasico",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "bonificaciones",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "descuentos",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Almacenes",
    "titulo": "Almacenes",
    "area": "Logistica",
    "endpoint": "/api/Almacenes",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "direccion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "responsableEmpleadoId",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "direccion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "responsableEmpleadoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "CategoriasProducto",
    "titulo": "Categorias de producto",
    "area": "Logistica",
    "endpoint": "/api/CategoriasProducto",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Productos",
    "titulo": "Productos",
    "area": "Logistica",
    "endpoint": "/api/Productos",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "codigo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "categoriaProductoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "unidadMedida",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "precioCompra",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "precioVenta",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "stockMinimo",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "codigo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "categoriaProductoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "unidadMedida",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "precioCompra",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "precioVenta",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "stockMinimo",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Inventarios",
    "titulo": "Inventarios",
    "area": "Logistica",
    "endpoint": "/api/Inventarios",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "productoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "almacenId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "cantidad",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "ubicacion",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "cantidad",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "ubicacion",
        "tipo": "texto",
        "opcional": true
      }
    ]
  },
  {
    "clave": "TiposMovimientoInventario",
    "titulo": "Tipos de movimiento",
    "area": "Logistica",
    "endpoint": "/api/TiposMovimientoInventario",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "signo",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "signo",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "MovimientosInventario",
    "titulo": "Kardex",
    "area": "Logistica",
    "endpoint": "/api/MovimientosInventario",
    "soloLectura": true,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "productoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipoMovimientoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "almacenOrigenId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "almacenDestinoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "cantidad",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "costoUnitario",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "documentoReferencia",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "observacion",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": []
  },
  {
    "clave": "Proveedores",
    "titulo": "Proveedores",
    "area": "Compras",
    "endpoint": "/api/Proveedores",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "razonSocial",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "ruc",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "contactoNombre",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "email",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "direccion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "condicionPago",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "razonSocial",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "ruc",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "contactoNombre",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "email",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "direccion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "condicionPago",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "OrdenesCompra",
    "titulo": "Ordenes de compra",
    "area": "Compras",
    "endpoint": "/api/OrdenesCompra",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "proveedorId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "numero",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "fechaEmision",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaEntregaEstimada",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "subtotal",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "observaciones",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "fechaEmision",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaEntregaEstimada",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "subtotal",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "observaciones",
        "tipo": "texto",
        "opcional": true
      }
    ]
  },
  {
    "clave": "DetalleOrdenCompra",
    "titulo": "Detalle de orden",
    "area": "Compras",
    "endpoint": "/api/DetalleOrdenCompra",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "ordenCompraId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "productoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "cantidad",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "precioUnitario",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "cantidad",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "precioUnitario",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Recepciones",
    "titulo": "Recepciones",
    "area": "Compras",
    "endpoint": "/api/Recepciones",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "ordenCompraId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "almacenId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "numeroGuia",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "fechaRecepcion",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "observaciones",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "numeroGuia",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "fechaRecepcion",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "observaciones",
        "tipo": "texto",
        "opcional": true
      }
    ]
  },
  {
    "clave": "CuentasPorPagar",
    "titulo": "Cuentas por pagar",
    "area": "Compras",
    "endpoint": "/api/CuentasPorPagar",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "proveedorId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "ordenCompraId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "numeroDocumento",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "fechaEmision",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "monto",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "montoAbonado",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Clientes",
    "titulo": "Clientes",
    "area": "Ventas",
    "endpoint": "/api/Clientes",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "razonSocial",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "tipoDocumento",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "numeroDocumento",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "empresaId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "usuarioId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "direccion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "email",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "condicionPago",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "lineaCredito",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "vendedorId",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "razonSocial",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "tipoDocumento",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "numeroDocumento",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "direccion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "telefono",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "email",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "condicionPago",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "lineaCredito",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "vendedorId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Cotizaciones",
    "titulo": "Cotizaciones",
    "area": "Ventas",
    "endpoint": "/api/Cotizaciones",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "clienteId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "numero",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "fechaEmision",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaValidez",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "subtotal",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "observaciones",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "fechaEmision",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaValidez",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "subtotal",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "observaciones",
        "tipo": "texto",
        "opcional": true
      }
    ]
  },
  {
    "clave": "DetalleCotizacion",
    "titulo": "Detalle de cotizacion",
    "area": "Ventas",
    "endpoint": "/api/DetalleCotizacion",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "cotizacionId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "productoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "cantidad",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "precioUnitario",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "cantidad",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "precioUnitario",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Pedidos",
    "titulo": "Pedidos",
    "area": "Ventas",
    "endpoint": "/api/Pedidos",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "clienteId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "cotizacionId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "numero",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "fechaPedido",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaEntrega",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "subtotal",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "fechaPedido",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaEntrega",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "subtotal",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "DetallePedido",
    "titulo": "Detalle de pedido",
    "area": "Ventas",
    "endpoint": "/api/DetallePedido",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "pedidoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "productoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "cantidad",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "precioUnitario",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "cantidad",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "precioUnitario",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Facturas",
    "titulo": "Facturas",
    "area": "Ventas",
    "endpoint": "/api/Facturas",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "clienteId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "pedidoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "serie",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "numero",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "tipoComprobante",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "fechaEmision",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "subtotal",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "subtotal",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "DetalleFactura",
    "titulo": "Detalle de factura",
    "area": "Ventas",
    "endpoint": "/api/DetalleFactura",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "facturaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "productoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "cantidad",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "precioUnitario",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "cantidad",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "precioUnitario",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "CuentasPorCobrar",
    "titulo": "Cuentas por cobrar",
    "area": "Ventas",
    "endpoint": "/api/CuentasPorCobrar",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "clienteId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "facturaId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "fechaEmision",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "monto",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "montoCobrado",
        "tipo": "numero",
        "opcional": false
      }
    ]
  },
  {
    "clave": "PlanCuentas",
    "titulo": "Plan de cuentas",
    "area": "Contabilidad",
    "endpoint": "/api/PlanCuentas",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "codigo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "tipoCuenta",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "cuentaPadreId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "nivel",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "aceptaMovimiento",
        "tipo": "booleano",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "codigo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "tipoCuenta",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "cuentaPadreId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "nivel",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "aceptaMovimiento",
        "tipo": "booleano",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "AsientosContables",
    "titulo": "Asientos contables",
    "area": "Contabilidad",
    "endpoint": "/api/AsientosContables",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "numero",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "fecha",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "glosa",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "tipoAsiento",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "fecha",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "glosa",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "tipoAsiento",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "DetalleAsiento",
    "titulo": "Detalle de asiento",
    "area": "Contabilidad",
    "endpoint": "/api/DetalleAsiento",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "asientoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "cuentaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "debe",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "haber",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "glosa",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "cuentaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "debe",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "haber",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "glosa",
        "tipo": "texto",
        "opcional": true
      }
    ]
  },
  {
    "clave": "Cajas",
    "titulo": "Cajas",
    "area": "Finanzas",
    "endpoint": "/api/Cajas",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "responsableEmpleadoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "saldoInicial",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "responsableEmpleadoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "MovimientosCaja",
    "titulo": "Movimientos de caja",
    "area": "Finanzas",
    "endpoint": "/api/MovimientosCaja",
    "soloLectura": true,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "cajaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "concepto",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "monto",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "documentoReferencia",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": []
  },
  {
    "clave": "CuentasBancarias",
    "titulo": "Cuentas bancarias",
    "area": "Finanzas",
    "endpoint": "/api/CuentasBancarias",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "banco",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "numeroCuenta",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "cci",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "tipoCuenta",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "moneda",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "saldo",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "banco",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "numeroCuenta",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "cci",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "tipoCuenta",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "moneda",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "MovimientosBancarios",
    "titulo": "Movimientos bancarios",
    "area": "Finanzas",
    "endpoint": "/api/MovimientosBancarios",
    "soloLectura": true,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "cuentaBancariaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tipo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "concepto",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "monto",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "referencia",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": []
  },
  {
    "clave": "TiposProyecto",
    "titulo": "Tipos de proyecto",
    "area": "Proyectos",
    "endpoint": "/api/TiposProyecto",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "modalidad",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "modalidad",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "ContratosDesarrollo",
    "titulo": "Contratos",
    "area": "Proyectos",
    "endpoint": "/api/ContratosDesarrollo",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "numero",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "clienteId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "fechaInicio",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaFin",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "montoTotal",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "moneda",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "condicionPago",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "fechaFin",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "montoTotal",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "condicionPago",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Proyectos",
    "titulo": "Proyectos",
    "area": "Proyectos",
    "endpoint": "/api/Proyectos",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "codigo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "tipoProyectoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "contratoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "productoSoftwareId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "jefeProyectoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "fechaInicio",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaFinEstimada",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "presupuesto",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "horasEstimadas",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "jefeProyectoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "fechaFinEstimada",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "presupuesto",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "horasEstimadas",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "HitosProyecto",
    "titulo": "Hitos",
    "area": "Proyectos",
    "endpoint": "/api/HitosProyecto",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "proyectoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "fechaObjetivo",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "monto",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "fechaObjetivo",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "monto",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "EquiposProyecto",
    "titulo": "Equipos de proyecto",
    "area": "Proyectos",
    "endpoint": "/api/EquiposProyecto",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "proyectoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "rol",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "dedicacionPorcentaje",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "rol",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "dedicacionPorcentaje",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "fechaSalida",
        "tipo": "fecha",
        "opcional": true
      }
    ]
  },
  {
    "clave": "TarifasHora",
    "titulo": "Tarifas por hora",
    "area": "Proyectos",
    "endpoint": "/api/TarifasHora",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "cargoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "proyectoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "tarifa",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "moneda",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "vigenteDesde",
        "tipo": "fecha",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "tarifa",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "vigenteDesde",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "vigenteHasta",
        "tipo": "fecha",
        "opcional": true
      }
    ]
  },
  {
    "clave": "Sprints",
    "titulo": "Sprints",
    "area": "Proyectos",
    "endpoint": "/api/Sprints",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "proyectoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "numero",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "objetivo",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "fechaInicio",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaFin",
        "tipo": "fecha",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "objetivo",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "fechaInicio",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "fechaFin",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "HistoriasUsuario",
    "titulo": "Historias de usuario",
    "area": "Proyectos",
    "endpoint": "/api/HistoriasUsuario",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "proyectoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "sprintId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "codigo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "titulo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "criteriosAceptacion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "puntosHistoria",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "prioridad",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "titulo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "criteriosAceptacion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "puntosHistoria",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "prioridad",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Tareas",
    "titulo": "Tareas",
    "area": "Proyectos",
    "endpoint": "/api/Tareas",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "historiaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "titulo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "horasEstimadas",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "titulo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "horasEstimadas",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "RegistrosHoras",
    "titulo": "Parte de horas",
    "area": "Proyectos",
    "endpoint": "/api/RegistrosHoras",
    "soloLectura": true,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "proyectoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "tareaId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "fecha",
        "tipo": "fecha",
        "opcional": false
      },
      {
        "nombre": "horas",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "facturable",
        "tipo": "booleano",
        "opcional": false
      }
    ],
    "camposEditar": []
  },
  {
    "clave": "CasosPrueba",
    "titulo": "Casos de prueba",
    "area": "Calidad y despliegue",
    "endpoint": "/api/CasosPrueba",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "historiaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "codigo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "titulo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "precondiciones",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "pasos",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "resultadoEsperado",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "tipo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "automatizado",
        "tipo": "booleano",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "titulo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "precondiciones",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "pasos",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "resultadoEsperado",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "tipo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "automatizado",
        "tipo": "booleano",
        "opcional": false
      }
    ]
  },
  {
    "clave": "EjecucionesPrueba",
    "titulo": "Ejecuciones de prueba",
    "area": "Calidad y despliegue",
    "endpoint": "/api/EjecucionesPrueba",
    "soloLectura": true,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "casoPruebaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "versionId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "resultado",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "observaciones",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": []
  },
  {
    "clave": "Defectos",
    "titulo": "Defectos",
    "area": "Calidad y despliegue",
    "endpoint": "/api/Defectos",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "proyectoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "historiaId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "versionId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "codigo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "titulo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "pasosReproduccion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "severidad",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "reportadoPorId",
        "tipo": "numero",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "titulo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "pasosReproduccion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "severidad",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "asignadoAId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Ambientes",
    "titulo": "Ambientes",
    "area": "Calidad y despliegue",
    "endpoint": "/api/Ambientes",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "orden",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "esProductivo",
        "tipo": "booleano",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "orden",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "esProductivo",
        "tipo": "booleano",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Despliegues",
    "titulo": "Despliegues",
    "area": "Calidad y despliegue",
    "endpoint": "/api/Despliegues",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "versionId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "ambienteId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "responsableId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "observaciones",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": []
  },
  {
    "clave": "ProductosSoftware",
    "titulo": "Productos de software",
    "area": "Calidad y despliegue",
    "endpoint": "/api/ProductosSoftware",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "tipo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "fechaLanzamiento",
        "tipo": "fecha",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "tipo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "fechaLanzamiento",
        "tipo": "fecha",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "VersionesProducto",
    "titulo": "Versiones de producto",
    "area": "Calidad y despliegue",
    "endpoint": "/api/VersionesProducto",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "productoSoftwareId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "numero",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "notasVersion",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "numero",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "notasVersion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Repositorios",
    "titulo": "Repositorios",
    "area": "Calidad y despliegue",
    "endpoint": "/api/Repositorios",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "productoSoftwareId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "url",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "proveedor",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "ramaPrincipal",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "visibilidad",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "productoSoftwareId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "url",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "proveedor",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "ramaPrincipal",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "visibilidad",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "AcuerdosServicio",
    "titulo": "Acuerdos de servicio (SLA)",
    "area": "Soporte",
    "endpoint": "/api/AcuerdosServicio",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "contratoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "horasRespuestaCritica",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "horasRespuestaAlta",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "horasRespuestaNormal",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "horasResolucion",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "disponibilidadPorcentaje",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "vigenteDesde",
        "tipo": "fecha",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "horasRespuestaCritica",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "horasRespuestaAlta",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "horasRespuestaNormal",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "horasResolucion",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "disponibilidadPorcentaje",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "vigenteHasta",
        "tipo": "fecha",
        "opcional": true
      }
    ]
  },
  {
    "clave": "TiposTicket",
    "titulo": "Tipos de ticket",
    "area": "Soporte",
    "endpoint": "/api/TiposTicket",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "facturable",
        "tipo": "booleano",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "facturable",
        "tipo": "booleano",
        "opcional": false
      }
    ]
  },
  {
    "clave": "TicketsSoporte",
    "titulo": "Tickets de soporte",
    "area": "Soporte",
    "endpoint": "/api/TicketsSoporte",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "codigo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "clienteId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "productoSoftwareId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "tipoTicketId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "acuerdoServicioId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "asunto",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "severidad",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "asunto",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "tipoTicketId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "severidad",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "defectoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "SeguimientosTicket",
    "titulo": "Seguimientos de ticket",
    "area": "Soporte",
    "endpoint": "/api/SeguimientosTicket",
    "soloLectura": true,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "ticketId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "comentario",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "visibleCliente",
        "tipo": "booleano",
        "opcional": false
      },
      {
        "nombre": "horasInvertidas",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": []
  },
  {
    "clave": "UsuariosSistema",
    "titulo": "Usuarios del sistema",
    "area": "Seguridad",
    "endpoint": "/api/UsuariosSistema",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "empleadoId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "username",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "password",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "username",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "RolesSistema",
    "titulo": "Roles",
    "area": "Seguridad",
    "endpoint": "/api/RolesSistema",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": [
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "estado",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "Permisos",
    "titulo": "Permisos",
    "area": "Seguridad",
    "endpoint": "/api/Permisos",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "codigo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "modulo",
        "tipo": "texto",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "codigo",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "nombre",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "modulo",
        "tipo": "texto",
        "opcional": false
      }
    ]
  },
  {
    "clave": "RolPermiso",
    "titulo": "Permisos por rol",
    "area": "Seguridad",
    "endpoint": "/api/RolPermiso",
    "soloLectura": false,
    "llaveCompuesta": true,
    "camposCrear": [
      {
        "nombre": "rolId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "permisoId",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": []
  },
  {
    "clave": "UsuarioRol",
    "titulo": "Roles por usuario",
    "area": "Seguridad",
    "endpoint": "/api/UsuarioRol",
    "soloLectura": false,
    "llaveCompuesta": true,
    "camposCrear": [
      {
        "nombre": "usuarioSistemaId",
        "tipo": "numero",
        "opcional": false
      },
      {
        "nombre": "rolId",
        "tipo": "numero",
        "opcional": false
      }
    ],
    "camposEditar": []
  },
  {
    "clave": "Auditoria",
    "titulo": "Auditoria",
    "area": "Seguridad",
    "endpoint": "/api/Auditoria",
    "soloLectura": true,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "usuarioSistemaId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "accion",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "tablaAfectada",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "registroId",
        "tipo": "numero",
        "opcional": true
      },
      {
        "nombre": "datosAntes",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "datosDespues",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "direccionIp",
        "tipo": "texto",
        "opcional": true
      }
    ],
    "camposEditar": []
  },
  {
    "clave": "ParametrosSistema",
    "titulo": "Parametros",
    "area": "Seguridad",
    "endpoint": "/api/ParametrosSistema",
    "soloLectura": false,
    "llaveCompuesta": false,
    "camposCrear": [
      {
        "nombre": "clave",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "valor",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      },
      {
        "nombre": "tipoDato",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "editable",
        "tipo": "booleano",
        "opcional": false
      }
    ],
    "camposEditar": [
      {
        "nombre": "valor",
        "tipo": "texto",
        "opcional": false
      },
      {
        "nombre": "descripcion",
        "tipo": "texto",
        "opcional": true
      }
    ]
  }
];

export const AREAS: string[] = [...new Set(MODULOS.map((m) => m.area))];

export function modulosDeArea(area: string): Modulo[] {
  return MODULOS.filter((m) => m.area === area);
}

export function buscarModulo(clave: string): Modulo | undefined {
  return MODULOS.find((m) => m.clave === clave);
}
