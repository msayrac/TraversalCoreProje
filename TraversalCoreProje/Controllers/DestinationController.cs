﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
	public class DestinationController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public DestinationController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}


		DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
		{
            var values = destinationManager.TGetList();

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> DestinationDetails(int id)
        {
            ViewBag.i = id;
            ViewBag.destID = id;
			var value = await _userManager.FindByNameAsync(User.Identity.Name);
            
			ViewBag.userID = value.Id;
			var values = destinationManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult DestinationDetails(Destination p)
        {

            return View();


        }




    }
}
