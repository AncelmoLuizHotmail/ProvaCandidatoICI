using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Data.Repositories.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaCandidato.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContextoPrincipal _contexto;

        public ClienteRepository(ContextoPrincipal contexto)
        {
            _contexto = contexto;
        }

        public async Task Criar(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            await _contexto.SaveChangesAsync();
        }

        public async Task Alterar(Cliente cliente)
        {
            _contexto.Entry(cliente).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        public async Task Excluir(Cliente cliente)
        {
            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> Clientes()
        {
            return await _contexto.Clientes.Where(c => c.Ativo).AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> ObterCliente(int id)
        {
            return await _contexto.Clientes.FirstOrDefaultAsync(x => x.Codigo == id && x.Ativo);
        }
    }
}
