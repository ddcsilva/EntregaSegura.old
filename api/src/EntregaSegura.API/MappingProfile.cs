using AutoMapper;
using EntregaSegura.Entities.Models;
using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.API;

/// <summary>
/// Classe que define o mapeamento entre os objetos de domínio e os DTOs (Data Transfer Objects) utilizados na aplicação.
/// Herda da classe Profile do AutoMapper.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Construtor que configura o mapeamento entre os objetos de domínio e os DTOs.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Condominio, CondominioDTO>()
            .ForCtorParam("Endereco", 
                option => option.MapFrom(src => $"{src.Logradouro}, {src.Numero}, {src.Complemento}{(src.Complemento == null ? "" : $", ")}{src.Bairro}"));
        CreateMap<CondominioCriacaoDTO, Condominio>();
        CreateMap<Entrega, EntregaDTO>();
        CreateMap<Funcionario, FuncionarioDTO>();
        CreateMap<FuncionarioCriacaoDTO, Funcionario>();
        CreateMap<Morador, MoradorDTO>();
        CreateMap<Transportadora, TransportadoraDTO>();
        CreateMap<Unidade, UnidadeDTO>();
        CreateMap<UnidadeCriacaoDTO, Unidade>();
    }
}