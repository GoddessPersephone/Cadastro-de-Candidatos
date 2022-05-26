using CrudApi.Models;
using CrudApi.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CrudApi.Controllers
{
    public class VagasController : Controller
    {
        private readonly IVagasRepositorio _vagasRepositorio;

        public VagasController(IVagasRepositorio vagasRepositorio)
        {
            _vagasRepositorio = vagasRepositorio;//Injeção de dependência
        }
        public IActionResult Index()
        {
            List<VagasModel> vaga = _vagasRepositorio.BuscarTodos();

            return View(vaga);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(VagasModel vaga)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _vagasRepositorio.Adicionar(vaga);//Metodo Adicionar recebe uma VagaModel como parâmetro
                    TempData["MensagemSucesso"] = "Vaga adicionada com Sucesso!";
                    return RedirectToAction("Index");//Volta para index com a vaga gravada
                }

                return View(vaga);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível adicionar a vaga, tente novamente{erro.Message}";

                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Alterar(VagasModel vaga)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _vagasRepositorio.Atualizar(vaga);//Metodo Editar VagasModel 
                    TempData["MensagemSucesso"] = "Vaga atualizada com Sucesso!";
                    return RedirectToAction("Index");//Volta para index com vaga gravada
                }

                return View("Editar", vaga);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível atualizar a Vaga, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _vagasRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Vaga excluída com Sucesso!";

                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível excluir a Vaga.";


                }

                return RedirectToAction("Index");

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível excluir a Vaga, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            VagasModel vaga = _vagasRepositorio.ListarPorId(id);
            return View(vaga);
        }
        public IActionResult Editar(int id)
        {
            VagasModel vaga = _vagasRepositorio.ListarPorId(id);
            return View(vaga);
        }

    }
}
