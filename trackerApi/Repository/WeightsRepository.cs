using trackerApi.Contracts;
using trackerApi.Data;

namespace trackerApi.Repository
{
    public class WeightsRepository : GenericRepository<Weight>, IWeightsRepository
    {
        public WeightsRepository(UserDataDbContext context) : base(context)
        {

        }
    }
}
