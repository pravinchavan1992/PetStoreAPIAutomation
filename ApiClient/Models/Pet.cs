namespace ApiClient.Models
{
   public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class Pet
    {
        public long Id { get; set; }
        public Category Category { get; set; }
        public required string Name { get; set; }
        public required List<string> PhotoUrls { get; set; }
        public List<Tag> Tags { get; set; }
        public string Status { get; set; }
    }

    public class Order
    {
        public long Id { get; set; }
        public long PetId { get; set; }
        public int Quantity { get; set; }
        public string ShipDate { get; set; }
        public string Status { get; set; }
        public bool Complete { get; set; }
    }

        public class OrderDelete
    {
        public int Code { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}