
using Domain.Models;
using System.Text.Json;

namespace Common.Utilities
{
    public static class Utility
    {
        public static async Task<List<dynamic>> GetData(string url)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Throw an exception if HTTP request was unsuccessful
            var responseContent = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var data = JsonSerializer.Deserialize<List<dynamic>>(responseContent, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return data;
        }

        //public async Task<User> GetLoggedUserInfo()
        //{
        //    if (_httpContextAccessor.HttpContext.User.Claims.Any())
        //    {
        //        var userId = _httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
        //        return await _userManager.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
        //    }
        //    return null;
        //}



        //public string GetLoggedInUserId()
        //{
        //    return _httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
        //}

    }
}
