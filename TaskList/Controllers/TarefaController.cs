using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaskList.BLL;
using TaskList.Model.Dto;
using TaskList.Model.Excecoes;
using TaskList.Model.Model;
using TaskList.Model.Resources;

namespace TaskList.Controllers
{
    public class TarefaController : Controller
    {
        private ITarefaNegocio negocio { get; }
        
        public TarefaController(ITarefaNegocio negocio)
        {
            this.negocio = negocio;
        }

        public ActionResult Index()
        {
            var entidades = negocio.ObterTodos().ToList();
            var entidadesDto = Mapper.Map<List<Tarefa>, List<TarefaDto>>(entidades);

            return View(entidadesDto);
        }

        public ActionResult Criar()
        {
            ViewBag.Title = ResourceComponentes.TITULO_TELA_INCLUIR_TAREFA;
            return View("Editar", new TarefaDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(TarefaDto entidadeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Title = ResourceComponentes.TITULO_TELA_INCLUIR_TAREFA;
                    return View("Editar", entidadeDto);
                }

                var entidade = Mapper.Map<TarefaDto, Tarefa>(entidadeDto);
                negocio.Adicionar(entidade);

                TempData["Sucesso"] = ResourceMensagens.MENSAGEM_OPERACAO_REALIZADA_COM_SUCESSO;

                return RedirectToAction("Index");
            }
            catch (ValidacaoException ve)
            {
                var erros = ve.ObterErros();
                foreach (var erro in erros)
                {
                    ModelState.AddModelError(erro.Campo, erro.Mensagem);
                }
                ViewBag.Title = ResourceComponentes.TITULO_TELA_INCLUIR_TAREFA;
                return View("Editar", entidadeDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Descricao", ex.Message);
                ViewBag.Title = ResourceComponentes.TITULO_TELA_INCLUIR_TAREFA;
                return View("Editar", entidadeDto);
            }
        }


        public ActionResult Editar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entidade = negocio.ObterPorId(id.Value);

            if (negocio.TarefaConcluida(entidade) || negocio.TarefaExcluida(entidade))
            {
                TempData["Sucesso"] = "Não é possivel editar uma tarefa concluída ou excluída.";
                return RedirectToAction("Index");
            }

            var entidadeDto = Mapper.Map<Tarefa, TarefaDto>(entidade);
            if (entidadeDto == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = ResourceComponentes.TITULO_TELA_EDITAR_TAREFA;
            return View(entidadeDto);
        }

        [HttpPost]
        public ActionResult Editar(long id, TarefaDto entidadeDto)
        {
            try
            {
                var entidade = Mapper.Map<TarefaDto, Tarefa>(entidadeDto);
                negocio.Atualizar(entidade);

                TempData["Sucesso"] = ResourceMensagens.MENSAGEM_OPERACAO_REALIZADA_COM_SUCESSO;

                return RedirectToAction("Index");
            }
            catch (ValidacaoException ve)
            {
                var erros = ve.ObterErros();
                foreach (var erro in erros)
                {
                    ModelState.AddModelError(erro.Campo, erro.Mensagem);
                }

                ViewBag.Title = ResourceComponentes.TITULO_TELA_EDITAR_TAREFA;
                return View(entidadeDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Descricao", ex.Message);
                ViewBag.Title = ResourceComponentes.TITULO_TELA_EDITAR_TAREFA;
                return View(entidadeDto);
            }
        }

        public ActionResult Concluir(int? id)
        {
            try
            {
                var entidade = negocio.ObterPorId(id.Value);

                if (negocio.TarefaExcluida(entidade))
                {
                    TempData["Sucesso"] = "Não é possivel concluir uma tarefa excluída.";
                    return RedirectToAction("Index");
                }

                negocio.Concluir(entidade);

                TempData["Sucesso"] = ResourceMensagens.MENSAGEM_OPERACAO_REALIZADA_COM_SUCESSO;

                return RedirectToAction("Index");
            }
            catch (ValidacaoException ve)
            {
                var erros = ve.ObterErros();
                foreach (var erro in erros)
                {
                    ModelState.AddModelError(erro.Campo, erro.Mensagem);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Descricao", ex.Message);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Reabrir(int? id)
        {
            try
            {
                var entidade = negocio.ObterPorId(id.Value);

                if (negocio.TarefaExcluida(entidade))
                {
                    TempData["Sucesso"] = "Não é possivel concluir uma tarefa excluída.";
                    return RedirectToAction("Index");
                }

                negocio.Reabrir(entidade);

                TempData["Sucesso"] = ResourceMensagens.MENSAGEM_OPERACAO_REALIZADA_COM_SUCESSO;

                return RedirectToAction("Index");
            }
            catch (ValidacaoException ve)
            {
                var erros = ve.ObterErros();
                foreach (var erro in erros)
                {
                    ModelState.AddModelError(erro.Campo, erro.Mensagem);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Descricao", ex.Message);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Excluir(int? id)
        {
            try
            {
                var entidade = negocio.ObterPorId(id.Value);
                negocio.Remover(entidade);

                TempData["Sucesso"] = ResourceMensagens.MENSAGEM_OPERACAO_REALIZADA_COM_SUCESSO;

                return RedirectToAction("Index");
            }
            catch (ValidacaoException ve)
            {
                var erros = ve.ObterErros();
                foreach (var erro in erros)
                {
                    ModelState.AddModelError(erro.Campo, erro.Mensagem);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Descricao", ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
 