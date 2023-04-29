using System.Collections.Generic;

namespace Immb.App.ViewModels
{
    public class MembroAndListaViewModel
    {

        public MembroAndListaViewModel()
        { 
            this.membroViewModels = new MembroViewModel();
        }

        public IEnumerable<MembroViewModel> membrosViewModels { get; set; }

        public MembroViewModel membroViewModels { get; set; }

    }
}
