using AutoMapper;
using EntregaSegura.Entities.Models;
using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Condominio, CondominioDTO>()
            .ForCtorParam("Endereco", 
                option => option.MapFrom(src => $"{src.Logradouro}, {src.Numero}, {src.Complemento}{(src.Complemento == null ? "" : $", ")}{src.Bairro}"));
        CreateMap<CondominioCriacaoDTO, Condominio>();
        CreateMap<Entrega, EntregaDTO>();
        CreateMap<Funcionario, FuncionarioDTO>();
        CreateMap<Morador, MoradorDTO>();
        CreateMap<Transportadora, TransportadoraDTO>();
        CreateMap<Unidade, UnidadeDTO>();
    }
}