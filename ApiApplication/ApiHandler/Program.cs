using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ApiHandler<T>
{
    private readonly string _baseUrl;
    private readonly string _resource;

    public ApiHandler(string baseUrl, string resource)
    {
        _baseUrl = baseUrl;
        _resource = resource;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var url = $"{_baseUrl}/{_resource}/{id}";
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var entity = JsonConvert.DeserializeObject<T>(responseContent);
            return entity;
        }
    }

    public async Task<List<T>> GetAllAsync()
    {
        var url = $"{_baseUrl}/{_resource}";
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var entities = JsonConvert.DeserializeObject<List<T>>(responseContent);
            return entities;
        }
    }

    public async Task<T> CreateAsync(T entity)
    {
        var url = $"{_baseUrl}/{_resource}";
        using (var client = new HttpClient())
        {
            var json = JsonConvert.SerializeObject(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(responseContent);
            return data;
        }
    }

    public async Task UpdateAsync(int id, T entity)
    {
        var url = $"{_baseUrl}/{_resource}/{id}";
        using (var client = new HttpClient())
        {
            var json = JsonConvert.SerializeObject(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var url = $"{_baseUrl}/{_resource}/{id}";
        using (var client = new HttpClient())
        {
            var response = await client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
