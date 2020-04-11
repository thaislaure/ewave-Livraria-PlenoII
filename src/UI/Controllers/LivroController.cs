using BLL.Interfaces;
using BLL.Interfaces.BLL;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Extension;
using UI.Models;

namespace UI.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroBLL _livroBLL;

        public LivroController(ILivroBLL livroBLL)
        {
            _livroBLL = livroBLL;
        }

        // GET: LivroViewModels
        public IActionResult Index()
        {
            return View(_livroBLL.GetAll());
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
        public IActionResult Create(LivroViewModel livroViewModel, IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                if (Img != null && Img.Length > 0)
                {
                    livroViewModel.ImagemCapa = Img.ToByteArray();
                    livroViewModel.ImagemCapaContentType = Img.ContentType;
                }

                var livro = new Livro(livroViewModel.Titulo,
                                      livroViewModel.GeneroId,
                                      livroViewModel.AutorId,
                                      livroViewModel.Sinopse,
                                      livroViewModel.ImagemCapa,
                                      livroViewModel.ImagemCapaContentType);

                var result = _livroBLL.Add(livro);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    return View(livroViewModel);
            }
            else
            {
                CarregarCamposSelects();
                return View(livroViewModel);
            }
        }

        // GET: LivroViewModels/Edit/5
        public IActionResult Edit(int id)
        {
            var livro = _livroBLL.GetById(id);

            var livroViewModel = new LivroViewModel
            {
                LivroId = livro.LivroId,
                Titulo = livro.Titulo,
                GeneroId = livro.GeneroId,
                AutorId = livro.AutorId,
                Sinopse = livro.Sinopse,
                ImagemCapa = livro.ImagemCapa,
                ImagemCapaContentType = livro.ImagemCapaContentType
            };

            if (livroViewModel == null)
            {
                return NotFound();
            }

            CarregarCamposSelects();
            return View(livroViewModel);
        }

        // POST: LivroViewModels/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LivroViewModel livroViewModel, IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                if (Img != null && Img.Length > 0)
                {
                    livroViewModel.ImagemCapa = Img.ToByteArray();
                    livroViewModel.ImagemCapaContentType = Img.ContentType;
                }

                var livro = new Livro(livroViewModel.LivroId,
                                      livroViewModel.Titulo,
                                      livroViewModel.GeneroId,
                                      livroViewModel.AutorId,
                                      livroViewModel.Sinopse,
                                      livroViewModel.ImagemCapa,
                                      livroViewModel.ImagemCapaContentType);

                var result = _livroBLL.Update(livro);


                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                {
                    CarregarCamposSelects();
                    return View(livroViewModel);
                }
            }
            else
            {
                CarregarCamposSelects();
                return View(livroViewModel);
            }
        }

        // GET: LivroViewModels/Delete/5
        public IActionResult Delete(int id)
        {
            var livro = _livroBLL.GetById(id);

            var livroViewModel = new LivroViewModel
            {
                LivroId = livro.LivroId,
                Titulo = livro.Titulo,
                GeneroId = livro.GeneroId,
                AutorId = livro.AutorId,
                Sinopse = livro.Sinopse,
                ImagemCapa = livro.ImagemCapa,
                ImagemCapaContentType = livro.ImagemCapaContentType
            };

            return View(livroViewModel);
        }

        // POST: LivroViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _livroBLL.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private void CarregarCamposSelects()
        {            
            ViewBag.Autores = _livroBLL.GetAllAutor();
            ViewBag.Generos = _livroBLL.GetAllGenero();
        }
    }
}
