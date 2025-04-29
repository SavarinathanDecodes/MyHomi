using MyHomi.PropertyManager.DataAccess.Interface;
using MyHomi.PropertyManager.Domain.Model.Entity;

namespace MyHomi.PropertyManager.DataAccess.Implementation
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(IUnitOfWork context) : base(context)
        {
        }
    }
}
