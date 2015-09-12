namespace Basket.Resources
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Representation of a Basket
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class BasketModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasketModel"/> class.
        /// </summary>
        public BasketModel()
        {
            BasketItems = new List<BasketItemModel>();
            Discounts = new List<DiscountModel>();
        }

        /// <summary>
        /// Gets or sets the <see cref="BasketItemModel"/> that have been added to the basket.
        /// </summary>
        public List<BasketItemModel> BasketItems { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DiscountModel"/>.
        /// </summary>
        public List<DiscountModel> Discounts { get; set; }

        /// <summary>
        /// Get the total cost of the basket items without any discounts.
        /// </summary>
        public decimal SubTotal => BasketItems.Sum(p => p.ItemTotal);

        /// <summary>
        /// Get the total cost of discounts applied to the basket.
        /// </summary>
        public decimal DiscountTotal => Discounts.Sum(d => d.Amount);

        /// <summary>
        /// Gets the total cost of the basket, includes any discounts.
        /// </summary>
        public decimal BasketTotal => SubTotal + DiscountTotal;

        /// <summary>
        /// Gets the display value to show in the debugger.
        /// </summary>
        private string DebuggerDisplay
        {
            get
            {
                var itemNames = BasketItems.Select(x => x.Product.Name).ToArray();
                return $"Products in basket: {string.Join(",", itemNames)}";
            }
        }
    }
}
