using Microsoft.EntityFrameworkCore;
using RomiCapaAplicacion.Interfaces;
using RomiCapaDominio.Entidades;

namespace RomiCapaInfraestructura.Repositorios;

public class ClienteRepositorio: IClienteRepositorio
{
    private readonly ApplicationDbContext context;

    public ClienteRepositorio(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<int> Crear(Cliente cliente)
    {
        context.Add(cliente);
        await context.SaveChangesAsync();
        return cliente.ID;
    }

    public async Task<Cliente?> ObtenerPorID(int id)
    {
        return await context.Cliente.FirstOrDefaultAsync(c => c.ID == id);
    }

    public async Task<List<Cliente>> ObtenerTodos()
    {
        return await context.Cliente.ToListAsync();
    }
}