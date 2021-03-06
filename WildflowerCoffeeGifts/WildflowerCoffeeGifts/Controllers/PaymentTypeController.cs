﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WildflowerCoffeeGifts.DataAccess;
using WildflowerCoffeeGifts.Models;
using Microsoft.AspNetCore.Authorization;

namespace WildflowerCoffeeGifts.Controllers
{
    [Route("api/paymentTypes")]
    [ApiController]
    [Authorize]
    // [AllowAnonymous] add this to any method that does not require auth
    public class PaymentTypeController : FirebaseEnabledController
    {
        PaymentTypeRepository _paymentTypeRepo;
        UsersRepository _userRepo;
        public PaymentTypeController()
        {
            _paymentTypeRepo = new PaymentTypeRepository();
            _userRepo = new UsersRepository();
        }

        [HttpGet]
        public IActionResult GetAllPaymentTypes()
        {
            var allPaymentTypes = _paymentTypeRepo.GetAllPaymentTypes();

            return Ok(allPaymentTypes);
        }

        [HttpGet("allByUid")]
        public IActionResult GetAllPaymentTypesByUserUid()

        {
            var currentUserId = _userRepo.GetUserIdByUid(UserId);
            if (_paymentTypeRepo.GetAllPaymentTypesByUserId(currentUserId) == null) return NoContent();
            var allPaymentTypesForSelectedUser = _paymentTypeRepo.GetAllPaymentTypesByUserId(currentUserId);

            return Ok(allPaymentTypesForSelectedUser);
        }


        [HttpGet("{id}")]
        public IActionResult GetSinglePaymentTypeById(int id)
        {
            var singlePayment = _paymentTypeRepo.GetSinglePaymentTypeById(id);
            if (singlePayment == null) return NotFound("Nothing was found with this id! Try again.");

            return Ok(singlePayment);
        }

        // Anca: Adding a method to get the latest payment type added for a user:
        [HttpGet("latestByUid")]
        public IActionResult GetLatestPaymentTypeForUser()
        {
            var currentUserId = _userRepo.GetUserIdByUid(UserId);
            var latestPaymentTypeForUser = _paymentTypeRepo.GetLatestPaymentTypeForUser(currentUserId);
            if (latestPaymentTypeForUser == null) return NoContent();

            return Ok(latestPaymentTypeForUser);
        }

        [HttpGet("bystatus/{isActive}")]
        public IActionResult GetPaymentTypesByStatus(bool isActive)
        {
            var allPaymentTypes = _paymentTypeRepo.GetPaymentTypesByStatus(isActive);

            return Ok(allPaymentTypes);
        }

        [HttpPost]
        public IActionResult AddNewPayment(PaymentType newPayment)
        {
            var createPaymentType = _paymentTypeRepo.AddNewPayment(newPayment);

            return Created($"/api/paymentTypes/{newPayment.Id}", createPaymentType);

        }

        [HttpPut("{id}")]
        public IActionResult UpdatePaymentType(int id, PaymentType paymentUpdate)
        {
            var updatePaymentType = _paymentTypeRepo.UpdatePaymentType(id, paymentUpdate);

            if (_paymentTypeRepo.GetSinglePaymentTypeById(id) == null)
            {
                return NotFound("We don't have a record of anything with this id! Try a different one!");
            }

            return Ok(updatePaymentType);
        }


    }
}
