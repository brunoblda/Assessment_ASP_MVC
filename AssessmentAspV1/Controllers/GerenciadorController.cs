using AssessmentAspV1.Data;
using AssessmentAspV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssessmentAspV1.Controllers
{
    public class GerenciadorController : Controller
    {

        private Repositorio repositorio = new Repositorio();
        
        // GET: Gerenciador
        public ActionResult Index()
        {

            List<Pessoa> Lista = repositorio.TodasAsPessoas().ToList();

            OrdenarLista OrdenarLista = new OrdenarLista();

            
            
            return View(OrdenarLista.TempoParaAniversario(Lista));
        }

        public PartialViewResult AniversariosDeHoje()
        {

            List<Pessoa> Lista = repositorio.TodasAsPessoas().ToList();

            OrdenarLista AniversariosHoje = new OrdenarLista();           

            return PartialView("_AniversariosDeHoje", AniversariosHoje.AniversariosDoDia(Lista) );
        }

        // GET: Gerenciador/Details/5
        public ActionResult Details(int id)
        {
            Pessoa p = repositorio.BuscarPessoaPorId(id);

            PessoaDetalhada pd = new PessoaDetalhada()
            {
                PessoaId = p.PessoaId,
                Nome = p.Nome,
                Sobrenome = p.Sobrenome,
                DataDeNascimento = p.DataDeNascimento
            };

            pd.aniversario();
            
            return View(pd);
        }

        // GET: Gerenciador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gerenciador/Create
        [HttpPost]
        public ActionResult Create(Pessoa p)
        {
            try
            {
            
                repositorio.IncluirPessoa(p);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gerenciador/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repositorio.BuscarPessoaPorId(id));
        }

        // POST: Gerenciador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pessoa pessoa)
        {
            try
            {
                repositorio.EditarPessoa(pessoa);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gerenciador/Delete/5
        public ActionResult Delete(int id)
        {           

            return View(repositorio.BuscarPessoaPorId(id));
        }

        // POST: Gerenciador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Pessoa p)
        {
            try
            {
                repositorio.ExluirPessoa(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search()
        {

            List<Pessoa> pessoas = repositorio.TodasAsPessoas().ToList();

            return View(pessoas);
        }

        
        [HttpPost]
        public ActionResult Search(string pesquisa)
        {
            try
            {
                
                return View(repositorio.BuscarPessoaPorNome(pesquisa));
                
            }
            catch
            {
                return View();
            }
        }
    }
}
