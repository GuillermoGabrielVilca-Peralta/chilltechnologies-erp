import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "./AuthContext";

export function RutaProtegida() {
  const { sesion, cargando } = useAuth();
  if (cargando) return <div className="cargando-pantalla">Cargando...</div>;
  if (!sesion) return <Navigate to="/login" replace />;
  return <Outlet />;
}
