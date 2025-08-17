using Microsoft.AspNetCore.Mvc;
using RomiCapaAplicacion.CasosDeUsoInterfaces;
using RomiCapaDominio.Entidades;
using RomiCapaDominio.Entidades.DTOs;

namespace RomiAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteCasos clienteCasos;

    public ClienteController(IClienteCasos clienteCasos)
    {
        this.clienteCasos = clienteCasos;
    }
    
    [HttpPost()]
    public async Task<ActionResult<int>> Post(CrearClienteDTO clienteDTO)
    {
        (int clienteID, string mensaje) respuesta = 
            await clienteCasos.CrearCliente(clienteDTO);
        
        int clienteID = respuesta.clienteID;
        string mensaje = respuesta.mensaje;

        if (clienteID == -1)
        {
            return BadRequest(mensaje);
        }

        return CreatedAtAction(
            actionName: nameof(Get),  
            routeValues: new { id = clienteID },  
            value: new { id = clienteID } 
        );
    }
    
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
    {
        return Ok(await clienteCasos.ConsultarClientes());
    }
    
    [HttpGet("{ID}")]
    public async Task<ActionResult<ClienteDTO>> GetByID(int ID)
    {
        (ClienteDTO? cliente, string mensaje) respuesta = 
            await clienteCasos.ConsultarClientePorID(ID);

        ClienteDTO? cliente = respuesta.cliente;
        string mensaje = respuesta.mensaje;

        if (cliente == null)
        {
            return NotFound(mensaje);
        }

        return Ok(cliente);
    }
}