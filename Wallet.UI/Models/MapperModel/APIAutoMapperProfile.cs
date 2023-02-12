using AutoMapper; 
using Wallet.UI.Models.TransactionModels; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.ServiceLayer.Contract.IEntityServices.ITransactionServices.DTOs;

namespace Wallet.UI.Models.MapperModel
{
    public class APIAutoMapperProfile : Profile
    {
        public APIAutoMapperProfile()
        { 

            CreateMap<CreateTransactionReqModel, TransactionDTO>().ReverseMap();

           

        }
    }
}
