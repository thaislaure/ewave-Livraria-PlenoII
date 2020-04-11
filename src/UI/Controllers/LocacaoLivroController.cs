using BLL.Interfaces.BLL;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using UI.Models;

namespace UI.Controllers
{
    public class LocacaoLivroController : Controller
    {
        private readonly ILocacaoLivroBLL _locacaoLivroBLL;

        public LocacaoLivroController(ILocacaoLivroBLL locacaoLivroBLL)
        {
            _locacaoLivroBLL = locacaoLivroBLL;
        }

        // GET: LivroViewModels
        public IActionResult Index()
        {
            return View(_locacaoLivroBLL.GetAll());
        }


        // GET: LivroViewModels/Create
        public IActionResult Create()
        {
            CarregarCamposSelects();
            return View();
        }

        // POST: LivroViewModels/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LocacaoLivroViewModel locacaoLivroViewModel)
        {
            ModelState.Remove(nameof(LocacaoLivroViewModel.DataDevolucao));

            if (ModelState.IsValid)
            {

                var locacaoLivro = new LocacaoLivro(locacaoLivroViewModel.DataLocacao,
                                                    locacaoLivroViewModel.DataEntrega,
                                                    null,
                                                    null,
                                                    locacaoLivroViewModel.UsuarioId,
                                                    locacaoLivroViewModel.LivroId,
                                                    false);

                var result = _locacaoLivroBLL.Add(locacaoLivro);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    return View(locacaoLivroViewModel);
            }
            else
            {
                CarregarCamposSelects();
                return View(locacaoLivroViewModel);
            }
        }

        // GET: LivroViewModels/Edit/5
        public IActionResult Edit(int id)
        {
            var locacaoLivro = _locacaoLivroBLL.GetById(id);

            var locacaoLivroViewModel = new LocacaoLivroViewModel
            {
               LocacaoId = locacaoLivro.LocacaoId,
               DataEntrega = locacaoLivro.DataEntrega,               
               DataLocacao = locacaoLivro.DataLocacao,
               DataDevolucao = locacaoLivro.DataDevolucao,
               LivroId = locacaoLivro.LivroId,
               UsuarioId = locacaoLivro.UsuarioId
            };

            if (locacaoLivroViewModel == null)
            {
                return NotFound();
            }

            CarregarCamposSelects(true);
            return View(locacaoLivroViewModel);
        }

        // POST: LivroViewModels/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LocacaoLivroViewModel locacaoLivroViewModel)
        {
            if (ModelState.IsValid)
            {             
                var locacaoLivro = new LocacaoLivro(locacaoLivroViewModel.LocacaoId,
                                                    locacaoLivroViewModel.DataLocacao,
                                                    locacaoLivroViewModel.DataEntrega,
                                                    null,
                                                   locacaoLivroViewModel.DataDevolucao,                                                    
                                                    locacaoLivroViewModel.UsuarioId,
                                                    locacaoLivroViewModel.LivroId,
                                                    !string.IsNullOrEmpty(locacaoLivroViewModel.DataDevolucao.ToString()) ? true : false);

                var result = _locacaoLivroBLL.Update(locacaoLivro);
                
                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                {
                    CarregarCamposSelects(true);
                    return View(locacaoLivroViewModel);
                }
            }
            else
            {
                CarregarCamposSelects(true);
                return View(locacaoLivroViewModel);
            }
        }

        // GET: LivroViewModels/Delete/5
        public IActionResult Delete(int id)
        {
            var locacaoLivro = _locacaoLivroBLL.GetLocaoDTOById(id);

            var locacaoLivroViewModel = new LocacaoLivroViewModel
            {
                LocacaoId = locacaoLivro.LocacaoId,               
                NomeLivro = locacaoLivro.NomeLivro
            };

            return View(locacaoLivroViewModel);
        }

        // POST: LivroViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _locacaoLivroBLL.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private void CarregarCamposSelects(bool editando = false)
        {            
            ViewBag.Livros = _locacaoLivroBLL.GetAllLivro(editando);
            ViewBag.Usuarios = _locacaoLivroBLL.GetAllUsuario();
        }
    }
}
