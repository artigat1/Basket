namespace Basket.DiscountEngine.Discounts
{
    using System;
    using System.Linq;
    using Conditions;
    using Resources;

    /// <summary>
    /// Buy 2 of 1 product and get 50% off another product
    /// </summary>
    public class Buy2Get50PercentOff : BaseDiscount<BasketModel>
    {
        private readonly ProductModel _buyingProduct;
        private readonly ProductModel _discountProduct;
        private int _numOfBuyProducts;
        private int _numOfDiscountProductsInBasket;

        /// <summary>
        /// Initializes a new instance of the <see cref="Buy2Get50PercentOff"/> class.
        /// </summary>
        /// <param name="buyingProduct">The <see cref="ProductModel"/> to be bought.</param>
        /// <param name="discountProduct">The <see cref="ProductModel"/> to get the 50% discount.</param>
        public Buy2Get50PercentOff(ProductModel buyingProduct, ProductModel discountProduct)
        {
            if (buyingProduct == null)
                throw new ArgumentNullException(nameof(buyingProduct));
            if (discountProduct == null)
                throw new ArgumentNullException(nameof(discountProduct));

            _buyingProduct = buyingProduct;
            _discountProduct = discountProduct;
        }

        /// <summary>
        /// Initializes the rule for the current <paramref name="basket"/>.
        /// </summary>
        /// <param name="basket">The <see cref="BasketModel"/>.</param>
        public override void Initialize(BasketModel basket)
        {
            // Need to check the basket contains at least 2 of the items being bought
            // And at least 1 item to apply the discount to.
            _numOfBuyProducts = (basket.BasketItems
                                       .Where(p => p.Product.Name == _buyingProduct.Name)
                                       .Select(p => p.Quantity)).Sum();
            _numOfDiscountProductsInBasket = (basket.BasketItems
                                            .Where(p => p.Product.Name == _discountProduct.Name)
                                            .Select(p => p.Quantity)).Sum();

            Conditions.Add(new GreaterThan(1, _numOfBuyProducts));
            Conditions.Add(new GreaterThan(0, _numOfDiscountProductsInBasket));
        }

        /// <summary>
        /// Adds this discount rule to the <paramref name="basket"/>.
        /// </summary>
        /// <param name="basket">The <see cref="BasketModel"/>.</param>
        /// <returns>The update <see cref="BasketModel"/> with the discount.</returns>
        public override BasketModel Apply(BasketModel basket)
        {
            // Only get discount off 1 discount product with every 2 buy products
            // 2 butter would give discount on 1 loaf of bread
            // 4 butter would give discount on 2 loaves of bread

            // Get the number of discounts available for the basket
            var numberOfDiscounts = _numOfBuyProducts/2;

            // Want to check only applying 1 discount for every 2 products bought
            var numberOfProductsToApplyDiscountTo = _numOfDiscountProductsInBasket;
            if (numberOfProductsToApplyDiscountTo >= numberOfDiscounts)
            {
                numberOfProductsToApplyDiscountTo = numberOfDiscounts;
            }

            var discountAmount = ((0.5M*_discountProduct.Price)*numberOfProductsToApplyDiscountTo) *-1;

            basket.Discounts.Add(
                new DiscountModel
                {
                    Description = $"Buy 2 {_buyingProduct.Name} and get 50% off {_discountProduct.Name}.",
                    Amount = discountAmount,
                });

            return basket;
        }
    }
}
