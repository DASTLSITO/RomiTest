using RomiCapaAplicacion.Interfaces;
using RomiCapaDominio.Entidades.DTOs;

namespace RomiCapaAplicacion.CasosDeUsoInterfaces;

public interface IClienteCasos
{
    public Task<(int clienteID, string mensaje)>
        CrearCliente(CrearClienteDTO crearClienteDto);

    public Task<List<ClienteDTO>>
        ConsultarClientes();

    public Task<(ClienteDTO cliente, string mensaje)>
        ConsultarClientePorID(int clienteID);
}