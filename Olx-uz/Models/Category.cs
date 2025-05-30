﻿using Newtonsoft.Json;

namespace Olx_uz.Models;

public class Category
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("imageUrl")]
    public string ImageUrl { get; set; }
    
    [JsonProperty("properties")]
    public object Properties { get; set; }
}