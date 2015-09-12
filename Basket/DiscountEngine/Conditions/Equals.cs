namespace Basket.DiscountEngine.Conditions
{
    using Interfaces;

    public class Equals : ICondition
    {
        readonly decimal _value1;
        readonly decimal _value2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Equals"/> class.
        /// </summary>
        /// <param name="value1">The first value to compare.</param>
        /// <param name="value2">The second value to compare.</param>
        public Equals(decimal value1, decimal value2)
        {
            _value1 = value1;
            _value2 = value2;
        }

        /// <summary>
        /// Determine whether this condition is satisfied.
        /// </summary>
        public bool IsSatisfied()
        {
            return _value1 == _value2;
        }
    }
}
