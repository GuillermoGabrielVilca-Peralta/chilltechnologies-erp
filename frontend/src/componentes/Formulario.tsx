import type { Campo } from "../api/modulos";
import type { Catalogos } from "./useCatalogos";

interface Props {
  campos: Campo[];
  valores: Record<string, unknown>;
  catalogos: Catalogos;
  onCambio: (nombre: string, valor: unknown) => void;
}

export function Formulario({ campos, valores, catalogos, onCambio }: Props) {
  return (
    <div className="modal-cuerpo">
      {campos.map((c) => {
        const opciones = catalogos[c.nombre];
        return (
          <div key={c.nombre} className="campo">
            <label htmlFor={c.nombre}>
              {etiqueta(c.nombre)}
              {c.opcional && <span className="campo-opcional"> (opcional)</span>}
            </label>

            {opciones ? (
              <select
                id={c.nombre}
                value={(valores[c.nombre] ?? "") as string | number}
                required={!c.opcional}
                onChange={(e) =>
                  onCambio(c.nombre, e.target.value === "" ? null : Number(e.target.value))
                }
              >
                <option value="">
                  {opciones.size === 0 ? "No hay registros todavia" : "Elegir..."}
                </option>
                {[...opciones.entries()].map(([id, texto]) => (
                  <option key={id} value={id}>
                    {texto}
                  </option>
                ))}
              </select>
            ) : c.tipo === "booleano" ? (
              <input
                id={c.nombre}
                type="checkbox"
                checked={Boolean(valores[c.nombre])}
                onChange={(e) => onCambio(c.nombre, e.target.checked)}
              />
            ) : (
              <input
                id={c.nombre}
                type={tipoHtml(c)}
                value={(valores[c.nombre] ?? "") as string | number}
                required={!c.opcional}
                step={c.tipo === "numero" ? "any" : undefined}
                onChange={(e) =>
                  onCambio(
                    c.nombre,
                    e.target.value === ""
                      ? null
                      : c.tipo === "numero"
                        ? Number(e.target.value)
                        : e.target.value
                  )
                }
              />
            )}
          </div>
        );
      })}
    </div>
  );
}

function tipoHtml(c: Campo): string {
  if (c.tipo === "numero") return "number";
  if (c.tipo === "fecha") return "date";
  if (c.tipo === "fechahora") return "datetime-local";
  const n = c.nombre.toLowerCase();
  if (n.includes("password")) return "password";
  if (n.includes("correo") || n === "email") return "email";
  return "text";
}

export function etiqueta(nombre: string): string {
  const limpio = nombre.replace(/Id$/, "");
  const conEspacios = limpio.replace(/([A-Z])/g, " $1").toLowerCase().trim();
  return conEspacios.charAt(0).toUpperCase() + conEspacios.slice(1);
}
