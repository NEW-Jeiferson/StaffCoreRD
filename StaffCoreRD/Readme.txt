Nombre: Jeiferson David Paez
Matrícula: jp2024-0449
Materia: ISW-311 Tecnologías de Internet I
Práctica: StaffCore RD - Sistema de Gestión de Staff

Repositorio de GitHub:
https://github.com/NEW-Jeiferson/StaffCoreRD

Credenciales de usuarios de prueba:

Rol             Correo                              Contraseña
Administrador   administrador@gmail.com             123456zpz
RRHH            recursoshumanos@staffcorerd.com     123456zpz57
Viewer          viwer@staffcorerd.com               123456zpz57

Nota: el usuario Administrador quedó asignado automáticamente a ese
rol por ser el primero en registrarse en el sistema. El usuario RRHH
fue registrado normalmente (quedando como Viewer por defecto) y luego
reasignado al rol "RRHH" manualmente en la base de datos vía SQL,
ya que el flujo de registro solo distingue entre Administrador
(primer usuario) y Viewer (todos los demás).

Roles del sistema:

Rol             Ver listado   Crear   Editar   Eliminar   Gestionar usuarios
Administrador   Si            Si      Si       Si         Si
RRHH            Si            Si      Si       No         No
Viewer          Si            No      No       No         No