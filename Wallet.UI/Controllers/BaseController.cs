using AutoMapper;
using Wallet.Domain.Common.APPSetting;
using Wallet.Domain.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Wallet.UI.Controllers
{
  
    public class BaseController : Controller
    {

        protected readonly AppSettings _appSettings;
        protected readonly IMapper _mapper;
        protected readonly UserManager<IdentityUser> _UserManager;

        public BaseController( IMapper _mapper, IOptions<AppSettings> _appSetting, UserManager<IdentityUser> UserManager)
        {
            this._appSettings = _appSetting.Value;
            this._mapper = _mapper;
            _UserManager = UserManager;

        }
    }
}
