using FoodCart_Hexaware.DTO;
using FoodCart_Hexaware.Models;
using FoodCart_Hexaware.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodCart_Hexaware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Customer")]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartsController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        [HttpGet("AllCarts")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            try
            {
                var menu = await _cartRepository.GetAllCartItemsAsync();
                if (menu == null)
                {
                    return NotFound(new { message = "Menu item not found" });
                }
                return Ok(menu);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { message = "An error occurred while retriving the cart item.", details = ex.Message });
            }
        }

        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDTO addToCartDto)
        {
            try
            {
                var menuItem = await _cartRepository.GetMenuItemByIdAsync(addToCartDto.ItemID);
                if (menuItem == null)
                {
                    return NotFound(new { message = "Menu item not found" });
                }

                decimal totalCost = menuItem.ItemPrice * addToCartDto.Quantity;

                var cart = new Cart
                {
                    UserID = addToCartDto.UserID,
                    ItemID = addToCartDto.ItemID,
                    Quantity = addToCartDto.Quantity,
                    DeliveryAddress = addToCartDto.DeliveryAddress,
                    TotalCost = totalCost,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                var newCart = await _cartRepository.AddToCartAsync(cart);

                return Ok(new { message = "Item added to cart successfully", newCart.CartID });
            }
            catch (Exception ex)
            {
                // Return a generic error message
                return StatusCode(500, new { message = "An error occurred while adding the item to the cart.", details = ex.Message });
            }
        }


        [HttpPut("UpdateCart")]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartDTO updateCartDto)
        {
            try
            {

                if (updateCartDto.Quantity <= 0)
                {
                    return BadRequest(new { message = "Quantity must be greater than zero." });
                }


                var existingCartItem = await _cartRepository.GetCartItemByIdAsync(updateCartDto.CartID);
                if (existingCartItem == null)
                {
                    return NotFound(new { message = $"Cart item with ID {updateCartDto.CartID} not found." });
                }


                existingCartItem.Quantity = updateCartDto.Quantity;
                var menuItem = await _cartRepository.GetMenuItemByIdAsync(existingCartItem.ItemID);
                if (menuItem == null)
                {
                    return NotFound(new { message = $"Menu item with ID {existingCartItem.ItemID} not found." });
                }
                existingCartItem.TotalCost = existingCartItem.Quantity * menuItem.ItemPrice;
                existingCartItem.UpdatedAt = DateTime.Now;


                await _cartRepository.UpdateCartItemAsync(existingCartItem);

                return Ok(new { message = "Cart item updated successfully", cartItem = existingCartItem });
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(new { message = knfEx.Message });
            }
            catch (Exception ex)
            {
                // Return a generic error message
                return StatusCode(500, new { message = "An error occurred while updating the cart item.", details = ex.Message });
            }
        }



        [HttpDelete("RemoveCartItem/{cartId}")]
        public async Task<IActionResult> RemoveCartItem(int cartId)
        {
            try
            {
                var result = await _cartRepository.RemoveCartItemAsync(cartId);
                if (result)
                {
                    return Content("Cart item removed successfully");
                }
                else
                {
                    return NotFound(new { message = "Cart item not found" });
                }
            }
            catch (Exception ex)
            {
                // Return a generic error message
                return StatusCode(500, new { message = "An error occurred while removing the cart item.", details = ex.Message });
            }
        }

        [HttpGet("GetCartItems/{cartId}")]
        public async Task<IActionResult> GetCartItemsByCartId(int cartId)
        {
            try
            {
                var cartItems = await _cartRepository.GetCartItemsByCartIdAsync(cartId);

                if (cartItems == null || !cartItems.Any())
                {
                    return NotFound(new { message = "No items found for the given cart ID." });
                }

                return Ok(cartItems);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { message = $"An error occurred: {ex.Message}" });
            }
        }
    }
}

