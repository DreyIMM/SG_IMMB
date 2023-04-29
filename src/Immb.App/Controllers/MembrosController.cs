using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Immb.App.Data;
using Immb.App.ViewModels;
using Immb.Business.Interfaces;
using AutoMapper;
using Immb.Business.Models;
using Immb.Data.Repository;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Immb.App.Controllers
{
    public class MembrosController : Controller
    {

        private readonly IMembroRepository _membroRepository;
        private readonly IUnidadeReligiosaRepository _unidadeReligiosa;

        private readonly IMapper _mapper;

        public MembrosController(IMembroRepository membroRepository, IMapper mapper, IUnidadeReligiosaRepository unidadeReligiosa)
        {
            _membroRepository = membroRepository;
            _mapper = mapper;
            _unidadeReligiosa = unidadeReligiosa;
        }

        // GET: Membros
        public async Task<IActionResult> Index()
        {
            var membroViewModel = new MembroAndListaViewModel();

            membroViewModel.membrosViewModels = _mapper.Map<IEnumerable<MembroViewModel>>(await _membroRepository.ObterMembros());

            membroViewModel.membroViewModels = await PopularUnidades(new MembroViewModel());
            ViewBag.action = "Create";
            ViewBag.nameButton = "Adicionar";

            return View(membroViewModel);
        }


        
        //[HttpGet]
        //public async Task<IActionResult> Create()
        //{
        //    var membro = await PopularUnidades(new MembroViewModel());
        //    //ViewBag.action = "Create";
        //    return View(membro);
        //}

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MembroViewModel membroViewModel)
        {
            membroViewModel = await PopularUnidades(membroViewModel);

            if (!ModelState.IsValid)
            {
                var membroViewModelLista = new MembroAndListaViewModel();
                membroViewModelLista.membroViewModels = membroViewModel;
                membroViewModelLista.membrosViewModels = _mapper.Map<IEnumerable<MembroViewModel>>(await _membroRepository.ObterMembros());

                return View("Index", membroViewModelLista);
            }
            Membro membro = _mapper.Map<Membro>(membroViewModel);

            await _membroRepository.Adicionar(membro);

            return RedirectToAction("Index");

        }


        // GET: Membros/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
                if (id == null)
                {
                    return NotFound();
                }

                var membroResultado = _mapper.Map<MembroViewModel>(await _membroRepository.ObterPorId(id));
           
                var membroAndListaViewModel = new MembroAndListaViewModel();

                membroAndListaViewModel.membrosViewModels = _mapper.Map<IEnumerable<MembroViewModel>>(await _membroRepository.ObterMembros());
                membroAndListaViewModel.membroViewModels = await PopularUnidades(membroResultado);
                membroAndListaViewModel.membroViewModels.Inclusao = false;

                ViewBag.nameButton = "Atualizar";
                ViewBag.action = "Edit";

                if (membroAndListaViewModel == null)
                {
                    return NotFound();
                }

                return View("Index", membroAndListaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MembroViewModel membroViewModelAtualizado)
        {
            if (id != membroViewModelAtualizado.Id) return NotFound();

            var membroBanco = (await _membroRepository.ObterPorId(id));

            membroBanco.DataOutorga = membroViewModelAtualizado.DataOutorga;
            membroBanco.Email = membroViewModelAtualizado.Email;
            membroBanco.Nome = membroViewModelAtualizado.Nome;
            membroBanco.UnidadeReligiosaId = membroViewModelAtualizado.UnidadeReligiosaId;
            membroBanco.Telefone = membroViewModelAtualizado.Telefone;

            await _membroRepository.Atualizar(membroBanco);

            return RedirectToAction("Index"); 
        }





        private async Task<MembroViewModel> PopularUnidades(MembroViewModel membro)
        {
            membro.Unidades = _mapper.Map<IEnumerable<UnidadeReligiosaViewModel>>(await _unidadeReligiosa.ObterTodos());
            return membro;
        }

        

        // POST: Membros/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            await _membroRepository.Remover(id);

            return RedirectToAction("Index");
        }

  



        /*



        // GET: Membros/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroViewModel = await _context.MembroViewModel.FindAsync(id);
            if (membroViewModel == null)
            {
                return NotFound();
            }
            return View(membroViewModel);
        }

       
       

        // GET: Membros/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroViewModel = await _context.MembroViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membroViewModel == null)
            {
                return NotFound();
            }

            return View(membroViewModel);
        }

        // POST: Membros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var membroViewModel = await _context.MembroViewModel.FindAsync(id);
            _context.MembroViewModel.Remove(membroViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembroViewModelExists(Guid id)
        {
            return _context.MembroViewModel.Any(e => e.Id == id);
        }

        */
    }
}
