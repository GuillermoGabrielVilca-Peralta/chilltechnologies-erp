export interface LoginResponse {
  token: string;
  expira: string;
  usuarioSistemaId: number;
  username: string;
  empleadoId: number;
  roles: string[];
}

export interface UsuarioSistemaResponse {
  id: number;
  empleadoId: number;
  empleadoNombre: string;
  username: string;
  estado: string;
  ultimoAcceso: string | null;
  fechaRegistro: string;
  roles: string[];
}

export interface UsuarioResponse {
  id: number;
  nombres: string;
  apellidos: string;
  nombreCompleto: string;
  correo: string;
  telefono: string | null;
  fotoPerfil: string | null;
  planId: number;
  planNombre: string;
  tipoConductorId: number;
  tipoConductorNombre: string;
  empresaId: number | null;
  empresaRazonSocial: string | null;
  estado: string;
  ultimoAcceso: string | null;
  fechaRegistro: string;
}
