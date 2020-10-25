﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WildflowerCoffeeGifts.DataAccess;

namespace WildflowerCoffeeGifts.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UsersRepository _userRepo;
        public UsersController()
        {
            _userRepo = new UsersRepository();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = _userRepo.GetAllUsers();

            return Ok(allUsers);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsersById(int id)
        {
            var selectedUser = _userRepo.GetUsersById(id);
            if (selectedUser == null) return NotFound("We did not find a user with that ID. Please try again.");
            return Ok(selectedUser);
        }
    }
}