using AutoMapper;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Data.Repositories.Interface;
using ProvaCandidato.Helper;
using ProvaCandidato.Models;
using ProvaCandidato.Service.Cidades;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public class CidadeController : Controller
    {
        private readonly ConsultasCidade _consultas;
        private readonly CriarCidade _criar;
        private readonly AlterarCidade _alterar;
        private readonly ExcluirCidade _excluir;

        public CidadeController(ICidadeRepository cidadeRepository)
        {
            _consultas = new ConsultasCidade(cidadeRepository);
            _criar = new CriarCidade(cidadeRepository);
            _alterar = new AlterarCidade(cidadeRepository);
            _excluir = new ExcluirCidade(cidadeRepository);
        }

        // GET: Cidades
        public async Task<ActionResult> Index()
        {
            var cidades = await _consultas.ListarCidades();

            return View(Mapper.Map<IEnumerable<Cidade>, IEnumerable<CidadeViewModel>>(cidades));
        }

        // GET: Cidade/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var cidade = await _consultas.ObterCidade(id);
            return View(Mapper.Map<Cidade, CidadeViewModel>(cidade));
        }

        // GET: Cidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cidade/Create
        [HttpPost]
        public async Task<ActionResult> Create(CidadeViewModel cidadeViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(cidadeViewModel);
                }

                await _criar.Executar(Mapper.Map<CidadeViewModel, Cidade>(cidadeViewModel));

                MessageHelper.DisplaySuccessMessage(this, "Cidade criada com sucesso");

                return RedirectToAction("Index");
            }
            catch
            {
                return View(cidadeViewModel);
            }
        }

        // GET: Cidade/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var cidade = await _consultas.ObterCidade(id);

            if (cidade == null)
            {
                return RedirectToAction("Index");
            }

            return View(Mapper.Map<Cidade, CidadeViewModel>(cidade));
        }

        // POST: Cidade/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, CidadeViewModel cidadeViewModel)
        {
            try
            {
                if (id != cidadeViewModel.Codigo)
                {
                    return View(cidadeViewModel);
                }

                await _alterar.Executar(Mapper.Map<CidadeViewModel, Cidade>(cidadeViewModel));

                MessageHelper.DisplaySuccessMessage(this, "Cidade alterada com sucesso");

                return RedirectToAction("Index");
            }
            catch
            {
                return View(cidadeViewModel);
            }
        }

        // GET: Cidade/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var cidade = await _consultas.ObterCidade(id);

                if (cidade == null)
                {
                    return RedirectToAction("Index");
                }

                await _excluir.Executar(id);

                MessageHelper.DisplaySuccessMessage(this, "Cidade excluída com sucesso");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
