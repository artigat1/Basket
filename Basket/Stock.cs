namespace Basket
{
    using Resources;

    /// <summary>
    /// The stock avaailable to add to the basket
    /// </summary>
    public static class Stock
    {
        public static ProductModel Butter => new ProductModel("Butter", 0.8M);

        public static ProductModel Milk => new ProductModel("Milk", 1.15M);

        public static ProductModel Bread => new ProductModel("Bread", 1M);
    }
}
