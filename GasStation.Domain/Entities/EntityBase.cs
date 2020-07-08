namespace GasStation.Domain.Entities
{
    public class EntityBase<T> 
        where T : struct
    {
        public T Id { get; set; }
    }
}
