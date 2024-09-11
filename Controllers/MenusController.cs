using FoodCart_Hexaware.Models;
using FoodCart_Hexaware.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodCart_Hexaware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]   
    public class MenusController : ControllerBase
    {
        private readonly IMenuRepository _menuRepository;

        public MenusController(IMenuRepository menu)
        {
            _menuRepository = menu;


        }
        [HttpGet]
        public async Task<ActionResult> GetMenuItem()

        {
            var menuitems = await _menuRepository.GetMenuItem();


            return Ok
                (new

                {

                    menuItem = menuitems.Select(mi => new
                    {
                        itemID = mi.ItemID,
                        itemName = mi.ItemName,
                        itemDescription = mi.ItemDescription,
                        itemPrice = mi.ItemPrice,
                        ingredients = mi.Ingredients,
                        cuisineType = mi.CuisineType,
                        tasteInfo = mi.TasteInfo,
                        availabilityStatus = mi.AvailabilityStatus,
                        dietaryInfo = mi.DietaryInfo,
                        imageURL = mi.ImageURL,
                        restaurants = mi.Restaurants.Select(r => new
                        {
                            restaurantID = r.RestaurantID,
                            name = r.RestaurantName,
                            email = r.RestaurantEmail,
                            address = r.RestaurantAddress,
                            phoneNumber = r.RestaurantPhone,
                            description = r.RestaurantDescription,
                        }).ToList()
                    })
                });

        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetMenuItembyId(int id)
        {
            var menuitems = await _menuRepository.GetMenuItembyId(id);

            return Ok(new

            {

                menuItem = new
                {
                    itemID = menuitems.ItemID,
                    itemName = menuitems.ItemName,
                    itemDescription = menuitems.ItemDescription,
                    itemPrice = menuitems.ItemPrice,
                    ingredients = menuitems.Ingredients,
                    cuisineType = menuitems.CuisineType,
                    tasteInfo = menuitems.TasteInfo,
                    availabilityStatus = menuitems.AvailabilityStatus,
                    dietaryInfo = menuitems.DietaryInfo,
                    imageURL = menuitems.ImageURL,
                    restaurants = menuitems.Restaurants.Select(r => new
                    {
                        restaurantID = r.RestaurantID,
                        name = r.RestaurantName,
                        email = r.RestaurantEmail,
                        address = r.RestaurantAddress,
                        phoneNumber = r.RestaurantPhone,
                        description = r.RestaurantDescription,
                    }).ToList()
                }
            });

        }




        [HttpGet]
        [Route("byName")]
        public async Task<ActionResult<IEnumerable<MenuItems>>> GetMenuItembyName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name parameter is Required");
            }
            var menuitems = await _menuRepository.GetMenuItembyName(name);

            return Ok(new
            {
                menuitem = menuitems.Select(mi => new
                {

                    itemID = mi.ItemID,
                    itemName = mi.ItemName,
                    itemDescription = mi.ItemDescription,
                    itemPrice = mi.ItemPrice,
                    ingredients = mi.Ingredients,
                    cuisineType = mi.CuisineType,
                    tasteInfo = mi.TasteInfo,
                    availabilityStatus = mi.AvailabilityStatus,
                    dietaryInfo = mi.DietaryInfo,
                    imageURL = mi.ImageURL,
                    restaurants = mi.Restaurants.Select(r => new
                    {
                        restaurantID = r.RestaurantID,
                        name = r.RestaurantName,
                        email = r.RestaurantEmail,
                        address = r.RestaurantAddress,
                        phoneNumber = r.RestaurantPhone,
                        description = r.RestaurantDescription,
                    }).ToList()

                })
            });
        }

        [HttpGet]
        [Route("byCategory")]
        public async Task<ActionResult<IEnumerable<MenuItems>>> GetMenuItemByCategory(string categoryname)
        {
            if (string.IsNullOrEmpty(categoryname))
            {
                return BadRequest("Category parameter is Required");
            }

            var menuitems = await _menuRepository.GetMenuItembyCategory(categoryname);

            return Ok(new
            {
                menuItem = menuitems.Select(mi => new
                {
                    itemID = mi.ItemID,
                    itemName = mi.ItemName,
                    itemDescription = mi.ItemDescription,
                    itemPrice = mi.ItemPrice,
                    ingredients = mi.Ingredients,
                    cuisineType = mi.CuisineType,
                    tasteInfo = mi.TasteInfo,
                    availabilityStatus = mi.AvailabilityStatus,
                    dietaryInfo = mi.DietaryInfo,
                    imageURL = mi.ImageURL,
                    restaurants = mi.Restaurants.Select(r => new
                    {
                        restaurantID = r.RestaurantID,
                        name = r.RestaurantName,
                        email = r.RestaurantEmail,
                        address = r.RestaurantAddress,
                        phoneNumber = r.RestaurantPhone,
                        description = r.RestaurantDescription,
                    }).ToList()

                })
            });


        }


        [HttpGet]
        [Route("byCuisine")]
        public async Task<ActionResult<IEnumerable<MenuItems>>> GetMenuItemsByCuisine(string cuisineName)
        {
            if (string.IsNullOrEmpty(cuisineName))
            {
                return BadRequest("CusineName parameter is required");
            }

            var menuitems = await _menuRepository.GetMenuItemsbyCuisine(cuisineName);

            return Ok(new
            {
                menuItem = menuitems.Select(mi => new
                {
                    itemID = mi.ItemID,
                    itemName = mi.ItemName,
                    itemDescription = mi.ItemDescription,
                    itemPrice = mi.ItemPrice,
                    ingredients = mi.Ingredients,
                    cuisineType = mi.CuisineType,
                    tasteInfo = mi.TasteInfo,
                    availabilityStatus = mi.AvailabilityStatus,
                    dietaryInfo = mi.DietaryInfo,
                    imageURL = mi.ImageURL,
                    restaurants = mi.Restaurants.Select(r => new
                    {
                        restaurantID = r.RestaurantID,
                        name = r.RestaurantName,
                        email = r.RestaurantEmail,
                        address = r.RestaurantAddress,
                        phoneNumber = r.RestaurantPhone,
                        description = r.RestaurantDescription,
                    }).ToList()
                })
            });
        }

        [HttpGet]
        [Route("byAvailability")]

        public async Task<ActionResult<IEnumerable<MenuItems>>> GetMenuItemsbyAvailability()
        {
            var menuitems = await _menuRepository.GetMenuItemsbyAvailability();
            if (menuitems == null || !menuitems.Any())
            {
                return NotFound("No Available Items now");
            }
            return Ok(new
            {
                menuItem = menuitems.Select(mi => new
                {
                    itemID = mi.ItemID,
                    itemName = mi.ItemName,
                    itemDescription = mi.ItemDescription,
                    itemPrice = mi.ItemPrice,
                    ingredients = mi.Ingredients,
                    cuisineType = mi.CuisineType,
                    tasteInfo = mi.TasteInfo,
                    availabilityStatus = mi.AvailabilityStatus,
                    dietaryInfo = mi.DietaryInfo,
                    imageURL = mi.ImageURL,
                    restaurants = mi.Restaurants.Select(r => new
                    {
                        restaurantID = r.RestaurantID,
                        name = r.RestaurantName,
                        email = r.RestaurantEmail,
                        address = r.RestaurantAddress,
                        phoneNumber = r.RestaurantPhone,
                        description = r.RestaurantDescription,
                    }).ToList()
                })
            });

        }


        [HttpGet]
        [Route("byPriceRange")]
        public async Task<ActionResult<IEnumerable<MenuItems>>> GetMenuItemsbyPrice(int maxprice, int minprice)
        {
            if (minprice < 0 || maxprice <= 0 || minprice >= maxprice)
            {
                return BadRequest("Invalid price range");
            }
            var menuitems = await _menuRepository.GetMenuItemsbyPrice(maxprice, minprice);
            if (menuitems == null || !menuitems.Any())
            {
                return NotFound("Items are not found");
            }



            return Ok(new
            {
                menuItem = menuitems.Select(mi => new
                {
                    itemID = mi.ItemID,
                    itemName = mi.ItemName,
                    itemDescription = mi.ItemDescription,
                    itemPrice = mi.ItemPrice,
                    ingredients = mi.Ingredients,
                    cuisineType = mi.CuisineType,
                    tasteInfo = mi.TasteInfo,
                    availabilityStatus = mi.AvailabilityStatus,
                    dietaryInfo = mi.DietaryInfo,
                    imageURL = mi.ImageURL,
                    restaurants = mi.Restaurants.Select(r => new
                    {
                        restaurantID = r.RestaurantID,
                        name = r.RestaurantName,
                        email = r.RestaurantEmail,
                        address = r.RestaurantAddress,
                        phoneNumber = r.RestaurantPhone,
                        description = r.RestaurantDescription,
                    }).ToList()
                })
            });
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<IEnumerable<MenuItems>>> GetMenuItemsbySearch(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("Search is required");
            }
            var menuitems = await _menuRepository.GetMenuItemsbySearch(query);
            if (menuitems == null || !menuitems.Any())
            {
                return NotFound("Item not found");
            };

            return Ok(new
            {
                menuItem = menuitems.Select(mi => new
                {
                    itemID = mi.ItemID,
                    itemName = mi.ItemName,
                    itemDescription = mi.ItemDescription,
                    itemPrice = mi.ItemPrice,
                    ingredients = mi.Ingredients,
                    cuisineType = mi.CuisineType,
                    tasteInfo = mi.TasteInfo,
                    availabilityStatus = mi.AvailabilityStatus,
                    dietaryInfo = mi.DietaryInfo,
                    imageURL = mi.ImageURL,
                    restaurants = mi.Restaurants.Select(r => new
                    {
                        restaurantID = r.RestaurantID,
                        name = r.RestaurantName,
                        email = r.RestaurantEmail,
                        address = r.RestaurantAddress,
                        phoneNumber = r.RestaurantPhone,
                        description = r.RestaurantDescription,
                    }).ToList()
                })
            });
        }

        [HttpGet]
        [Route("Filter")]
        public async Task<ActionResult<IEnumerable<MenuItems>>> GetMenuItemsByFilters(string? type, string? category, decimal? minprice, decimal? maxprice, string? cuisine)
        {
            var menuitems = await _menuRepository.GetMenuItemsByFilters(type, category, minprice, maxprice, cuisine);
            if (menuitems == null || !menuitems.Any())
            {
                return NotFound("Items not found");

            };

            return Ok(new
            {
                menuItem = menuitems.Select(mi => new
                {
                    itemID = mi.ItemID,
                    itemName = mi.ItemName,
                    itemDescription = mi.ItemDescription,
                    itemPrice = mi.ItemPrice,
                    ingredients = mi.Ingredients,
                    cuisineType = mi.CuisineType,
                    tasteInfo = mi.TasteInfo,
                    availabilityStatus = mi.AvailabilityStatus,
                    dietaryInfo = mi.DietaryInfo,
                    imageURL = mi.ImageURL,
                    restaurants = mi.Restaurants.Select(r => new
                    {
                        restaurantID = r.RestaurantID,
                        name = r.RestaurantName,
                        email = r.RestaurantEmail,
                        address = r.RestaurantAddress,
                        phoneNumber = r.RestaurantPhone,
                        description = r.RestaurantDescription,
                    }).ToList()

                })
            });
        }


        
        [HttpPost("link/{menuItemId}/{restaurantId}")]
        public async Task<IActionResult> LinkMenuItemToRestaurant(int menuItemId, int restaurantId)
        {

            var menus = await _menuRepository.LinkMenuItemToRestaurant(menuItemId, restaurantId);
            return Ok(new
            {
                linkedMenu = new
                {
                    itemID = menus.ItemID,
                    itemName = menus.ItemName,
                    itemPrice = menus.ItemPrice,
                    Restaurants = menus.Restaurants.Select(r => new
                    {
                        restaurantID = r.RestaurantID,
                        restaurantName = r.RestaurantName
                    })
                }
            });
        }
    }
}
