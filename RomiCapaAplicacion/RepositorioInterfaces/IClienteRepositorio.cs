using RomiCapaDominio.Entidades;

namespace RomiCapaAplicacion.Interfaces;

public interface IClienteRepositorio
{
    public Task<int> Crear(Cliente cliente);
    public Task<Cliente?> ObtenerPorID(int id);
    public Task<List<Cliente>> ObtenerTodos();
}