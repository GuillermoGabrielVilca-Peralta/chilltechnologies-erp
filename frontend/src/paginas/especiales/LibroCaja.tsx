import { useEffect, useState } from "react";
import { api } from "../../api/cliente";
import { Aviso, Encabezado, Selector, fecha, soles } from "../../componentes/comunes";

interface Caja { id: number; nombre: string; saldoInicial: number; saldoActual: number; estado: string }
interface Movimiento {
  id: number; cajaId: number; tipo: string; concepto: string;
  monto: number; documentoReferencia: string | null; fechaMovimiento: string;
}

export function LibroCaja() {
  const [cajas, setCajas] = useState<Caja[]>([]);
  const [cajaId, setCajaId] = useState<number | null>(null);
  const [movimientos, setMovimientos] = useState<Movimiento[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [tipo, setTipo] = useState("Ingreso");
  const [concepto, setConcepto] = useState("");
  const [monto, setMonto] = useState("");
  const [guardando, setGuardando] = useState(false);

  async function cargarCajas() {
    const c = await api.get<Caja[]>("/api/Cajas");
    setCajas(c);
    if (cajaId === null && c.length) setCajaId(c[0].id);
  }

  useEffect(() => {
    cargarCajas().catch((e) => setError(e.message));
  }, []);

  useEffect(() => {
    if (cajaId === null) return;
    api.get<Movimiento[]>(`/api/MovimientosCaja/caja/${cajaId}`)
      .then(setMovimientos)
      .catch((e) => setError(e.message));
  }, [cajaId]);

  const caja = cajas.find((c) => c.id === cajaId);

  const ordenados = [...movimientos].sort(
    (a, b) => a.fechaMovimiento.localeCompare(b.fechaMovimiento)
  );

  let corriente = caja?.saldoInicial ?? 0;
  const conSaldo = ordenados.map((m) => {
    corriente += m.tipo === "Ingreso" ? m.monto : -m.monto;
    return { ...m, saldo: corriente };
  });

  const ingresos = movimientos.filter((m) => m.tipo === "Ingreso").reduce((s, m) => s + m.monto, 0);
  const egresos = movimientos.filter((m) => m.tipo === "Egreso").reduce((s, m) => s + m.monto, 0);

  async function registrar(e: React.FormEvent) {
    e.preventDefault();
    if (cajaId === null) return;
    setGuardando(true);
    setError(null);
    try {
      await api.post("/api/MovimientosCaja", {
        cajaId,
        tipo,
        concepto,
        monto: Number(monto)
      });
      setConcepto("");
      setMonto("");
      const [m] = await Promise.all([
        api.get<Movimiento[]>(`/api/MovimientosCaja/caja/${cajaId}`),
        cargarCajas()
      ]);
      setMovimientos(m);
    } catch (err) {
      setError(err instanceof Error ? err.message : "No se pudo registrar.");
    } finally {
      setGuardando(false);
    }
  }

  return (
    <>
      <Encabezado
        titulo="Libro de caja"
        detalle="Cada movimiento ajusta el saldo de la caja en la misma transaccion del backend."
        acciones={
          <Selector rotulo="Caja" opciones={cajas} valor={cajaId} onCambio={setCajaId}
            texto={(c) => `${c.nombre} (${soles(c.saldoActual)})`} />
        }
      />

      {error && <div className="alerta-error" style={{ marginBottom: 14 }}>{error}</div>}

      {caja && (
        <div className="tarjetas">
          <div className="tarjeta">
            <div className="tarjeta-rotulo">Saldo inicial</div>
            <div className="tarjeta-valor">{soles(caja.saldoInicial)}</div>
          </div>
          <div className="tarjeta">
            <div className="tarjeta-rotulo">Ingresos</div>
            <div className="tarjeta-valor" style={{ color: "var(--ok)" }}>{soles(ingresos)}</div>
          </div>
          <div className="tarjeta">
            <div className="tarjeta-rotulo">Egresos</div>
            <div className="tarjeta-valor" style={{ color: "var(--alerta)" }}>{soles(egresos)}</div>
          </div>
          <div className="tarjeta">
            <div className="tarjeta-rotulo">Saldo actual</div>
            <div className="tarjeta-valor">{soles(caja.saldoActual)}</div>
            <div className="tarjeta-pie">
              {caja.saldoInicial + ingresos - egresos === caja.saldoActual
                ? <span className="cuadrado">cuadra con el libro</span>
                : <span className="descuadre">no cuadra con el libro</span>}
            </div>
          </div>
        </div>
      )}

      {caja && (
        <div className="panel" style={{ marginBottom: 16 }}>
          <form className="panel-barra" onSubmit={registrar}>
            <select value={tipo} onChange={(e) => setTipo(e.target.value)}
              style={{ padding: "8px 10px", borderRadius: 6, border: "1px solid var(--borde)" }}>
              <option>Ingreso</option>
              <option>Egreso</option>
            </select>
            <input className="tabla-buscador" placeholder="Concepto" required
              value={concepto} onChange={(e) => setConcepto(e.target.value)} />
            <input className="tabla-buscador" type="number" step="0.01" min="0.01" placeholder="Monto" required
              style={{ maxWidth: 140 }} value={monto} onChange={(e) => setMonto(e.target.value)} />
            <button type="submit" className="boton-principal" disabled={guardando}>
              {guardando ? "Registrando..." : "Registrar"}
            </button>
          </form>
        </div>
      )}

      <div className="panel">
        {conSaldo.length === 0 ? (
          <Aviso>Esta caja no tiene movimientos todavia.</Aviso>
        ) : (
          <div className="tabla-scroll">
            <table className="tabla">
              <thead>
                <tr>
                  <th>Fecha</th>
                  <th>Concepto</th>
                  <th className="numero">Ingreso</th>
                  <th className="numero">Egreso</th>
                  <th className="numero">Saldo</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td colSpan={4} style={{ color: "var(--texto-suave)" }}>Saldo inicial</td>
                  <td className="numero">{soles(caja?.saldoInicial ?? 0)}</td>
                </tr>
                {conSaldo.map((m) => (
                  <tr key={m.id}>
                    <td>{fecha(m.fechaMovimiento)}</td>
                    <td>{m.concepto}</td>
                    <td className="numero" style={{ color: "var(--ok)" }}>
                      {m.tipo === "Ingreso" ? soles(m.monto) : ""}
                    </td>
                    <td className="numero" style={{ color: "var(--alerta)" }}>
                      {m.tipo === "Egreso" ? soles(m.monto) : ""}
                    </td>
                    <td className="numero">{soles(m.saldo)}</td>
                  </tr>
                ))}
              </tbody>
              <tfoot>
                <tr>
                  <td colSpan={2}>Totales</td>
                  <td className="numero">{soles(ingresos)}</td>
                  <td className="numero">{soles(egresos)}</td>
                  <td className="numero">{soles(caja?.saldoActual ?? 0)}</td>
                </tr>
              </tfoot>
            </table>
          </div>
        )}
      </div>
    </>
  );
}
