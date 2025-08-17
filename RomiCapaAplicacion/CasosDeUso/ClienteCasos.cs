using RomiCapaAplicacion.CasosDeUsoInterfaces;
using RomiCapaAplicacion.Interfaces;
using RomiCapaDominio.Entidades;
using RomiCapaDominio.Entidades.DTOs;
using static RomiCapaDominio.ReglasDeNegocio.ClienteReglas;

namespace RomiCapaAplicacion.CasosDeUso;

public class ClienteCasos : IClienteCasos
{
    private readonly IClienteRepositorio clienteRepositorio;
    
    public ClienteCasos(IClienteRepositorio clienteRepositorio)
    {
        this.clienteRepositorio =  clienteRepositorio;
    }
    
    public async Task<(int clienteID, string mensaje)>
        CrearCliente(CrearClienteDTO crearClienteDto)
    {
        if (!NombreCompletoEsValido(crearClienteDto.Nombres, crearClienteDto.Apellidos))
        {
            return (-1, "Nombres y/o apellidos no validos");
        }
        
        if (!EdadEsValida(crearClienteDto.FechaDeNacimiento))
        {
            return (-1, "Fecha de nacimiento no valida. Minimo 18 años o mas");
        }
        
        if (!SexoValido(crearClienteDto.Sexo))
        {
            return (-1, "Sexo no valido, solo M o F");
        }
        
        if (!SintomasSonValidos(crearClienteDto.Sintomas))
        {
            return (-1, "Sintomas no validos, minimo de 3 caracteres, maximo de 500");
        }

        Cliente cliente = Mapeos.ClienteMapeos.ConvertirAEntidad(crearClienteDto);
        int clienteID = await clienteRepositorio.Crear(cliente);

        return (clienteID, "Cliente creado exitosamente");
    }
    
    public async Task<List<ClienteDTO>>
        ConsultarClientes()
    {
        List<Cliente> clientes = await clienteRepositorio.ObtenerTodos();
        List<ClienteDTO> clientesDTO = new List<ClienteDTO>();
        
        foreach (Cliente cliente in clientes)
        {
            ClienteDTO clienteDTO = Mapeos.ClienteMapeos.ConvertirADTO(cliente);
            clientesDTO.Add(clienteDTO);
        }
    
        return clientesDTO;
    }
    
    public async Task<(ClienteDTO cliente, string mensaje)>
        ConsultarClientePorID(int clienteID)
    {
        Cliente? cliente = await clienteRepositorio.ObtenerPorID(clienteID);

        if (cliente == null)
        {
            return (null, "Cliente no encontrado");
        }
        
        ClienteDTO clienteDTO = Mapeos.ClienteMapeos.ConvertirADTO(cliente);
    
        return (clienteDTO, "Cliente retornado exitosamente");
    }
}