using RomiCapaDominio.Entidades;
using RomiCapaDominio.Entidades.DTOs;
using RomiCapaDominio.Helpers;

namespace RomiCapaAplicacion.Mapeos;

public static class ClienteMapeos
{
    public static ClienteDTO ConvertirADTO(Cliente cliente)
    {
        return new ClienteDTO
        {
            Nombres = cliente.Nombres,
            Apellidos = cliente.Apellidos,
            Edad = EdadHelpers.FechaDeNacimientoAEdad(cliente.FechaDeNacimiento),
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
}