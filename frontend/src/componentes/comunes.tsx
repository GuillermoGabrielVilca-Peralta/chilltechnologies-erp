import type { ReactNode } from "react";

export function Encabezado({ titulo, detalle, acciones }: { titulo: string; detalle?: string; acciones?: ReactNode }) {
  return (
    <div className="pagina-encabezado">
      <div>
        <h1>{titulo}</h1>
        {detalle && <p>{detalle}</p>}
      </div>
      {acciones}
    </div>
  );
}

export function Selector<T extends { id: number }>({
  rotulo,
  opciones,
  valor,
  onCambio,
  texto
}: {
  rotulo: string;
  opciones: T[];
  valor: number | null;
  onCambio: (id: number) => void;
  texto: (t: T) => string;
}) {
  return (
    <div className="selector-linea">
      <label>{rotulo}</label>
      <select value={valor ?? ""} onChange={(e) => onCambio(Number(e.target.value))}>
        {opciones.length === 0 && <option value="">No hay registros</option>}
        {opciones.map((o) => (
          <option key={o.id} value={o.id}>
            {texto(o)}
          </option>
        ))}
      </select>
    </div>
  );
}

export function Aviso({ children }: { children: ReactNode }) {
  return <div className="vacio">{children}</div>;
}

export function soles(n: number): string {
  return n.toLocaleString("es-PE", { style: "currency", currency: "PEN" });
}

export function fecha(valor: string | null | undefined): string {
  if (!valor) return "—";
  return valor.slice(0, 16).replace("T", " ");
}
