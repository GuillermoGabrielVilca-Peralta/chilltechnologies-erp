import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { api } from "../api/cliente";
import { AREAS, MODULOS, modulosDeArea } from "../api/modulos";
import { ESPECIALES } from "../api/especiales";
import { useAuth } from "../auth/AuthContext";

interface Indicadores {
  proyectosEnCurso: number;
  ticketsPendientes: number;
  ticketsFueraSla: number;
  saldoCajas: number;
  defectosAbiertos: number;
  conductores: number;
}

export function Dashboard() {
  const { sesion } = useAuth();
  const [ind, setInd] = useState<Indicadores | null>(null);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    async function cargar() {
      try {
        const [proyectos, pendientes, fueraSla, cajas, defectos, conductores] = await Promise.all([
          api.get<{ estado: string }[]>("/api/Proyectos"),
          api.get<unknown[]>("/api/TicketsSoporte/pendientes"),
          api.get<unknown[]>("/api/TicketsSoporte/fuera-de-sla"),
          api.get<{ saldoActual: number }[]>("/api/Cajas"),
          api.get<{ estado: string }[]>("/api/Defectos"),
          api.get<unknown[]>("/api/Usuarios")
        ]);
        setInd({
          proyectosEnCurso: proyectos.filter((p) => p.estado === "En curso").length,
          ticketsPendientes: pendientes.length,
          ticketsFueraSla: fueraSla.length,
          saldoCajas: cajas.reduce((s, c) => s + (c.saldoActual ?? 0), 0),
          defectosAbiertos: defectos.filter((d) => d.estado !== "Cerrado" && d.estado !== "Descartado").length,
          conductores: conductores.length
        });
      } catch (err) {
        setError(err instanceof Error ? err.message : "No se pudieron cargar los indicadores.");
      }
    }
    void cargar();
  }, []);

  const maximo = Math.max(...AREAS.map((a) => modulosDeArea(a).length));

  return (
    <>
      <div className="pagina-encabezado">
        <div>
          <h1>Hola, {sesion?.username}</h1>
          <p>
            {MODULOS.length} modulos en {AREAS.length} areas
            {sesion?.roles.length ? ` · ${sesion.roles.join(", ")}` : ""}
          </p>
        </div>
      </div>

      {error && <div className="alerta-error" style={{ marginBottom: 14 }}>{error}</div>}

      <div className="tarjetas">
        <Tarjeta rotulo="Proyectos en curso" valor={ind?.proyectosEnCurso} pie="Capa de software" />
        <Tarjeta rotulo="Tickets pendientes" valor={ind?.ticketsPendientes} pie="Sin resolver ni cerrar" />
        <Tarjeta
          rotulo="Fuera de SLA"
          valor={ind?.ticketsFueraSla}
          pie="Pasaron el plazo de respuesta"
          alerta={(ind?.ticketsFueraSla ?? 0) > 0}
        />
        <Tarjeta rotulo="Saldo en cajas" valor={ind?.saldoCajas} pie="Suma de cajas abiertas" moneda />
        <Tarjeta rotulo="Defectos abiertos" valor={ind?.defectosAbiertos} pie="Calidad" />
        <Tarjeta rotulo="Conductores" valor={ind?.conductores} pie="ChillDrive" />
      </div>

      <div className="rejilla-dos">
        <div className="panel">
          <div className="panel-barra">
            <strong>Modulos por area</strong>
          </div>
          <div className="barra-horizontal">
            {AREAS.map((area) => {
              const n = modulosDeArea(area).length;
              return (
                <div key={area} className="barra-fila">
                  <span>{area}</span>
                  <div className="barra-pista">
                    <div className="barra-relleno" style={{ width: `${(n / maximo) * 100}%` }} />
                  </div>
                  <span className="barra-numero">{n}</span>
                </div>
              );
            })}
          </div>
        </div>

        <div className="panel">
          <div className="panel-barra">
            <strong>Vistas de operacion</strong>
          </div>
          <div className="barra-horizontal">
            {ESPECIALES.map((v) => (
              <Link key={v.ruta} to={`/vista/${v.ruta}`} className="boton-secundario"
                style={{ textDecoration: "none", color: "inherit", display: "block" }}>
                <strong>{v.titulo}</strong>
                <div style={{ fontSize: 12, color: "var(--texto-suave)", fontWeight: 400 }}>{v.detalle}</div>
              </Link>
            ))}
          </div>
        </div>
      </div>
    </>
  );
}

function Tarjeta({
  rotulo,
  valor,
  pie,
  moneda,
  alerta
}: {
  rotulo: string;
  valor: number | undefined;
  pie: string;
  moneda?: boolean;
  alerta?: boolean;
}) {
  const texto =
    valor === undefined
      ? "..."
      : moneda
        ? valor.toLocaleString("es-PE", { style: "currency", currency: "PEN" })
        : String(valor);
  return (
    <div className="tarjeta">
      <div className="tarjeta-rotulo">{rotulo}</div>
      <div className={`tarjeta-valor${alerta ? " alerta" : ""}`}>{texto}</div>
      <div className="tarjeta-pie">{pie}</div>
    </div>
  );
}
