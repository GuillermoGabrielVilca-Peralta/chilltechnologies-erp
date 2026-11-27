export interface PantallaEspecial {
  ruta: string;
  titulo: string;
  detalle: string;
}

export const ESPECIALES: PantallaEspecial[] = [
  { ruta: "sprint", titulo: "Tablero de sprint", detalle: "Historias por estado y puntos del sprint" },
  { ruta: "ficha-proyecto", titulo: "Ficha de proyecto", detalle: "Hitos, equipo, horas y avance" },
  { ruta: "kardex", titulo: "Kardex", detalle: "Movimientos y stock por almacen" },
  { ruta: "libro-caja", titulo: "Libro de caja", detalle: "Ingresos, egresos y saldo corriente" },
  { ruta: "asiento", titulo: "Asiento contable", detalle: "Partida doble y contabilizacion" },
  { ruta: "soporte", titulo: "Bandeja de soporte", detalle: "Tickets, SLA y bitacora" }
];
