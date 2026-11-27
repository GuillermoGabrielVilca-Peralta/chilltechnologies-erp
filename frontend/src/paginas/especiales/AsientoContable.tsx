import { useEffect, useState } from "react";
import { api } from "../../api/cliente";
import { Aviso, Encabezado, Selector, soles } from "../../componentes/comunes";

interface Asiento {
  id: number; numero: string; fecha: string; glosa: string; tipoAsiento: string;
  totalDebe: number; totalHaber: number; estado: string;
}
interface Cuenta { id: number; codigo: string; nombre: string; tipoCuenta: string; aceptaMovimiento: boolean }
interface Detalle { id: number; asientoId: number; cuentaId: number; debe: number; haber: number; glosa: string | null }

export function AsientoContable() {
  const [asientos, setAsientos] = useState<Asiento[]>([]);
  const [asientoId, setAsientoId] = useState<number | null>(null);
  const [cuentas, setCuentas] = useState<Cuenta[]>([]);
  const [detalles, setDetalles] = useState<Detalle[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [cuentaId, setCuentaId] = useState("");
  const [lado, setLado] = useState("debe");
  const [importe, setImporte] = useState("");
  const [glosa, setGlosa] = useState("");
  const [guardando, setGuardando] = useState(false);

  async function cargarAsientos() {
    const a = await api.get<Asiento[]>("/api/AsientosContables");
    setAsientos(a);
    if (asientoId === null && a.length) setAsientoId(a[0].id);
  }

  useEffect(() => {
    Promise.all([cargarAsientos(), api.get<Cuenta[]>("/api/PlanCuentas").then(setCuentas)])
      .catch((e) => setError(e.message));
  }, []);

  useEffect(() => {
    api.get<Detalle[]>("/api/DetalleAsiento")
      .then((d) => setDetalles(d))
      .catch((e) => setError(e.message));
  }, [asientoId]);

  const asiento = asientos.find((a) => a.id === asientoId);
  const lineas = detalles.filter((d) => d.asientoId === asientoId);
  const sumaDebe = lineas.reduce((s, d) => s + d.debe, 0);
  const sumaHaber = lineas.reduce((s, d) => s + d.haber, 0);
  const cuadra = sumaDebe === sumaHaber && sumaDebe > 0;
  const cuenta = (id: number) => cuentas.find((c) => c.id === id);

  async function agregarLinea(e: React.FormEvent) {
    e.preventDefault();
    if (asientoId === null) return;
    setGuardando(true);
    setError(null);
    try {
      const valor = Number(importe);
      await api.post("/api/DetalleAsiento", {
        asientoId,
        cuentaId: Number(cuentaId),
        debe: lado === "debe" ? valor : 0,
        haber: lado === "haber" ? valor : 0,
        glosa: glosa || null
      });
      setImporte("");
      setGlosa("");
      setDetalles(await api.get<Detalle[]>("/api/DetalleAsiento"));
    } catch (err) {
      setError(err instanceof Error ? err.message : "No se pudo agregar la linea.");
    } finally {
      setGuardando(false);
    }
  }

  async function contabilizar() {
    if (!asiento) return;
    setError(null);
    try {
      await api.put(`/api/AsientosContables/${asiento.id}`, {
        fecha: asiento.fecha,
        glosa: asiento.glosa,
        tipoAsiento: asiento.tipoAsiento,
        estado: "Contabilizado"
      });
      await cargarAsientos();
    } catch (err) {
      setError(err instanceof Error ? err.message : "No se pudo contabilizar.");
    }
  }

  return (
    <>
      <Encabezado
        titulo="Asiento contable"
        detalle="La partida doble la fuerza la base de datos; los totales los recalcula el backend desde las lineas."
        acciones={
          <Selector rotulo="Asiento" opciones={asientos} valor={asientoId} onCambio={setAsientoId}
            texto={(a) => `${a.numero} - ${a.glosa}`} />
        }
      />

      {error && <div className="alerta-error" style={{ marginBottom: 14 }}>{error}</div>}
      {asientos.length === 0 && !error && <Aviso>No hay asientos registrados todavia.</Aviso>}

      {asiento && (
        <>
          <div className="tarjetas">
            <div className="tarjeta">
              <div className="tarjeta-rotulo">Estado</div>
              <div className="tarjeta-valor" style={{ fontSize: 20 }}>{asiento.estado}</div>
              <div className="tarjeta-pie">{asiento.tipoAsiento} · {asiento.fecha}</div>
            </div>
            <div className="tarjeta">
              <div className="tarjeta-rotulo">Suma al debe</div>
              <div className="tarjeta-valor">{soles(sumaDebe)}</div>
            </div>
            <div className="tarjeta">
              <div className="tarjeta-rotulo">Suma al haber</div>
              <div className="tarjeta-valor">{soles(sumaHaber)}</div>
            </div>
            <div className="tarjeta">
              <div className="tarjeta-rotulo">Partida doble</div>
              <div className={`tarjeta-valor${cuadra ? "" : " alerta"}`} style={{ fontSize: 20 }}>
                {cuadra ? "Cuadra" : "Descuadrado"}
              </div>
              <div className="tarjeta-pie">
                diferencia {soles(Math.abs(sumaDebe - sumaHaber))}
              </div>
            </div>
          </div>

          {asiento.estado === "Borrador" && (
            <div className="panel" style={{ marginBottom: 16 }}>
              <form className="panel-barra" onSubmit={agregarLinea}>
                <select required value={cuentaId} onChange={(e) => setCuentaId(e.target.value)}
                  style={{ padding: "8px 10px", borderRadius: 6, border: "1px solid var(--borde)", minWidth: 220 }}>
                  <option value="">Cuenta...</option>
                  {cuentas.filter((c) => c.aceptaMovimiento).map((c) => (
                    <option key={c.id} value={c.id}>{c.codigo} - {c.nombre}</option>
                  ))}
                </select>
                <select value={lado} onChange={(e) => setLado(e.target.value)}
                  style={{ padding: "8px 10px", borderRadius: 6, border: "1px solid var(--borde)" }}>
                  <option value="debe">Debe</option>
                  <option value="haber">Haber</option>
                </select>
                <input className="tabla-buscador" type="number" step="0.01" min="0.01" placeholder="Importe"
                  required style={{ maxWidth: 130 }} value={importe} onChange={(e) => setImporte(e.target.value)} />
                <input className="tabla-buscador" placeholder="Glosa de la linea"
                  value={glosa} onChange={(e) => setGlosa(e.target.value)} />
                <button type="submit" className="boton-principal" disabled={guardando}>
                  {guardando ? "Agregando..." : "Agregar linea"}
                </button>
              </form>
            </div>
          )}

          <div className="panel">
            <div className="panel-barra">
              <strong>{asiento.numero} · {asiento.glosa}</strong>
              {asiento.estado === "Borrador" && (
                <button type="button" className="boton-principal" disabled={!cuadra} onClick={() => void contabilizar()}
                  title={cuadra ? "" : "El asiento tiene que cuadrar antes de contabilizar"}>
                  Contabilizar
                </button>
              )}
            </div>
            {lineas.length === 0 ? (
              <Aviso>Este asiento no tiene lineas.</Aviso>
            ) : (
              <table className="tabla">
                <thead>
                  <tr>
                    <th>Cuenta</th><th>Glosa</th>
                    <th className="numero">Debe</th><th className="numero">Haber</th>
                  </tr>
                </thead>
                <tbody>
                  {lineas.map((d) => {
                    const c = cuenta(d.cuentaId);
                    return (
                      <tr key={d.id}>
                        <td>{c ? `${c.codigo} - ${c.nombre}` : `#${d.cuentaId}`}</td>
                        <td>{d.glosa ?? "—"}</td>
                        <td className="numero">{d.debe > 0 ? soles(d.debe) : ""}</td>
                        <td className="numero">{d.haber > 0 ? soles(d.haber) : ""}</td>
                      </tr>
                    );
                  })}
                </tbody>
                <tfoot>
                  <tr>
                    <td colSpan={2}>Totales del libro</td>
                    <td className={`numero ${cuadra ? "cuadrado" : "descuadre"}`}>{soles(sumaDebe)}</td>
                    <td className={`numero ${cuadra ? "cuadrado" : "descuadre"}`}>{soles(sumaHaber)}</td>
                  </tr>
                  <tr>
                    <td colSpan={2} style={{ color: "var(--texto-suave)", fontWeight: 400 }}>
                      Totales guardados en el asiento
                    </td>
                    <td className="numero">{soles(asiento.totalDebe)}</td>
                    <td className="numero">{soles(asiento.totalHaber)}</td>
                  </tr>
                </tfoot>
              </table>
            )}
          </div>
        </>
      )}
    </>
  );
}
