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
            return View(_mapper.Map<IEnumerable<MembroViewModel>>(await _membroRepository.ObterTodos()));
        }


        // GET: Membros/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var membro = await PopularUnidades(new MembroViewModel());
            
            return View(membro);
        }

        // POST: Membros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MembroViewModel membroViewModel)
        {
            if (!ModelState.IsValid) return View(membroViewModel);


            
            return View(membroViewModel);
        }

        private async Task<MembroViewModel> PopularUnidades(MembroViewModel membro)
        {
            membro.Unidades = _mapper.Map<IEnumerable<UnidadeReligiosaViewModel>>(await _unidadeReligiosa.ObterTodos());
            return membro;
        }

        /*
        // GET: Membros/Details/5
        public async Task<IActionResult> Details(Guid? id)
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

        // POST: Membros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UnidadeReligiosaId,Nome,Telefone,Email,DataOutorga")] MembroViewModel membroViewModel)
        {
            if (id != membroViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membroViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembroViewModelExists(membroViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
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
