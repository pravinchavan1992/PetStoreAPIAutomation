using ApiClient.Models;

namespace Tests.TestData
{
    public class PetTestData
    {
        public static Pet GetTestPet()
        {
            string localImagePath = Path.Combine(AppContext.BaseDirectory, "TestData", "testimage.jpg");

            return new Pet
            {
                Id = 0,
                Category = new Category { Id = 1, Name = "Dogs" },
                Name = "Buddy",
                PhotoUrls = new List<string> { localImagePath },
                Tags = new List<Tag> { new Tag { Id = 1, Name = "MyPet" } },
                Status = "available"
            };
        }

        public static Order GetTestOrder(long id)
        {
            return new Order
            {
                Id = 0,
                PetId = id,
                Quantity = 1,
                ShipDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                Status = "placed",
                Complete = false
            };
        }
    }
}