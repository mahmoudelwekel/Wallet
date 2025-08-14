using App.Domain.CommonAppSetting;
using App.Domain.Entities.App;
using App.RepositoryLayer.Contract.IAppRepository;
using App.ServiceLayer.Contract.IEntityServices.IExampleServices;
using App.ServiceLayer.Contract.IEntityServices.IExampleServices.DTOs;
using App.ServiceLayer.Persistence.GenericService;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace App.ServiceLayer.Persistence.EntityServices.ExampleService
{
    public class ExampleService : GenericServices, IExampleService
    {
        public ExampleService(
            IAppUnitOfWork AppWrapper,
            IOptions<AppSettings> appSettings,
            ILogger<ExampleService> logger,
            IMapper mapper) : base(AppWrapper, appSettings, logger, mapper)
        {

        }

        public bool AddExample(ExampleDTO _tran)
        {
            bool response = false;

            try
            {

                var ToUser = _AppWrapper.ExampleRepository.GetFromUser(_tran.ExampleToUserPhone);

                if (ToUser != null)
                {
                    Example Example = _mapper.Map<Example>(_tran);
                    Example.ExampleCreateDate = DateTime.Now;
                    //Example.ExampleToUserId = ToUser.Id;

                    response = _AppWrapper.ExampleRepository.Create(Example);
                    _AppWrapper.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"ExampleEntityService>> AddExample>> throws the following Exception {ex.Message}");
            }
            return response;
        }

        public decimal GetUserExampleBalance(string _userID)
        {
            decimal response = 0;

            try
            {

                decimal ToUser = _AppWrapper.ExampleRepository.GetToUser(_userID).Sum(x => x.ExampleAmount);
                decimal FromUser = _AppWrapper.ExampleRepository.GetFromUser(_userID).Sum(x => x.ExampleAmount);

                response = ToUser - FromUser;

            }
            catch (Exception ex)
            {
                _logger.LogError($"ExampleEntityService>> GetUserExampleBalance>> throws the following Exception {ex.Message}");
            }
            return response;
        }
    }
}
