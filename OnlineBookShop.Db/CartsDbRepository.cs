
using Microsoft.EntityFrameworkCore;

namespace OnlineBookShop.Db.Models
{
    public class CartsDbRepository : ICartsRepository
    {
		private readonly DatabaseContext _dataBaseContext;

        public CartsDbRepository(DatabaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
		public Cart TryGetByUserId(string userId)
        {
            return _dataBaseContext.Carts.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);

		}

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId
                };
                newCart.CartItems = new List<CartItem>
                    {
                        new CartItem
                        {
                            Amount = 1,
                            Product = product,
                            Cart = newCart
                        }
                    };
				_dataBaseContext.Carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart?.CartItems?.FirstOrDefault(x => x.Product.Id == product.Id);

                if (existingCartItem != null)
                {
                    existingCartItem.Amount++;
                }
                else
                {
                    existingCart.CartItems.Add(new CartItem
                    {
                        Amount = 1,
                        Product = product,
                        Cart = existingCart
                    });
                }
            }
            _dataBaseContext.SaveChanges();
        }

        public void Delete(Guid productId, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            
                var existingCartItem = existingCart?.CartItems?.FirstOrDefault(x => x.Product.Id == productId);
                if (existingCartItem == null)
                {
                    return;
                }
                existingCartItem.Amount--;
                if (existingCartItem.Amount == 0)
                {
                    existingCart.CartItems.Remove(existingCartItem);
                }
            _dataBaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
			var existingCart = TryGetByUserId(userId);
            _dataBaseContext.Carts?.Remove(existingCart);
            _dataBaseContext.SaveChanges();
		}
    }
}
