using MyHomi.PropertyManager.ViewModel.Request;
using MyHomi.PropertyManager.ViewModel.Response;

namespace MyHomi.PropertyManager.Service.Interface
{
    public interface IPropertyService
    {
        Task<PropertyResponseVM> CreateProperty(PropertyRequestVM propertyRequest);
    }
}
