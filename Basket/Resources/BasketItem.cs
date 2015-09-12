namespace Basket.Resources
{
    /// <summary>
    /// Representation of the items in a basket.
    /// </summary>
    public class BasketItem
    {
        /// <summary>
        /// The <see cref="Product"/>.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// The number of products.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The total cost of these products.
        /// </summary>
        public decimal ItemTotal => Product.Price*Quantity;
    }
}
