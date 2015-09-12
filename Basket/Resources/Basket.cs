namespace Basket.Resources
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Representation of a Basket
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Basket"/> class.
        /// </summary>
        public Basket()
        {
            BasketItems = new List<BasketItem>();
        }

        /// <summary>
        /// The items that have been added to the basket
        /// </summary>
        public List<BasketItem> BasketItems { get; set; }

        /// <summary>
        /// The total cost of the basket items without any discounts.
        /// </summary>
        public decimal SubTotal => BasketItems.Sum(p => p.ItemTotal);

        /// <summary>
        /// The total cost of the basket, includes any discounts.
        /// </summary>
        public decimal BasketTotal => SubTotal;
    }
}
