using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Models;
using EntregaSegura.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EntregaSegura.Data.Repositories;

/// <summary>
/// Repositório para a entidade Condominio
/// </summary>
public class CondominioRepository : Repository<Condominio>, ICondominioRepository
{
    /// <summary>
    /// Construtor padrão que recebe o contexto do banco de dados
    /// </summary>
    public CondominioRepository(EntregaSeguraContext context) : base(context) { }

    /// <summary>
    /// Método para obter um condomínio com o endereço
    /// </summary>
    /// <param name="condominioId">Id do condomínio</param>
    /// <returns>Condomínio com o endereço</returns>
    public async Task<Condominio> ObterCondominioComEndereco(Guid condominioId)
    {
        return await _context.Condominios
            .AsNoTracking()
            .Include(c => c.Endereco)
            .FirstOrDefaultAsync(c => c.Id == condominioId);
    }

    /// <summary>
    /// Método para obter um condomínio com as unidades
    /// </summary>
    /// <param name="id">Id do condomínio</param>
    /// <returns>Condomínio com as unidades</returns>
    public Task<Condominio> ObterCondominioComUnidades(Guid id)
    {
        return _context.Condominios
            .AsNoTracking()
            .Include(c => c.Unidades)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    /// <summary>
    /// Método para obter todos os condomínios com o endereço
    /// </summary>
    /// <returns>Lista de condomínios com o endereço</returns>
    public Task<List<Condominio>> ObterTodosCondominioscomEndereco()
    {
        return _context.Condominios
            .AsNoTracking()
            .Include(c => c.Endereco)
            .ToListAsync();
    }

    /// <summary>
    /// Método para obter todos os condomínios com as unidades
    /// </summary>
    /// <returns>Lista de condomínios com as unidades</returns>
    public Task<List<Condominio>> ObterTodosCondominioscomUnidades()
    {
        return _context.Condominios
            .AsNoTracking()
            .Include(c => c.Unidades)
            .ToListAsync();
    }
}
