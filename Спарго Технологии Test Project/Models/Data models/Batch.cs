namespace Spargo_Technology_Test_Project.Models.Data_models
{
    public class Batch
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Stock Stock { get; set; }
        public int Count { get; set; }
    }
}
