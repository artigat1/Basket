namespace Basket
{
    using System;
    using System.Collections.Generic;
    using Resources;

    public class Basket : IBasket
    {
        /// <summary>
        /// The <see cref="BasketModel"/>.
        /// </summary>
        private BasketModel _basket;

        /// <summary>
        /// The current discounts available for the basket.
        /// </summary>
        private readonly CurrentDiscounts _currentDiscounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="Basket"/> class.
        /// </summary>
        public Basket()
        {
            _basket = new BasketModel();
            _currentDiscounts = new CurrentDiscounts(_basket);
        }

        /// <summary>
        /// Add the <paramref name="itemModel"/> to the basket.
        /// </summary>
        /// <param name="itemModel">The <see cref="BasketItemModel"/> to add to the basket.</param>
        /// <returns>The updated <see cref="BasketModel"/></returns>
        public BasketModel AddBasketItem(BasketItemModel itemModel)
        {
            if (itemModel == null)
                throw new ArgumentNullException(nameof(itemModel));

            _basket.BasketItems.Add(itemModel);

            return _basket;
        }

        /// <summary>
        /// Adds the <paramref name="items" /> to the basket.
        /// </summary>
        /// <param name="items">
        /// An <see cref="IEnumerable{TEntity}" /> of <see cref="BasketItemModel" /> entities to add to the basket.
        /// </param>
        /// <returns>The updated <see cref="BasketModel" /></returns>
        public BasketModel AddBasketItems(IEnumerable<BasketItemModel> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
            {
                AddBasketItem(item);
            }
            
            _basket = _currentDiscounts.Run();

            return _basket;
        }
    }
}
