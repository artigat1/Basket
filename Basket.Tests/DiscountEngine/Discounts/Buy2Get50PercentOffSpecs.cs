namespace Basket.Tests.DiscountEngine.Discounts
{
    using System.Collections.Generic;
    using Machine.Specifications;
    using global::Basket.DiscountEngine.Discounts;
    using Resources;

    /// <summary>
    /// Tests for <see cref="Buy2Get50PercentOff"/>
    /// </summary>
    public class Buy2Get50PercentOffSpecs
    {
        [Subject("Buy 2 get 50% off")]
        public class When_adding_a_basket_with_2_milk_and_1_bread
        {
            private static Buy2Get50PercentOff _sut;
            private static BasketModel _basket;
            private static BasketModel _actual;

            Establish context = () =>
            {
                _basket = new BasketModel
                {
                    BasketItems = new List<BasketItemModel>
                                            {
                                                new BasketItemModel(Stock.Milk, 2),
                                                new BasketItemModel(Stock.Bread, 1),
                                            }
                };

                _sut = new Buy2Get50PercentOff(Stock.Milk, Stock.Bread);
                _sut.Initialize(_basket);
            };

            Because of = () => _sut.Apply(_basket);

            It Should_contain_a_discount_item = () => _basket.Discounts.Count.ShouldEqual(1);

            It Should_be_discount_for_half_the_bread_cost = () => _basket.DiscountTotal.ShouldEqual((Stock.Bread.Price * 0.5M) * -1);
        }

        [Subject("Buy 2 get 50% off")]
        public class When_adding_a_basket_with_2_bread_and_1_butter
        {
            private static Buy2Get50PercentOff _sut;
            private static BasketModel _basket;
            private static BasketModel _actual;

            Establish context = () =>
            {
                _basket = new BasketModel
                {
                    BasketItems = new List<BasketItemModel>
                                            {
                                                new BasketItemModel(Stock.Bread, 2),
                                                new BasketItemModel(Stock.Butter, 1),
                                            }
                };

                _sut = new Buy2Get50PercentOff(Stock.Bread, Stock.Butter);
                _sut.Initialize(_basket);
            };

            Because of = () => _sut.Apply(_basket);

            It Should_contain_a_discount_item = () => _basket.Discounts.Count.ShouldEqual(1);

            It Should_be_discount_for_half_the_butter_cost = () => _basket.DiscountTotal.ShouldEqual((Stock.Butter.Price * 0.5M) * -1);
        }

        [Subject("Buy 2 get 50% off")]
        public class When_adding_a_basket_with_4_bread_and_1_butter
        {
            private static Buy2Get50PercentOff _sut;
            private static BasketModel _basket;
            private static BasketModel _actual;

            Establish context = () =>
            {
                _basket = new BasketModel
                {
                    BasketItems = new List<BasketItemModel>
                                            {
                                                new BasketItemModel(Stock.Bread, 4),
                                                new BasketItemModel(Stock.Butter, 1),
                                            }
                };

                _sut = new Buy2Get50PercentOff(Stock.Bread, Stock.Butter);
                _sut.Initialize(_basket);
            };

            Because of = () => _sut.Apply(_basket);

            It Should_contain_a_discount_item = () => _basket.Discounts.Count.ShouldEqual(1);

            It Should_be_discount_for_half_the_butter_cost = () => _basket.DiscountTotal.ShouldEqual((Stock.Butter.Price * 0.5M) * -1);
        }

        [Subject("Buy 2 get 50% off")]
        public class When_adding_a_basket_with_4_bread_and_2_butter
        {
            private static Buy2Get50PercentOff _sut;
            private static BasketModel _basket;
            private static BasketModel _actual;

            Establish context = () =>
            {
                _basket = new BasketModel
                {
                    BasketItems = new List<BasketItemModel>
                                            {
                                                new BasketItemModel(Stock.Bread, 4),
                                                new BasketItemModel(Stock.Butter, 2),
                                            }
                };

                _sut = new Buy2Get50PercentOff(Stock.Bread, Stock.Butter);
                _sut.Initialize(_basket);
            };

            Because of = () => _sut.Apply(_basket);

            It Should_contain_a_discount_item = () => _basket.Discounts.Count.ShouldEqual(1);

            It Should_be_discount_for_half_the_butter_cost = () => _basket.DiscountTotal.ShouldEqual(((Stock.Butter.Price*2) * 0.5M) * -1);
        }
    }
}
