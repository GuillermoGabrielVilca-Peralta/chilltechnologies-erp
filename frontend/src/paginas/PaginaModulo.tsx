import { useEffect, useMemo, useState } from "react";
import { useParams } from "react-router-dom";
import { api } from "../api/cliente";
import { buscarModulo, type Modulo } from "../api/modulos";
import { Modal } from "../componentes/Modal";
import { Formulario, etiqueta } from "../componentes/Formulario";

type Fila = Record<string, unknown>;

export function PaginaModulo() {
  const { clave } = useParams();
  const modulo = clave ? buscarModulo(clave) : undefined;

  if (!modulo) {
    return (
      <div className="panel">
        <div className="vacio">Ese modulo no existe.</div>
      </div>
    );
  }

  return <VistaModulo key={modulo.clave} modulo={modulo} />;
}

function VistaModulo({ modulo }: { modulo: Modulo }) {
  const [filas, setFilas] = useState<Fila[]>([]);
  const [cargando, setCargando] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [filtro, setFiltro] = useState("");
  const [editando, setEditando] = useState<Fila | null>(null);
  const [creando, setCreando] = useState(false);
  const [valores, setValores] = useState<Record<string, unknown>>({});
  const [guardando, setGuardando] = useState(false);
  const [errorForm, setErrorForm] = useState<string | null>(null);

  async function cargar() {
    setCargando(true);
    setError(null);
    try {
      const datos = await api.get<Fila[]>(modulo.endpoint);
      setFilas(Array.isArray(datos) ? datos : []);
    } catch (err) {
      setError(err instanceof Error ? err.message : "Error al cargar.");
      setFilas([]);
    } finally {
      setCargando(false);
    }
  }

  useEffect(() => {
    void cargar();
  }, [modulo.endpoint]);

  const columnas = useMemo(() => {
    if (filas.length === 0) return [];
    const vistas = new Set<string>();
    for (const fila of filas.slice(0, 20)) {
      for (const [k, v] of Object.entries(fila)) {
        if (v !== null && typeof v === "object") continue;
        vistas.add(k);
      }
    }
    return [...vistas];
  }, [filas]);

  const visibles = useMemo(() => {
    const q = filtro.trim().toLowerCase();
    if (!q) return filas;
    return filas.filter((f) =>
      columnas.some((c) => String(f[c] ?? "").toLowerCase().includes(q))
    );
  }, [filas, columnas, filtro]);

  function abrirCrear() {
    const iniciales: Record<string, unknown> = {};
    for (const c of modulo.camposCrear) {
      iniciales[c.nombre] = c.tipo === "booleano" ? false : null;
    }
    setValores(iniciales);
    setErrorForm(null);
    setCreando(true);
  }

  function abrirEditar(fila: Fila) {
    const iniciales: Record<string, unknown> = {};
    for (const c of modulo.camposEditar) {
      const valor = fila[c.nombre];
      iniciales[c.nombre] =
        c.tipo === "fechahora" && typeof valor === "string"
          ? valor.slice(0, 16)
          : (valor ?? (c.tipo === "booleano" ? false : null));
    }
    setValores(iniciales);
    setErrorForm(null);
    setEditando(fila);
  }

  async function guardar() {
    setGuardando(true);
    setErrorForm(null);
    try {
      if (creando) {
        await api.post(modulo.endpoint, valores);
      } else if (editando) {
        await api.put(`${modulo.endpoint}/${editando.id}`, valores);
      }
      setCreando(false);
      setEditando(null);
      await cargar();
    } catch (err) {
      setErrorForm(err instanceof Error ? err.message : "No se pudo guardar.");
    } finally {
      setGuardando(false);
    }
  }

  async function eliminar(fila: Fila) {
    if (!confirm("Esto elimina el registro. Continuar?")) return;
    try {
      await api.del(`${modulo.endpoint}/${fila.id}`);
      await cargar();
    } catch (err) {
      alert(err instanceof Error ? err.message : "No se pudo eliminar.");
    }
  }

  const puedeEditar = !modulo.soloLectura && !modulo.llaveCompuesta && modulo.camposEditar.length > 0;
  const puedeEliminar = !modulo.soloLectura && !modulo.llaveCompuesta;

  return (
    <>
      <div className="pagina-encabezado">
        <div>
          <h1>{modulo.titulo}</h1>
          <p>
            {modulo.area} &middot; <code>{modulo.endpoint}</code>
            {modulo.soloLectura && " · libro: solo se registra, no se edita"}
          </p>
        </div>
        {modulo.camposCrear.length > 0 && (
          <button type="button" className="boton-principal" onClick={abrirCrear}>
            Nuevo
          </button>
        )}
      </div>

      {error && <div className="alerta-error" style={{ marginBottom: 14 }}>{error}</div>}

      <div className="panel">
        <div className="panel-barra">
          <input
            className="tabla-buscador"
            placeholder="Buscar en la tabla..."
            value={filtro}
            onChange={(e) => setFiltro(e.target.value)}
          />
          <span className="panel-conteo">
            {cargando ? "Cargando..." : `${visibles.length} de ${filas.length} registros`}
          </span>
        </div>

        {!cargando && filas.length === 0 && !error && (
          <div className="vacio">Todavia no hay registros en este modulo.</div>
        )}

        {filas.length > 0 && (
          <div className="tabla-scroll">
            <table className="tabla">
              <thead>
                <tr>
                  {columnas.map((c) => (
                    <th key={c}>{etiqueta(c)}</th>
                  ))}
                  {(puedeEditar || puedeEliminar) && <th />}
                </tr>
              </thead>
              <tbody>
                {visibles.map((fila, i) => (
                  <tr key={String(fila.id ?? i)}>
                    {columnas.map((c) => (
                      <td key={c}>{celda(c, fila[c])}</td>
                    ))}
                    {(puedeEditar || puedeEliminar) && (
                      <td>
                        <div className="celda-acciones">
                          {puedeEditar && (
                            <button type="button" className="boton-mini" onClick={() => abrirEditar(fila)}>
                              Editar
                            </button>
                          )}
                          {puedeEliminar && (
                            <button
                              type="button"
                              className="boton-mini peligro"
                              onClick={() => void eliminar(fila)}
                            >
                              Eliminar
                            </button>
                          )}
                        </div>
                      </td>
                    )}
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </div>

      {(creando || editando) && (
        <Modal
          titulo={creando ? `Nuevo en ${modulo.titulo}` : `Editar ${modulo.titulo}`}
          onCerrar={() => {
            setCreando(false);
            setEditando(null);
          }}
          pie={
            <>
              {errorForm && <div className="alerta-error" style={{ flex: 1 }}>{errorForm}</div>}
              <button
                type="button"
                className="boton-secundario"
                onClick={() => {
                  setCreando(false);
                  setEditando(null);
                }}
              >
                Cancelar
              </button>
              <button
                type="button"
                className="boton-principal"
                disabled={guardando}
                onClick={() => void guardar()}
              >
                {guardando ? "Guardando..." : "Guardar"}
              </button>
            </>
          }
        >
          <Formulario
            campos={creando ? modulo.camposCrear : modulo.camposEditar}
            valores={valores}
            onCambio={(nombre, valor) => setValores((v) => ({ ...v, [nombre]: valor }))}
          />
        </Modal>
      )}
    </>
  );
}

const ESTADOS_OK = ["activo", "activa", "aprobado", "exitoso", "hecho", "hecha", "liberada", "pagada", "cerrado", "finalizado", "vigente", "paso"];
const ESTADOS_ALERTA = ["inactivo", "inactiva", "bloqueado", "cancelado", "fallido", "rechazado", "anulado", "vencida", "fallo", "critica", "bloqueante"];

function celda(columna: string, valor: unknown) {
  if (valor === null || valor === undefined) return <span style={{ color: "#aeb6c2" }}>—</span>;
  if (typeof valor === "boolean") {
    return <span className={`etiqueta ${valor ? "ok" : "neutra"}`}>{valor ? "Si" : "No"}</span>;
  }
  if (Array.isArray(valor)) return valor.join(", ");
  const texto = String(valor);
  const col = columna.toLowerCase();
  if (col === "estado" || col === "severidad" || col === "resultado" || col === "prioridad") {
    const v = texto.toLowerCase();
    const clase = ESTADOS_OK.includes(v) ? "ok" : ESTADOS_ALERTA.includes(v) ? "alerta" : "aviso";
    return <span className={`etiqueta ${clase}`}>{texto}</span>;
  }
  if (/^\d{4}-\d{2}-\d{2}T/.test(texto)) return texto.slice(0, 16).replace("T", " ");
  return texto;
}
