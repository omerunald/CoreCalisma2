﻿using Abc.Business.Abstract;
using Abc.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.UI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        IDistributedCache _distributedCache;
        public CategoryController(ICategoryService category, IDistributedCache distributedCache)
        {
            categoryService = category;
            _distributedCache = distributedCache;

        }

        public IActionResult Index()
        {
            var list = _distributedCache.GetString("category");


            if (list != null)
            {

                var cacheKey = "Time";
                var existingTime = _distributedCache.GetString(cacheKey); // Daha önceden bir cache var mı?

                existingTime = DateTime.Now.ToString(); // Zaman Bilgisi 
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions(); // Cache süresi ile ilgili işlemler için instance oluşturuldu.

                options.AbsoluteExpiration = DateTime.Now.AddSeconds(25); // Cache ömrü 1 dakika verildi.
                var pers = _distributedCache.Get("category");
                var personString = Encoding.UTF8.GetString(pers);
                var person = JsonConvert.DeserializeObject<List<Category>>(personString);

                 
                _distributedCache.SetString("category", JsonConvert.SerializeObject(categoryService.GetAllCategories()));


                return View(person);
        

            }


            else
            {

                var data = JsonConvert.SerializeObject(categoryService.GetAllCategories());
                _distributedCache.SetString("category", data);
                return View(categoryService.GetAllCategories());

            }



        }
    }
}
