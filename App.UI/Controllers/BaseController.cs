using App.Domain.CommonAppSetting;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace App.UI.Controllers
{

    public class BaseController : Controller
    {

        protected readonly AppSettings _appSettings;
        protected readonly IMapper _mapper;
        protected readonly UserManager<IdentityUser> _UserManager;

        public BaseController(IMapper _mapper, IOptions<AppSettings> _appSetting, UserManager<IdentityUser> UserManager)
        {
            this._appSettings = _appSetting.Value;
            this._mapper = _mapper;
            _UserManager = UserManager;

        }
    }
}
