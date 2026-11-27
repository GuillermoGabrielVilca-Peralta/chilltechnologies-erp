import { useEffect, useState } from "react";
import { api } from "../../api/cliente";
import { Aviso, Encabezado, Selector, soles } from "../../componentes/comunes";

interface Proyecto {
  id: number; codigo: string; nombre: string; descripcion: string | null;
  tipoProyectoId: number; contratoId: number | null; productoSoftwareId: number | null;
  jefeProyectoId: number | null; fechaInicio: string; fechaFinEstimada: string | null;
  fechaFinReal: string | null; presupuesto: number; horasEstimadas: number;
  avancePorcentaje: number; estado: string;
}
interface Hito { id: number; nombre: string; fechaObjetivo: string; fechaEntrega: string | null; monto: number; estado: string }
interface Equipo { id: number; empleadoId: number; rol: string; dedicacionPorcentaje: number; fechaSalida: string | null }
interface Empleado { id: number; nombres: string; apellidos: string }
interface Hora { id: number; empleadoId: number; horas: number; facturable: boolean; aprobado: boolean; fecha: string }

export function FichaProyecto() {
  const [proyectos, setProyectos] = useState<Proyecto[]>([]);
  const [proyectoId, setProyectoId] = useState<number | null>(null);
  const [hitos, setHitos] = useState<Hito[]>([]);
  const [equipo, setEquipo] = useState<Equipo[]>([]);
  const [empleados, setEmpleados] = useState<Empleado[]>([]);
  const [horas, setHoras] = useState<Hora[]>([]);
  const [facturables, setFacturables] = useState<number>(0);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    Promise.all([
      api.get<Proyecto[]>("/api/Proyectos"),
      api.get<Empleado[]>("/api/Empleados")
    ])
      .then(([p, e]) => {
        setProyectos(p);
        setEmpleados(e);
        if (p.length) setProyectoId(p[0].id);
      })
      .catch((err) => setError(err.message));
  }, []);

  async function cargarDetalle(id: number) {
    const [h, eq, hr, f] = await Promise.all([
      api.get<Hito[]>(`/api/HitosProyecto/proyecto/${id}`),
      api.get<Equipo[]>(`/api/EquiposProyecto/proyecto/${id}`),
      api.get<Hora[]>(`/api/RegistrosHoras/proyecto/${id}`),
      api.get<number>(`/api/RegistrosHoras/proyecto/${id}/facturables`)
    ]);
    setHitos(h);
    setEquipo(eq);
    setHoras(hr);
    setFacturables(f);
  }

  useEffect(() => {
    if (proyectoId === null) return;
    cargarDetalle(proyectoId).catch((e) => setError(e.message));
  }, [proyectoId]);

  const proyecto = proyectos.find((p) => p.id === proyectoId);
  const empleado = (id: number) => {
    const e = empleados.find((x) => x.id === id);
    return e ? `${e.nombres} ${e.apellidos}` : `#${id}`;
  };

  const aprobados = hitos.filter((h) => h.estado === "Aprobado").length;
  const avanceHitos = hitos.length > 0 ? Math.round((aprobados / hitos.length) * 100) : 0;
  const horasCargadas = horas.reduce((s, h) => s + h.horas, 0);
  const montoHitos = hitos.reduce((s, h) => s + h.monto, 0);

  async function aprobarHito(h: Hito) {
    if (proyectoId === null || !proyecto) return;
    setError(null);
    try {
      await api.put(`/api/HitosProyecto/${h.id}`, {
        nombre: h.nombre,
        fechaObjetivo: h.fechaObjetivo,
        monto: h.monto,
        estado: "Aprobado"
      });
      await api.put(`/api/Proyectos/${proyecto.id}`, {
        nombre: proyecto.nombre,
        descripcion: proyecto.descripcion,
        jefeProyectoId: proyecto.jefeProyectoId,
        fechaFinEstimada: proyecto.fechaFinEstimada,
        presupuesto: proyecto.presupuesto,
        horasEstimadas: proyecto.horasEstimadas,
        estado: proyecto.estado
      });
      setProyectos(await api.get<Proyecto[]>("/api/Proyectos"));
      await cargarDetalle(proyecto.id);
    } catch (err) {
      setError(err instanceof Error ? err.message : "No se pudo aprobar el hito.");
    }
  }

  return (
    <>
      <Encabezado
        titulo="Ficha de proyecto"
        detalle="El avance no se escribe: sale de los hitos aprobados. Las horas reales vienen del parte de horas."
        acciones={
          <Selector rotulo="Proyecto" opciones={proyectos} valor={proyectoId} onCambio={setProyectoId}
            texto={(p) => `${p.codigo} - ${p.nombre}`} />
        }
      />

      {error && <div className="alerta-error" style={{ marginBottom: 14 }}>{error}</div>}
      {proyectos.length === 0 && !error && <Aviso>No hay proyectos registrados.</Aviso>}

      {proyecto && (
        <>
          <div className="tarjetas">
            <div className="tarjeta">
              <div className="tarjeta-rotulo">Avance guardado</div>
              <div className="tarjeta-valor">{proyecto.avancePorcentaje}%</div>
              <div style={{ marginTop: 8 }}>
                <div className="medidor">
                  <div className={`medidor-relleno${proyecto.avancePorcentaje === 100 ? " ok" : ""}`}
                    style={{ width: `${proyecto.avancePorcentaje}%` }} />
                </div>
              </div>
              <div className="tarjeta-pie">
                {aprobados} de {hitos.length} hitos aprobados ({avanceHitos}%)
              </div>
            </div>
            <div className="tarjeta">
              <div className="tarjeta-rotulo">Presupuesto</div>
              <div className="tarjeta-valor">{soles(proyecto.presupuesto)}</div>
              <div className="tarjeta-pie">hitos por {soles(montoHitos)}</div>
            </div>
            <div className="tarjeta">
              <div className="tarjeta-rotulo">Horas</div>
              <div className="tarjeta-valor">{horasCargadas}</div>
              <div className="tarjeta-pie">de {proyecto.horasEstimadas} estimadas</div>
            </div>
            <div className="tarjeta">
              <div className="tarjeta-rotulo">Facturables</div>
              <div className="tarjeta-valor">{facturables}</div>
              <div className="tarjeta-pie">aprobadas por el jefe</div>
            </div>
            <div className="tarjeta">
              <div className="tarjeta-rotulo">Estado</div>
              <div className="tarjeta-valor" style={{ fontSize: 20 }}>{proyecto.estado}</div>
              <div className="tarjeta-pie">
                {proyecto.fechaInicio} al {proyecto.fechaFinReal ?? proyecto.fechaFinEstimada ?? "—"}
              </div>
            </div>
          </div>

          <div className="rejilla-dos">
            <div className="panel">
              <div className="panel-barra"><strong>Hitos</strong></div>
              {hitos.length === 0 ? (
                <Aviso>Este proyecto no tiene hitos.</Aviso>
              ) : (
                <table className="tabla">
                  <thead>
                    <tr><th>Hito</th><th>Objetivo</th><th className="numero">Monto</th><th>Estado</th><th /></tr>
                  </thead>
                  <tbody>
                    {hitos.map((h) => (
                      <tr key={h.id}>
                        <td>{h.nombre}</td>
                        <td>{h.fechaObjetivo}</td>
                        <td className="numero">{soles(h.monto)}</td>
                        <td>
                          <span className={`etiqueta ${h.estado === "Aprobado" ? "ok" : h.estado === "Rechazado" ? "alerta" : "aviso"}`}>
                            {h.estado}
                          </span>
                        </td>
                        <td>
                          {h.estado !== "Aprobado" && (
                            <button type="button" className="boton-mini" onClick={() => void aprobarHito(h)}>
                              Aprobar
                            </button>
                          )}
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              )}
            </div>

            <div className="panel">
              <div className="panel-barra"><strong>Equipo</strong></div>
              {equipo.length === 0 ? (
                <Aviso>Este proyecto no tiene equipo asignado.</Aviso>
              ) : (
                <table className="tabla">
                  <thead>
                    <tr><th>Integrante</th><th>Rol</th><th className="numero">Dedicacion</th><th>Horas</th></tr>
                  </thead>
                  <tbody>
                    {equipo.map((e) => (
                      <tr key={e.id}>
                        <td>{empleado(e.empleadoId)}</td>
                        <td>{e.rol}</td>
                        <td className="numero">{e.dedicacionPorcentaje}%</td>
                        <td>{horas.filter((h) => h.empleadoId === e.empleadoId).reduce((s, h) => s + h.horas, 0)}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              )}
            </div>
          </div>
        </>
      )}
    </>
  );
}
