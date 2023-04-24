using AutoMapper;
using EntregaSegura.API.DTOs;
using EntregaSegura.Business.Models;

namespace EntregaSegura.API.Configurations;

/// <summary>
/// Classe que representa a configuração do AutoMapper
/// </summary>
public class AutoMapperConfiguration : Profile
{
    /// <summary>
    /// Construtor da classe de configuração do AutoMapper, onde são mapeados os objetos
    /// </summary>
    public AutoMapperConfiguration()
    {
        CreateMap<Condominio, CondominioDTO>().ReverseMap();
        CreateMap<Endereco, EnderecoDTO>().ReverseMap();
    }
}