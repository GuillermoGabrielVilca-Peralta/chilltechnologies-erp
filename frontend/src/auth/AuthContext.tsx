import { createContext, useContext, useEffect, useMemo, useState, type ReactNode } from "react";
import { api, borrarToken, guardarToken, leerToken, registrarExpiracion } from "../api/cliente";
import type { LoginResponse } from "../api/tipos";

interface Sesion {
  usuarioSistemaId: number;
  username: string;
  empleadoId: number;
  roles: string[];
}

interface Contexto {
  sesion: Sesion | null;
  cargando: boolean;
  entrar: (username: string, password: string) => Promise<void>;
  salir: () => void;
}

const CLAVE_SESION = "erp_sesion";
const AuthContext = createContext<Contexto | null>(null);

export function AuthProvider({ children }: { children: ReactNode }) {
  const [sesion, setSesion] = useState<Sesion | null>(null);
  const [cargando, setCargando] = useState(true);

  useEffect(() => {
    const guardada = localStorage.getItem(CLAVE_SESION);
    if (guardada && leerToken()) {
      try {
        setSesion(JSON.parse(guardada));
      } catch {
        localStorage.removeItem(CLAVE_SESION);
      }
    }
    setCargando(false);
    registrarExpiracion(() => {
      localStorage.removeItem(CLAVE_SESION);
      setSesion(null);
    });
  }, []);

  async function entrar(username: string, password: string) {
    const r = await api.post<LoginResponse>("/api/Auth/login", { username, password });
    guardarToken(r.token);
    const nueva: Sesion = {
      usuarioSistemaId: r.usuarioSistemaId,
      username: r.username,
      empleadoId: r.empleadoId,
      roles: r.roles
    };
    localStorage.setItem(CLAVE_SESION, JSON.stringify(nueva));
    setSesion(nueva);
  }

  function salir() {
    borrarToken();
    localStorage.removeItem(CLAVE_SESION);
    setSesion(null);
  }

  const valor = useMemo(() => ({ sesion, cargando, entrar, salir }), [sesion, cargando]);

  return <AuthContext.Provider value={valor}>{children}</AuthContext.Provider>;
}

export function useAuth() {
  const ctx = useContext(AuthContext);
  if (!ctx) throw new Error("useAuth tiene que usarse dentro de AuthProvider");
  return ctx;
}
