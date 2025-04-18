﻿using DreamWedds.Web.Models;
using DreamWedds.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;

namespace DreamWedds.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService=productService;
        }


        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto>? list = new();

            ResponseDto? response = await _productService.GetAllProductsAsync();

            if (response != null && response.IsSuccess)
            {
                list= JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ProductCreate([FromForm] FoodMasterDto model)
        {
            // Process Ingredients
            var selectedIngredients = Request.Form["Ingredients[]"].ToList();

            // Process Images
            var images = Request.Form["Images[]"]
                                .Select(i => JsonConvert.DeserializeObject<Image>(i))
                                .ToList();

            // Process FoodItems
            var foodItems = new List<FoodItem>();
            var foodItemsRaw = Request.Form["FoodItems[]"].ToList();

            foreach (var item in foodItemsRaw)
            {
                if (item.StartsWith("{")) // If JSON string, deserialize it
                {
                    FoodItem foodItem = JsonConvert.DeserializeObject<FoodItem>(item);


                    if (foodItem != null)
                    {
                        foodItems.Add(foodItem);
                    }
                }
            }


            if (ModelState.IsValid)
            {
                ResponseDto? response = await _productService.CreateProductsAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Product created successfully";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ProductDelete(string productId)
        {
			ResponseDto? response = await _productService.GetProductByIdAsync(productId);

			if (response != null && response.IsSuccess)
			{
                ProductDto? model= JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
			}
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDto productDto)
        {
            ResponseDto? response = await _productService.DeleteProductsAsync(productDto.Id);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Product deleted successfully";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(productDto);
        }

        public async Task<IActionResult> ProductEdit(string productId)
        {
            ResponseDto? response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
                FoodMasterDto? model = JsonConvert.DeserializeObject<FoodMasterDto>(Convert.ToString(response.Result));
         
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ProductEdit([FromForm] FoodMasterDto productDto)
        {
            // Process Ingredients
            var selectedIngredients = Request.Form["Ingredients[]"].ToList();

            // Process Images
            var images = Request.Form["Images[]"]
                                .Select(i => JsonConvert.DeserializeObject<Image>(i))
                                .ToList();

            // Process FoodItems
            var foodItems = new List<FoodItem>();
            var foodItemsRaw = Request.Form["FoodItems[]"].ToList();

            foreach (var item in foodItemsRaw)
            {
                if (item.StartsWith("{")) // If JSON string, deserialize it
                {
                    FoodItem foodItem = JsonConvert.DeserializeObject<FoodItem>(item);
                   

                    if (foodItem != null)
                    {
                        foodItems.Add(foodItem);
                    }
                }
            }

            if (ModelState.IsValid)
            {
                ResponseDto? response = await _productService.UpdateProductsAsync(productDto);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Product updated successfully";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return Json(new { success = true, message = "Product updated successfully!" });
        }

    }
}
