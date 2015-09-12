namespace Basket.DiscountEngine
{
    using System.Collections.Generic;
    using Interfaces;
    using Resources;

    public static class DiscountEngine
    {
        /// <summary>
        /// Applies the list of <see cref="IDiscount{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object the discounts are being applied to.</param>
        /// <param name="discounts">The <see cref="List{T}"/> of <see cref="DiscountModel"/> entities.</param>
        /// <returns>The updated <paramref name="obj"/></returns>
        public static T ApplyDiscounts<T>(this T obj, List<IDiscount<T>> discounts) where T : class
        {
            foreach (var discount in discounts)
            {
                obj.ApplyDiscount(discount);
            }

            return obj;
        }

        /// <summary>
        /// Applies a single <see cref="IDiscount{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object the discounts are being applied to.</param>
        /// <param name="discount">The <see cref="IDiscount{T}"/>.</param>
        /// <returns>The updated <paramref name="obj"/></returns>
        public static T ApplyDiscount<T>(this T obj, IDiscount<T> discount) where T : class
        {
            discount.ClearConditions();
            discount.Initialize(obj);

            if (discount.IsValid())
            {
                discount.Apply(obj);
            }

            return obj;
        }
    }
}
