namespace StockCare.SharedInterfaces;

public interface IEntity<T>
{
	public T Id { get; set; }
}