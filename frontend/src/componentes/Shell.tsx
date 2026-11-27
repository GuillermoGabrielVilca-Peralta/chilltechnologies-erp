import { useState } from "react";
import { Link, NavLink, Outlet, useLocation } from "react-router-dom";
import { AREAS, modulosDeArea } from "../api/modulos";
import { ESPECIALES } from "../api/especiales";
import { useAuth } from "../auth/AuthContext";

export function Shell() {
  const { sesion, salir } = useAuth();
  const ubicacion = useLocation();
  const [abiertas, setAbiertas] = useState<string[]>(() => [AREAS[0]]);
  const [filtro, setFiltro] = useState("");

  function alternar(area: string) {
    setAbiertas((prev) =>
      prev.includes(area) ? prev.filter((a) => a !== area) : [...prev, area]
    );
  }

  const busqueda = filtro.trim().toLowerCase();

  return (
    <div className="shell">
      <aside className="barra-lateral">
        <Link to="/" className="marca">
          <span className="marca-logo">CT</span>
          <span className="marca-texto">ChillTechnologies</span>
        </Link>

        <input
          className="buscador-menu"
          placeholder="Buscar modulo..."
          value={filtro}
          onChange={(e) => setFiltro(e.target.value)}
        />

        <nav className="menu">
          <NavLink to="/" className="menu-enlace menu-destacado" end>
            Dashboard
          </NavLink>

          {(() => {
            const vistas = ESPECIALES.filter((v) =>
              busqueda ? v.titulo.toLowerCase().includes(busqueda) : true
            );
            if (vistas.length === 0) return null;
            return (
              <div className="menu-grupo">
                <div className="menu-area" style={{ cursor: "default" }}>
                  <span>Operacion</span>
                  <span className="menu-contador">{vistas.length}</span>
                </div>
                <div className="menu-items">
                  {vistas.map((v) => (
                    <NavLink key={v.ruta} to={`/vista/${v.ruta}`} className="menu-enlace">
                      {v.titulo}
                    </NavLink>
                  ))}
                </div>
              </div>
            );
          })()}

          {AREAS.map((area) => {
            const modulos = modulosDeArea(area).filter((m) =>
              busqueda ? m.titulo.toLowerCase().includes(busqueda) : true
            );
            if (modulos.length === 0) return null;
            const abierta = busqueda ? true : abiertas.includes(area);
            return (
              <div key={area} className="menu-grupo">
                <button
                  type="button"
                  className="menu-area"
                  onClick={() => alternar(area)}
                >
                  <span>{area}</span>
                  <span className="menu-contador">{modulos.length}</span>
                </button>
                {abierta && (
                  <div className="menu-items">
                    {modulos.map((m) => (
                      <NavLink
                        key={m.clave}
                        to={`/modulo/${m.clave}`}
                        className="menu-enlace"
                      >
                        {m.titulo}
                      </NavLink>
                    ))}
                  </div>
                )}
              </div>
            );
          })}
        </nav>
      </aside>

      <div className="contenido">
        <header className="barra-superior">
          <div className="ruta-actual">
            {ubicacion.pathname === "/" ? "Dashboard" : "Modulos"}
          </div>
          <div className="usuario">
            <div className="usuario-datos">
              <strong>{sesion?.username}</strong>
              <span>{sesion?.roles.join(", ") || "sin roles"}</span>
            </div>
            <button type="button" className="boton-secundario" onClick={salir}>
              Salir
            </button>
          </div>
        </header>

        <main className="area-trabajo">
          <Outlet />
        </main>
      </div>
    </div>
  );
}
