namespace Basket.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoMoq;
    using Resources;

    /// <summary>
    /// Tests for the <see cref="BasketModel"/>.
    /// </summary>
    public class BasketSpecs
    {
        [Subject("Basket")]
        public class When_adding_an_item_to_the_basket
        {
            static BasketItemModel _itemModel;
            static IBasket _sut;
            static BasketModel _actual;

            Establish context = () =>
            {
                var fixture = new Fixture().Customize(new AutoMoqCustomization());
                _itemModel = fixture.Create<BasketItemModel>();

                _sut = new Basket();
            };

            Because of = () => _actual = _sut.AddBasketItem(_itemModel);

            It Should_have_the_correct_total = () => _actual.BasketTotal.ShouldEqual(_itemModel.ItemTotal);
        }

        [Subject("Basket")]
        public class When_adding_multiple_items_to_the_basket
        {
            static List<BasketItemModel> _items;
            static IBasket _sut;
            static BasketModel _actual;
            static decimal _expectedTotal;

            Establish context = () =>
            {
                var fixture = new Fixture().Customize(new AutoMoqCustomization());
                _items = fixture.Create<List<BasketItemModel>>();

                _expectedTotal = _items.Sum(x => x.ItemTotal);

                _sut = new Basket();
            };

            Because of = () => _actual = _sut.AddBasketItems(_items);

            It Should_have_the_correct_total = () => _actual.BasketTotal.ShouldEqual(_expectedTotal);
        }

        [Subject("Basket")]
        public class When_adding_1_bread_and_1_butter_and_1_milk
        {
            static List<BasketItemModel> _items;
            static IBasket _sut;
            static BasketModel _actual;

            Establish context = () =>
            {
                _items = new List<BasketItemModel>
                         {
                             new BasketItemModel(Stock.Bread, 1),
                             new BasketItemModel(Stock.Butter, 1),
                             new BasketItemModel(Stock.Milk, 1),

                         };

                _sut = new Basket();
            };

            Because of = () => _actual = _sut.AddBasketItems(_items);

            It Should_have_expected_total = () => _actual.BasketTotal.ShouldEqual(2.95M);
        }
    }
}