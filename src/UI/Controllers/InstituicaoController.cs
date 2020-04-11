using BLL.Interfaces.BLL;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class InstituicaoController : Controller
    {
        private readonly IInstituicaoBLL _instituicaoBLL;

        public InstituicaoController(IInstituicaoBLL instituicaoBLL)
        {
            _instituicaoBLL = instituicaoBLL;
        }

        // GET: LivroViewModels
        public IActionResult Index()
        {
            return View(_instituicaoBLL.GetAll());
        }


        // GET: LivroViewModels/Create
        public IActionResult Create()
        {            
            return View();
        }

        // POST: LivroViewModels/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InstituicaoViewModel instituicaoViewModel)
        {
            if (ModelState.IsValid)
            {               
                var instituicao = new Instituicao(instituicaoViewModel.Nome,
                                                  instituicaoViewModel.Endereco,
                                                  instituicaoViewModel.CNPJ,
                                                  instituicaoViewModel.Telefone);

                var result = _instituicaoBLL.Add(instituicao);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    return View(instituicaoViewModel);
            }
            else
            {                
                return View(instituicaoViewModel);
            }
        }

        // GET: LivroViewModels/Edit/5
        public IActionResult Edit(int id)
        {
            var instituicao = _instituicaoBLL.GetById(id);

            var instituicaoViewModel = new InstituicaoViewModel
            {
                InstituicaoId = instituicao.InstituicaoId,
                Nome = instituicao.Nome,
                Endereco = instituicao.Endereco,
                CNPJ = instituicao.CNPJ,
                Telefone = instituicao.Telefone

            };

            if (instituicaoViewModel == null)
            {
                return NotFound();
            }
            
            return View(instituicaoViewModel);
        }

        // POST: LivroViewModels/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InstituicaoViewModel instituicaoViewModel)
        {
            if (ModelState.IsValid)
            {               
                var instituicao = new Instituicao(instituicaoViewModel.InstituicaoId,
                                                  instituicaoViewModel.Nome,
                                                  instituicaoViewModel.Endereco,
                                                  instituicaoViewModel.CNPJ,
                                                  instituicaoViewModel.Telefone);

                var result = _instituicaoBLL.Update(instituicao);


                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                {                    
                    return View(instituicaoViewModel);
                }
            }
            else
            {                
                return View(instituicaoViewModel);
            }
        }

        // GET: LivroViewModels/Delete/5
        public IActionResult Delete(int id)
        {
            var instituicao = _instituicaoBLL.GetById(id);

            var instituicaoViewModel = new InstituicaoViewModel
            {
                InstituicaoId = instituicao.InstituicaoId,
                Nome = instituicao.Nome,
                Endereco = instituicao.Endereco,
                CNPJ = instituicao.CNPJ,
                Telefone = instituicao.Telefone

            };

            return View(instituicaoViewModel);
        }

        // POST: LivroViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _instituicaoBLL.Remove(id);
            return RedirectToAction(nameof(Index));
        }       
    }
}
