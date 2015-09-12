namespace Basket.Tests
{
    using System.Collections.Generic;
    using Machine.Specifications;
    using Resources;

    /// <summary>
    /// Tests for the basket applying discounts.
    /// </summary>
    public class BasketWithDiscountSpecs
    {
        [Subject("Basket with discounts applied")]
        public class When_adding_4_milk
        {
            static List<BasketItemModel> _items;
            static IBasket _sut;
            static BasketModel _actual;

            Establish context = () =>
            {
                _items = new List<BasketItemModel>
                         {
                             new BasketItemModel(Stock.Milk, 4),
                         };

                _sut = new Basket();
            };

            Because of = () => _actual = _sut.AddBasketItems(_items);

            It Should_have_expected_total = () => _actual.BasketTotal.ShouldEqual(3.45M);
        }

        [Subject("Basket with discounts applied")]
        public class When_adding_2_butter_and_2_bread
        {
            static List<BasketItemModel> _items;
            static IBasket _sut;
            static BasketModel _actual;

            Establish context = () =>
            {
                _items = new List<BasketItemModel>
                         {
                             new BasketItemModel(Stock.Butter, 2),
                             new BasketItemModel(Stock.Bread, 2),
                         };

                _sut = new Basket();
            };

            Because of = () => _actual = _sut.AddBasketItems(_items);

            It Should_have_expected_total = () => _actual.BasketTotal.ShouldEqual(3.10M);
        }

        [Subject("Basket with discounts applied")]
        public class When_adding_2_butter_and_1_bread_and_8_milk
        {
            static List<BasketItemModel> _items;
            static IBasket _sut;
            static BasketModel _actual;

            Establish context = () =>
            {
                _items = new List<BasketItemModel>
                         {
                             new BasketItemModel(Stock.Butter, 2),
                             new BasketItemModel(Stock.Bread, 1),
                             new BasketItemModel(Stock.Milk, 8),
                         };

                _sut = new Basket();
            };

            Because of = () => _actual = _sut.AddBasketItems(_items);

            It Should_have_expected_total = () => _actual.BasketTotal.ShouldEqual(9M);
        }
    }
}
