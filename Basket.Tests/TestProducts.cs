namespace Basket.Tests
{
    using Resources;

    /// <summary>
    /// Products to use for testing
    /// </summary>
    public class TestProducts
    {
        public Product Butter => new Product
                                 {
                                     Name = "Butter",
                                     Price = 0.8M,
                                 };

        public Product Milk => new Product
                               {
                                   Name = "Milk",
                                   Price = 1.15M,
                               };

        public Product Bread => new Product
                                {
                                    Name = "Bread",
                                    Price = 1M,
                                };
    }
}
