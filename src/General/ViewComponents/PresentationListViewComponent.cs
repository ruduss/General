using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using General.Model;

namespace General.ViewComponents
{
    public class PresentationListViewComponent : ViewComponent
    {
        readonly IPresentationRepository _presentationRepository;

        public PresentationListViewComponent(IPresentationRepository presentationRepository)
        {
            _presentationRepository = presentationRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var presentations = await _presentationRepository.AllPresentations();
            return View("PresentationList", presentations);
        }
    }
}
