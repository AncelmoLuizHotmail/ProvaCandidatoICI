using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Data.Repositories.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ProvaCandidato.Data.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly ContextoPrincipal _contexto;

        public CidadeRepository(ContextoPrincipal contexto)
        {
            _contexto = contexto;
        }

        public async Task Criar(Cidade cidade)
        {
            _contexto.Cidades.Add(cidade);
            await _contexto.SaveChangesAsync();
        }

        public async Task Alterar(Cidade cidade)
        {
            _contexto.Entry(cidade).State = System.Data.Entity.EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        public async Task Excluir(Cidade cidade)
        {
            _contexto.Cidades.Remove(cidade);
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cidade>> Cidades()
        {
            return await _contexto.Cidades.AsNoTracking().ToListAsync();
        }

        public async Task<Cidade> ObterCidade(int id)
        {
            return await _contexto.Cidades.FirstOrDefaultAsync(x => x.Codigo == id);
        }
    }
}
