using AutoMapper;
using EntregaSegura.Entities.Models;
using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Condominio, CondominioDTO>();
        CreateMap<Endereco, EnderecoDTO>();
        CreateMap<Entrega, EntregaDTO>();
        CreateMap<Funcionario, FuncionarioDTO>();
        CreateMap<Morador, MoradorDTO>();
        CreateMap<Transportadora, TransportadoraDTO>();
        CreateMap<Unidade, UnidadeDTO>();
    }
}