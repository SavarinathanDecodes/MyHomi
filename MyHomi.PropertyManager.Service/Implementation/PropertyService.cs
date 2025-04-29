using MyHomi.PropertyManager.DataAccess.Interface;
using MyHomi.PropertyManager.Domain.Model.Entity;
using MyHomi.PropertyManager.Service.Interface;
using MyHomi.PropertyManager.ViewModel.Request;
using MyHomi.PropertyManager.ViewModel.Response;

namespace MyHomi.PropertyManager.Service.Implementation
{
    public class PropertyService : IPropertyService
    {
        #region Private members

        private readonly IPropertyRepository _propertyRepository;
        private readonly CancellationToken _cancellationToken;

        #endregion

        #region Constractor

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
            _cancellationToken = CancellationToken.None;
        }

        #endregion

        #region Public methods

        public async Task<PropertyResponseVM> CreateProperty(PropertyRequestVM propertyRequest)
        {
            const string LOG_ID = "PropertyService::CreateProperty";
            PropertyResponseVM propertyResponse = null!;

            try
            {
                Property property = new()
                {
                    Id = propertyRequest.Id,
                    Area = propertyRequest.Area,
                    Price = propertyRequest.Price,
                    Title = propertyRequest.Title,
                    Type = propertyRequest.Type,
                };

                var spropertyResponse = await _propertyRepository.Create(property, _cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LOG_ID} {ex.Message}");
            }
            return propertyResponse;
        }

        #endregion
    }
}
