using GasStation.Domain.Entities;
using GasStation.Domain.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GasStation.Domain.Interfaces.Entity
{
    public interface IStationDomainService
    {
        Task<Station> InsertAsync(StationInput station);
        Task<Station> AlterAsync(int id, Station station);
        Task DeleteAsync(int id);
        Task<IEnumerable<Station>> GetAsync();
        Task<Station> GetByIdAsync(int id);
    }
}
