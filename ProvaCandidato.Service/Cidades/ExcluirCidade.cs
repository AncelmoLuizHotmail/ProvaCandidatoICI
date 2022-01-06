using ProvaCandidato.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaCandidato.Service.Cidades
{
    public class ExcluirCidade
    {
        public Dictionary<string, string> Erros { get; private set; } = new Dictionary<string, string>();
        private readonly ICidadeRepository _repository;
        public ExcluirCidade(ICidadeRepository cidadeRepository)
        {
            _repository = cidadeRepository;
        }

        public async Task Executar(int id)
        {
            try
            {
                var dadosCidade = await _repository.ObterCidade(id);

                await _repository.Excluir(dadosCidade);
            }
            catch (Exception)
            {
                this.Erros.Add("Erro", "Ocorreu um erro ao excluir uma cidade");
            }
        }
    }
}
