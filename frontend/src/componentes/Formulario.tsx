import type { Campo } from "../api/modulos";

interface Props {
  campos: Campo[];
  valores: Record<string, unknown>;
  onCambio: (nombre: string, valor: unknown) => void;
}

export function Formulario({ campos, valores, onCambio }: Props) {
  return (
    <div className="modal-cuerpo">
      {campos.map((c) => (
        <div key={c.nombre} className={`campo${c.tipo === "booleano" ? "" : ""}`}>
          <label htmlFor={c.nombre}>
            {etiqueta(c.nombre)}
            {c.opcional && <span className="campo-opcional"> (opcional)</span>}
          </label>
          {c.tipo === "booleano" ? (
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
                  c.tipo === "numero"
                    ? e.target.value === ""
                      ? null
                      : Number(e.target.value)
                    : e.target.value === ""
                      ? null
                      : e.target.value
                )
              }
            />
          )}
        </div>
      ))}
    </div>
  );
}

function tipoHtml(c: Campo): string {
  if (c.tipo === "numero") return "number";
  if (c.tipo === "fecha") return "date";
  if (c.tipo === "fechahora") return "datetime-local";
  if (c.nombre.toLowerCase().includes("password")) return "password";
  if (c.nombre.toLowerCase().includes("correo") || c.nombre.toLowerCase() === "email") return "email";
  return "text";
}

export function etiqueta(nombre: string): string {
  const conEspacios = nombre.replace(/([A-Z])/g, " $1").toLowerCase().trim();
  return conEspacios.charAt(0).toUpperCase() + conEspacios.slice(1);
}
