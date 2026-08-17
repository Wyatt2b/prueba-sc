namespace ReforaTec.Models;

// ============================================================================
//  ESTADO DE LA APP (solo frontend / demo): AppState
// ----------------------------------------------------------------------------
//  Como el backend lo hace otra persona, aquí simulamos la "sesión": si el
//  usuario ya inició sesión y con qué ROL. Esto nos permite que el menú y el
//  dashboard cambien según el rol, tal como pide la especificación, SIN tener
//  todavía el login real con JWT.
//
//  Cuando el backend esté listo, este archivo se reemplaza por el rol real que
//  venga dentro del token JWT.
//
//  Es "static" para que TODAS las pantallas compartan el mismo estado sin tener
//  que configurar inyección de dependencias en Program.cs.
// ============================================================================
public static class AppState
{
    // ¿El usuario ya pasó el login?
    public static bool Autenticado { get; private set; }

    // Rol con el que entró (define qué secciones ve).
    public static RolUsuario RolActual { get; private set; } = RolUsuario.Coordinador;

    // Correo con el que inició sesión (solo para mostrarlo en la barra superior).
    public static string CorreoActual { get; private set; } = string.Empty;

    // Evento para avisar a los componentes que algo cambió y deben redibujarse.
    // (El layout se suscribe y llama StateHasChanged cuando esto se dispara.)
    public static event Action? OnCambio;

    // Iniciar sesión (simulado): guardamos rol y correo, marcamos autenticado.
    public static void IniciarSesion(RolUsuario rol, string correo)
    {
        Autenticado = true;
        RolActual = rol;
        CorreoActual = correo;
        OnCambio?.Invoke();
    }

    // Cerrar sesión.
    public static void CerrarSesion()
    {
        Autenticado = false;
        CorreoActual = string.Empty;
        OnCambio?.Invoke();
    }
}