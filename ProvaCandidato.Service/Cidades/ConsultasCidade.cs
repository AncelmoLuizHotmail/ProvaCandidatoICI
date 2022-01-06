using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Data.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaCandidato.Service.Cidades
{
    public class ConsultasCidade
    {
        private readonly ICidadeRepository _repository;

        public ConsultasCidade(ICidadeRepository cidadeRepository)
        {
            _repository = cidadeRepository;
        }

        public async Task<Cidade> ObterCidade(int id)
        {
            return await _repository.ObterCidade(id);
        }

        public async Task<IEnumerable<Cidade>> ListarCidades()
        {
            var cidades = await _repository.Cidades();

            return cidades;
        }
    }
}
