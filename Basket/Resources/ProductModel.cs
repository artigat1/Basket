namespace Basket.Resources
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Representation of a Product
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ProductModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductModel"/> class.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="price">The price of the product.</param>
        public ProductModel(string name, decimal price)
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            Price = price;
        }

        /// <summary>
        /// Gets the product's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the cost of the product.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Gets the display value to show in the debugger.
        /// </summary>
        private string DebuggerDisplay => $"Product name: {Name}";
    }
}
