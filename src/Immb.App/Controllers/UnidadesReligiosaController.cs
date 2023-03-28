using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Immb.App.Data;
using Immb.App.ViewModels;
using Immb.Business.Interfaces;
using AutoMapper;
using Immb.Business.Models;
using Immb.Business.Models.Enums;
using Immb.App.Utils;

namespace Immb.App.Controllers
{
    public class UnidadesReligiosaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnidadeReligiosaRepository _unidadesReligiosaRepository; 
            
        public UnidadesReligiosaController(IUnidadeReligiosaRepository unidadesReligiosaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _unidadesReligiosaRepository = unidadesReligiosaRepository;
        }

        // GET: UnidadesReligiosa
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<UnidadeReligiosaViewModel>>(await _unidadesReligiosaRepository.ObterTodos()));
        }

        // GET: UnidadesReligiosa/Create
        public IActionResult Create()
        {
            var unidadeViewModel = popularComboEnum();

            return PartialView(unidadeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnidadeReligiosaViewModel unidadeReligiosaViewModel)
        {

            if (!ModelState.IsValid) return PartialView(unidadeReligiosaViewModel);

            unidadeReligiosaViewModel.TipoUnidadeId = unidadeReligiosaViewModel.TipoUnidade.GetHashCode();

            UnidadeReligiosa unidade = _mapper.Map<UnidadeReligiosa>(unidadeReligiosaViewModel);
            await _unidadesReligiosaRepository.Adicionar(unidade);
            return RedirectToAction(nameof(Index));
            
        }


        /* 
        // GET: UnidadesReligiosa/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadeReligiosaViewModel = await _context.UnidadeReligiosaViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadeReligiosaViewModel == null)
            {
                return NotFound();
            }

            return View(unidadeReligiosaViewModel);
        }

       

        

        // GET: UnidadesReligiosa/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadeReligiosaViewModel = await _context.UnidadeReligiosaViewModel.FindAsync(id);
            if (unidadeReligiosaViewModel == null)
            {
                return NotFound();
            }
            return View(unidadeReligiosaViewModel);
        }

        // POST: UnidadesReligiosa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,TipoUnidade")] UnidadeReligiosaViewModel unidadeReligiosaViewModel)
        {
            if (id != unidadeReligiosaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadeReligiosaViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadeReligiosaViewModelExists(unidadeReligiosaViewModel.Id))
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
            return View(unidadeReligiosaViewModel);
        }

        // GET: UnidadesReligiosa/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadeReligiosaViewModel = await _context.UnidadeReligiosaViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadeReligiosaViewModel == null)
            {
                return NotFound();
            }

            return View(unidadeReligiosaViewModel);
        }

        // POST: UnidadesReligiosa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var unidadeReligiosaViewModel = await _context.UnidadeReligiosaViewModel.FindAsync(id);
            _context.UnidadeReligiosaViewModel.Remove(unidadeReligiosaViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadeReligiosaViewModelExists(Guid id)
        {
            return _context.UnidadeReligiosaViewModel.Any(e => e.Id == id);
        }
        */

        public UnidadeReligiosaViewModel popularComboEnum()
        {
            var unList = new List<SelectListItem>();
            unList.Add(new SelectListItem
            {
                Text = "Selecione",
                Value = ""
            });

            foreach (TipoUnidadeReligiosa uVal in Enum.GetValues(typeof(TipoUnidadeReligiosa)))
            {
                unList.Add(new SelectListItem { Text = Enum.GetName(typeof(TipoUnidadeReligiosa), uVal), Value = uVal.ToString() });
            }

            UnidadeReligiosaViewModel unidadeViewModel = new UnidadeReligiosaViewModel();
            unidadeViewModel.TiposUnidadesReligiosas = unList;

            return unidadeViewModel;
        }


    }
}
