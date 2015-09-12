namespace Basket.DiscountEngine.Discounts
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    /// <summary>
    /// An abstract base class for all the discounts to implement.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseDiscount<T> : IDiscount<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDiscount{T}"/> class.
        /// </summary>
        protected BaseDiscount()
        {
            Conditions = new List<ICondition>();
        }

        /// <summary>
        /// Gets or sets the <see cref="ICondition"/> for this discount.
        /// </summary>
        public IList<ICondition> Conditions { get; set; }

        /// <summary>
        /// Clears the discount conditions.
        /// </summary>
        public void ClearConditions()
        {
            Conditions.Clear();
        }

        /// <summary>
        /// Determines whether this discount is valid.
        /// </summary>
        public bool IsValid()
        {
            return Conditions.All(x => x.IsSatisfied());
        }

        /// <summary>
        /// Initializes the specified object.
        /// Each concrete class will have it's own implementation of this method
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Initialize(T obj)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Applies the discount to the object.
        /// Each concrete class will have it's own implementation of this method
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The updated object</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual T Apply(T obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
