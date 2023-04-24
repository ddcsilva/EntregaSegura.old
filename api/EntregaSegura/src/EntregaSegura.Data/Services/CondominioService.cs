using EntregaSegura.Business.Interfaces;
using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Interfaces.Services;
using EntregaSegura.Business.Models;
using EntregaSegura.Business.Validations;

namespace EntregaSegura.Business.Services;

/// <summary>
/// Classe de serviço para a entidade Condominio
/// </summary>
public class CondominioService : BaseService, ICondominioService
{
    private readonly ICondominioRepository _condominioRepository;
    private readonly IEnderecoRepository _enderecoRepository;

    /// <summary>
    /// Construtor padrão que recebe o repositório de condomínio e o repositório de endereço
    /// </summary>
    public CondominioService(ICondominioRepository condominioRepository,
                             IEnderecoRepository enderecoRepository,
                             INotificador notificador) : base(notificador)
    {
        _condominioRepository = condominioRepository;
        _enderecoRepository = enderecoRepository;
    }

    /// <summary>
    /// Método para Adicionar um condomínio
    /// </summary>
    /// <param name="condominio">Condomínio a ser adicionado</param>
    public async Task Adicionar(Condominio condominio)
    {
        if (!ExecutarValidacao(new CondominioValidation(), condominio))
        {
            return;
        }

        if (!ExecutarValidacao(new EnderecoValidation(), condominio.Endereco))
        {
            return;
        }

        if (_condominioRepository.Buscar(c => c.CNPJ == condominio.CNPJ).Result.Any())
        {
            Notificar("Já existe um condomínio com este CNPJ.");
            return;
        }

        if (_condominioRepository.Buscar(c => c.Nome == condominio.Nome).Result.Any())
        {
            Notificar("Já existe um condomínio com este nome.");
            return;
        }

        await _condominioRepository.Adicionar(condominio);
    }

    /// <summary>
    /// Método para Atualizar um condomínio
    /// </summary>
    /// <param name="condominio">Condomínio a ser atualizado</param>
    public async Task Atualizar(Condominio condominio)
    {
        if (!ExecutarValidacao(new CondominioValidation(), condominio))
        {
            return;
        }

        var condominioCNPJExistente = await _condominioRepository.Buscar(f => f.CNPJ == condominio.CNPJ && f.Id != condominio.Id);
        if (condominioCNPJExistente.Any())
        {
            Notificar("Já existe um condomínio com este CNPJ informado.");
            return;
        }

        var condominioNomeExistente = await _condominioRepository.Buscar(f => f.Nome == condominio.Nome && f.Id != condominio.Id);
        if (condominioNomeExistente.Any())
        {
            Notificar("Já existe um condomínio com este nome informado.");
            return;
        }

        await _condominioRepository.Atualizar(condominio);
    }

    /// <summary>
    /// Método para Atualizar o endereço de um condomínio
    /// </summary>
    /// <param name="endereco">Endereço a ser atualizado</param>
    public async Task AtualizarEndereco(Endereco endereco)
    {
        if (!ExecutarValidacao(new EnderecoValidation(), endereco))
        {
            return;
        }

        await _enderecoRepository.Atualizar(endereco);
    }

    /// <summary>
    /// Método para Remover um condomínio
    /// </summary>
    /// <param name="id">Id do condomínio a ser removido</param>
    public async Task Remover(Guid id)
    {
        var condominio = await _condominioRepository.ObterPorId(id);
        if (condominio == null)
        {
            Notificar("Não existe um condomínio com este id.");
            return;
        }

        await _condominioRepository.Remover(id);
    }

    /// <summary>
    /// Método para liberar os recursos da memória
    /// </summary>
    public void Dispose()
    {
        _condominioRepository?.Dispose();
        _enderecoRepository?.Dispose();
    }
}