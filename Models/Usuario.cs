namespace ReforaTec.Models;

// ============================================================================
//  MODELO: Usuario
// ----------------------------------------------------------------------------
//  Representa a las personas del sistema que se identifican por CORREO
//  institucional: Administradores, Coordinadores e Inspectores.
//  (Los alumnos tienen su propia clase Alumno porque guardamos datos extra
//   como número de control y el árbol que cuidan.)
//
//  El "InquilinoId" es a qué institución pertenece el usuario. El Administrador
//  del Sistema es global, así que puede no tener inquilino (InquilinoId = 0).
// ============================================================================
public class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    // Correo institucional (sirve como identificador para el login por OTP).
    public string Correo { get; set; } = string.Empty;

    public RolUsuario Rol { get; set; }

    // Institución a la que pertenece (0 = global / sin inquilino).
    public int InquilinoId { get; set; }

    // Rol en texto amigable para mostrar en pantalla.
    public string RolTexto => Rol switch
    {
        RolUsuario.AdminSistema => "Administrador del Sistema",
        RolUsuario.Coordinador  => "Coordinador de Campaña",
        RolUsuario.Inspector    => "Inspector de Campo",
        RolUsuario.Alumno       => "Alumno",
        _                       => "Desconocido"
    };
}
