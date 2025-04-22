using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Olx_uz.Models;
using RealEstateApp.Models;

namespace Olx_uz.Services;

public static class ApiService
{
    public static async Task<bool> RegisterUser(string name, string email, string password, string phone)
    {
        var register = new Register()
        {
            Name = name,
            Email = email,
            Password = password,
            Phone = phone
        };
        
        var httpClient = new HttpClient();
        
        var response = await  httpClient.PostAsJsonAsync(AppSettings.BaseUrl + "api/users/register", register);
        
        string result = await response.Content.ReadAsStringAsync();

        Console.WriteLine("Response: " + result);
        
        return response.IsSuccessStatusCode;
    }


    public static async Task<bool> Login(string email, string password)
    {
        var login = new Login()
        {
            Email = email,
            Password = password
        };
        
        
        var httpClient = new HttpClient();
        
        var response = await httpClient.PostAsJsonAsync(AppSettings.BaseUrl + "api/users/login", login);
        
        var json = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<Token>(json);
        Preferences.Set("accesstoken",result?.AccessToken);
        Preferences.Set("userid",result?.UserId.ToString());
        Preferences.Set("username",result?.UserName);
        
        return response.IsSuccessStatusCode;
    }

    public static async Task<List<Category>> GetCategories()
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",Preferences.Get("accesstoken",string.Empty));
        var response = await httpClient.GetStringAsync(AppSettings.BaseUrl + "api/categories");
        
        var items = JsonConvert.DeserializeObject<List<Category>>(response);
        
        return items!;
    }
    
    public static async Task<List<TrendingProperty>> GetTrendingProperties()
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",Preferences.Get("accesstoken",string.Empty));
        var response = await httpClient.GetStringAsync(AppSettings.BaseUrl + "api/Properties/TrendingProperties");
        
        var items = JsonConvert.DeserializeObject<List<TrendingProperty>>(response);
        
        return items!;
    }
    
    
    public static async Task<List<SearchProperty>> FindProperties(string address)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",Preferences.Get("accesstoken",string.Empty));
        var response = await httpClient.GetStringAsync(AppSettings.BaseUrl + "api/Properties/SearchProperties?address=" + address);
        
        var items = JsonConvert.DeserializeObject<List<SearchProperty>>(response);
        
        return items!;
    } 
    
    public static async Task<List<PropertyByCategory>> GetPropertyByCategory(int categoryId)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",Preferences.Get("accesstoken",string.Empty));
        var response = await httpClient.GetStringAsync(AppSettings.BaseUrl + "api/Properties/PropertyList?categoryId=" + categoryId);
        
        var items = JsonConvert.DeserializeObject<List<PropertyByCategory>>(response);
        
        return items!;
    }  
    
    public static async Task<PropertyDetail> GetPropertyDetail(int propertyId)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",Preferences.Get("accesstoken",string.Empty));
        var response = await httpClient.GetStringAsync(AppSettings.BaseUrl + "api/Properties/PropertyDetail?id=" + propertyId);
        
        var items = JsonConvert.DeserializeObject<PropertyDetail>(response);
        
        return items!;
    }
    
    
    public static async Task<List<BookmarkList>> GetBookmarkList()
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",Preferences.Get("accesstoken",string.Empty));
        var response = await httpClient.GetStringAsync(AppSettings.BaseUrl + "api/bookmarks");
        
        var items = JsonConvert.DeserializeObject<List<BookmarkList>>(response);
        
        return items!;
    }
    
    
    public static async Task<bool> AddBookmark(AddBookmark addBookmark)
    {
        
        var httpClient = new HttpClient();
        
        var response = await  httpClient.PostAsJsonAsync(AppSettings.BaseUrl + "api/users/register", addBookmark);
        
        return response.IsSuccessStatusCode;
    }
    
    
    public static async Task<bool> DeleteBookmark(int propertyId)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",Preferences.Get("accesstoken",string.Empty));
        var response = await httpClient.DeleteAsync(AppSettings.BaseUrl + "api/bookmarks/" + propertyId);
        
        return response.IsSuccessStatusCode;
    }
    
    
}