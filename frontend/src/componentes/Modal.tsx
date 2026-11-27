import type { ReactNode } from "react";

interface Props {
  titulo: string;
  onCerrar: () => void;
  children: ReactNode;
  pie: ReactNode;
}

export function Modal({ titulo, onCerrar, children, pie }: Props) {
  return (
    <div className="modal-fondo" onClick={onCerrar}>
      <div className="modal" onClick={(e) => e.stopPropagation()}>
        <div className="modal-encabezado">
          <h2>{titulo}</h2>
          <button type="button" className="boton-mini" onClick={onCerrar}>
            Cerrar
          </button>
        </div>
        {children}
        <div className="modal-pie">{pie}</div>
      </div>
    </div>
  );
}
