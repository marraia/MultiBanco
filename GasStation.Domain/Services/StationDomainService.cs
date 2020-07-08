using GasStation.Domain.Entities;
using GasStation.Domain.Input;
using GasStation.Domain.Interfaces.Entity;
using GasStation.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GasStation.Domain.Services
{
    public class StationDomainService : IStationDomainService
    {
        private readonly IStationRepository _stationRepository;
        public StationDomainService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<Station> AlterAsync(int id, Station station)
        {
            await _stationRepository
                    .AlterAsync(station)
                    .ConfigureAwait(false);

            return station;
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await GetByIdAsync(id)
                            .ConfigureAwait(false);

            await _stationRepository
                    .DeleteAsync(obj)
                    .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Station>> GetAsync()
        {
            return await _stationRepository
                            .GetAsync()
                            .ConfigureAwait(false);
        }

        public async Task<Station> GetByIdAsync(int id)
        {
            return await _stationRepository
                            .GetByIdAsync(id)
                            .ConfigureAwait(false);
        }

        public async Task<Station> InsertAsync(StationInput input)
        {
            var station = new Station()
            {
                Name = input.Name,
                Address = input.Address,
                Phone = input.Phone
            };

            await _stationRepository
                    .InsertAsync(station)
                    .ConfigureAwait(false);

            return station;
        }
    }
}
