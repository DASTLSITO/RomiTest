namespace RomiCapaDominio.Helpers;

public static class EdadHelpers
{
    public static int FechaDeNacimientoAEdad(DateTime fechaNacimiento)
    {
        int edad = DateTime.UtcNow.Year - fechaNacimiento.Year;
        
        if (fechaNacimiento.Date > DateTime.UtcNow.AddYears(-edad))
        {
            edad--;
        }
        
        return edad;
    }
}