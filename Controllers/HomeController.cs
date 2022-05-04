﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewApp.ViewModels;
using RedisAPI;
using Microsoft.AspNetCore.Http;
using NewApp.Dao;

namespace NewApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private RedisDataAgent _redis;
        private readonly MyDbContext _dbContext;
        public HomeController(ILogger<HomeController> logger, IConfiguration config, MyDbContext dbContext)
        {
            _logger = logger;
            _config = config;
            //_redis = new RedisDataAgent(config);
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            //var message = "";
            //using (_dbContext)
            //{
            //    var user = new User
            //    {
            //        User_ID = "00005",
            //        User_Name = "Raymond"
            //    };
            //    _dbContext.User.Add(user);
            //    var i = _dbContext.SaveChanges();

            //    message = i > 0 ? "資料寫入成功" : "資料寫入失敗";
            //}

            var carts = new List<Cart>();

            try 
            {
                /*
                var carts_redis = _redis.GetListValue<List<Cart>>("carts");
                if(carts_redis == null || !carts_redis.Any())
                {
                    carts.Add(new Cart() {ProductName = "Cabbages", UnitPrice = 0.95});
                    carts.Add(new Cart() {ProductName = "Oranges", UnitPrice = 9.95});
                    carts.Add(new Cart() {ProductName = "Onions", UnitPrice= 6.45});

                    _redis.SetListValue("carts", carts);
                }
                else{
                    carts.AddRange(carts_redis);
                }
                */
            }
            catch (Exception ex)
            {
                ViewBag.Exp = ex.Message;
            }
            
            return View(carts);
        }

        [HttpPost]
        public IActionResult CheckOut([FromBody]List<Cart> carts)
        {
            var isOk = false;
            var statusCode = StatusCodes.Status200OK;
            var rtnMsg = "OK";

            try
            {
                isOk = _redis.SetListValue("carts", carts);
            }
            catch(Exception ex)
            {
                statusCode = StatusCodes.Status500InternalServerError;
                rtnMsg = ex.Message;
            }
            
            return Json(new RtnResult() {
                StatusCode = statusCode,
                RtnMsg = rtnMsg,
                RtnValue = isOk
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}