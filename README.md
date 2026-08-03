# StaffCore RD

**Nombre:** Jeiferson David Paez

**Matrícula:** jp2024-0449

**Materia:** ISW-311 Tecnologías de Internet I

**Práctica:** Sistema de Gestión de Staff — StaffCore RD

## Repositorio

https://github.com/NEW-Jeiferson/StaffCoreRD

## Credenciales de usuarios de prueba

| Rol | Correo | Contraseña |
|---|---|---|
| 🛡️ Administrador | `administrador@gmail.com` | `123456zpz` |
| 👔 RRHH | `recursoshumanos@staffcorerd.com` | `123456zpz57` |
| 👁️ Viewer | `viwer@staffcorerd.com` | `123456zpz57` |

> El usuario **Administrador** quedó asignado automáticamente a ese rol por ser el primero en registrarse en el sistema (lógica en `AccountController.cs`). El usuario **RRHH** fue registrado normalmente (quedando como Viewer por defecto) y luego reasignado al rol `RRHH` manualmente vía SQL, ya que el flujo de registro solo distingue entre Administrador (primer usuario) y Viewer (los demás).

## 🛡️ Roles del sistema

| Rol | Ver listado | Crear | Editar | Eliminar | Gestionar usuarios |
|---|---|---|---|---|---|
| Administrador | ✅ | ✅ | ✅ | ✅ | ✅ |
| RRHH | ✅ | ✅ | ✅ | ❌ | ❌ |
| Viewer | ✅ | ❌ | ❌ | ❌ | ❌ |

## Tecnologías

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core (Code First)
- ASP.NET Identity (autenticación y roles)
- SQL Server LocalDB
