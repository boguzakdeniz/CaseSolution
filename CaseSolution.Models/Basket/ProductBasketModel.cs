namespace CaseSolution.Models.Basket
{
    public class ProductBasketModel
    {
        public string ProductId;
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public double Total
        {
            get
            {
                return Amount * Quantity;
            }
        }
    }
}
