namespace ReforaTec.Models;

// ============================================================================
//  MODELO: Arbol
// ----------------------------------------------------------------------------
//  Representa UN árbol registrado. En el portal, el coordinador asigna árboles
//  disponibles a los alumnos de una campaña (ver pantalla "Asignaciones").
//
//  El enum EstadoSalud ahora vive en Enums.cs (lo compartimos con otras clases).
// ============================================================================
public class Arbol
{
    public int Id { get; set; }

    // Especie (ej. "Encino", "Mezquite").
    public string Especie { get; set; } = string.Empty;

    // Dónde está plantado.
    public string Ubicacion { get; set; } = string.Empty;

    // Estado de salud reportado por los inspectores.
    public EstadoSalud Salud { get; set; }

    // Id de la campaña a la que pertenece el árbol (0 = sin campaña).
    public int CampaniaId { get; set; }

    // Texto corto y legible para mostrar el árbol en listas y menús.
    public string Etiqueta => $"#{Id} · {Especie} ({Ubicacion})";
}
