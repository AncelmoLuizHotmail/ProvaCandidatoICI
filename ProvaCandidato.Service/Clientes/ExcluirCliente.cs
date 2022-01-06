using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaCandidato.Service.Clientes
{
    public class ExcluirCliente
    {
        public Dictionary<string, string> Erros { get; private set; } = new Dictionary<string, string>();
        private readonly IClienteRepository _repository;

        public ExcluirCliente(IClienteRepository clienteRepository)
        {
            _repository = clienteRepository;
        }

        public async Task Executar(Cliente cliente)
        {
            try
            {
                await _repository.Excluir(cliente);
            }
            catch (Exception)
            {
                this.Erros.Add("Erro", "Ocorreu um erro ao excluir uma cliente");
            }
        }
    }
}
