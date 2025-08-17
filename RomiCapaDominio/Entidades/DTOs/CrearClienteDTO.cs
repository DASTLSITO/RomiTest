namespace RomiCapaDominio.Entidades.DTOs;

public class CrearClienteDTO
{
    public string Nombres { get; set; }
    public string Apellidos  { get; set; }
    public DateTime FechaDeNacimiento { get; set; }
    public char Sexo  { get; set; }
    public string Sintomas { get; set; }
}