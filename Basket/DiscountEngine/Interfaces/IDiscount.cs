namespace Basket.DiscountEngine.Interfaces
{
    /// <summary>
    /// Interface to represent a single discount.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDiscount<T>
    {
        void ClearConditions();

        void Initialize(T obj);

        bool IsValid();

        T Apply(T obj);
    }
}
