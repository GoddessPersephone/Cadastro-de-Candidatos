using CrudApi.Models;
using CrudApi.Data;
using Microsoft.AspNetCore.Mvc;
using CrudApi.Repositorio;
using System.Collections.Generic;

namespace CrudApi.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ICandidatoRepositorio _candidatoRepositorio;
        
        public CandidatoController(ICandidatoRepositorio candidatoRepositorio)
        {
            _candidatoRepositorio = candidatoRepositorio;//Injeção de dependência

        }
        public IActionResult Index()
        {
           List<CandidatoModel> candidato = _candidatoRepositorio.BuscarTodos();

            return View(candidato);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            CandidatoModel candidato = _candidatoRepositorio.ListarPorId(id);
            return View(candidato);
        }
        public IActionResult Editar(int id)
        {
           CandidatoModel candidato = _candidatoRepositorio.ListarPorId(id);
            return View(candidato);
        }

        [HttpPost]
        public IActionResult Criar(CandidatoModel candidato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _candidatoRepositorio.Adicionar(candidato);//Metodo Adicionar recebe um CandidatoModel como parâmetro
                    TempData["MensagemSucesso"] = "Candidato cadastrado com Sucesso!";
                    return RedirectToAction("Index");//Volta para index com Candidato gravado
                }

                return View(candidato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o Candidato, tente novamente{erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(CandidatoModel candidato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _candidatoRepositorio.Atualizar(candidato);//Metodo Editar CandidatoModel 
                    TempData["MensagemSucesso"] = "Candidato atualizado com Sucesso!";
                    return RedirectToAction("Index");//Volta para index com Candidato gravado
                }

                return View("Editar", candidato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível atualizar o Candidato, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _candidatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Candidato excluído com Sucesso!";

                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível excluir o Candidato.";
 

                }

                return RedirectToAction("Index");

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível excluir o Candidato, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
