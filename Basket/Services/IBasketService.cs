namespace Basket.Services
{
    using System.Collections.Generic;
    using Resources;

    public interface IBasketService
    {
        /// <summary>
        /// Add the <paramref name="item"/> to the basket.
        /// </summary>
        /// <param name="item">The <see cref="BasketItem"/> to add to the basket.</param>
        /// <returns>The updated <see cref="Basket"/></returns>
        Basket AddBasketItem(BasketItem item);

        /// <summary>
        /// Adds the <paramref name="items"/> to the basket.
        /// </summary>
        /// <param name="items">
        /// An <see cref="IEnumerable{TEntity}"/> of <see cref="BasketItem"/> entities to add to the basket.
        /// </param>
        /// <returns>The updated <see cref="Basket"/></returns>
        Basket AddBasketItems(IEnumerable<BasketItem> items);
    }
}
