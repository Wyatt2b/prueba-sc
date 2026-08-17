namespace ReforaTec.Models;

// ============================================================================
//  MODELO: Campania
// ----------------------------------------------------------------------------
//  Una campaña de reforestación (ej. "ReforaTec Primavera 2026"). El coordinador
//  la da de alta y el sistema genera un CÓDIGO compartido (ej. CAMP-4829) que los
//  alumnos usan para auto-inscribirse desde la app móvil.
//
//  Regla de la especificación: cuando la campaña pasa su fecha de fin, cambia
//  sola a INACTIVA (código deshabilitado y edición bloqueada). Aquí eso se
//  calcula solo con la propiedad "EsActiva".
// ============================================================================
public class Campania
{
    public int Id { get; set; }

    // Nombre visible de la campaña.
    public string Nombre { get; set; } = string.Empty;

    // Código alfanumérico único para inscripción (ej. "CAMP-4829").
    public string Codigo { get; set; } = string.Empty;

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    // Institución (inquilino) dueña de la campaña.
    public int InquilinoId { get; set; }

    // ---- Estado calculado ----------------------------------------------------
    // Activa mientras hoy no pase la fecha de fin. No se guarda: se calcula.
    public bool EsActiva => DateTime.Today <= FechaFin.Date;

    // Texto listo para mostrar ("Activa" / "Inactiva").
    public string EstadoTexto => EsActiva ? "Activa" : "Inactiva";
}
