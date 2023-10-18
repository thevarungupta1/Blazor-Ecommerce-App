using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartProducts();
        Task RemoveProductFromCart(int productId, int productTypeId);
        Task UpdateQuantity(int quantity);
        Task StoreCartItems(bool emptyLOcalCart);
        Task GetCartItemsCount();
    }
}
