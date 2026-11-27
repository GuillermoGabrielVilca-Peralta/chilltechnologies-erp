import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import { AuthProvider } from "./auth/AuthContext";
import { RutaProtegida } from "./auth/RutaProtegida";
import { Shell } from "./componentes/Shell";
import { Login } from "./paginas/Login";
import { Dashboard } from "./paginas/Dashboard";
import { PaginaModulo } from "./paginas/PaginaModulo";
import { TableroSprint } from "./paginas/especiales/TableroSprint";
import { FichaProyecto } from "./paginas/especiales/FichaProyecto";
import { Kardex } from "./paginas/especiales/Kardex";
import { LibroCaja } from "./paginas/especiales/LibroCaja";
import { AsientoContable } from "./paginas/especiales/AsientoContable";
import { BandejaTickets } from "./paginas/especiales/BandejaTickets";

export function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route element={<RutaProtegida />}>
            <Route element={<Shell />}>
              <Route path="/" element={<Dashboard />} />
              <Route path="/modulo/:clave" element={<PaginaModulo />} />
              <Route path="/vista/sprint" element={<TableroSprint />} />
              <Route path="/vista/ficha-proyecto" element={<FichaProyecto />} />
              <Route path="/vista/kardex" element={<Kardex />} />
              <Route path="/vista/libro-caja" element={<LibroCaja />} />
              <Route path="/vista/asiento" element={<AsientoContable />} />
              <Route path="/vista/soporte" element={<BandejaTickets />} />
            </Route>
          </Route>
          <Route path="*" element={<Navigate to="/" replace />} />
        </Routes>
      </BrowserRouter>
    </AuthProvider>
  );
}
