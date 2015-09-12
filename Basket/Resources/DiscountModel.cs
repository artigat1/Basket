namespace Basket.Resources
{
    using System.Diagnostics;

    /// <summary>
    /// Representation of a discount
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class DiscountModel
    {
        /// <summary>
        /// Gets or sets the description of the discount.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets the display value to show in the debugger.
        /// </summary>
        string DebuggerDisplay => $"Discount amount: {Amount.ToString("C2")}";
    }
}
