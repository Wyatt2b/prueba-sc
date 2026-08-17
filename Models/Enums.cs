namespace ReforaTec.Models;

// ============================================================================
//  ENUMS DEL PORTAL
// ----------------------------------------------------------------------------
//  Un enum es una lista cerrada de valores posibles. Los juntamos aquí para
//  tenerlos en un solo lugar y que el resto del proyecto siempre use valores
//  válidos (evita errores de dedo tipo "Activoo" o "coordinadorr").
// ============================================================================

// Roles que puede tener un usuario dentro del sistema.
// Solo los dos primeros pueden entrar al PORTAL WEB (admin). Alumno e Inspector
// usan la app móvil, aquí solo se listan para el mensaje "Rol No Autorizado".
public enum RolUsuario
{
    AdminSistema,   // máximo nivel: administra instituciones y coordinadores
    Coordinador,    // administra campañas, árboles, inspectores de SU institución
    Inspector,      // (app móvil) revisa árboles en campo
    Alumno          // (app móvil) cuida un árbol
}

// Estado de salud de un árbol (lo reporta la inspección de campo).
public enum EstadoSalud
{
    Saludable,
    EnObservacion,
    Critico
}

// Estado de una institución (inquilino) dentro de la plataforma.
public enum EstadoInquilino
{
    Activo,
    Inactivo
}
