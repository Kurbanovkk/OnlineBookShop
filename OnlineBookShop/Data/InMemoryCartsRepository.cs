
namespace OnlineBookShop
{
    public class InMemoryCartsRepository : ICartsRepository
    {
        private List<Cart> _carts = new List<Cart>();
        public Cart TryGetByUserId(string userId)
        {
            return _carts.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    CartItems = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product
                        }
                    }
                };
                _carts.Add(newCart);
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
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Product = product
                    });
                }
            }
        }

        public void Delete(int productId, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            {
                var existingCartItem = existingCart.CartItems.FirstOrDefault(x => x.Product.Id == productId);
                existingCartItem.Amount--;
                if (existingCartItem.Amount == 0)
                {
                    existingCart.CartItems.Remove(existingCartItem);
                }
                if (existingCart.CartItems.Count == 0)
                {
                    _carts.Clear();
                }
            }
        }

        public void Clear()
        {
            _carts.Clear();
        }
    }
}
