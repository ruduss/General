using General.Model;
using Microsoft.AspNet.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNamespace
{
    public class PresentationController : Controller
    {
        readonly IPresentationRepository _presentationRepository;

        public PresentationController(IPresentationRepository presentationRepository)
        {
            _presentationRepository = presentationRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Presentations>> GetAll()
        {
            var presentations = await _presentationRepository.AllPresentations();
            return presentations;
        }

        [HttpPost]
        public void Create([FromBody] Presentations presentations)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                _presentationRepository.Add(presentations);

                string url = Url.RouteUrl("GetByIdRoute", new { id = presentations.Id.ToString() }, Request.Scheme, Request.Host.ToUriComponent());
                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        public IActionResult Edit(string id)
        {
            var model = _presentationRepository.Get(new ObjectId(id));
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }        

    }
}
