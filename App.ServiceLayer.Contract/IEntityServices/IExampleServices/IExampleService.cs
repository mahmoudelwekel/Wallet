using App.ServiceLayer.Contract.IEntityServices.IExampleServices.DTOs;

namespace App.ServiceLayer.Contract.IEntityServices.IExampleServices
{
    public interface IExampleService
    {
        bool AddExample(ExampleDTO _Example);
        decimal GetUserExampleBalance(string _userID);
    }
}
