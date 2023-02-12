using AutoMapper;
using Wallet.Domain.Entities.Wallet; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Wallet.ServiceLayer.Contract.IEntityServices.ITransactionServices.DTOs; 

namespace Wallet.ServiceLayer.Persistence.Mapper
{
    public class DBAutoMapperProfile : Profile
    {
        public DBAutoMapperProfile()
        {
            
 
            
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
 
        }
    }
}
