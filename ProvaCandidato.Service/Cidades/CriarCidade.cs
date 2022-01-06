using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaCandidato.Service.Cidades
{
    public class CriarCidade
    {
        public Dictionary<string, string> Erros { get; private set; } = new Dictionary<string, string>();

        private readonly ICidadeRepository _repository;

        public CriarCidade(ICidadeRepository cidadeRepository)
        {
            _repository = cidadeRepository;
        }

        public async Task Executar(Cidade cidade)
        {
            try
            {
                await _repository.Criar(cidade);
            }
            catch (Exception)
            {
                this.Erros.Add("Erro", "Ocorreu um erro ao criar uma cidade");
            }
        }
    }
}
