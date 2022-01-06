using AutoMapper;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Models;
using System.Collections.Generic;

namespace ProvaCandidato.Mappers
{
    public class EntidadeToViewModelMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Cidade, CidadeViewModel>();

            Mapper.CreateMap<List<Cidade>, List<CidadeViewModel>>();
            Mapper.CreateMap<List<Cliente>, List<ClienteViewModel>>();
        }
    }
}