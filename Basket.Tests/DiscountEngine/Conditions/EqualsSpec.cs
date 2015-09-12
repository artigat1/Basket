namespace Basket.Tests.DiscountEngine.Conditions
{
    using global::Basket.DiscountEngine.Conditions;
    using Machine.Specifications;

    /// <summary>
    /// Tests for the <see cref="Equals"/> condition.
    /// </summary>
    public class EqualsSpec
    {
        [Subject("Equals")]
        public class When_2_numbers_are_the_same
        {
            private static Equals _sut;
            private static bool _result;

            Establish context = () =>
            {
                _sut = new Equals(2, 2);
            };

            Because of = () => _result = _sut.IsSatisfied();

            It Should_be_true = () => _result.ShouldBeTrue();
        }

        [Subject("Equals")]
        public class When_2_numbers_are_not_the_same
        {
            private static Equals _sut;
            private static bool _result;

            Establish context = () =>
            {
                _sut = new Equals(2, 4);
            };

            Because of = () => _result = _sut.IsSatisfied();

            It Should_be_false = () => _result.ShouldBeFalse();
        }
    }
}
