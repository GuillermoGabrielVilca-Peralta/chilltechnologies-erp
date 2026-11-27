import { useEffect, useState } from "react";
import { api } from "../../api/cliente";
import { Aviso, Encabezado, fecha } from "../../componentes/comunes";

interface Ticket {
  id: number; codigo: string; clienteId: number; tipoTicketId: number;
  acuerdoServicioId: number | null; asunto: string; severidad: string;
  asignadoAId: number | null; estado: string;
  fechaApertura: string; fechaPrimeraRespuesta: string | null; fechaCierre: string | null;
}
interface Cliente { id: number; razonSocial: string }
interface Empleado { id: number; nombres: string; apellidos: string }
interface Seguimiento {
  id: number; ticketId: number; empleadoId: number | null; comentario: string;
  visibleCliente: boolean; horasInvertidas: number; fechaSeguimiento: string;
}

export function BandejaTickets() {
  const [tickets, setTickets] = useState<Ticket[]>([]);
  const [fueraSla, setFueraSla] = useState<Set<number>>(new Set());
  const [clientes, setClientes] = useState<Cliente[]>([]);
  const [empleados, setEmpleados] = useState<Empleado[]>([]);
  const [abierto, setAbierto] = useState<number | null>(null);
  const [seguimientos, setSeguimientos] = useState<Seguimiento[]>([]);
  const [comentario, setComentario] = useState("");
  const [visible, setVisible] = useState(true);
  const [horas, setHoras] = useState("0");
  const [error, setError] = useState<string | null>(null);
  const [guardando, setGuardando] = useState(false);

  async function cargar() {
    const [t, f, c, e] = await Promise.all([
      api.get<Ticket[]>("/api/TicketsSoporte"),
      api.get<Ticket[]>("/api/TicketsSoporte/fuera-de-sla"),
      api.get<Cliente[]>("/api/Clientes"),
      api.get<Empleado[]>("/api/Empleados")
    ]);
    setTickets(t);
    setFueraSla(new Set(f.map((x) => x.id)));
    setClientes(c);
    setEmpleados(e);
  }

  useEffect(() => {
    cargar().catch((err) => setError(err.message));
  }, []);

  useEffect(() => {
    if (abierto === null) { setSeguimientos([]); return; }
    api.get<Seguimiento[]>(`/api/SeguimientosTicket/ticket/${abierto}`)
      .then(setSeguimientos)
      .catch((e) => setError(e.message));
  }, [abierto]);

  const cliente = (id: number) => clientes.find((c) => c.id === id)?.razonSocial ?? `#${id}`;
  const empleado = (id: number | null) => {
    if (id === null) return "sin asignar";
    const e = empleados.find((x) => x.id === id);
    return e ? `${e.nombres} ${e.apellidos}` : `#${id}`;
  };

  async function responder(e: React.FormEvent) {
    e.preventDefault();
    if (abierto === null) return;
    setGuardando(true);
    setError(null);
    try {
      await api.post("/api/SeguimientosTicket", {
        ticketId: abierto,
        comentario,
        visibleCliente: visible,
        horasInvertidas: Number(horas)
      });
      setComentario("");
      setHoras("0");
      const [s] = await Promise.all([
        api.get<Seguimiento[]>(`/api/SeguimientosTicket/ticket/${abierto}`),
        cargar()
      ]);
      setSeguimientos(s);
    } catch (err) {
      setError(err instanceof Error ? err.message : "No se pudo registrar.");
    } finally {
      setGuardando(false);
    }
  }

  const ticket = tickets.find((t) => t.id === abierto);
  const horasTicket = seguimientos.reduce((s, x) => s + x.horasInvertidas, 0);

  return (
    <>
      <Encabezado
        titulo="Bandeja de soporte"
        detalle="En rojo, los tickets que pasaron el plazo de primera respuesta de su SLA."
      />

      {error && <div className="alerta-error" style={{ marginBottom: 14 }}>{error}</div>}

      <div className="tarjetas">
        <div className="tarjeta">
          <div className="tarjeta-rotulo">Total</div>
          <div className="tarjeta-valor">{tickets.length}</div>
        </div>
        <div className="tarjeta">
          <div className="tarjeta-rotulo">Sin responder</div>
          <div className="tarjeta-valor">{tickets.filter((t) => !t.fechaPrimeraRespuesta).length}</div>
        </div>
        <div className="tarjeta">
          <div className="tarjeta-rotulo">Fuera de SLA</div>
          <div className={`tarjeta-valor${fueraSla.size > 0 ? " alerta" : ""}`}>{fueraSla.size}</div>
        </div>
        <div className="tarjeta">
          <div className="tarjeta-rotulo">Cerrados</div>
          <div className="tarjeta-valor">
            {tickets.filter((t) => t.estado === "Cerrado" || t.estado === "Resuelto").length}
          </div>
        </div>
      </div>

      <div className="panel" style={{ marginBottom: 16 }}>
        {tickets.length === 0 ? (
          <Aviso>No hay tickets registrados.</Aviso>
        ) : (
          <div className="tabla-scroll">
            <table className="tabla">
              <thead>
                <tr>
                  <th>Codigo</th><th>Cliente</th><th>Asunto</th><th>Severidad</th>
                  <th>Asignado</th><th>Estado</th><th>Apertura</th><th>1a respuesta</th><th />
                </tr>
              </thead>
              <tbody>
                {tickets.map((t) => (
                  <tr key={t.id} className={fueraSla.has(t.id) ? "fila-alerta" : undefined}>
                    <td>{t.codigo}</td>
                    <td>{cliente(t.clienteId)}</td>
                    <td>{t.asunto}</td>
                    <td>
                      <span className={`etiqueta ${t.severidad === "Critica" ? "alerta" : t.severidad === "Alta" ? "aviso" : "neutra"}`}>
                        {t.severidad}
                      </span>
                    </td>
                    <td>{empleado(t.asignadoAId)}</td>
                    <td>{t.estado}</td>
                    <td>{fecha(t.fechaApertura)}</td>
                    <td>
                      {t.fechaPrimeraRespuesta
                        ? fecha(t.fechaPrimeraRespuesta)
                        : <span className="descuadre">sin responder</span>}
                    </td>
                    <td>
                      <button type="button" className="boton-mini" onClick={() => setAbierto(t.id)}>
                        Abrir
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </div>

      {ticket && (
        <div className="rejilla-dos">
          <div className="panel">
            <div className="panel-barra">
              <strong>{ticket.codigo}</strong>
              <button type="button" className="boton-mini" onClick={() => setAbierto(null)}>Cerrar ficha</button>
            </div>
            <dl className="lista-definicion">
              <dt>Cliente</dt><dd>{cliente(ticket.clienteId)}</dd>
              <dt>Asunto</dt><dd>{ticket.asunto}</dd>
              <dt>Severidad</dt><dd>{ticket.severidad}</dd>
              <dt>Estado</dt><dd>{ticket.estado}</dd>
              <dt>Asignado a</dt><dd>{empleado(ticket.asignadoAId)}</dd>
              <dt>Apertura</dt><dd>{fecha(ticket.fechaApertura)}</dd>
              <dt>1a respuesta</dt>
              <dd>{ticket.fechaPrimeraRespuesta ? fecha(ticket.fechaPrimeraRespuesta) : "sin responder"}</dd>
              <dt>Horas invertidas</dt><dd>{horasTicket}</dd>
              <dt>SLA</dt>
              <dd>{fueraSla.has(ticket.id)
                ? <span className="descuadre">incumplido</span>
                : <span className="cuadrado">dentro del plazo</span>}</dd>
            </dl>
          </div>

          <div className="panel">
            <div className="panel-barra"><strong>Bitacora</strong></div>
            <form className="panel-barra" onSubmit={responder} style={{ flexWrap: "wrap" }}>
              <input className="tabla-buscador" placeholder="Escribe la respuesta o la nota" required
                value={comentario} onChange={(e) => setComentario(e.target.value)} />
              <input className="tabla-buscador" type="number" step="0.25" min="0" style={{ maxWidth: 90 }}
                value={horas} onChange={(e) => setHoras(e.target.value)} title="Horas invertidas" />
              <label style={{ display: "flex", gap: 6, alignItems: "center", fontSize: 12 }}>
                <input type="checkbox" checked={visible} onChange={(e) => setVisible(e.target.checked)} />
                visible al cliente
              </label>
              <button type="submit" className="boton-principal" disabled={guardando}>
                {guardando ? "Enviando..." : "Registrar"}
              </button>
            </form>
            <div className="bitacora">
              {seguimientos.length === 0 && (
                <div style={{ color: "var(--texto-suave)", fontSize: 13 }}>Sin seguimientos todavia.</div>
              )}
              {seguimientos.map((s) => (
                <div key={s.id} className={`bitacora-item${s.visibleCliente ? "" : " interna"}`}>
                  <div>{s.comentario}</div>
                  <div className="bitacora-meta">
                    <span>{fecha(s.fechaSeguimiento)}</span>
                    <span>{s.horasInvertidas} h</span>
                    <span>{s.visibleCliente ? "visible al cliente" : "nota interna"}</span>
                  </div>
                </div>
              ))}
            </div>
          </div>
        </div>
      )}
    </>
  );
}
