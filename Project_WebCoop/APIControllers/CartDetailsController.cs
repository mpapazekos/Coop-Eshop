using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_WebCoop.Data;
using Project_WebCoop.Models;
using Project_WebCoop.Services;

//namespace Project_WebCoop.APIControllers
//{

//    [Produces("application/json")]
//    [Route("api/CartDetails")]
//    [Authorize(Roles="ClientRole")]
//    public class CartDetailsController : Controller
//    {
//        private readonly IOrderRepository _repository;

//        public CartDetailsController(IOrderRepository repository) => _repository = repository;


//        // GET: api/CartDetails
//        [HttpGet]
//        public IEnumerable<CartDetails> GetCartDetails()
//        {
//            return _repository.CartDetails;
//        }

//        // GET: api/CartDetails/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetCartDetails([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var cartDetails = await _repository.CartDetails.SingleOrDefaultAsync(m => m.CartDetailsID == id);

//            if (cartDetails == null)
//            {
//                return NotFound();
//            }

//            return Ok(cartDetails);
//        }

//        // PUT: api/CartDetails/5
//        [HttpPut("subtract/id")]
//        public async Task<IActionResult> SubtractQuantity([FromRoute] int id)
//        {
//            CartDetails item = await _repository.CartDetails.SingleAsync(ci => ci.CartDetailsID == id);

//            if (item.Quantity > 1)
//            {
//                item.Quantity--;
//                item.Cost -= item.Cost;
//                _repository.UpdateCartDetails(item);
//            }
//            else
//            {
//                item.Quantity--;
//                _repository.DeleteCartDetails(item);
//            }

//            return Json(new { id = item.CartDetailsID, quantity = item.Quantity, cost = item.Cost });
//        }

//        [HttpPut("add/id")]
//        public async Task<IActionResult> AddQuantity([FromRoute] int id)
//        {
//            CartDetails item = await _repository.CartDetails.SingleAsync(ci => ci.CartDetailsID == id);

//            item.Quantity++;
//            item.Cost += item.Cost;
//            _repository.UpdateCartDetails(item);


//            return Json(new { id = item.CartDetailsID, quantity = item.Quantity, cost = item.Cost });
//        }

//        // POST: api/CartDetails
//        [HttpPost]
//        public async Task<IActionResult> PostCartDetails([FromBody] CartDetails cartDetails)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _repository.StoreCartDetails(cartDetails);

//            return CreatedAtAction("GetCartDetails", new { id = cartDetails.CartDetailsID }, cartDetails);
//        }

//        // DELETE: api/CartDetails/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCartDetails([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var cartDetails = await _repository.CartDetails.SingleOrDefaultAsync(m => m.CartDetailsID == id);
//            if (cartDetails == null)
//            {
//                return NotFound();
//            }

//            _repository.DeleteCartDetails(cartDetails);

//            return Ok(cartDetails);
//        }

//        private bool CartDetailsExists(int id)
//        {
//            return _repository.CartDetails.Any(e => e.CartDetailsID == id);
//        }
//    }
//}