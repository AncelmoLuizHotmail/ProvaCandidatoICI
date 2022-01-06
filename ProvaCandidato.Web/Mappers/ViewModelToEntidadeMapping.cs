using AutoMapper;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Models;

namespace ProvaCandidato.Mappers
{
    public class ViewModelToEntidadeMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<CidadeViewModel, Cidade>();
        }
    }
}