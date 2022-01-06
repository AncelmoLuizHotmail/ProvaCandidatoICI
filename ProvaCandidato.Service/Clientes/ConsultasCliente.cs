using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Data.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaCandidato.Service.Clientes
{
    public class ConsultasCliente
    {
        private readonly IClienteRepository _repository;
        public ConsultasCliente(IClienteRepository clienteRepository)
        {
            _repository = clienteRepository;
        }

        public async Task<Cliente> ObterCliente(int id)
        {
            return await _repository.ObterCliente(id);
        }

        public async Task<IEnumerable<Cliente>> ListarClientes()
        {
            var clientes = await _repository.Clientes();

            return clientes;
        }
    }
}
