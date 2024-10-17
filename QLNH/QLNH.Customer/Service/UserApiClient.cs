﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using QLNH.Data.ViewModels;
using System.Net.Http.Headers;
using QLNH.Customer.Service;
using QLNH.Data.Models;

namespace QLNH.Customer.Service
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7244");
            return client;
        }

        public async Task<string> Authenticate(LoginReQuest loginRequest)
        {
            var json = JsonConvert.SerializeObject(loginRequest);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = CreateClient();

            var response = await client.PostAsync("/api/Author/login", httpContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
                return tokenResponse.Token;
            }
            else
            {
                // Xử lý lỗi nếu cần thiết
                return null;
            }
        }

        public HttpClient CreateClientWithToken(string token)
        {
            var client = CreateClient();
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        // Phương thức để gọi API không cần token
        public async Task<ResponeMessage> GetDataWithoutToken(string url)
        {
            var client = CreateClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponeMessage>(json);
            }

            return new ResponeMessage { IsSuccess = false, Message = "Failed to call API" }; // Xử lý lỗi
        }

        public class TokenResponse
        {
            public string Token { get; set; }
        }
    }
}
