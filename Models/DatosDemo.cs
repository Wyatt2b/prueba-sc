namespace ReforaTec.Models;

// ============================================================================
//  DATOS DE PRUEBA: DatosDemo
// ----------------------------------------------------------------------------
//  guardamos aquí datos de ejemplo EN MEMORIA. Todas
//  las pantallas leen y modifican estas mismas listas, así los cambios (crear
//  campaña, asignar árbol, etc.) se ven al navegar entre secciones.
//
// ============================================================================
public static class DatosDemo
{
    // ---- Instituciones (inquilinos) -----------------------------------------
    public static List<Inquilino> Inquilinos { get; } = new()
    {
        new Inquilino { Id = 1, TenantId = "ITCM", Nombre = "Instituto Tecnologico de Ciudad Madero", Ubicacion = "Ciudad Madero", Estatus = EstadoInquilino.Activo },
        new Inquilino { Id = 2, TenantId = "UAT",  Nombre = "Universidad Autonoma de Tamaulipas",      Ubicacion = "Tampico",       Estatus = EstadoInquilino.Activo }
    };

    // ---- Usuarios (coordinadores, inspectores, admin) -----------------------
    public static List<Usuario> Usuarios { get; } = new()
    {
        new Usuario { Id = 1, Nombre = "Admin General",  Correo = "admin@cdmadero.tecnm.mx",       Rol = RolUsuario.AdminSistema, InquilinoId = 0 },
        new Usuario { Id = 2, Nombre = "Danna",          Correo = "coordinador@cdmadero.tecnm.mx", Rol = RolUsuario.Coordinador,  InquilinoId = 1 },
        new Usuario { Id = 3, Nombre = "Luis Inspector", Correo = "inspector1@cdmadero.tecnm.mx",  Rol = RolUsuario.Inspector,    InquilinoId = 1 }
    };

    // ---- Campanias -----------------------------------------------------------
    public static List<Campania> Campanias { get; } = new()
    {
        new Campania { Id = 1, Nombre = "ReforaTec Primavera 2026", Codigo = "CAMP-4829", FechaInicio = new DateTime(2026, 2, 1), FechaFin = new DateTime(2026, 12, 15), InquilinoId = 1 },
        new Campania { Id = 2, Nombre = "ReforaTec Otono 2025",     Codigo = "CAMP-1073", FechaInicio = new DateTime(2025, 8, 1), FechaFin = new DateTime(2025, 12, 1),  InquilinoId = 1 }
    };

    // ---- Arboles -------------------------------------------------------------
    public static List<Arbol> Arboles { get; } = new()
    {
        new Arbol { Id = 1, Especie = "Encino",    Ubicacion = "Parque Central, sector A", Salud = EstadoSalud.Saludable,     CampaniaId = 1 },
        new Arbol { Id = 2, Especie = "Mezquite",  Ubicacion = "Rivera del rio, tramo 3",  Salud = EstadoSalud.EnObservacion, CampaniaId = 1 },
        new Arbol { Id = 3, Especie = "Roble",     Ubicacion = "Primaria, patio norte",    Salud = EstadoSalud.Critico,       CampaniaId = 1 },
        new Arbol { Id = 4, Especie = "Jacaranda", Ubicacion = "Avenida principal",        Salud = EstadoSalud.Saludable,     CampaniaId = 1 }
    };

    // ---- Alumnos -------------------------------------------------------------
    public static List<Alumno> Alumnos { get; } = new()
    {
        new Alumno { Id = 1, Nombre = "Maria Lopez",  NumeroControl = "20070123", Telefono = "833-111-2233", CampaniaId = 1, ArbolId = 1 },
        new Alumno { Id = 2, Nombre = "Juan Perez",   NumeroControl = "20070124", Telefono = "833-222-3344", CampaniaId = 1, ArbolId = null },
        new Alumno { Id = 3, Nombre = "Ana Martinez", NumeroControl = "20070125", Telefono = "833-333-4455", CampaniaId = 1, ArbolId = null }
    };

    // ------------------------------------------------------------------------
    //  AYUDANTES
    // ------------------------------------------------------------------------

    // Devuelve el siguiente Id disponible para una lista (mayor actual + 1).
    public static int SiguienteId(IEnumerable<int> ids)
        => ids.Any() ? ids.Max() + 1 : 1;

    // Genera un codigo de campana tipo "CAMP-####" con 4 digitos al azar.
    // (Es solo para la demo; el codigo unico definitivo lo dara el backend.)
    public static string GenerarCodigoCampania()
    {
        var numero = Random.Shared.Next(1000, 9999);
        return $"CAMP-{numero}";
    }
}
