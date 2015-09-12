namespace Basket.Services
{
    using System;
    using System.Collections.Generic;
    using Resources;

    public class BasketService : IBasketService
    {
        /// <summary>
        /// The <see cref="Basket"/>
        /// </summary>
        readonly Basket _basket;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketService"/> class.
        /// </summary>
        public BasketService()
        {
            _basket = new Basket();
        }

        /// <summary>
        /// Add the <paramref name="item"/> to the basket.
        /// </summary>
        /// <param name="item">The <see cref="BasketItem"/> to add to the basket.</param>
        /// <returns>The updated <see cref="Basket"/></returns>
        public Basket AddBasketItem(BasketItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _basket.BasketItems.Add(item);

            return _basket;
        }

        /// <summary>
        /// Adds the <paramref name="items" /> to the basket.
        /// </summary>
        /// <param name="items">
        /// An <see cref="IEnumerable{TEntity}" /> of <see cref="BasketItem" /> entities to add to the basket.
        /// </param>
        /// <returns>The updated <see cref="Basket" /></returns>
        public Basket AddBasketItems(IEnumerable<BasketItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
            {
                AddBasketItem(item);
            }

            return _basket;
        }
    }
}
