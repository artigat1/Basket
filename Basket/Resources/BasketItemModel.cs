namespace Basket.Resources
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Representation of the items in a basket.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class BasketItemModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasketItemModel"/> class.
        /// </summary>
        /// <param name="product">The <see cref="Product"/>.</param>
        /// <param name="quantity">The quantity of <paramref name="product"/>.</param>
        public BasketItemModel(ProductModel product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            Product = product;
            Quantity = quantity;
        }

        /// <summary>
        /// Gets the <see cref="Product"/>.
        /// </summary>
        public ProductModel Product { get; private set; }
        
        /// <summary>
        /// Gets the number of <see cref="Product"/>.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Gets the total cost of these products.
        /// </summary>
        public decimal ItemTotal => Product.Price*Quantity;

        /// <summary>
        /// Gets the display value to show in the debugger.
        /// </summary>
        string DebuggerDisplay => $"Product: {Product.Name}, Quantity: {Quantity}";
    }
}
