namespace Basket.DiscountEngine.Discounts
{
    using System;
    using System.Linq;
    using Conditions;
    using Resources;

    /// <summary>
    /// Buy 3 <see cref="ProductModel"/> and get the 4th one free.
    /// </summary>
    public class Buy3Get4ThFree : BaseDiscount<BasketModel>
    {
        private readonly ProductModel _product;
        private int _numOfMatchingProducts;

        /// <summary>
        /// Initializes a new instance of the <see cref="Buy3Get4ThFree"/> class.
        /// </summary>
        /// <param name="product">The <see cref="ProductModel"/> to apply this discount to.</param>
        public Buy3Get4ThFree(ProductModel product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _product = product;
        }


        /// <summary>
        /// Initializes the rule for the current <paramref name="basket"/>.
        /// </summary>
        /// <param name="basket">The <see cref="BasketModel"/>.</param>
        public override void Initialize(BasketModel basket)
        {
            _numOfMatchingProducts = (from p in basket.BasketItems
                                         where p.Product.Name == _product.Name
                                         select p.Quantity).Sum();
            
            Conditions.Add(new GreaterThan(3, _numOfMatchingProducts));
        }

        /// <summary>
        /// Adds this discount rule to the <paramref name="basket"/>.
        /// </summary>
        /// <param name="basket">The <see cref="BasketModel"/>.</param>
        /// <returns>The update <see cref="BasketModel"/> with the discount.</returns>
        public override BasketModel Apply(BasketModel basket)
        {
            int numberOfFreeProducts = _numOfMatchingProducts/ 3;
            decimal discountAmount = (_product.Price*numberOfFreeProducts)*-1;

            basket.Discounts.Add(
                new DiscountModel
                {
                    Description = $"Buy 3 {_product.Name} and get 1 free.",
                    Amount = discountAmount,
                });

            return basket;
        }
    }
}
