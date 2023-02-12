using AutoMapper;
using Wallet.Domain.Common;
using Wallet.Domain.Common.APPSetting; 
using Wallet.ServiceLayer.Contract.IGenericService;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.RepositoryLayer.Contract.IWalletRepository;
 
namespace Wallet.ServiceLayer.Persistence.GenericService
{
    public class GenericServices: IGenericService
    {
        protected readonly IWalletWrapper _WalletWrapper;
        protected readonly IOptions<AppSettings> _appSetting;
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;
 



        public GenericServices(
            IWalletWrapper WalletWrapper,
            IOptions<AppSettings> appSettings,
            ILogger<GenericServices> logger,
            IMapper mapper)
        {
            _WalletWrapper = WalletWrapper;
            _appSetting = appSettings;
            _mapper = mapper;
            _logger = logger;
        }


        public GenericServices(
           IOptions<AppSettings> appSettings,
           ILogger<GenericServices> logger,
           IMapper mapper)
        {
            _appSetting = appSettings;
            _mapper = mapper;
            _logger = logger;
        }

    }
}
