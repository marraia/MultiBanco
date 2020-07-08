using GasStation.Domain.Entities;
using GasStation.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasStation.Domain.Interfaces.Repositories
{
    public interface IStationRepository : IRepositoryBase<Station, int>
    {
    }
}
