using GasStation.Domain.Entities;
using GasStation.Domain.Interfaces.Repositories;
using GasStation.Repositories.Context;
using GasStation.Repositories.Repository.Base;

namespace GasStation.Repositories.Repository
{
    public class StationRepository : RepositoryBase<Station, int>, IStationRepository
    {
        public StationRepository(
           GasStationContext context)
           : base(context)
        {
            
        }
    }
}
