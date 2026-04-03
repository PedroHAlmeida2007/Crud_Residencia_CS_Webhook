using System.Net.Http;
using System.Text;
using System.Text.Json;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // GET
    public async Task<string> GetProdutos()
    {
        var response = await _httpClient.GetAsync("http://localhost:3000/produtos");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    // POST
    public async Task<string> PostProduto(object produto)
    {
        var json = JsonSerializer.Serialize(produto);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("http://localhost:3000/produtos", content);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    // PUT
    public async Task<string> PutProduto(int id, object produto)
    {
        var json = JsonSerializer.Serialize(produto);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"http://localhost:3000/produtos/{id}", content);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    // DELETE
    public async Task<string> DeleteProduto(int id)
    {
        var response = await _httpClient.DeleteAsync($"http://localhost:3000/produtos/{id}");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}