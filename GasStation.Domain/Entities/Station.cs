﻿namespace GasStation.Domain.Entities
{
    public class Station 
        : EntityBase<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
