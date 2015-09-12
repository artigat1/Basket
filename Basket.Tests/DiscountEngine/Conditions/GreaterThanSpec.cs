namespace Basket.Tests.DiscountEngine.Conditions
{
    using global::Basket.DiscountEngine.Conditions;
    using Machine.Specifications;

    /// <summary>
    /// Tests for the <see cref="GreaterThan"/> condition.
    /// </summary>
    public class GreaterThanSpec
    {
        [Subject("Greater than")]
        public class When_number_is_greater_than_expected
        {
            private static GreaterThan _sut;
            private static bool _result;

            Establish context = () =>
            {
                _sut = new GreaterThan(2, 5);
            };

            Because of = () => _result = _sut.IsSatisfied();

            It Should_be_true = () => _result.ShouldBeTrue();
        }

        [Subject("Greater than")]
        public class When_number_is_less_than_expected
        {
            private static GreaterThan _sut;
            private static bool _result;

            Establish context = () =>
            {
                _sut = new GreaterThan(2, 1);
            };

            Because of = () => _result = _sut.IsSatisfied();

            It Should_be_false = () => _result.ShouldBeFalse();
        }

        [Subject("Greater than")]
        public class When_numbers_are_equal
        {
            private static GreaterThan _sut;
            private static bool _result;

            Establish context = () =>
            {
                _sut = new GreaterThan(2, 2);
            };

            Because of = () => _result = _sut.IsSatisfied();

            It Should_be_false = () => _result.ShouldBeFalse();
        }
    }
}
