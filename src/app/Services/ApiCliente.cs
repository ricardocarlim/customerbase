using app.Resources;

namespace app.Services
{
    public interface IApiCliente
    {
        Task<QueryResultResource<ClienteResource>> GetClientesAsync();
        Task<ClienteResource> GetClienteAsync(int id);
        Task CreateClienteAsync(ClienteResource cliente);
        Task UpdateClienteAsync(int id, ClienteResource cliente);
        Task DeleteClienteAsync(int id);
    }

    public class ApiCliente : IApiCliente
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7177/api";

        public ApiCliente(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<QueryResultResource<ClienteResource>> GetClientesAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/Cliente");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<QueryResultResource<ClienteResource>>();
        }

        public async Task<ClienteResource> GetClienteAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/Cliente/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClienteResource>();
        }

        public async Task CreateClienteAsync(ClienteResource cliente)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/Cliente", cliente);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateClienteAsync(int id, ClienteResource cliente)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/Cliente/{id}", cliente);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/Cliente/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}
