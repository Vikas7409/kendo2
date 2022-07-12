using Microsoft.AspNetCore.Mvc;
using System;

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

using vikasApplication.Models;
using vikasApplication.Repositiory.Interfaces;
using vikasApplication.Repositiory.Services;

namespace vikasApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly UsersDbContext context;
       private readonly IUser user;

        public UserController(UsersDbContext context, IUser user)
        {
            this.context = context;
            this.user = user;
        }

        
        public IActionResult Index()
        {
            return View();


        }

        [HttpPost]
        public IActionResult IndexPost()
        {
            var result = user.IndexPost();
            

            return Ok(result);
        }
        [HttpPost]
        public IActionResult check(string data)
        {

            var objTableDetails = JsonConvert.DeserializeObject<List<TableDetailsModel>>(data);
            foreach (var item in objTableDetails)
            {
               user.Check(item);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UsersModel model)
        {
            var res = user.Login(model);
            if (res == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.vikas = ("----Invalid  user");
            }
            return View();

        }
        
    }
}
