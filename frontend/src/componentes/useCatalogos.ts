import { useEffect, useState } from "react";
import { api } from "../api/cliente";
import { RELACIONES, cargarCatalogo } from "../api/relaciones";

export type Catalogos = Record<string, Map<number, string>>;

export function useCatalogos(claveModulo: string): Catalogos {
  const [catalogos, setCatalogos] = useState<Catalogos>({});

  useEffect(() => {
    let vigente = true;
    const relaciones = RELACIONES[claveModulo];
    if (!relaciones) {
      setCatalogos({});
      return;
    }

    const campos = Object.keys(relaciones);
    Promise.all(
      campos.map((campo) =>
        cargarCatalogo(relaciones[campo], (ruta) =>
          api.get<Record<string, unknown>[]>(ruta)
        )
      )
    ).then((mapas) => {
      if (!vigente) return;
      const siguiente: Catalogos = {};
      campos.forEach((campo, i) => {
        siguiente[campo] = mapas[i];
      });
      setCatalogos(siguiente);
    });

    return () => {
      vigente = false;
    };
  }, [claveModulo]);

  return catalogos;
}
