using ProvaCandidato.Data.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaCandidato.Data.Repositories.Interface
{
    public interface ICidadeRepository
    {
        Task Criar(Cidade cidade);

        Task Alterar(Cidade cidade);

        Task Excluir(Cidade cidade);

        Task<IEnumerable<Cidade>> Cidades();

        Task<Cidade> ObterCidade(int id);
    }
}
