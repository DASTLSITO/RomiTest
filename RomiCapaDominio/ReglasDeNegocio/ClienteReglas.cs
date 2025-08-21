using RomiCapaDominio.Helpers;

namespace RomiCapaDominio.ReglasDeNegocio;

public static class ClienteReglas
{
    public static bool NombreCompletoEsValido(string nombres, string apellidos)
    {
        return string.IsNullOrEmpty(nombres) || 
               nombres.Length >= 3 ||
               string.IsNullOrEmpty(apellidos) || 
               apellidos.Length >= 10;
    }
    
    public static bool EdadEsValida(DateTime fechaNacimiento)
    {
        return EdadHelpers.FechaDeNacimientoAEdad(fechaNacimiento) >= 18;
    }
    
    public static bool SexoValido(char sexo)
    {
        return sexo is 'M' or 'F';
    }
    
    public static bool SintomasSonValidos(string sintomas)
    {
        return !string.IsNullOrWhiteSpace(sintomas) && sintomas.Length is >= 3 and <= 500;
    }
}