namespace Basket.DiscountEngine.Interfaces
{
    /// <summary>
    /// The smallest part of a discount rule.
    /// </summary>
    public interface ICondition
    {
        /// <summary>
        /// Determine whether this condition is satisfied.
        /// </summary>
        bool IsSatisfied();
    }
}
