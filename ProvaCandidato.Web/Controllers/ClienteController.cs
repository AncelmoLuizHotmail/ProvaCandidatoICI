using AutoMapper;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Data.Repositories.Interface;
using ProvaCandidato.Helper;
using ProvaCandidato.Models;
using ProvaCandidato.Service.Cidades;
using ProvaCandidato.Service.Clientes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ConsultasCliente _consultas;
        private readonly ConsultasCidade _consultasCidade;
        private readonly CriarCliente _criar;
        private readonly AlterarCliente _alterar;
        private readonly ExcluirCliente _excluir;

        public ClienteController(IClienteRepository clienteRepository, ICidadeRepository cidadeRepository)
        {
            _consultas = new ConsultasCliente(clienteRepository);
            _consultasCidade = new ConsultasCidade(cidadeRepository);
            _criar = new CriarCliente(clienteRepository);
            _alterar = new AlterarCliente(clienteRepository);
            _excluir = new ExcluirCliente(clienteRepository);
        }

        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            var clientes = await _consultas.ListarClientes();

            return View(Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(clientes));
        }

        // GET: Cliente/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var cliente = await _consultas.ObterCliente(id);

            return View(Mapper.Map<Cliente, ClienteViewModel>(cliente));
        }

        // GET: Cliente/Create
        public async Task<ActionResult> Create()
        {
            await PreencherViewBags();

            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<ActionResult> Create(ClienteViewModel clienteViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(clienteViewModel);
                }

                clienteViewModel.Ativo = true;

                await _criar.Executar(Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel));

                MessageHelper.DisplaySuccessMessage(this, "Cliente criado com sucesso");

                return RedirectToAction("Index");
            }
            catch
            {
                return View(clienteViewModel);
            }
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var cliente = await _consultas.ObterCliente(id);

            if (cliente == null)
            {
                return RedirectToAction("Index");
            }

            await PreencherViewBags();

            return View(Mapper.Map<Cliente, ClienteViewModel>(cliente));
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, ClienteViewModel clienteViewModel)
        {
            try
            {
                if (id != clienteViewModel.Codigo)
                {
                    return View(clienteViewModel);
                }

                clienteViewModel.Ativo = true;

                await _alterar.Executar(Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel));

                MessageHelper.DisplaySuccessMessage(this, "Cliente alterado com sucesso");

                return RedirectToAction("Index");
            }
            catch
            {
                return View(clienteViewModel);
            }
        }

        // GET: Cliente/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var cliente = await _consultas.ObterCliente(id);

                if (cliente == null)
                {
                    return RedirectToAction("Index");
                }

                await _excluir.Executar(cliente);

                MessageHelper.DisplaySuccessMessage(this, "Cidade excluído com sucesso");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private async Task PreencherViewBags()
        {
            var cidades = await _consultasCidade.ListarCidades();
            ViewBag.Cidades = cidades;
        }
    }
}
