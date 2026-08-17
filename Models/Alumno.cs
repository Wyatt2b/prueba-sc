namespace ReforaTec.Models;

// ============================================================================
//  MODELO: Alumno
// ----------------------------------------------------------------------------
//  Un alumno inscrito en una campaña. Guardamos los datos que pide la
//  exportación CSV (nombre, número de control, teléfono) y a qué árbol está
//  asignado (si es que ya tiene uno).
// ============================================================================
public class Alumno
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    // Número de control (matrícula escolar).
    public string NumeroControl { get; set; } = string.Empty;

    public string Telefono { get; set; } = string.Empty;

    // Campaña en la que está inscrito.
    public int CampaniaId { get; set; }

    // Árbol asignado. Es "int?" (nullable): null significa que TODAVÍA no tiene
    // árbol asignado. La pantalla de Asignaciones sirve justo para llenar esto.
    public int? ArbolId { get; set; }

    // Ayuda visual: ¿ya tiene árbol asignado?
    public bool TieneArbol => ArbolId.HasValue;
}
