import { useEffect, useState } from "react";
import { api } from "../../api/cliente";
import { Aviso, Encabezado, Selector } from "../../componentes/comunes";

interface Proyecto { id: number; nombre: string; codigo: string }
interface Sprint {
  id: number; proyectoId: number; numero: number; objetivo: string | null;
  fechaInicio: string; fechaFin: string;
  puntosComprometidos: number; puntosCompletados: number; estado: string;
}
interface Historia {
  id: number; codigo: string; titulo: string; puntosHistoria: number;
  prioridad: string; estado: string; sprintId: number | null;
}

const COLUMNAS = ["Por hacer", "En curso", "En revision", "Hecho"];

export function TableroSprint() {
  const [proyectos, setProyectos] = useState<Proyecto[]>([]);
  const [proyectoId, setProyectoId] = useState<number | null>(null);
  const [sprints, setSprints] = useState<Sprint[]>([]);
  const [sprintId, setSprintId] = useState<number | null>(null);
  const [historias, setHistorias] = useState<Historia[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    api.get<Proyecto[]>("/api/Proyectos")
      .then((p) => { setProyectos(p); if (p.length) setProyectoId(p[0].id); })
      .catch((e) => setError(e.message));
  }, []);

  useEffect(() => {
    if (proyectoId === null) return;
    api.get<Sprint[]>(`/api/Sprints/proyecto/${proyectoId}`)
      .then((s) => { setSprints(s); setSprintId(s.length ? s[0].id : null); })
      .catch((e) => setError(e.message));
  }, [proyectoId]);

  async function recargarHistorias(id: number) {
    const h = await api.get<Historia[]>(`/api/HistoriasUsuario/sprint/${id}`);
    setHistorias(h);
  }

  useEffect(() => {
    if (sprintId === null) { setHistorias([]); return; }
    void recargarHistorias(sprintId).catch((e) => setError(e.message));
  }, [sprintId]);

  const sprint = sprints.find((s) => s.id === sprintId);

  async function mover(historia: Historia, estado: string) {
    await api.put(`/api/HistoriasUsuario/${historia.id}`, {
      titulo: historia.titulo,
      puntosHistoria: historia.puntosHistoria,
      prioridad: historia.prioridad,
      estado
    });
    if (sprint) {
      await api.put(`/api/Sprints/${sprint.id}`, {
        objetivo: sprint.objetivo,
        fechaInicio: sprint.fechaInicio,
        fechaFin: sprint.fechaFin,
        estado: sprint.estado
      });
      const s = await api.get<Sprint[]>(`/api/Sprints/proyecto/${proyectoId}`);
      setSprints(s);
    }
    if (sprintId !== null) await recargarHistorias(sprintId);
  }

  const avance = sprint && sprint.puntosComprometidos > 0
    ? Math.round((sprint.puntosCompletados / sprint.puntosComprometidos) * 100)
    : 0;

  return (
    <>
      <Encabezado
        titulo="Tablero de sprint"
        detalle="Al mover una historia a Hecho, los puntos del sprint se recalculan en el backend."
        acciones={
          <div style={{ display: "flex", gap: 10 }}>
            <Selector rotulo="Proyecto" opciones={proyectos} valor={proyectoId}
              onCambio={setProyectoId} texto={(p) => `${p.codigo} - ${p.nombre}`} />
            <Selector rotulo="Sprint" opciones={sprints} valor={sprintId}
              onCambio={setSprintId} texto={(s) => `Sprint ${s.numero}`} />
          </div>
        }
      />

      {error && <div className="alerta-error" style={{ marginBottom: 14 }}>{error}</div>}

      {sprint && (
        <div className="tarjetas">
          <div className="tarjeta">
            <div className="tarjeta-rotulo">Objetivo</div>
            <div className="tarjeta-pie" style={{ fontSize: 14, marginTop: 8 }}>
              {sprint.objetivo ?? "Sin objetivo"}
            </div>
          </div>
          <div className="tarjeta">
            <div className="tarjeta-rotulo">Comprometidos</div>
            <div className="tarjeta-valor">{sprint.puntosComprometidos}</div>
            <div className="tarjeta-pie">puntos de historia</div>
          </div>
          <div className="tarjeta">
            <div className="tarjeta-rotulo">Completados</div>
            <div className="tarjeta-valor">{sprint.puntosCompletados}</div>
            <div className="tarjeta-pie">{avance}% del compromiso</div>
          </div>
          <div className="tarjeta">
            <div className="tarjeta-rotulo">Avance</div>
            <div style={{ marginTop: 14 }}>
              <div className="medidor">
                <div className={`medidor-relleno${avance === 100 ? " ok" : ""}`} style={{ width: `${avance}%` }} />
              </div>
            </div>
            <div className="tarjeta-pie">
              {sprint.fechaInicio} al {sprint.fechaFin}
            </div>
          </div>
        </div>
      )}

      {!sprint && <Aviso>Este proyecto no tiene sprints todavia.</Aviso>}

      {sprint && (
        <div className="tablero">
          {COLUMNAS.map((col) => {
            const dela = historias.filter((h) => h.estado === col);
            return (
              <div key={col} className="columna">
                <div className="columna-titulo">
                  <span>{col}</span>
                  <span>{dela.reduce((s, h) => s + h.puntosHistoria, 0)} pts</span>
                </div>
                {dela.map((h) => (
                  <div key={h.id} className="ficha">
                    <div className="ficha-codigo">{h.codigo}</div>
                    <div className="ficha-titulo">{h.titulo}</div>
                    <div className="ficha-pie">
                      <span className="puntos">{h.puntosHistoria} pts</span>
                      <select
                        value={h.estado}
                        onChange={(e) => void mover(h, e.target.value)}
                        style={{ fontSize: 11, padding: "2px 4px", borderRadius: 4, border: "1px solid var(--borde)" }}
                      >
                        {COLUMNAS.map((c) => (
                          <option key={c} value={c}>{c}</option>
                        ))}
                      </select>
                    </div>
                  </div>
                ))}
                {dela.length === 0 && (
                  <div style={{ fontSize: 12, color: "var(--texto-suave)", padding: 8 }}>Vacia</div>
                )}
              </div>
            );
          })}
        </div>
      )}
    </>
  );
}
