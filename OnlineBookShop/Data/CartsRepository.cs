

namespace OnlineBookShop
{
    public class CartsRepository
    {
        private static List<Cart> carts = new List<Cart>();

        public static Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }

        internal static void Add(Product product, string userId)
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
                carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.CartItems.FirstOrDefault(x => x.Product.Id == product.Id);

                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
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
    }
}
