using RomiCapaDominio.Entidades;
using RomiCapaDominio.Entidades.DTOs;

namespace RomiCapaAplicacion.Mapeos;

public static class ClienteMapeos
{
    public static ClienteDTO ConvertirADTO(Cliente cliente)
    {
        return new ClienteDTO
        {
            Nombres = cliente.Nombres,
            Apellidos = cliente.Apellidos,
            Edad = CalcularEdad(cliente.FechaDeNacimiento),
            Sexo = cliente.Sexo,
            Sintomas = cliente.Sintomas
        };
    }
    
    public static Cliente ConvertirAEntidad(CrearClienteDTO clienteDTO)
    {
        return new Cliente
        {
            Nombres = clienteDTO.Nombres,
            Apellidos = clienteDTO.Apellidos,
            FechaDeNacimiento = clienteDTO.FechaDeNacimiento,
            Sexo = clienteDTO.Sexo,
            Sintomas = clienteDTO.Sintomas
        };
    }
    
    private static int CalcularEdad(DateTime fechaNacimiento)
    {
        DateTime fechaActual = DateTime.Today; 
        
        int edad = fechaActual.Year - fechaNacimiento.Year;
        
        if (fechaNacimiento.Date > fechaActual.AddYears(-edad))
        {
            edad--;
        }
        
        return edad;
    }
}