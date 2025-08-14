using App.Domain.CommonAppSetting;
using App.RepositoryLayer.Contract.IAppRepository;
using App.ServiceLayer.Contract.IGenericService;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace App.ServiceLayer.Persistence.GenericService
{
    public class GenericServices : IGenericService
    {
        protected readonly IAppUnitOfWork _AppWrapper;
        protected readonly IOptions<AppSettings> _appSetting;
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;




        public GenericServices(
            IAppUnitOfWork AppWrapper,
            IOptions<AppSettings> appSettings,
            ILogger<GenericServices> logger,
            IMapper mapper)
        {
            _AppWrapper = AppWrapper;
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
