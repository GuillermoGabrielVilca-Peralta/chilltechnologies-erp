# ChillTechnologies ERP - Frontend

Frontend del ERP, en React + Vite + TypeScript. Consume la API de
`ChillTechnologies.API`.

## Correr en local

```
npm install
npm run dev
```

Queda en http://localhost:5173 y apunta a la API de `.env.development`.
La API tiene que estar levantada con el perfil `http` (puerto 5081).

## Variables

| Variable       | Para que sirve                  |
|----------------|---------------------------------|
| `VITE_API_URL` | URL base de la API              |

En Vercel se setea `VITE_API_URL` con la URL de Render.
El dominio de Vercel tiene que estar en `Cors__Origenes` de la API.

## Build

```
npm run build
```

Queda en `dist/`.
