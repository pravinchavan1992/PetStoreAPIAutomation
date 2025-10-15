using System.Net.Http.Json;
using ApiClient.Models;

namespace ApiClient.Services
{
    public class PetServices
    {
        private readonly HttpClient _httpClient;

        public PetServices()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://petstore.swagger.io/v2/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("api_key", "special-key");
        }

        public async Task<Pet> AddNewPet(Pet pet)
        {
            var response = await _httpClient.PostAsJsonAsync("pet", pet);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Pet>();
        }

        public async Task<Order> PlacePetOrder(Order order)
        {
            var response = await _httpClient.PostAsJsonAsync("store/order", order);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Order>();
        }

        public async Task<Order> GetOrderByID(long orderId)
        {

              for (int i = 0; i < 3; i++)
            {
                var response = await _httpClient.GetAsync($"store/order/{orderId}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Order found.: " + await response.Content.ReadAsStringAsync());
                    return await response.Content.ReadFromJsonAsync<Order>();
                }

                await Task.Delay(5000); 
            }

           throw new HttpRequestException($"GetOrderByID: Order with ID {orderId} not found after 3 retries.");
        }
        public async Task<OrderDelete> DeleteOrderByID(long orderId)
        {
              for (int i = 0; i < 3; i++)
            {
                var response = await _httpClient.DeleteAsync($"store/order/{orderId}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Order found.: " + await response.Content.ReadAsStringAsync());
                    return await response.Content.ReadFromJsonAsync<OrderDelete>();
                }

                await Task.Delay(5000); 
            }

           throw new HttpRequestException($"DeleteOrderByID: Order with ID {orderId} not found after 3 retries.");
        }

    }
}