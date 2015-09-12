namespace Basket.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoMoq;
    using Resources;
    using Services;

    /// <summary>
    /// Tests for the <see cref="Basket"/>.
    /// </summary>
    public class BasketSpecs
    {
        [Subject("Basket")]
        public class When_adding_an_item_to_the_basket
        {
            static BasketItem _item;
            static IBasketService _sut;
            static Basket _actual;

            Establish context = () =>
            {
                var fixture = new Fixture().Customize(new AutoMoqCustomization());
                _item = fixture.Create<BasketItem>();

                _sut = new BasketService();
            };

            Because of = () => _actual = _sut.AddBasketItem(_item);

            It Should_have_the_correct_total = () => _actual.BasketTotal.ShouldEqual(_item.ItemTotal);
        }

        [Subject("Basket")]
        public class When_adding_multiple_items_to_the_basket
        {
            static List<BasketItem> _items;
            static IBasketService _sut;
            static Basket _actual;
            static decimal _expectedTotal;

            Establish context = () =>
            {
                var fixture = new Fixture().Customize(new AutoMoqCustomization());
                _items = fixture.Create<List<BasketItem>>();

                _expectedTotal = _items.Sum(x => x.ItemTotal);

                _sut = new BasketService();
            };

            Because of = () => _actual = _sut.AddBasketItems(_items);

            It Should_have_the_correct_total = () => _actual.BasketTotal.ShouldEqual(_expectedTotal);
        }
    }
}