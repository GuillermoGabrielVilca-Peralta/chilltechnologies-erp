import { useEffect, useState } from "react";
import { api } from "../../api/cliente";
import { Aviso, Encabezado, Selector, fecha } from "../../componentes/comunes";

interface Producto { id: number; codigo: string; nombre: string; unidadMedida: string; stockMinimo: number }
interface Almacen { id: number; nombre: string }
interface Inventario { id: number; productoId: number; almacenId: number; cantidad: number; ubicacion: string | null }
interface TipoMovimiento { id: number; nombre: string; signo: number }
interface Movimiento {
  id: number; productoId: number; tipoMovimientoId: number;
  almacenOrigenId: number | null; almacenDestinoId: number | null;
  cantidad: number; fechaMovimiento: string; documentoReferencia: string | null;
}

export function Kardex() {
  const [productos, setProductos] = useState<Producto[]>([]);
  const [productoId, setProductoId] = useState<number | null>(null);
  const [almacenes, setAlmacenes] = useState<Almacen[]>([]);
  const [tipos, setTipos] = useState<TipoMovimiento[]>([]);
  const [inventarios, setInventarios] = useState<Inventario[]>([]);
  const [movimientos, setMovimientos] = useState<Movimiento[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    Promise.all([
      api.get<Producto[]>("/api/Productos"),
      api.get<Almacen[]>("/api/Almacenes"),
      api.get<TipoMovimiento[]>("/api/TiposMovimientoInventario"),
      api.get<Inventario[]>("/api/Inventarios"),
      api.get<Movimiento[]>("/api/MovimientosInventario")
    ])
      .then(([p, a, t, i, m]) => {
        setProductos(p);
        setAlmacenes(a);
        setTipos(t);
        setInventarios(i);
        setMovimientos(m);
        if (p.length) setProductoId(p[0].id);
      })
      .catch((e) => setError(e.message));
  }, []);

  const nombreAlmacen = (id: number | null) =>
    id === null ? "—" : almacenes.find((a) => a.id === id)?.nombre ?? `#${id}`;
  const tipo = (id: number) => tipos.find((t) => t.id === id);

  const delProducto = movimientos
    .filter((m) => m.productoId === productoId)
    .sort((a, b) => a.fechaMovimiento.localeCompare(b.fechaMovimiento));

  let acumulado = 0;
  const conSaldo = delProducto.map((m) => {
    const signo = tipo(m.tipoMovimientoId)?.signo ?? 0;
    acumulado += signo * m.cantidad;
    return { ...m, signo, acumulado };
  });

  const stockPorAlmacen = inventarios.filter((i) => i.productoId === productoId);
  const stockTotal = stockPorAlmacen.reduce((s, i) => s + i.cantidad, 0);
  const producto = productos.find((p) => p.id === productoId);

  return (
    <>
      <Encabezado
        titulo="Kardex de inventario"
        detalle="El stock lo mueve el signo del tipo de movimiento, en la misma transaccion del registro."
        acciones={
          <Selector rotulo="Producto" opciones={productos} valor={productoId}
            onCambio={setProductoId} texto={(p) => `${p.codigo} - ${p.nombre}`} />
        }
      />

      {error && <div className="alerta-error" style={{ marginBottom: 14 }}>{error}</div>}
      {productos.length === 0 && !error && <Aviso>No hay productos cargados todavia.</Aviso>}

      {producto && (
        <>
          <div className="tarjetas">
            <div className="tarjeta">
              <div className="tarjeta-rotulo">Stock total</div>
              <div className="tarjeta-valor">{stockTotal}</div>
              <div className="tarjeta-pie">
                minimo {producto.stockMinimo} {producto.unidadMedida}
              </div>
            </div>
            <div className="tarjeta">
              <div className="tarjeta-rotulo">Movimientos</div>
              <div className="tarjeta-valor">{delProducto.length}</div>
              <div className="tarjeta-pie">en el kardex</div>
            </div>
            <div className="tarjeta">
              <div className="tarjeta-rotulo">Acumulado del kardex</div>
              <div className={`tarjeta-valor${acumulado === stockTotal ? "" : " alerta"}`}>{acumulado}</div>
              <div className="tarjeta-pie">
                {acumulado === stockTotal
                  ? <span className="cuadrado">cuadra con el stock</span>
                  : <span className="descuadre">no cuadra con el stock</span>}
              </div>
            </div>
          </div>

          <div className="rejilla-dos" style={{ marginBottom: 16 }}>
            <div className="panel">
              <div className="panel-barra"><strong>Stock por almacen</strong></div>
              {stockPorAlmacen.length === 0 ? (
                <Aviso>Este producto no tiene stock registrado.</Aviso>
              ) : (
                <table className="tabla">
                  <thead>
                    <tr><th>Almacen</th><th>Ubicacion</th><th className="numero">Cantidad</th><th /></tr>
                  </thead>
                  <tbody>
                    {stockPorAlmacen.map((i) => (
                      <tr key={i.id}>
                        <td>{nombreAlmacen(i.almacenId)}</td>
                        <td>{i.ubicacion ?? "—"}</td>
                        <td className="numero">{i.cantidad}</td>
                        <td>
                          {i.cantidad <= producto.stockMinimo && (
                            <span className="etiqueta alerta">bajo minimo</span>
                          )}
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              )}
            </div>

            <div className="panel">
              <div className="panel-barra"><strong>Tipos de movimiento</strong></div>
              <table className="tabla">
                <thead><tr><th>Tipo</th><th className="numero">Signo</th><th>Efecto</th></tr></thead>
                <tbody>
                  {tipos.map((t) => (
                    <tr key={t.id}>
                      <td>{t.nombre}</td>
                      <td className="numero">{t.signo}</td>
                      <td>{t.signo > 0 ? "suma al destino" : t.signo < 0 ? "resta del origen" : "traslada"}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>

          <div className="panel">
            <div className="panel-barra"><strong>Kardex de {producto.nombre}</strong></div>
            {conSaldo.length === 0 ? (
              <Aviso>Este producto no tiene movimientos.</Aviso>
            ) : (
              <div className="tabla-scroll">
                <table className="tabla">
                  <thead>
                    <tr>
                      <th>Fecha</th><th>Tipo</th><th>Origen</th><th>Destino</th>
                      <th className="numero">Entrada</th><th className="numero">Salida</th><th className="numero">Saldo</th>
                    </tr>
                  </thead>
                  <tbody>
                    {conSaldo.map((m) => (
                      <tr key={m.id}>
                        <td>{fecha(m.fechaMovimiento)}</td>
                        <td>{tipo(m.tipoMovimientoId)?.nombre ?? `#${m.tipoMovimientoId}`}</td>
                        <td>{nombreAlmacen(m.almacenOrigenId)}</td>
                        <td>{nombreAlmacen(m.almacenDestinoId)}</td>
                        <td className="numero" style={{ color: "var(--ok)" }}>{m.signo > 0 ? m.cantidad : ""}</td>
                        <td className="numero" style={{ color: "var(--alerta)" }}>{m.signo < 0 ? m.cantidad : ""}</td>
                        <td className="numero">{m.acumulado}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            )}
          </div>
        </>
      )}
    </>
  );
}
