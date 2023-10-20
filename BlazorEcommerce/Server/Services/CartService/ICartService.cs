namespace BlazorEcommerce.Server.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task<ServiceResponse<bool>> AddToCart(CartItem cartItem);
        Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem);
        Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId);

        Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(List<CartItem> cartItems);
        Task<ServiceResponse<int>> GetCartItemsCount();
        
        Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems);
        Task<ServiceResponse<List<CartProductResponse>>> GetDbCartProducts(int? userId = null);

    }
}
