namespace Basket.DiscountEngine.Conditions
{
    using Interfaces;

    public class GreaterThan : ICondition
    {
        readonly decimal _value;
        readonly decimal _actual;

        /// <summary>
        /// Initializes a new instance of the <see cref="GreaterThan"/> class.
        /// </summary>
        /// <param name="value">The value that <paramref name="actual"/> should be greater than.</param>
        /// <param name="actual">The actual value to compare.</param>
        public GreaterThan(decimal value, decimal actual)
        {
            _value = value;
            _actual = actual;
        }

        /// <summary>
        /// Determine whether this condition is satisfied.
        /// </summary>
        public bool IsSatisfied()
        {
            return _value < _actual;
        }
    }
}
