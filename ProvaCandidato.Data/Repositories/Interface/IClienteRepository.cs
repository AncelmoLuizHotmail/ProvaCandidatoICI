using ProvaCandidato.Data.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaCandidato.Data.Repositories.Interface
{
    public interface IClienteRepository
    {
        Task Criar(Cliente cliente);

        Task Alterar(Cliente cliente);

        Task Excluir(Cliente cliente);

        Task<IEnumerable<Cliente>> Clientes();

        Task<Cliente> ObterCliente(int id);
    }
}
