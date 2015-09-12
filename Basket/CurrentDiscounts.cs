namespace Basket
{
    using System;
    using DiscountEngine;
    using DiscountEngine.Discounts;
    using Resources;

    public class CurrentDiscounts
    {
        /// <summary>
        /// The <see cref="BasketModel"/>
        /// </summary>
        readonly BasketModel _basket;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentDiscounts"/> class.
        /// </summary>
        /// <param name="basket">The <see cref="BasketModel"/>.</param>
        public CurrentDiscounts(BasketModel basket)
        {
            if (basket == null)
                throw new ArgumentNullException(nameof(basket));

            _basket = basket;
        }

        /// <summary>
        /// Applies the discounts to the current <see cref="BasketModel"/>
        /// </summary>
        /// <returns>The updated <see cref="BasketModel"/></returns>
        public BasketModel Run()
        {
            _basket
                .ApplyDiscount(new Buy3Get4ThFree(Stock.Milk))
                .ApplyDiscount(new Buy2Get50PercentOff(Stock.Butter, Stock.Bread));

            return _basket;
        }
    }
}
