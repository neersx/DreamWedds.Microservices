﻿using DreamWedds.Web.Utility;
using System.ComponentModel.DataAnnotations;

namespace DreamWedds.Web.Models
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        [Range(1,100)]
        public int Count { get; set; } = 1;
        [MaxFileSize(1)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile? Image { get; set; }
    }
}
