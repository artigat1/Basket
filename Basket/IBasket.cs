namespace Basket
{
    using System.Collections.Generic;
    using Resources;

    public interface IBasket
    {
        /// <summary>
        /// Add the <paramref name="itemModel"/> to the basket.
        /// </summary>
        /// <param name="itemModel">The <see cref="BasketItemModel"/> to add to the basket.</param>
        /// <returns>The updated <see cref="BasketModel"/></returns>
        BasketModel AddBasketItem(BasketItemModel itemModel);

        /// <summary>
        /// Adds the <paramref name="items"/> to the basket.
        /// </summary>
        /// <param name="items">
        /// An <see cref="IEnumerable{TEntity}"/> of <see cref="BasketItemModel"/> entities to add to the basket.
        /// </param>
        /// <returns>The updated <see cref="BasketModel"/></returns>
        BasketModel AddBasketItems(IEnumerable<BasketItemModel> items);
    }
}
