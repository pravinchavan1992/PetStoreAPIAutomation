using NUnit.Framework;
using ApiClient.Models;
using ApiClient.Services;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Tests
{
    [TestFixture]
    [AllureNUnit]
    public class PetOrderTest
    {
        private PetServices _petServices;

        [SetUp]
        public void Setup()
        {
            _petServices = new PetServices();
        }

        [Test]
        [AllureFeature("Place Order")]
        [AllureTag("Smoke", "Sanity")]
        [AllureSeverity(SeverityLevel.critical)]
        public async Task TestPlacePetOrder()
        {
            Pet pet = TestData.PetTestData.GetTestPet();
            var createdPet = await _petServices.AddNewPet(pet);
            
            Order order = TestData.PetTestData.GetTestOrder(createdPet.Id);
            var createdOrder = await _petServices.PlacePetOrder(order);
        
            var receivedOrder = await _petServices.GetOrderByID(createdOrder.Id);
            Assert.That(createdOrder.Id, Is.EqualTo(receivedOrder.Id), "Pet orderid mismatch. Order not placed successfully");

            await _petServices.DeleteOrderByID(createdOrder.Id);

            Assert.ThrowsAsync<HttpRequestException>(async () => await _petServices.GetOrderByID(createdOrder.Id));
        }
    }
}