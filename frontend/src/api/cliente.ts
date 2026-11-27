const BASE = import.meta.env.VITE_API_URL ?? "http://localhost:5081";

const CLAVE_TOKEN = "erp_token";

export function guardarToken(token: string) {
  localStorage.setItem(CLAVE_TOKEN, token);
}

export function leerToken(): string | null {
  return localStorage.getItem(CLAVE_TOKEN);
}

export function borrarToken() {
  localStorage.removeItem(CLAVE_TOKEN);
}

export class ErrorApi extends Error {
  constructor(public status: number, mensaje: string) {
    super(mensaje);
  }
}

let alExpirar: (() => void) | null = null;

export function registrarExpiracion(fn: () => void) {
  alExpirar = fn;
}

async function pedir<T>(metodo: string, ruta: string, cuerpo?: unknown): Promise<T> {
  const cabeceras: Record<string, string> = { "Content-Type": "application/json" };
  const token = leerToken();
  if (token) cabeceras["Authorization"] = `Bearer ${token}`;

  let respuesta: Response;
  try {
    respuesta = await fetch(`${BASE}${ruta}`, {
      method: metodo,
      headers: cabeceras,
      body: cuerpo === undefined ? undefined : JSON.stringify(cuerpo)
    });
  } catch {
    throw new ErrorApi(0, "No se pudo contactar la API. Revisa que este levantada.");
  }

  if (respuesta.status === 401) {
    borrarToken();
    alExpirar?.();
    throw new ErrorApi(401, "Tu sesion expiro. Vuelve a entrar.");
  }

  if (respuesta.status === 204) return undefined as T;

  const texto = await respuesta.text();
  let datos: unknown = null;
  if (texto) {
    try {
      datos = JSON.parse(texto);
    } catch {
      datos = texto;
    }
  }

  if (!respuesta.ok) {
    throw new ErrorApi(respuesta.status, extraerMensaje(datos, respuesta.status));
  }

  return datos as T;
}

function extraerMensaje(datos: unknown, status: number): string {
  if (datos && typeof datos === "object") {
    const d = datos as Record<string, unknown>;
    if (typeof d.mensaje === "string") return d.mensaje;
    if (typeof d.title === "string") {
      const errores = d.errors as Record<string, string[]> | undefined;
      if (errores) {
        const detalle = Object.values(errores).flat().join(" ");
        if (detalle) return detalle;
      }
      return d.title;
    }
  }
  if (typeof datos === "string" && datos) return datos;
  return `La API respondio ${status}.`;
}

export const api = {
  get: <T>(ruta: string) => pedir<T>("GET", ruta),
  post: <T>(ruta: string, cuerpo: unknown) => pedir<T>("POST", ruta, cuerpo),
  put: <T>(ruta: string, cuerpo: unknown) => pedir<T>("PUT", ruta, cuerpo),
  patch: <T>(ruta: string, cuerpo: unknown) => pedir<T>("PATCH", ruta, cuerpo),
  del: <T>(ruta: string) => pedir<T>("DELETE", ruta)
};
