namespace Basket.Tests.DiscountEngine.Discounts
{
    using System.Collections.Generic;
    using global::Basket.DiscountEngine.Discounts;
    using Machine.Specifications;
    using Resources;

    /// <summary>
    /// Tests for <see cref="Buy3Get4ThFree"/>
    /// </summary>
    public class Buy3Get4ThFreeSpecs
    {
        [Subject("Buy 3 of a product and get 4th free")]
        public class When_adding_a_basket_with_4_milk
        {
            private static Buy3Get4ThFree _sut;
            private static BasketModel _basket;

            Establish context = () =>
            {
                _basket = new BasketModel
                {
                    BasketItems = new List<BasketItemModel>
                                            {
                                                new BasketItemModel(Stock.Milk, 4),
                                            }
                };

                _sut = new Buy3Get4ThFree(Stock.Milk);
                _sut.Initialize(_basket);
            };

            Because of = () => _sut.Apply(_basket);

            It Should_contain_a_discount_item = () => _basket.Discounts.Count.ShouldEqual(1);

            It Should_discount_of_cost_of_1_milk = () => _basket.DiscountTotal.ShouldEqual(Stock.Milk.Price*-1);
        }

        [Subject("Buy 3 of a product and get 4th free")]
        public class When_adding_a_basket_with_8_milk
        {
            private static Buy3Get4ThFree _sut;
            private static BasketModel _basket;

            Establish context = () =>
            {
                _basket = new BasketModel
                {
                    BasketItems = new List<BasketItemModel>
                                            {
                                                new BasketItemModel(Stock.Milk, 8),
                                            }
                };

                _sut = new Buy3Get4ThFree(Stock.Milk);
                _sut.Initialize(_basket);
            };

            Because of = () => _sut.Apply(_basket);

            It Should_contain_a_discount_item = () => _basket.Discounts.Count.ShouldEqual(1);

            It Should_be_discount_of_cost_of_2_milk = () => _basket.DiscountTotal.ShouldEqual((Stock.Milk.Price*2)*-1);
        }

        [Subject("Buy 3 of a product and get 4th free")]
        public class When_adding_a_basket_with_4_bread
        {
            private static Buy3Get4ThFree _sut;
            private static BasketModel _basket;

            Establish context = () =>
            {
                _basket = new BasketModel
                {
                    BasketItems = new List<BasketItemModel>
                                            {
                                                new BasketItemModel(Stock.Bread, 4),
                                            }
                };

                _sut = new Buy3Get4ThFree(Stock.Bread);
                _sut.Initialize(_basket);
            };

            Because of = () => _sut.Apply(_basket);

            It Should_contain_a_discount_item = () => _basket.Discounts.Count.ShouldEqual(1);

            It Should_discount_of_cost_of_1_bread = () => _basket.DiscountTotal.ShouldEqual(Stock.Bread.Price * -1);
        }
    }
}
