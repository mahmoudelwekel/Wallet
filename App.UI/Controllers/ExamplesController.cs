using App.Domain.CommonAppSetting;
using App.ServiceLayer.Contract.IEntityServices.IExampleServices;
using App.ServiceLayer.Contract.IEntityServices.IExampleServices.DTOs;
using App.UI.Models.ExampleModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
namespace App.UI.Controllers
{
    public class ExamplesController : BaseController
    {
        private readonly IExampleService _ExampleService;


        public ExamplesController(
            IExampleService ExampleService,
            IMapper mapper,
            IOptions<AppSettings> _appSetting, UserManager<IdentityUser> UserManager) : base(mapper, _appSetting, UserManager)
        {
            _ExampleService = ExampleService;
        }
        #region Create Example

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateExampleReqModel model)
        {
            if (ModelState.IsValid)
            {
                model.ExampleFromUserId = User?.Claims?.FirstOrDefault()?.Value;
                model.ExampleCreateBy = User?.Claims?.FirstOrDefault()?.Value;

                var res = _ExampleService.AddExample(_mapper.Map<ExampleDTO>(model));

                if (res)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("All", "Failed");
                }
            }
            return View(model);
        }


        #endregion



    }
}
