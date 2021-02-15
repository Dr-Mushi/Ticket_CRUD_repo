using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_CRUD.Models;
using Ticket_CRUD.Repositories;

namespace Ticket_CRUD.Controllers
{
   
    public class AccountController : Controller
    {
        
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        //GET
        public IActionResult SignUp()
        {
            return View();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> SignUp([Bind("id,Email,Password,ConfirmPassword")]SignUpModel SignUp)
        {
            if (ModelState.IsValid)
            {
                var result =await  _accountRepository.CreateUserAsync(SignUp);
                if (!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(SignUp);
                }
                ModelState.Clear();
            }

            return View();
        }


        //GET
        public IActionResult LogIn()
        {
            return View();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult>LogIn(LogInModel logInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(logInModel);
                if (result.Succeeded)
                {
                   return RedirectToAction("index", "Tickets");
                }
                ModelState.AddModelError("", "Invalid Credintials");
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index","Tickets");


        }
    }
}
